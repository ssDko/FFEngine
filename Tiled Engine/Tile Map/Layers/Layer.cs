using Microsoft.Xna.Framework;

namespace TiledEngine.Layers
{
    public abstract class Layer
    {
        #region Declarations
        private float opacity = 1.0f;
        #endregion

        #region Properties
        public virtual string Name { get; set; } = "";

        public virtual bool Visible { get; set; } = true;

        public virtual bool Locked { get; set; } = false;

        public virtual float Opacity
        {
            get { return opacity; }
            set { opacity = MathHelper.Clamp(value, 0.0f, 1.0f); }
        } 

        public virtual float HorizontalOffset { get; set; } = 0.0f;

        public virtual float VerticalOffset { get; set; } = 0.0f;
        #endregion

        #region Constructor(s)
        public Layer(string name, 
                     bool visible = true, 
                     bool locked = false, 
                     float opacity = 1.0f, 
                     float horizontalOffset = 0.0f, 
                     float verticalOffset = 0.0f)
        {
            Name = name;
            Visible = visible;
            Locked = locked;
            Opacity = opacity;
            HorizontalOffset = horizontalOffset;
            VerticalOffset = verticalOffset;
        }
        #endregion       

    }
}
