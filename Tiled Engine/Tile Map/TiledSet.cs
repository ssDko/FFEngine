using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;
 

namespace TiledEngine
{
    public class TiledSet
    {       
        #region Properties
        public string Name { get; } = "";

        public int TileWidth { get; } = 0;

        public int TileHeight { get; } = 0;

        public int TileCount { get; } = 0;

        public int Columns { get; } = 0;

        public string SourceTSXFile { get; } = "";

        public string SourceImage { get; } = "";

        public string SourceDirectory { get; } = "";

        public int SourceWidth
        {
            get { return Texture.Width; }
        }

        public int SourceHeight
        {
            get { return Texture.Height; }
        }

        public Texture2D Texture { get; }

        public int ImageWidth
        {
            get { return Texture.Width; }            
        }

        public int ImageHeight
        {
            get { return Texture.Height; }            
        }
        public List<TiledTile> Tiles { get; }
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
            Name = name;
            SourceTSXFile = sourceTSXFile;
            SourceImage = sourceImage;
            SourceDirectory = sourceDirectory;
            Columns = columns;
            TileWidth = tileWidth;
            TileHeight = tileHeight;
            TileCount = tileCount;

            Tiles = new List<TiledTile>();

            try
            {
                FileStream fileSteam = new FileStream(sourceDirectory + sourceImage, FileMode.Open);

                Texture = Texture2D.FromStream(graphicsDevice, fileSteam);

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
                Tiles.Add(newTile);
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (TiledTile tile in Tiles)
            {
                tile.Update(gameTime);
            }
        }


        #endregion


    }
}
