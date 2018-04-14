using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Tiled_Engine.Layers
{
    public class TileLayer : Layer
    {
        #region Properties
        public int Width { get; set; } = 0;
        public int TileWidth { get; set; } = 0;
        public int PixelWidth
        {
            get
            {
                return Width * TileWidth;            
            }
        }
        
        public int Height { get; set; } = 0;
        public int TileHeight { get; set; } = 0;
        public int PixelHeight
        {
            get
            {
                return Height * TileHeight;
            }
        }

        public DataEncoding DataEncoding { get; } = DataEncoding.CSV;

        public string EncodedData { get; } = "";

        public List<MapChunk> MapChunks { get; }
        #endregion

        #region Constructor(s)
        public TileLayer(string name,
                         int width,
                         int height,
                         int tileWidth,
                         int tileHeight,
                         string encodedData,                         
                         DataEncoding dataEncoding = DataEncoding.CSV,                         
                         bool visible = true,
                         bool locked = false,
                         float opacity = 1.0f,
                         float horizontalOffset = 0.0f,
                         float verticalOffset = 0.0f) : base (name, visible, locked, opacity, horizontalOffset, verticalOffset)
        {
            Width = width;
            TileWidth = tileWidth;
            Height = height;
            TileHeight = tileHeight;
            EncodedData = encodedData;
            DataEncoding = dataEncoding;
            MapChunks = new List<MapChunk>();                       
        }
        #endregion

        #region Methods
        public bool AddMapChunk<T>(T encodedData, int x, int y, int width, int height, int tileWidth, int tileHeight, DataEncoding dataEncoding )
        {
            bool success = false;
            MapChunk newChunk = new MapChunk(new Vector2(x, y), width, height, tileWidth, tileHeight);

            // String data
            if (typeof(T) == typeof(string))
            {
                switch (dataEncoding)
                {
                    case DataEncoding.CSV:
                        success = newChunk.LoadDataFromString(encodedData as string);
                        break;

                    case DataEncoding.BASE64:
                        // Todo
                        break;

                    case DataEncoding.BASE64GZIP:
                        // Todo
                        break;

                    case DataEncoding.BASE64ZLIB:
                        // Todo
                        break;

                    default:
                        success = false;
                        break;
                }

                MapChunks.Add(newChunk);
            }
            // Element data
            else if (typeof(T) == typeof(XElement) && dataEncoding == DataEncoding.XML)
            {
                // Todo
            }
            else
            {
                success = false;
            }

            return success;
        }
       
        #endregion

    }

    public enum DataEncoding
    {
        CSV,
        XML,
        BASE64,
        BASE64GZIP,
        BASE64ZLIB
    };

}
