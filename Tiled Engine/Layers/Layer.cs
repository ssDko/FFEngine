using System;
using System.Collections.Generic;
using System.Text;

namespace Tiled_Engine.Layers
{
    public abstract class Layer
    {
        #region Declarations
        private string name = "";
        private bool visible = true;
        private bool locked = false;
        private float opacity = 1.0f;
        private float horizontalOffset = 0.0f;
        private float verticalOffset = 0.0f;
        #endregion

        #region Properties
        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }
        public virtual bool Visible
        {
            get { return visible; }
            set { visible = value; }
        }

        public virtual bool Locked
        {
            get { return locked; }
            set { locked = value; }
        }

        public virtual float Opacity
        {
            get { return opacity; }
            set { opacity = value; }
        }

        public virtual float HorizontalOffset
        {
            get { return horizontalOffset; }
            set { horizontalOffset = value; }
        }

        public virtual float VerticalOffset
        {
            get { return verticalOffset; }
            set { verticalOffset = value; }
        }
        #endregion

        #region Constructor(s)
        public Layer(string name, 
                     bool visible = true, 
                     bool locked = false, 
                     float opacity = 1.0f, 
                     float horizontalOffset = 0.0f, 
                     float verticalOffset = 0.0f)
        {
            this.name = name;
            this.visible = visible;
            this.locked = locked;
            this.opacity = opacity;
            this.horizontalOffset = horizontalOffset;
            this.verticalOffset = verticalOffset;
        }
        #endregion

        #region Methods
        public abstract void Update();
        #endregion


    }
}
