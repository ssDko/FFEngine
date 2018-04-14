using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using System.Linq;
using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Specialized;
using DkoLib;
using Tiled_Engine.Layers;
//using GameObjects;
using Microsoft.Xna.Framework.Input;
using System.Collections;

namespace Tiled_Engine
{
    public static class MapManager
    {
        #region Declarations
        private static List<string> mapFiles;
        private static List<string> tileSetFiles;
        private static Player player;        
        #endregion

        #region Properties
        public static string MapDirectory { get; set; } = "";

        public static TiledMap CurrentMap { get; private set; }

        public static TiledMap PreviousMap { get; private set; }

        public static OrderedDictionary Maps { get; private set; }

        public static OrderedDictionary TileSets { get; private set; }

        public static bool StartMapExists { get; private set; } = false;

        public static Point StartTilePosition { get; private set; } = new Point(0, 0);  // In Tiles
        #endregion


        #region Methods
        private static void LoadTileSets(GraphicsDevice graphicsDevice)
        {
            // Find all tile set file names.
            string searchPattern = "*.tsx";
            var fileNames = Directory.EnumerateFiles(MapDirectory, searchPattern, SearchOption.TopDirectoryOnly).Select(Path.GetFileName);
            tileSetFiles = new List<string>(fileNames);
            TileSets = new OrderedDictionary();
            

            // Load the tilesets
            foreach (var fileName in tileSetFiles)
            {
                if (File.Exists(MapDirectory + fileName))
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
                    TiledSet tileSet = new TiledSet(name, fileName, sourceImage, MapDirectory, graphicsDevice, tileWidth, tileHeight, tileCount, columns);
                    TileSets.Add(fileName, tileSet);

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
            var fileNames = Directory.EnumerateFiles(MapDirectory, searchPattern, SearchOption.TopDirectoryOnly).Select(Path.GetFileName);
            mapFiles = new List<string>(fileNames);
            Maps = new OrderedDictionary();
            
            // Load the maps
            foreach (var fileName in mapFiles)
            {
                if (File.Exists(MapDirectory + fileName))
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

                    // Handle any optional Properties.
                    if (XMLHelperFuncs.DoesElementExist(xElement, "properties"))
                    {
                        XElement properties = XMLHelperFuncs.GetElement(xElement, "properties");

                        //Process properties
                        foreach (var property in properties.Elements())
                        {
                            string name = XMLHelperFuncs.GetStringFromAttribute(property, "name");

                            //Todo
                            

                        }
                    }


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
                            layerList.Add(GenerateTileLayer(element, isInfinite, tileWidth, tileHeight));
                        }

                        if (element.Name == "imagelayer")
                        {
                            layerList.Add(GenerateImageLayer(element, graphicsDevice));
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

                   Maps.Add(fileName, newMap);
                }
            }
        }

        private static Layer GenerateImageLayer(XElement element, GraphicsDevice graphicsDevice)
        {
            string name = XMLHelperFuncs.GetStringFromAttribute(element, "name");
            string source = XMLHelperFuncs.GetStringFromAttribute(element.Element("image"), "source");            

            bool visible = XMLHelperFuncs.GetBoolFromAttribute(element, "visible", true);
            bool locked = XMLHelperFuncs.GetBoolFromAttribute(element, "locked");
            float opacity = XMLHelperFuncs.GetFloatFromAttribute(element, "opacity", 1.0f);
            float horizontalOffset = XMLHelperFuncs.GetFloatFromAttribute(element, "offsetx", 0.0f);
            float verticalOffset = XMLHelperFuncs.GetFloatFromAttribute(element, "offsety", 0.0f);


            ImageLayer layer = new ImageLayer(name, 
                                              source, 
                                              MapDirectory, 
                                              graphicsDevice, 
                                              visible, 
                                              locked, 
                                              opacity, 
                                              horizontalOffset, 
                                              verticalOffset);

            return layer;         
        }

        private static TileLayer GenerateTileLayer(XElement element, bool isInfinate, int tileWidth, int tileHeight)
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


            DataEncoding dataEncoding = DataEncoding.CSV;

            // The encoding attribute only exists if data isn't in XML format
            if (XMLHelperFuncs.DoesAttributeExist(element.Element("data"), "encoding"))
            {
                string strDataEncoding = XMLHelperFuncs.GetStringFromAttribute(element.Element("data"), "encoding");

                switch (strDataEncoding)
                {
                    case ("csv"):
                        dataEncoding = DataEncoding.CSV;
                        break;

                    case ("base64"):
                        if (XMLHelperFuncs.DoesAttributeExist(element.Element("data"), "compression"))
                        {
                            if (XMLHelperFuncs.GetStringFromAttribute(element.Element("data"), "compression") == "gzip")
                            {
                                dataEncoding = DataEncoding.BASE64GZIP;
                            }
                            else if (XMLHelperFuncs.GetStringFromAttribute(element.Element("data"), "compression") == "zlib")
                            {
                                dataEncoding = DataEncoding.BASE64ZLIB;
                            }
                            else
                            {
                                //Todo: report error that compression is unknown
                            }
                        }
                        else
                        {
                            dataEncoding = DataEncoding.BASE64;
                        }
                        break;

                    default:
                        //Todo: report error that encoding is unkown
                        break;
                }
            }
            else
            {
                dataEncoding = DataEncoding.XML;
            }

            layer = new TileLayer(name,
                                  layerWidth,
                                  layerHeight,
                                  tileWidth,
                                  tileHeight,
                                  encodedData,
                                  dataEncoding,
                                  visible,
                                  locked,
                                  opacity,
                                  horizontalOffset,
                                  verticalOffset);

            // Decode and add data

            if (!isInfinate)
            {

                if (dataEncoding != DataEncoding.XML)
                {
                    encodedData = XMLHelperFuncs.GetStringFromElement(element, "data");
                    layer.AddMapChunk<string>(encodedData, 0, 0, layerWidth, layerHeight, tileWidth, tileHeight, dataEncoding);                    
                }
                else
                {
                    encodedData = "";
                    XElement dataElement = XMLHelperFuncs.GetElement(element, "data");
                    layer.AddMapChunk(dataElement, 0, 0, layerWidth, layerHeight, tileWidth, tileHeight, dataEncoding);
                }
            }
            else

            {
                if (dataEncoding != DataEncoding.XML)
                {
                    foreach (var chunkElement in XMLHelperFuncs.GetElement(element, "data").Elements())
                    {
                        int x = XMLHelperFuncs.GetIntFromAttribute(chunkElement, "x");
                        int y = XMLHelperFuncs.GetIntFromAttribute(chunkElement, "y");
                        int width = XMLHelperFuncs.GetIntFromAttribute(chunkElement, "width");
                        int height = XMLHelperFuncs.GetIntFromAttribute(chunkElement, "height");
                        string tempEncodedData = chunkElement.Value.ToString();

                        layer.AddMapChunk(tempEncodedData, x, y, width, height, tileWidth, tileHeight, dataEncoding);
                    }
                }
                else
                {
                    encodedData = "";

                    //Todo
                    
                }
            }

            

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
            using (xmlReader = XmlReader.Create(MapDirectory + fileName))
            {

                while (xmlReader.NodeType != XmlNodeType.Element)
                    xmlReader.Read();

                xElement = XElement.Load(xmlReader);
            }

            return xElement;
        }

        public static bool ChangeCurrentMap(string fileName)
        {
            if (Maps.Contains(fileName))
            {
                PreviousMap = CurrentMap;
                CurrentMap = (TiledMap)Maps[fileName];
                Camera.WorldRectangle = new Rectangle(0, 0,
                                                      CurrentMap.TileWidth * CurrentMap.MapWidth,
                                                      CurrentMap.TileHeight * CurrentMap.MapHeight);
                
                return true;
            }

            return false;
        }

        public static bool ChangeCurrentMap(int index)
        {    
            if (index < Maps.Count)
            {
                string fileName = Maps.Cast<DictionaryEntry>().ElementAt(index).Key.ToString();

                return ChangeCurrentMap(fileName);
            }

            return false;
        }

        public static void Update(GameTime gameTime)
        {

            // Update tiles (animation)
            foreach(TiledSet tileSet in TileSets.Values)
            {
                tileSet.Update(gameTime);
            }
                        

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                player.Move(Dir.Up);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                player.Move(Dir.Down);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                player.Move(Dir.Left);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                player.Move(Dir.Right);
            }



            player.Update();         
                       



            // Update Camera to follow the player
            float cameraNewX = player.Position.X - (Camera.GameWidth / 2);
            float cameraNewY = player.Position.Y - (Camera.GameHeight / 2);
            Camera.Position = new Vector2(cameraNewX, cameraNewY);

        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            for (int layerIndex = 0; layerIndex < CurrentMap.Layers.Count; layerIndex++)
            {
                float z = 1f - ((float)layerIndex * 0.1f);

                Layer layer = CurrentMap.Layers[layerIndex];
                if (layer is TileLayer)
                {
                    DrawTileLayer(spriteBatch, z, layer);
                }
                else if (layer is ImageLayer)
                {
                    DrawImageLayer(spriteBatch, z, layer);
                }
            }

            // Draw the player
            Vector2 playerScreenPos = Camera.WorldToScreen(player.Position.X, player.Position.Y);
            Rectangle playerRect = new Rectangle((int)playerScreenPos.X, (int)playerScreenPos.Y, player.Texture.Width, player.Texture.Height);
            spriteBatch.Draw(player.Texture, playerRect, player.Texture.Bounds, Color.White, 0.0f, Vector2.Zero, SpriteEffects.None, player.Z);
        }

        private static void DrawImageLayer(SpriteBatch spriteBatch, float z, Layer layer)
        {
            ImageLayer imageLayer = layer as ImageLayer;
            Rectangle worldRect = new Rectangle((int)imageLayer.HorizontalOffset, (int)imageLayer.VerticalOffset, imageLayer.Width(), imageLayer.Height());
            Rectangle screenRect = Camera.WorldToScreen(worldRect);
            Rectangle sourceRect = new Rectangle(0, 0, imageLayer.Width(), imageLayer.Height());
            spriteBatch.Draw(imageLayer.Image,
                                screenRect,
                                sourceRect,
                                Color.White, 0.0f,
                                Vector2.Zero,
                                SpriteEffects.None,
                                z);            
        }

        private static void DrawTileLayer(SpriteBatch spriteBatch, float z, Layer layer)
        {
            List<uint> firstGlobalIDs = CurrentMap.TiledSets.Keys.ToList<uint>();            
            TileLayer tileLayer = layer as TileLayer;

           
            foreach (var chunk in tileLayer.MapChunks)
            {
                for (int tileY = 0; tileY < chunk.Height; tileY++)
                {
                    for (int tileX = 0; tileX < chunk.Width; tileX++)
                    {
                        uint GlobalID = chunk.Data[tileY, tileX];

                        if (GlobalID != 0)
                        {
                            int worldX = (tileX * CurrentMap.TileWidth) + (int)tileLayer.HorizontalOffset + (int)(chunk.Position.X * CurrentMap.TileWidth);
                            int worldY = (tileY * CurrentMap.TileHeight) + (int)tileLayer.VerticalOffset + (int)(chunk.Position.Y * CurrentMap.TileHeight);
                            
                            Rectangle worldRect = new Rectangle(worldX, worldY, CurrentMap.TileWidth, CurrentMap.TileHeight);
                            Rectangle screenRect = Camera.WorldToScreen(worldRect);

                            //Wrap the screen.
                            // the before and after changes to the position are done for smoothing purposes.
                            screenRect.X += CurrentMap.TileWidth;
                            screenRect.Y += CurrentMap.TileHeight;
                            screenRect.X = MyMath.Mod(screenRect.X, Camera.WorldRectangle.Width);
                            screenRect.Y = MyMath.Mod(screenRect.Y, Camera.WorldRectangle.Height);
                            screenRect.X -= CurrentMap.TileWidth;
                            screenRect.Y -= CurrentMap.TileHeight;

                            

                            //Check bounds
                            if (screenRect.X + screenRect.Width > 0 &&
                                screenRect.X < Camera.ViewPortWidth &&
                                screenRect.Y + screenRect.Height > 0 &&
                                screenRect.Y < Camera.ViewPortHeight)
                            {

                                int tilesetIndex = TiledHelperMethods.GetTileSetIndex(GlobalID, firstGlobalIDs);
                                int localID = TiledHelperMethods.ConvertGIDToID(GlobalID, firstGlobalIDs);
                                bool hFlip = TiledHelperMethods.isGIDHorizontallyFlipped(GlobalID);
                                bool vFlip = TiledHelperMethods.isGIDVerticallyFlipped(GlobalID);
                                bool dFlip = TiledHelperMethods.isGIDDiagonallyFlipped(GlobalID);
                                float rotation = 0.0f;
                                TiledSet tiledSet = (TiledSet)MapManager.TileSets[tilesetIndex];
                                Vector2 origin = new Vector2(tiledSet.TileWidth / 2, tiledSet.TileHeight / 2);
                                SpriteEffects effects = SpriteEffects.None;
                                Rectangle sourceRect = new Rectangle();

                                // Do we draw the default tile or it's animation tiles
                                if (tiledSet.Tiles[localID].IsAnimated)
                                {
                                    int currentAnimationTileIndex = tiledSet.Tiles[localID].CurrentFrameID;
                                    sourceRect = tiledSet.Tiles[currentAnimationTileIndex].Rectangle();
                                }
                                else
                                {
                                    sourceRect = tiledSet.Tiles[localID].Rectangle();
                                }

                                //Account for the new sprite origins
                                screenRect.X += (int)(origin.X);
                                screenRect.Y += (int)(origin.Y);

                                //Rotate and flip our sprites
                                effects = CalculateEffects(hFlip, vFlip, dFlip);
                                rotation = CalculateRotation(hFlip, vFlip, dFlip);


                                spriteBatch.Draw(tiledSet.Texture,
                                                    screenRect,
                                                    sourceRect,
                                                    Color.White,
                                                    rotation,
                                                    origin,
                                                    effects,
                                                    z);

                            }
                        }
                    }
                }
            }
        }

        private static Vector2 WrapCordinates(Vector2 worldPos)
        {
            worldPos.X = MyMath.Mod((int)worldPos.X, Camera.WorldRectangle.Width);
            worldPos.Y = MyMath.Mod((int)worldPos.Y, Camera.WorldRectangle.Height);
            int test = 0;
            return worldPos;
        }

        private static SpriteEffects CalculateEffects(bool hFlip, bool vFlip, bool dFlip)
        {
            SpriteEffects effect = SpriteEffects.None;
            if (!dFlip)
            {
                if (hFlip)
                {
                    effect |= SpriteEffects.FlipHorizontally;
                }

                if (vFlip)
                {
                    effect |= SpriteEffects.FlipVertically;
                }
            }
            else
            {
                // Diagonal flip is wierd to calculate
                if (hFlip && vFlip)
                {
                    effect = SpriteEffects.FlipHorizontally;
                }

                if (!hFlip && vFlip)
                {
                    effect |= SpriteEffects.FlipHorizontally;
                    effect |= SpriteEffects.FlipVertically;
                }

                if (hFlip && !vFlip)
                {
                    effect = SpriteEffects.None;
                }

                if (!hFlip && !vFlip)
                {
                    effect = SpriteEffects.FlipVertically;
                }
            }
            return effect;
        }

        private static float CalculateRotation(bool hFlip, bool vFlip, bool dFlip)
        {
            float rotation = 0.0f;

            // A diagonal flip is weird to calculate
            if (dFlip)
            {
                // Rotate 90 degrees
                rotation = MathHelper.ToRadians(90.0f);
            }

            return rotation;
        }

        public static bool Initialize(Player newPlayer, string mapDirectory, GraphicsDevice graphicsDevice)
        {
            player = newPlayer;
            MapDirectory = mapDirectory;
            bool success = LoadMapData(graphicsDevice);
            return success;
        }

        public static bool LoadMapData(GraphicsDevice graphicsDevice)
        {
            LoadTileSets(graphicsDevice);
            LoadMaps(graphicsDevice);
            return ChangeCurrentMap(0);
        }

        public static uint FindGlobalIDatPosition(int x, int y, MapChunk chunk, TileLayer layer)
        {
           
            WrapCordinates(ref x, ref y, layer);

            x /= chunk.Width;
            y /= chunk.Height;

            x /= layer.TileWidth;
            y /= layer.TileHeight;

            return chunk.Data[y, x];
        }

        public static MapChunk FindChunkAtPosition(int x, int y, TileLayer layer)
        {
            MapChunk chunk = null;

            WrapCordinates(ref x, ref y, layer);

            foreach (var curChunk in layer.MapChunks)
            {
                if (x >= curChunk.WorldPosition.X &&
                    x <= curChunk.WorldPosition.X + curChunk.PixelWidth &&
                    y >= curChunk.WorldPosition.Y &&
                    y <= curChunk.WorldPosition.Y + curChunk.PixelHeight)
                {
                    chunk = curChunk;
                }
            }

            return chunk;
        }

        private static void WrapCordinates(ref int x, ref int y, TileLayer layer)
        {
            // If we are searching out of bounds, wrap around the cords
            if (x < 0)
            {
                x = layer.PixelWidth + x;
            }

            if (x > layer.PixelWidth)
            {
                x = x - layer.PixelWidth;
            }

            if (y < 0)
            {
                y = layer.PixelHeight + y;
            }

            if (y > layer.PixelHeight)
            {
                y = y - layer.PixelHeight;
            }
        }
        #endregion

    }
}
