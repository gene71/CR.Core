using CR.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CR.Core.Services
{

    public class CRObjSerializer
    {
        /// <summary>
        /// SaveCRObj can save any CR object that's serializable
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="crobj"></param>
        /// <exception cref="CRObjSerializerException">CRObjSerializerException</exception>
        public void SaveCRObj(string filename, object crobj)
        {
            try
            {
                using (var writer = new StreamWriter(filename))
                {
                    var serializer = new XmlSerializer(crobj.GetType());
                    serializer.Serialize(writer, crobj);
                    writer.Flush();

                }
            }
            catch (Exception ex)
            {
                throw new CRServicesException("error serializing CRObj..." + ex.Message);
            }


        }

        public CRScanner LoadCRScanner(string filepath)
        {
            try
            {
                using (FileStream fs = new FileStream(filepath, FileMode.Open)) //double check that...
                {
                    XmlSerializer _xSer = new XmlSerializer(typeof(CRScanner));

                    return (CRScanner)_xSer.Deserialize(fs);
                }
            }
            catch (Exception ex)
            {
                throw new CRServicesException("error deserializing CRScanner..." + ex.Message);
            }


        }

        public CRTemplate LoadCRTemplate(string filepath)
        {
            try
            {
                using (FileStream fs = new FileStream(filepath, FileMode.Open)) //double check that...
                {
                    XmlSerializer _xSer = new XmlSerializer(typeof(CRTemplate));

                    return (CRTemplate)_xSer.Deserialize(fs);
                }
            }
            catch (Exception ex)
            {
                throw new CRServicesException("error deserializing CRTemplate..." + ex.Message);
            }
        }

        public CRProject LoadCRProject(string filepath)
        {
            try
            {
                using (FileStream fs = new FileStream(filepath, FileMode.Open)) //double check that...
                {
                    XmlSerializer _xSer = new XmlSerializer(typeof(CRProject));

                    return (CRProject)_xSer.Deserialize(fs);
                }
            }
            catch (Exception ex)
            {
                throw new CRServicesException("error deserializing CRProject..." + ex.Message);
            }
        }
    }
}
