using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace TiledEngine
{
    public class Player
    {        
        #region Declarations
        private Vector2 position;
        private Vector2 gridPosition;
        private Vector2 prevGridPosition;
        private Dictionary<Dir, AnimationStrip> idleAnimations;
        private Dictionary<Dir, AnimationStrip> walkAnimations;

        #endregion
        
        #region Properties
        public Vector2 Position
        {
            get { return position;  }
            private set
            {
                position = value;                
            }
        }        

        public Vector2 GridPosition
        {
            get { return gridPosition; }
            set
            {
                gridPosition = value;
       
                position.X = gridPosition.X * TileWidth;
                position.Y = gridPosition.Y * TileHeight;

            }
        }

        public Dir CurrentDirection { get; private set; } = Dir.Down;

        public Rectangle Bounds { get; set; } = new Rectangle(); // The area our character is confined to

        public bool RespectBounds { get; set; } = false;
        public bool WillWarpAroundBounds { get; set; } = false;

        public int TileWidth { get; private set; }
        public int TileHeight { get; private set; }

        public int Width { get; private set; }
        public int Height { get; private set; }

        public Vector2 Velocity { get; set; }
        public int Speed { get; set; }
        public Texture2D Texture { get; set; }
        public float Z { get; set; }

        //Animation properties
        
        #endregion

        #region Constructor(s)
        public Player(Vector2 gridPosition,
                      int width,
                      int height,
                      int tileWidth, 
                      int tileHeight, 
                      Texture2D texture, 
                      int speed = 1, 
                      float z = 0)
        {
            Width = width;
            Height = height;
            TileWidth = tileWidth;
            TileHeight = tileHeight;
            GridPosition = gridPosition;
            prevGridPosition = gridPosition;
            Speed = speed;
            Velocity = Vector2.Zero;
            Texture = texture;
            Z = z;

            // Create animations
            idleAnimations = new Dictionary<Dir, AnimationStrip>();
            walkAnimations = new Dictionary<Dir, AnimationStrip>();
            for (Dir dir = Dir.Up; dir <= Dir.Left; dir++)
            {
                idleAnimations.Add(dir, new AnimationStrip(0,
                                                           (int)dir * tileHeight,
                                                           texture,
                                                           tileWidth,
                                                           tileHeight,
                                                           1,
                                                           "idle_" + dir.ToString()));

                walkAnimations.Add(dir, new AnimationStrip(TileWidth,
                                                           (int)dir * tileHeight,
                                                           texture,
                                                           tileWidth,
                                                           tileHeight,
                                                           2,
                                                           "walk_" + dir.ToString(),
                                                           0.5f));

            }

        }

        public Player(int gridX, 
                      int gridY, 
                      int width,
                      int height,
                      int tileWidth, 
                      int tileHeight, 
                      Texture2D texture, 
                      int speed = 1, 
                      float z = 0) : 
                      this(new Vector2(gridX, gridY), 
                           width,
                           height,
                           tileWidth, 
                           tileHeight, 
                           texture, 
                           speed, 
                           z)
        {
            //Empty
        }
        #endregion

        #region Methods
        public void Update(GameTime gameTime)
        {
            int upState = Keyboard.GetState().IsKeyDown(Keys.Up) ? 1 : 0;
            int downState = Keyboard.GetState().IsKeyDown(Keys.Down) ? 1 : 0;
            int leftState = Keyboard.GetState().IsKeyDown(Keys.Left) ? 1 : 0;
            int rightState = Keyboard.GetState().IsKeyDown(Keys.Right) ? 1 : 0;


            int vert = upState - downState;
            int horz = leftState - rightState;

            // Correct for multiple direction key presses.
            if (horz == 1)
            {
                Move(Dir.Left);
            }
            else if (horz == -1)
            {
                Move(Dir.Right);
            }
            else
            {

                if (vert == 1)
                {
                    Move(Dir.Up);
                }
                else if (vert == -1)
                {
                    Move(Dir.Down);
                }
            }



            if (position.X < gridPosition.X * TileWidth) // Moving right
            {
                position.X = MathHelper.Min(Position.X + Speed, gridPosition.X * TileWidth);
            }
            else if (position.X > gridPosition.X * TileWidth) //Moving left
            {
                position.X = MathHelper.Max(Position.X - Speed, gridPosition.X * TileWidth);
            }

            if (position.Y < gridPosition.Y * TileHeight) // Moving right
            {
                position.Y = MathHelper.Min(Position.Y + Speed, gridPosition.Y * TileHeight);
            }
            else if (Position.Y > gridPosition.Y * TileHeight) //Moving left
            {
                position.Y = MathHelper.Max(Position.Y - Speed, gridPosition.Y * TileHeight);
            }

            //Animation Update
            idleAnimations[CurrentDirection].Update(gameTime);
            walkAnimations[CurrentDirection].Update(gameTime);            
        }

        public bool IsMoving()
        {
            return !(Position.X == GridPosition.X * TileWidth && Position.Y == GridPosition.Y * TileHeight);
        }

        public bool WalkKeyPressed()
        {
            bool up = Keyboard.GetState().IsKeyDown(Keys.Up);
            bool down = Keyboard.GetState().IsKeyDown(Keys.Down);
            bool left = Keyboard.GetState().IsKeyDown(Keys.Left);
            bool right = Keyboard.GetState().IsKeyDown(Keys.Right);


            return ((up ^ down) || (left ^ right));
        }

        public void Warp(int newGridX, int newGridY)
        {
            gridPosition = new Vector2(newGridX, newGridY);
            position = new Vector2(newGridX * TileWidth, newGridY * TileHeight);

        }

        public void Move(Dir direction)
        {
            if (IsMoving())
            {
                return;
            }

            CurrentDirection = direction;
            //prevGridPosition = gridPosition;
            Vector2 newPosition = gridPosition;
            bool needsToWarp = false;
           

            if (RespectBounds)
            {
                if (WillWarpAroundBounds)
                {                    
                    switch (CurrentDirection)
                    {
                        case Dir.Up:
                            if (newPosition.Y - 1 < 0)
                            {
                                newPosition.Y = (Bounds.Height / TileHeight) - 1;
                                needsToWarp = true;
                            }
                            else
                            {
                                newPosition.Y -= 1;
                            }
                            break;

                        case Dir.Down:
                            if (newPosition.Y + 1 > (Bounds.Height / TileHeight) - 1)
                            {
                                newPosition.Y = -1;
                                needsToWarp = true;
                            }
                            else
                            {
                                newPosition.Y += 1;
                            }
                            break;

                        case Dir.Left:
                            if (newPosition.X - 1 < 0)
                            {
                                newPosition.X = (Bounds.Width / TileWidth) -1;
                                needsToWarp = true;
                            }
                            else
                            {
                                newPosition.X -= 1;
                            }
                            break;

                        case Dir.Right:
                            if (newPosition.X + 1 > (Bounds.Width / TileWidth) - 1)
                            {
                                newPosition.X = -1;
                                needsToWarp = true;
                            }
                            else
                            {
                                newPosition.X += 1;
                            }
                            break;
                    }
                }
                else
                {
                    switch (CurrentDirection)
                    {
                        case Dir.Up:
                            if (!(newPosition.Y - 1 < 0))
                                newPosition.Y -= 1;
                            break;

                        case Dir.Down:
                            if (!(newPosition.Y + 1 > (Bounds.Height / TileHeight) - 1))
                                newPosition.Y += 1;
                            break;

                        case Dir.Left:
                            if (!(gridPosition.X - 1 < 0))
                               newPosition.X -= 1;
                            break;

                        case Dir.Right:
                            if (!(gridPosition.X + 1 > (Bounds.Width / TileWidth) - 1))
                               newPosition.X += 1;
                            break;
                    }
                }                
            }

            // Check if in a invalid tile and move back
            string type = MapManager.GetTypeAtCell((int)newPosition.X, (int)newPosition.Y, (int)Z);

            switch (type)
            {
                case "water":
                    newPosition = gridPosition;
                    needsToWarp = false;
                    break;
            }

            if (needsToWarp)
            {
                Warp((int)newPosition.X, (int)newPosition.Y);
            }
            else
            {
                gridPosition = newPosition;
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 playerScreenPos = Camera.WorldToScreen(position.X, position.Y);
            Rectangle playerRect = new Rectangle((int)playerScreenPos.X, (int)playerScreenPos.Y, Width, Height);
            
            spriteBatch.Draw(Texture,
                             playerRect,
                             Rectangle(),
                             Color.White,
                             0.0f,
                             Vector2.Zero,
                             SpriteEffects.None,
                             Z);
        }

        public Rectangle Rectangle()
        {
            if (WalkKeyPressed() || IsMoving())
            {
                return walkAnimations[CurrentDirection].FrameRectangle;
            }
            else
            {

                return idleAnimations[CurrentDirection].FrameRectangle;
            }
        }
       
        #endregion
    }

    public enum Dir {Up, Right, Down, Left};
}
