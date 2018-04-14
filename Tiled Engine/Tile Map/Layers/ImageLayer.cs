using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Tiled_Engine.Layers
{
    class ImageLayer : Layer
    {
        #region Properties
        public string SourceImage { get; private set; }
        public string SourceDirectory { get; private set; }
        
        public Texture2D Image { get; private set; }
        #endregion

        #region Constructor(s)
        public ImageLayer(string name,
                          string sourceImage,
                          string sourceDirectory,
                          GraphicsDevice graphicsDevice,
                          bool visible = true,
                          bool locked = false,
                          float opacity = 1.0f,
                          float horizontalOffset = 0.0f,
                          float verticalOffset = 0.0f) : base(name, visible, locked, opacity, horizontalOffset, verticalOffset)
        {
            SourceImage = sourceImage;
            SourceDirectory = sourceDirectory;

            try
            {
                FileStream fileSteam = new FileStream(sourceDirectory + sourceImage, FileMode.Open);

                Image = Texture2D.FromStream(graphicsDevice, fileSteam);

                fileSteam.Close();
            }
            catch (FileNotFoundException)
            {
                // Todo: Report Error 
            }
        }
        #endregion

        #region Methods
        public int Width()
        {
            return Image.Width;
        }

        public int Height()
        {
            return Image.Height;
        }
        #endregion
    }
}
