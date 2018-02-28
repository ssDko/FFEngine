using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameObjects

{
    public class Sprite
    {
        #region Declarations
        private Texture2D texture;     
        private string name;
      
        #endregion

        #region Properties       

        public Texture2D Texture
        {
            get { return texture; }
            set { texture = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        #endregion

        #region Constructor(s)
        public Sprite(Texture2D texture, string name)
        {
            this.texture = texture;            
            this.name = name;
                      
        }        
        #endregion
    }
}
