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
        private string sourceTMXFile = "";
        private Orientation orientation = Orientation.Orthogonal;
        private RenderOrder renderOrder = RenderOrder.LeftDown;
        private int mapWidth = 0;
        private int mapHeight = 0;
        private int tileWidth = 0;
        private int tileHeight = 0;
        private bool isInfinate = false;
        private int nextObjectID = 0;
        private Dictionary<uint, string> tiledSets; // Referenced by thier first GlobalID
        private List<Layer> layers;
        #endregion

        #region Properties
        public string Version
        {
            get { return version; }            
        }

        public string TiledVersion
        {
            get { return tiledVersion; }
        }

        public string SourceTMXFile
        {
            get { return sourceTMXFile; }
        }

        public Orientation Orientation
        {
            get { return Orientation; }
        }

        public RenderOrder RenderOrder
        {
            get { return renderOrder; }
        }

        public int MapWidth
        {
            get { return mapWidth; }
        }

        public int MapHeight
        {
            get { return mapHeight; }
        }

        public int TileWidth
        {
            get { return tileWidth; }
        }
        public int TileHeight
        {
            get { return tileHeight; }
        }

        public bool IsInfinate
        {
            get { return isInfinate; }
        }

        public int NextObjectID
        {
            get { return nextObjectID; }
        }

        public Dictionary<uint, string> TiledSets
        {
            get { return tiledSets; }
        }

        public List<Layer> Layers
        {
            get { return layers; }
        }
        #endregion

        #region Constructor(s)
        public TiledMap(string version,
                        string tiledVersion,
                        string sourceTMXFile,
                        Orientation orientation,
                        RenderOrder renderOrder,
                        int mapWidth,
                        int mapHeight,
                        int tileWidth,
                        int tileHeight,
                        bool isInfinate,
                        int nextObjectID,
                        Dictionary<uint, string> tiledSets,
                        List<Layer> layers)
        {
            this.version = version;
            this.tiledVersion = tiledVersion;
            this.sourceTMXFile = sourceTMXFile;
            this.orientation = orientation;
            this.renderOrder = renderOrder;
            this.mapWidth = mapWidth;
            this.mapHeight = mapHeight;
            this.tileWidth = tileWidth;
            this.tileHeight = tileHeight;
            this.isInfinate = isInfinate;
            this.nextObjectID = nextObjectID;
            this.tiledSets = tiledSets;
            this.layers = layers;
        }
        #endregion


    }

    public enum Orientation
    {
        Orthogonal,
        Isometric,
        IsometricStaggard,
        Hexagonal
    };

    public enum RenderOrder
    {
        RightDown,
        RightUp,
        LeftDown,
        LeftUp
    };
}
