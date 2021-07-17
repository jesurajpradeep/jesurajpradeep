using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace CS7Starter
{
    public class CS7Model
    {
        #region Serialization

        /// <summary>
        /// DeSerialize
        /// </summary>
        /// <param name="type">Type</param>
        /// <param name="filename">file name string</param>
        /// <returns></returns>
        internal object DeSerialize(Type type, string filename)
        {
            FileStream fs = null;
            XmlSerializer serializer = null;
            object obj = null;
            try
            {
                fs = new FileStream(filename, FileMode.Open);
                serializer = new XmlSerializer(type);
                obj = serializer.Deserialize(fs);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                    fs.Dispose();
                }
            }
            return obj;
        }


        /// <summary>
        /// Serialize
        /// </summary>
        /// <param name="infoSetting">Type</param>
        /// <param name="filename">file name string</param>
        /// <returns></returns>
        internal void Serialize(Type infoSetting, string filename, object _setting)
        {
            XmlSerializer serializer = null;
            FileStream fs = null;
            try
            {
                serializer = new XmlSerializer(infoSetting);
                fs = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.Write, 8, FileOptions.WriteThrough);
                serializer.Serialize(fs, _setting);
                fs.Flush(true);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                    fs.Dispose();
                }
            }
        }

        internal bool IsFileExists(string filePath)
        {
            if (File.Exists(filePath))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion
    }
}
