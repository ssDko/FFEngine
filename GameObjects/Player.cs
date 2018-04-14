using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameObjects
{
    public class Player
    {
        //Very much a work in progress. 
        #region Declarations
        private Vector2 position;
        private Vector2 gridPosition;
       
        #endregion


        #region Properties
        public Vector2 Position
        {
            get { return position;  }
            private set { position = value; }
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

        public int TileWidth { get; private set; }
        public int TileHeight { get; private set; }


        public Vector2 Velocity { get; set; }
        public int Speed { get; set; }
        public Texture2D Texture { get; set; }
        public float Z { get; set; }
        #endregion

        #region Constructor(s)
        public Player(Vector2 gridPosition, 
                      int tileWidth, 
                      int tileHeight, 
                      Texture2D texture, 
                      int speed = 1, 
                      float z = 0)
        {
            TileWidth = tileWidth;
            TileHeight = tileHeight;
            GridPosition = gridPosition;            
            Speed = speed;
            Velocity = Vector2.Zero;
            Texture = texture;
            Z = z;
        }

        public Player(int gridX, 
                      int gridY,  
                      int tileWidth, 
                      int tileHeight, 
                      Texture2D texture, 
                      int speed = 1, 
                      float z = 0) : 
                      this(new Vector2(gridX, gridY), 
                           tileWidth, 
                           tileHeight, 
                           texture, 
                           speed, 
                           z)
        {

        }
        #endregion

        #region Methods
        public void Update()
        {
            if (position.X < gridPosition.X * TileWidth) // Moving right
                position.X = MathHelper.Min(position.X + Speed, gridPosition.X * TileWidth);
            else if (position.X > gridPosition.X * TileWidth) //Moving left
                position.X = MathHelper.Max(position.X - Speed, gridPosition.X * TileWidth);

            if (position.Y < gridPosition.Y * TileHeight) // Moving right
                position.Y = MathHelper.Min(position.Y + Speed, gridPosition.Y * TileHeight);
            else if (position.Y > gridPosition.Y * TileHeight) //Moving left
                position.Y = MathHelper.Max(position.Y - Speed, gridPosition.Y * TileHeight);
            
            //Teleport the player if they go out of bounds
            //int wrapX = MyMath.Mod((int)player.Position.X, Camera.WorldRectangle.Width);
            //int wrapY = MyMath.Mod((int)player.Position.Y, Camera.WorldRectangle.Height);
            //player.Position = new Vector2(wrapX, wrapY);


        }

        public bool IsMoving()
        {
            return !(position.X == GridPosition.X * TileWidth && position.Y == GridPosition.Y * TileHeight);
        }

        public void Warp(int newGridX, int newGridY)
        {
            GridPosition = new Vector2(newGridX, newGridY);
        }

        public void Move(Dir direction)
        {
            if (IsMoving())
            {
                return;
            }

            switch (direction)
            {
                case Dir.Up:
                    gridPosition.Y -= 1;
                    break;

                case Dir.Down:
                    gridPosition.Y += 1;
                    break;

                case Dir.Left:
                    gridPosition.X -= 1;
                    break;

                case Dir.Right:
                    gridPosition.X += 1;
                    break;
            }
        }
       
        #endregion
    }

    public enum Dir {Up, Right, Down, Left};
}
