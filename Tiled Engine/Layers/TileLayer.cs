using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Tiled_Engine.Layers
{
    public class TileLayer : Layer
    {
        #region Declarations
        private int width = 0;
        private int height = 0;
        private DataEncoding dataEncoding = DataEncoding.CSV;
        private string encodedData = "";
        private List<uint> data;
        #endregion

        #region Properties
        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        public DataEncoding DataEncoding
        {
            get { return dataEncoding; }            
        }

        public string EncodedData
        {
            get { return encodedData; }

        }

        public List<uint> Data
        {
            get { return data; }
        }
        #endregion

        #region Constructor(s)
        public TileLayer(string name,
                         int width,
                         int height,
                         string encodedData,
                         List<uint> data,
                         DataEncoding dataEncoding = DataEncoding.CSV,                         
                         bool visible = true,
                         bool locked = false,
                         float opacity = 1.0f,
                         float horizontalOffset = 0.0f,
                         float verticalOffset = 0.0f) : base (name, visible, locked, opacity, horizontalOffset, verticalOffset)
        {
            this.width = width;
            this.height = height;
            this.encodedData = encodedData;
            this.dataEncoding = dataEncoding;
            this.data = data;
                       
        }
        #endregion

        #region Methods
        public override void Update()
        {

        }

        public static List<uint> CreateData(string encodedData, DataEncoding dataEncoding )
        {
            switch(dataEncoding)
            {
                case DataEncoding.CSV:
                    return CreateDataFromCSV(encodedData);                    
                                  
                case DataEncoding.BASE64:
                    return CreateDataFromBase64(encodedData);

                case DataEncoding.BASE64GZIP:
                    return CreateDataFromBase64GZip(encodedData);
                   
                case DataEncoding.BASE64ZLIB:
                    return CreateDataFromBase64ZLib(encodedData);
                    

                default:
                    // Todo: report error
                    return null;
                    
            }
        }

        public static List<uint> CreateData(XElement data, DataEncoding dataEncoding)
        {
            return CreateDataFromXML(data);
        }

        public static List<uint> CreateDataFromXML(XElement element)
        {
            return null; // Todo: report error
        }

        private static List<uint> CreateDataFromCSV(string encodedData)
        {
            return encodedData.Split(',').Select(uint.Parse).ToList();
        }               

        private static List<uint> CreateDataFromBase64(string encodedData)
        {
            return null; //Todo
        }

        private static List<uint> CreateDataFromBase64GZip(string encodedData)
        {
            return null; //Todo
        }

        private static List<uint> CreateDataFromBase64ZLib(string encodedData)
        {
            return null; //Todo
        }        
        #endregion

    }

    public enum DataEncoding
    {
        CSV,
        XML,
        BASE64,
        BASE64GZIP,
        BASE64ZLIB
    };

}
