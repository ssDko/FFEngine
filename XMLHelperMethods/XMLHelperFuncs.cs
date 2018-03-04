using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace XMLHelper
{
    public static class XMLHelperFuncs
    {


        #region Methods
        public static string GetStringFromAttribute(XElement element, string attribute, string defaultValue = "")
        {
            return DoesAttributeExist(element, attribute) ? GetAttribute(element, attribute).Value : defaultValue;
        }

        public static string GetStringFromElement(XElement baseElement, string subElement, string defaultValue = "")
        {
            return DoesElementExist(baseElement, subElement) ? GetElement(baseElement, subElement).Value : defaultValue;
        }

        public static int GetIntFromAttribute(XElement element, string attribute, int defaultValue = 0)
        {
            return DoesAttributeExist(element, attribute) ? Convert.ToInt32(GetAttribute(element, attribute).Value) : defaultValue;
        }

        public static uint GetUIntFromAttribute(XElement element, string attribute, uint defaultValue = 0)
        {
            return DoesAttributeExist(element, attribute) ? Convert.ToUInt32(GetAttribute(element, attribute).Value) : defaultValue;
        }

        public static float GetFloatFromAttribute(XElement element, string attribute, float defaultValue = 0.0f)
        {
            return DoesAttributeExist(element, attribute) ? Convert.ToSingle(GetAttribute(element, attribute).Value) : defaultValue;            
        }

        public static bool GetBoolFromAttribute(XElement element, string attribute, bool defaultValue = false)
        {
            return DoesAttributeExist(element, attribute) ? GetIntFromAttribute(element, attribute) != 0 : defaultValue;
        }

        public static XAttribute GetAttribute(XElement element, string attribute)
        {
            return DoesAttributeExist(element, attribute) ? element.Attribute(attribute) : null;
        }

        public static XElement GetElement(XElement baseElement, string subElement)
        {
            return DoesElementExist(baseElement, subElement) ? baseElement.Element(subElement) : null;
        }

        public static bool DoesAttributeExist(XElement element, string attribute)
        {
            return element.Attribute(attribute) != null;
        }

        public static bool DoesElementExist(XElement element, string subElement)
        {
            return element.Element(subElement) != null;
        }
        #endregion

    }
}
