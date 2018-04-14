using DkoLib;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tiled_Engine
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

        public Rectangle Bounds { get; set; } = new Rectangle(); // The area our character is confined to

        public bool RespectBounds { get; set; } = false;
        public bool WillWarpAroundBounds { get; set; } = false;

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
                position.X = MathHelper.Min(Position.X + Speed, gridPosition.X * TileWidth);
            else if (position.X > gridPosition.X * TileWidth) //Moving left
                position.X = MathHelper.Max(Position.X - Speed, gridPosition.X * TileWidth);

            if (position.Y < gridPosition.Y * TileHeight) // Moving rightp
                position.Y = MathHelper.Min(Position.Y + Speed, gridPosition.Y * TileHeight);
            else if (Position.Y > gridPosition.Y * TileHeight) //Moving left
                position.Y = MathHelper.Max(Position.Y - Speed, gridPosition.Y * TileHeight);            
        }

        public bool IsMoving()
        {
            return !(Position.X == GridPosition.X * TileWidth && Position.Y == GridPosition.Y * TileHeight);
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

            if (RespectBounds)
            {
                if (WillWarpAroundBounds)
                {
                    switch (direction)
                    {
                        case Dir.Up:
                            if (gridPosition.Y - 1 < 0)
                            {
                                Warp((int)gridPosition.X, Bounds.Height / TileHeight);
                            }
                            else
                            {
                                gridPosition.Y -= 1;
                            }
                            break;

                        case Dir.Down:
                            if (gridPosition.Y + 1 > (Bounds.Height / TileHeight) - 1)
                            {
                                Warp((int)gridPosition.X, -1);
                            }
                            else
                            {
                                gridPosition.Y += 1;
                            }
                            break;

                        case Dir.Left:
                            if (gridPosition.X - 1 < 0)
                            {
                                Warp(Bounds.Width / TileWidth, (int)gridPosition.Y);
                            }
                            else
                            {
                                gridPosition.X -= 1;
                            }
                            break;

                        case Dir.Right:
                            if (gridPosition.X + 1 > (Bounds.Width / TileWidth) - 1)
                            {
                                Warp(-1, (int)gridPosition.Y);
                            }
                            else
                            {
                                gridPosition.X += 1;
                            }
                            break;
                    }
                }
                else
                {
                    switch (direction)
                    {
                        case Dir.Up:
                            if (!(gridPosition.Y - 1 < 0))
                                gridPosition.Y -= 1;
                            break;

                        case Dir.Down:
                            if (!(gridPosition.Y + 1 > (Bounds.Height / TileHeight) - 1))
                                gridPosition.Y += 1;
                            break;

                        case Dir.Left:
                            if (!(gridPosition.X - 1 < 0))
                                gridPosition.X -= 1;
                            break;

                        case Dir.Right:
                            if (!(gridPosition.X + 1 > (Bounds.Width / TileWidth) - 1))
                                gridPosition.X += 1;
                            break;
                    }
                }                
            }


            
        }
       
        #endregion
    }

    public enum Dir {Up, Right, Down, Left};
}
