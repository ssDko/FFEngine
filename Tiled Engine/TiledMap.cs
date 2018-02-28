using System;
using System.Collections.Generic;
using System.Text;
using Tiled_Engine.Layers;

namespace Tiled_Engine
{
    public class TiledMap
    {
        #region Declarations
        private string version = "";
        private string tiledVersion = "";
        private Orientation orientation = Orientation.Orthogonal;
        private RenderOrder renderOrder = RenderOrder.LeftDown;
        private int width = 0;
        private int height = 0;
        private int tileHeight = 0;
        private bool infinate = false;
        private int nextObjectID = 0;
        private List<string> tiledSetSources;
        private Dictionary<uint, TiledSet> tiledSets; // Referenced by thier first GlobalID
        private List<Layer> layers;
        
        
        
        #endregion

    }

    enum Orientation
    {
        Orthogonal,
        Isometric,
        IsometricStaggard,
        Hexagonal
    };

    enum RenderOrder
    {
        RightDown,
        RightUp,
        LeftDown,
        LeftUp
    };
}
