using System;
using System.Collections.Generic;
using System.Text;

namespace Tiled_Engine
{
    public class FrameData
    {              
        #region Properties
        public int TileID { get; set; } = 0;

        public float Duration { get; set; } = 0.05f;
        #endregion

        #region Constructor(s)
        public FrameData(int tileID, float duration = 0.05f)
        {
            TileID = tileID;
            Duration = duration;
        }
        #endregion



    }
}
