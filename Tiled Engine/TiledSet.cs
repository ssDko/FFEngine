using GameObjects;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Tiled_Engine
{
    public class TiledSet
    {
        #region Declarations
        private string name = "";
        private int columns = 0;

        private string source = "";        

        private List<TiledTile> tiles;
        #endregion

        #region Properties

        // We assume that a TileSet's tiles will all have the same texture
        public string Name
        {
            get { return name; }            
        }

        public int TileWidth
        {
            get { return tiles[0].Width; }            
        }

        public int TileHeight
        {
            get { return tiles[0].Height; }            
        }

        public int TileCount
        {
            get { return tiles.Count; }                    
        }

        public int Columns
        {
            get { return columns; }           
        }

        public string Source
        {
            get { return source; }            
        }

        public Texture2D Texture
        {            
            get { return tiles[0].Texture; }  
        }

        public int ImageWidth
        {
            get { return tiles[0].Texture.Width; }            
        }
        public int ImageHeight
        {
            get { return tiles[0].Texture.Height; }            
        }
        public List<TiledTile> Tiles
        {
            get { return tiles; }
        }
        #endregion

        #region Constructor(s)
        public TiledSet(string name, 
                        string source,                        
                        int columns, 
                        List<TiledTile> tiles )
        {
            this.name = name;
            this.source = source;
            this.columns = columns;
            this.tiles = tiles;
        }
        #endregion

        #region Methods
        
        #endregion


    }
}
