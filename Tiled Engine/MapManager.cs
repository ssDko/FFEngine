using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using System.Linq;
using System;

namespace Tiled_Engine
{
    public static class MapManager
    {
        #region Declarations
        private static string mapDirectory = "";
        private static TiledMap currentMap;
        private static TiledMap previousMap;
        private static TiledSet currentTileSet;

        private static List<string> mapFiles;
        private static List<string> tileSetFiles;
        private static Dictionary<string, TiledMap> maps;
        private static Dictionary<string, TiledSet> tileSets;

        private static XmlReader xmlReader;
        private static XElement xElement;
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

        public static TiledSet CurrentTileSet
        {
            get { return currentTileSet; }
        }
        #endregion
              

        #region Methods
        private static void LoadTileSets()
        {
            // Find all tile set file names.
            string searchPattern = "*.tsx";
            var fileNames = Directory.EnumerateFiles(mapDirectory, searchPattern, SearchOption.TopDirectoryOnly).Select(Path.GetFileName);
            tileSetFiles = new List<string>(fileNames);

            // Load the tilesets
            foreach (var fileName in tileSetFiles)
            {
                if (File.Exists(mapDirectory + fileName))
                {
                    // Read in the data
                    xmlReader = XmlReader.Create(mapDirectory + fileName);

                    while (xmlReader.NodeType != XmlNodeType.Element)
                        xmlReader.Read();

                    xElement = XElement.Load(xmlReader);

                    TiledSet tempSet;

                    string nametemp = xElement.Attribute("name").Value.ToString();
                    int columnstemp = Convert.ToInt32(xElement.Attribute("columns").Value);
                    string sourcetemp = xElement.Attribute("source").Value;


                }
                else
                {
                    // Todo: log to file an error
                }
            }


           
        }

        private static void LoadMaps()
        {
            // Find all tile set file names.
            string searchPattern = "*.tmx";
            var fileNames = Directory.EnumerateFiles(mapDirectory, searchPattern, SearchOption.TopDirectoryOnly).Select(Path.GetFileName);
            mapFiles = new List<string>(fileNames);
        }
        public static void ChangeCurrentMap(string name)
        {

        }
        public static void Update()
        {

        }

        public static void Draw()
        {

        }

        public static bool LoadMapData()
        {
            LoadTileSets();
            LoadMaps();
            return true;
        }
        #endregion

    }
}
