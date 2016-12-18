using CodeRecon.Core.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
//test//

namespace CR.Util
{
    public class BuildCheck
    {
        List<string> files;
        List<string> hashes;
        List<string> fileExtensions;

        /// <summary>
        /// Call HasBuildErrors to see if errors exist, if so this list will contain errors
        /// </summary>
        public List<string> Errors;
        public BuildCheck()
        {
            files = new List<string>();
            hashes = new List<string>();
            Errors = new List<string>();
            fileExtensions = new List<string>();
        }

        /// <summary>
        /// HasBuildErrors checks the directory and files to make sure it can build CRFiles, if there
        /// errors it will return true.  All errors are add to the Errors list
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool HasBuildErrors(string path)
        {
            try
            {
                //first check can i enumerate all files
                files = GetFiles(path);

                //can i get extensions
                GetFileExtensions(path);

                //can I hash them
               
                foreach(var p in files)
                {
                    hashes.Add(this.GetMD5Hash(p));
                }

                if(Errors.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            
                    
            }
            catch (Exception ex)
            {
                //may throw here
                Errors.Add("issue testing for CRBuild " + ex.Message);
                return false;
            }
        }
       
        /// <summary>
        /// getFiles returns a generic list of file paths
        /// </summary>
        /// <param name="path"></param>
        /// <returns>List</returns>
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
                //throw new UtilException(ex.Message);
                Errors.Add("issue enumerating file " + path + " " + ex.Message);
            }

            return files;
        }

        /// <summary>
        /// GetMD5Hash computes an MD5Hash for the specified file path if an exception
        /// is encountered during the operation the exception message
        ///  is returned instead of the hash
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string GetMD5Hash(string path)
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
                //Catch the error before returning
                Errors.Add("MD5 compute issue with " + path + " " + ex.Message);
                return "Exception: " + ex.Message;
                
            }
            return sb.ToString(); ;
        }

        public void GetFileExtensions(string dir)
        {
            try
            {
                foreach(var f in GetFiles(dir))
                {
                    FileInfo fi = new FileInfo(f);
                    fileExtensions.Add(fi.Extension);
                }
            }
            catch (Exception ex)
            {
                Errors.Add("issue getting extension " + ex.Message);
            }
           
        }
    }
}
