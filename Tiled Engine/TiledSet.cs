using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;
 

namespace Tiled_Engine
{
    public class TiledSet
    {
        #region Declarations
        private string name = "";
        private int tileWidth = 0;
        private int tileHeight = 0;
        private int tileCount = 0;
        private int columns = 0;

        private string sourceTSXFile = "";
        private string sourceImage = "";
        private string sourceDirectory = "";
        private Texture2D texture;

        private List<TiledTile> tiles;
        #endregion

        #region Properties

        
        public string Name
        {
            get { return name; }            
        }

        public int TileWidth
        {
            get { return tileWidth; }            
        }

        public int TileHeight
        {
            get { return tileHeight; }            
        }

        public int TileCount
        {
            get { return tileCount; }                    
        }

        public int Columns
        {
            get { return columns; }           
        }

        public string SourceTSXFile
        {
            get { return sourceTSXFile; }
        }

        public string SourceImage
        {
            get { return sourceImage; }
        }

        public string SourceDirectory
        {
            get { return sourceDirectory; }
        }

        public int SourceWidth
        {
            get { return texture.Width; }
        }

        public int SourceHeight
        {
            get { return texture.Height; }
        }

        public Texture2D Texture
        {            
            get { return texture; }  
        }

        public int ImageWidth
        {
            get { return texture.Width; }            
        }
        public int ImageHeight
        {
            get { return texture.Height; }            
        }
        public List<TiledTile> Tiles
        {
            get { return tiles; }
            
        }
        #endregion

        #region Constructor(s)
        public TiledSet(string name,
                        string sourceTSXFile,
                        string sourceImage,
                        string sourceDirectory,
                        GraphicsDevice graphicsDevice,
                        int tileWidth,
                        int tileHeight,
                        int tileCount,
                        int columns   
                        )
        {
            this.name = name;
            this.sourceTSXFile = sourceTSXFile;
            this.sourceImage = sourceImage;
            this.sourceDirectory = sourceDirectory;
            this.columns = columns;
            this.tileWidth = tileWidth;
            this.tileHeight = tileHeight;
            this.tileCount = tileCount;

            tiles = new List<TiledTile>();

            try
            {
                FileStream fileSteam = new FileStream(sourceDirectory + sourceImage, FileMode.Open);

                this.texture = Texture2D.FromStream(graphicsDevice, fileSteam);

                fileSteam.Close();
            }
            catch(FileNotFoundException)
            {
                // Todo: Report Error 
            }                            
        }

        
        #endregion

        #region Methods
        public void AddTile(TiledTile newTile)
        {
            if (newTile.TiledSet == this)
            {
                tiles.Add(newTile);
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (TiledTile tile in tiles)
            {
                tile.Update(gameTime);
            }
        }


        #endregion


    }
}
