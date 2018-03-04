using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using System.Linq;
using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Specialized;
using XMLHelper;
using Tiled_Engine.Layers;

namespace Tiled_Engine
{
    public static class MapManager
    {
        #region Declarations
        private static string mapDirectory = "";
        private static TiledMap currentMap;
        private static TiledMap previousMap;
        

        private static List<string> mapFiles;
        private static List<string> tileSetFiles;
        private static OrderedDictionary maps;
        private static OrderedDictionary tileSets; //Key is the TSX file name as name and image source could potentially be duplicates

        
        #endregion

        #region Properties
        public static string MapDirectory
        {
            get { return mapDirectory; }
            set { mapDirectory = value; }
        }
        public static TiledMap CurrentMap
        {
            get { return currentMap; }
        }

        public static TiledMap PreviousMap
        {
            get { return previousMap; }
        }
        
        public static OrderedDictionary TileSets
        {
            get { return tileSets; }
        }
        #endregion
              

        #region Methods
        private static void LoadTileSets(GraphicsDevice graphicsDevice)
        {
            // Find all tile set file names.
            string searchPattern = "*.tsx";
            var fileNames = Directory.EnumerateFiles(mapDirectory, searchPattern, SearchOption.TopDirectoryOnly).Select(Path.GetFileName);
            tileSetFiles = new List<string>(fileNames);
            tileSets = new OrderedDictionary();
            

            // Load the tilesets
            foreach (var fileName in tileSetFiles)
            {
                if (File.Exists(mapDirectory + fileName))
                {
                    // Read in the data
                    XElement xElement = ReadFileIntoXElement(fileName);

                    string name = XMLHelperFuncs.GetStringFromAttribute(xElement, "name");
                    int tileWidth = XMLHelperFuncs.GetIntFromAttribute(xElement, "tilewidth");
                    int tileHeight = XMLHelperFuncs.GetIntFromAttribute(xElement, "tileheight");
                    int tileCount = XMLHelperFuncs.GetIntFromAttribute(xElement, "tilecount");
                    int columns = XMLHelperFuncs.GetIntFromAttribute(xElement, "columns");
                    string sourceImage = XMLHelperFuncs.GetStringFromAttribute(xElement.Element("image"), "source");

                    // Create the Tile Set
                    TiledSet tileSet = new TiledSet(name, fileName, sourceImage, mapDirectory, graphicsDevice, tileWidth, tileHeight, tileCount, columns);
                    tileSets.Add(fileName, tileSet);

                    // Add tiles                   
                    for (int currentID = 0; currentID < tileCount; currentID++)
                    {
                        // Calc the position based on id
                        Vector2 position = new Vector2();
                        position.X = (currentID % columns) * tileWidth;
                        position.Y = (currentID / columns) * tileHeight;


                        string type = "";
                        bool isAnimated = false;
                        List<FrameData> frameData = new List<FrameData>();

                        foreach (var element in xElement.Elements())
                        {

                            // Search for data specific to the tile                            
                            if (element.Name == "tile")
                            {
                                int attributeID = XMLHelperFuncs.GetIntFromAttribute(element, "id");
                                if (attributeID == currentID)
                                {
                                    // See if it has a type element
                                    if (XMLHelperFuncs.DoesAttributeExist(element, "type"))
                                    {
                                        type = element.Attribute("type").Value;
                                    }

                                    // See if it has animation data
                                    if (XMLHelperFuncs.DoesElementExist(element, "animation"))
                                    {
                                        isAnimated = true;
                                        foreach (var frameElement in element.Element("animation").Elements())
                                        {
                                            // Check to be sure each element is a frame
                                            if (frameElement.Name == "frame")
                                            {
                                                int frameId = XMLHelperFuncs.GetIntFromAttribute(frameElement, "tileid");
                                                float frameDurration = XMLHelperFuncs.GetFloatFromAttribute(frameElement, "duration");

                                                frameData.Add(new FrameData(frameId, frameDurration));
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        TiledTile tempTile = new TiledTile(currentID, position, tileWidth, tileHeight, tileSet, type, isAnimated, true, frameData);

                        tileSet.AddTile(tempTile);
                    }                                      
                }
                else
                {
                    // Todo: log to file an error
                }
            }
        }

        private static void LoadMaps(GraphicsDevice graphicsDevice)
        {
            // Find all map file names.
            string searchPattern = "*.tmx";
            var fileNames = Directory.EnumerateFiles(mapDirectory, searchPattern, SearchOption.TopDirectoryOnly).Select(Path.GetFileName);
            mapFiles = new List<string>(fileNames);
            maps = new OrderedDictionary();
            
            // Load the maps
            foreach (var fileName in mapFiles)
            {
                if (File.Exists(mapDirectory + fileName))
                {
                    TiledMap newMap;
                    List<Layer> layerList = new List<Layer>();
                    // Read in the data
                    XElement xElement = ReadFileIntoXElement(fileName);

                    string version = XMLHelperFuncs.GetStringFromAttribute(xElement, "version");
                    string tiledVersion = XMLHelperFuncs.GetStringFromAttribute(xElement, "tiledversion");
                    string strOrientation = XMLHelperFuncs.GetStringFromAttribute(xElement, "orientation");
                    string strRenderOrder = XMLHelperFuncs.GetStringFromAttribute(xElement, "renderorder");
                    int width = XMLHelperFuncs.GetIntFromAttribute(xElement, "width");
                    int height = XMLHelperFuncs.GetIntFromAttribute(xElement, "height");
                    int tileWidth = XMLHelperFuncs.GetIntFromAttribute(xElement, "tilewidth");
                    int tileHeight = XMLHelperFuncs.GetIntFromAttribute(xElement, "tileheight");
                    bool isInfinite = XMLHelperFuncs.GetBoolFromAttribute(xElement, "infinite");
                    int nextObjectID = XMLHelperFuncs.GetIntFromAttribute(xElement, "nextobjectid");

                    Orientation orientation;
                    Enum.TryParse(strOrientation, out orientation);

                    //Enum.TryParse doesn't know how to convert the render order string tiled makes
                    // So manually we go.
                    RenderOrder renderOrder;
                    switch (strRenderOrder)
                    {
                        case "left-down":
                            renderOrder = RenderOrder.LeftDown;
                            break;

                        case "right-down":
                            renderOrder = RenderOrder.RightDown;
                            break;

                        case "left-up":
                            renderOrder = RenderOrder.LeftUp;
                            break;

                        case "right-up":
                            renderOrder = RenderOrder.RightUp;
                            break;

                        default:
                            renderOrder = RenderOrder.LeftDown;
                            break;
                    }
                    
                    
                    Dictionary<uint, string> tiledSets = new Dictionary<uint, string>();
                    foreach (var element in xElement.Elements())
                    {
                       
                        // Get tileset info
                        if (element.Name == "tileset")
                        {
                            GenerateMapTileSetInfo(tiledSets, element);
                        }

                        // Get tile layer info
                        if (element.Name == "layer")
                        {
                            layerList.Add(GenerateTileLayer(element));
                        }

                        if (element.Name == "imagelayer")
                        {
                            //Todo: add image layer
                        }

                        if (element.Name == "objectgroup")
                        {
                            //Todo: add objectgroup layer
                        }

                        if (element.Name == "group")
                        {
                            //Todo: add group layer
                        }
                    }

                    newMap = new TiledMap(version, 
                                          tiledVersion, 
                                          fileName, 
                                          orientation, 
                                          renderOrder, 
                                          width, 
                                          height, 
                                          tileWidth, 
                                          tileHeight, 
                                          isInfinite, 
                                          nextObjectID, 
                                          tiledSets, 
                                          layerList);

                   maps.Add(fileName, newMap);
                }
            }
        }

        private static TileLayer GenerateTileLayer(XElement element)
        {
            string name = XMLHelperFuncs.GetStringFromAttribute(element, "name");
            int layerWidth = XMLHelperFuncs.GetIntFromAttribute(element, "width");
            int layerHeight = XMLHelperFuncs.GetIntFromAttribute(element, "height");

            // These attributes don't necisarially exist in the file. 
            // So if we don't we set what it's default value 'should' be.
            bool visible = XMLHelperFuncs.GetBoolFromAttribute(element, "visible", true);
            bool locked = XMLHelperFuncs.GetBoolFromAttribute(element, "locked");
            float opacity = XMLHelperFuncs.GetFloatFromAttribute(element, "opacity", 1.0f);
            float horizontalOffset = XMLHelperFuncs.GetFloatFromAttribute(element, "offsetx", 0.0f);
            float verticalOffset = XMLHelperFuncs.GetFloatFromAttribute(element, "offsety", 0.0f);

            TileLayer layer;
            string encodedData = "";
            List<uint> data = new List<uint>();


            Layers.DataEncoding dataEncoding = Layers.DataEncoding.CSV;

            // The encoding attribute only exists if data isn't in XML format
            if (XMLHelperFuncs.DoesAttributeExist(element.Element("data"), "encoding"))
            {
                string strDataEncoding = XMLHelperFuncs.GetStringFromAttribute(element.Element("data"), "encoding");

                switch (strDataEncoding)
                {
                    case ("csv"):
                        dataEncoding = Layers.DataEncoding.CSV;
                        break;

                    case ("base64"):
                        if (XMLHelperFuncs.DoesAttributeExist(element.Element("data"), "compression"))
                        {
                            if (XMLHelperFuncs.GetStringFromAttribute(element.Element("data"), "compression") == "gzip")
                            {
                                dataEncoding = Layers.DataEncoding.BASE64GZIP;
                            }
                            else if (XMLHelperFuncs.GetStringFromAttribute(element.Element("data"), "compression") == "zlib")
                            {
                                dataEncoding = Layers.DataEncoding.BASE64ZLIB;
                            }
                            else
                            {
                                //Todo: report error that compression is unknown
                            }
                        }
                        else
                        {
                            dataEncoding = Layers.DataEncoding.BASE64;
                        }
                        break;

                    default:
                        //Todo: report error that encoding is unkown
                        break;
                }
            }
            else
            {
                dataEncoding = Layers.DataEncoding.XML;
            }

            // Decode data            
            if (dataEncoding != Layers.DataEncoding.XML)
            {
                encodedData = XMLHelperFuncs.GetStringFromElement(element, "data");

                data = TileLayer.CreateData(encodedData, dataEncoding);
            }
            else
            {
                encodedData = "";

                data = TileLayer.CreateData(element.Element("data"), dataEncoding);

            }

            layer = new TileLayer(name,
                                  layerWidth,
                                  layerHeight,
                                  encodedData,
                                  data,
                                  dataEncoding,
                                  visible,
                                  locked,
                                  opacity,
                                  horizontalOffset,
                                  verticalOffset);

            return layer;

        }

        private static void GenerateMapTileSetInfo(Dictionary<uint, string> tiledSets, XElement element)
        {
            uint firstGlobalID = XMLHelperFuncs.GetUIntFromAttribute(element, "firstgid");
            string tsxSourceFile = XMLHelperFuncs.GetStringFromAttribute(element, "source");
            tiledSets.Add(firstGlobalID, tsxSourceFile);
        }

        private static XElement ReadFileIntoXElement(string fileName)
        {
            XmlReader xmlReader;
            XElement xElement;
            using (xmlReader = XmlReader.Create(mapDirectory + fileName))
            {

                while (xmlReader.NodeType != XmlNodeType.Element)
                    xmlReader.Read();

                xElement = XElement.Load(xmlReader);
            }

            return xElement;
        }

        public static bool ChangeCurrentMap(string fileName)
        {
            if (maps.Contains(fileName))
            {
                previousMap = currentMap;
                currentMap = (TiledMap)maps[fileName];

                return true;
            }

            return false;
        }

        public static bool ChangeCurrentMap(int index)
        {
            if (index < maps.Count)
            {
                previousMap = currentMap;

                currentMap = (TiledMap)maps[index];
                return true;
            }

            return false;
        }

        public static void Update(GameTime gameTime)
        {
            foreach(TiledSet tileSet in tileSets.Values)
            {
                tileSet.Update(gameTime);
            }
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            foreach (var layer in currentMap.Layers)
            {
                if (layer is TileLayer)
                {
                    List<uint> firstGlobalIDs = new List<uint>();
                    firstGlobalIDs = currentMap.TiledSets.Keys.ToList<uint>();
                    int tilePositionX = 0;
                    int tilePositionY = 0;
                    TileLayer tileLayer = layer as TileLayer;
                    for (int i = 0; i < tileLayer.Data.Count ; i++)
                    {
                        uint GlobalID = tileLayer.Data[i];

                        if (GlobalID != 0) //Empty air
                        {
                            int tilesetIndex = TiledHelperMethods.GetTileSetIndex(GlobalID, firstGlobalIDs);
                            int localId = TiledHelperMethods.ConvertGIDToID(GlobalID, firstGlobalIDs);

                            TiledSet tiledSet = (TiledSet)MapManager.tileSets[tilesetIndex];

                            tilePositionX = (i % tileLayer.Width) * tiledSet.TileWidth;
                            tilePositionY = (i / tileLayer.Width) * tiledSet.TileHeight;

                            int tilePositionOnImageX = 0;
                            int tilePositionOnImageY = 0;
                            if (tiledSet.Tiles[localId].IsAnimated)
                            {
                                int currentAnimationTileIndex = tiledSet.Tiles[localId].CurrentFrameID;
                                tilePositionOnImageX = (int)tiledSet.Tiles[currentAnimationTileIndex].PositionOnImage.X;
                                tilePositionOnImageY = (int)tiledSet.Tiles[currentAnimationTileIndex].PositionOnImage.Y;
                            }
                            else
                            {
                                tilePositionOnImageX = (int)tiledSet.Tiles[localId].PositionOnImage.X;
                                tilePositionOnImageY = (int)tiledSet.Tiles[localId].PositionOnImage.Y;
                            }

                            
                            // Todo: Rotate the tiles appropriately

                            spriteBatch.Draw(tiledSet.Texture,
                                             new Rectangle(tilePositionX, tilePositionY, tiledSet.TileWidth, tiledSet.TileHeight),
                                             new Rectangle(tilePositionOnImageX, tilePositionOnImageY, tiledSet.TileWidth, tiledSet.TileHeight),
                                             Color.White);
                        }
                        
                    }
                }
            }
        }

        public static bool LoadMapData(GraphicsDevice graphicsDevice)
        {
            LoadTileSets(graphicsDevice);
            LoadMaps(graphicsDevice);
            return ChangeCurrentMap(0);
        }
        #endregion

    }
}
