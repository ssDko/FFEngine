using System;
using System.Collections.Generic;
using System.Text;

namespace Tiled_Engine
{
    public class FrameData
    {
        #region Declarations
        private int tileID = 0;
        private float duration = 0.05f;
        #endregion

        #region Properties
        public int TileID
        {
            get { return tileID; }
            set { tileID = value; }
        }

        public float Duration
        {
            get { return duration; }
            set { duration = value; }
        }
        #endregion

        #region Constructor(s)
        public FrameData(int tileID, float duration = 0.05f)
        {
            this.tileID = tileID;
            this.duration = duration;
        }
        #endregion



    }
}
