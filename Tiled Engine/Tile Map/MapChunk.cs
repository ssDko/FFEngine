using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TiledEngine
{
    public class MapChunk
    {
        #region Properties
        public Vector2 Position { get; private set; }

        public Vector2 WorldPosition { get; private set; }

        public int Width { get; private set; }
        public int PixelWidth { get; private set; }

        public int Height { get; private set; }
        public int PixelHeight { get; private set; }

        public uint[,] Data { get; private set; }
        #endregion

        #region Constructor(s)
        public MapChunk(Vector2 position,
                        int width,
                        int height,
                        int tileWidth,
                        int tileHeight,
                        uint[,] data)
        {
            Position = position;
            WorldPosition = new Vector2(Position.X * tileWidth, Position.Y * tileWidth);
            Width = width;
            PixelWidth = width * tileWidth;           
            Height = height;
            PixelHeight = height * tileHeight;
            Data = data;
        }

        public MapChunk(Vector2 position,
                        int width,
                        int height,
                        int tileWidth,
                        int tileHeight) : this(position, width, height, tileWidth, tileHeight, new uint[width, height])
        {
           
        }
        #endregion

        #region Methods
        public bool LoadDataFromString(string data)
        {
            bool success = true;
            try
            {
                uint[] dataList = data.Split(',').Select(uint.Parse).ToArray();
                int index = 0;

                for (int i = 0; i < Height; i++)
                {
                    for (int j = 0; j < Width; j++)
                    {
                        Data[i, j] = dataList[index];
                        index++;
                    }
                }

            }
            catch (FormatException e)
            {
                success = false;
            }

           
            return success;
        }


        #endregion
    }
}
