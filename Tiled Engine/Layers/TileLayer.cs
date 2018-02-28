using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

            CreateData();
        }
        #endregion

        #region Methods
        public override void Update()
        {

        }

        private void CreateData()
        {
            switch(dataEncoding)
            {
                case DataEncoding.CSV:
                    CreateDataFromCSV();
                    break;

                case DataEncoding.XML:
                    CreateDataFromXML();
                    break;

                case DataEncoding.BASE64:
                    CreateDataFromBase64();
                    break;

                case DataEncoding.BASE64GZIP:
                    CreateDataFromBase64GZip();
                    break;

                case DataEncoding.BASE64ZLIB:
                    CreateDataFromBase64ZLib();
                    break;

                default:

                    break;
            }
        }

        private void CreateDataFromCSV()
        {
            data = encodedData.Split(',').Select(uint.Parse).ToList();
        }

        private void CreateDataFromXML()
        {

        }

        private void CreateDataFromBase64()
        {

        }

        private void CreateDataFromBase64GZip()
        {

        }

        private void CreateDataFromBase64ZLib()
        {

        }

        public void ChangeData(string encodedData, DataEncoding dataEncoding)
        {
            this.encodedData = encodedData;
            this.dataEncoding = dataEncoding;
            CreateData();
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
