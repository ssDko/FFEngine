using GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Tiled_Engine
{
    public class TiledTile
    {
        #region Declarations
        private int tileID = 0;
        private Animation animation;
        private string type;
        #endregion

        #region Properties
        public Texture2D Texture
        {
            get { return animation.Texture; }
            set { animation.Texture = value; }
        }

        public int TileID
        {
            get { return tileID; }
            set { tileID = value; }
        }

        public Animation Animation
        {
            get { return animation; }
            set { animation = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public int Width
        {
            get { return animation.Width; }
        }

        public int Height
        {
            get { return animation.Height; }
        }
        #endregion

        #region Constructor(s)
        public TiledTile(int tileID, Animation animation, string type = "")
        {
            this.tileID = tileID;
            this.animation = animation;
            this.type = type;
        }

        #endregion

        #region Methods
        // The tile gets to pretend it does all the work.
        public void Play()
        {
            animation.Play();
        }

        public void Stop()
        {
            animation.Stop();
        }

        public void Reset()
        {
            animation.Reset();
        }

        public void StopAndReset()
        {
            animation.StopAndReset();
        }

        public void ResetAndPlay()
        {
            animation.ResetAndPlay();
        }

        public void Update(GameTime gameTime)
        {
            animation.Update(gameTime);
        }
        #endregion
    }
}
