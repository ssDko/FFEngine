using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Tiled_Engine.Layers;

namespace Tiled_Engine
{
    public class TiledMap
    {
        #region Properties
        public string Version { get; } = "";

        public string TiledVersion { get; } = "";

        public string SourceTMXFile { get; } = "";

        public Orientation Orientation { get; } = Orientation.Orthogonal;

        public RenderOrder RenderOrder { get; } = RenderOrder.LeftDown;

        public int MapWidth { get; } = 0;

        public int MapHeight { get; } = 0;

        public int TileWidth { get; } = 0;

        public int TileHeight { get; } = 0;

        public bool IsInfinate { get; } = false;

        public int NextObjectID { get; } = 0;

        public Dictionary<uint, string> TiledSets { get; }

        public List<Layer> Layers { get; }
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
            Version = version;
            TiledVersion = tiledVersion;
            SourceTMXFile = sourceTMXFile;
            Orientation = orientation;
            RenderOrder = renderOrder;
            MapWidth = mapWidth;
            MapHeight = mapHeight;
            TileWidth = tileWidth;
            TileHeight = tileHeight;
            IsInfinate = isInfinate;
            NextObjectID = nextObjectID;
            TiledSets = tiledSets;
            Layers = layers;
        }
        #endregion

        #region Methods
        public int GetCellAtPixelX(int cellX)
        {
            return cellX / TileWidth;
        }

        public int GetCellAtPixelY(int cellY)
        {
            return cellY / TileHeight;
        }

        public Vector2 GetCellByPixel(Vector2 pixelLocation)
        {
            return new Vector2(
                GetCellAtPixelX((int)pixelLocation.X),
                GetCellAtPixelY((int)pixelLocation.Y));
        }

        public Vector2 GetCellCenter(int cellX, int cellY)
        {
            return new Vector2(
                (cellX * TileWidth) + (TileWidth / 2),
                (cellY * TileHeight) + (TileWidth / 2));
        }

        public Vector2 GetCellCenter(Vector2 cell)
        {
            return GetCellCenter(
                (int)cell.X,
                (int)cell.Y);
        }

        public Rectangle CellWorldRectangle(int cellX, int cellY, int horizontalOffset = 0, int verticalOffset = 0)
        {
            return new Rectangle(
                (cellX * TileWidth) + horizontalOffset,
                (cellY * TileHeight) + verticalOffset,
                TileWidth,
                TileHeight);
        }

        public Rectangle CellWorldRectangle(Vector2 cell)
        {
            return CellWorldRectangle(
                (int)cell.X,
                (int)cell.Y);
        }

        public int GetTileIndexAtPixel(int tileX, int tileY)
        {
            return tileX + (MapWidth * tileY);
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
