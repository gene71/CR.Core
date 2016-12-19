using CR.Util.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;

using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CR.Util
{
    public class FileUtil
    {
        List<string> files;

        public FileUtil()
        {
            files = new List<string>();
        }

        /// <summary>
        /// GetFiles returns a generic list of file paths
        /// </summary>
        /// <param name="path"></param>
        /// <returns>List</returns>
        /// <exception cref="FileUtilException">FileUtilException</exception>
        public List<string> GetFiles(string path)
        {


            try
            {
                foreach (string f in Directory.GetFiles(path))
                {
                    files.Add(f);
                }
                foreach (string d in Directory.GetDirectories(path))
                {
                    GetFiles(d);
                }
            }
            catch (Exception ex)
            {
                throw new FileUtilException("error enumerating files " + ex.Message);
            }

            return files;
        }
        /// <summary>
        /// GetMD5Hash computes an MD5Hash for the specified file path 
        /// </summary>
        /// <param name="path"></param>
        /// <returns>string</returns>
        /// <exception cref="FileUtilException">FileUtilException</exception>
        public static string GetMD5Hash(string path)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                MD5 md5 = MD5.Create();
                using (FileStream fs = File.Open(path, FileMode.Open))
                {
                    foreach (byte b in md5.ComputeHash(fs))
                        sb.Append(b.ToString("x2").ToLower());
                }
            }
            catch (Exception ex)
            {
                throw new FileUtilException(ex.Message);

            }
            return sb.ToString(); ;
        }
        /// <summary>
        /// GetFileExtensions returns a list of file extensions for the directory path
        /// </summary>
        /// <param name="dir"></param>
        /// <returns>List</returns>
        /// /// <exception cref="FileUtilException">FileUtilException</exception>
        public List<string> GetFileExtensions(string dir)
        {
            List<string> fileExtensions = new List<string>();
            try
            {
                foreach (var f in GetFiles(dir))
                {
                    FileInfo fi = new FileInfo(f);
                    if (!fileExtensions.Contains(fi.Extension))
                    {
                        fileExtensions.Add(fi.Extension);
                    }
                    
                }
            }
            catch (Exception ex)
            {
                throw new FileUtilException("error getting extensions " + ex.Message);
            }
            return fileExtensions;
        }
    }
}
