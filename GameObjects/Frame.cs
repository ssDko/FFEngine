using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameObjects
{
    public class Frame : Sprite
    {
        #region Declarations
        private Vector2 position;
        private int width = 0;
        private int height = 0;
        private float delay = 0.05f;        
        #endregion

        #region Properties
        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        public float Delay
        {
            get { return delay; }
            set { delay = value;  }
        }

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public Vector2 TilePosition
        {
            get
            {
                int x = (int)position.X % width;
                int y = (int)position.Y % height;
                return new Vector2(x, y);
            }
        }       
        #endregion

        #region Constructor(s)
        public Frame(Texture2D texture, 
                     string name, 
                     Vector2 position, 
                     int width, 
                     int height, 
                     float delay = 0.05f) : base(texture, name)
        {
            this.position = position;
            this.width = width;
            this.height = height;
            this.delay = delay;
        }
        #endregion
    }
}
