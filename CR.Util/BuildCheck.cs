using System;
using System.Collections.Generic;


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
                FileUtil fu = new FileUtil();
                files = fu.GetFiles(path);


                //can i get extensions using FileInfo
                fileExtensions = fu.GetFileExtensions(path);

                //can I hash them
               
                foreach(var p in files)
                {
                    hashes.Add(this.GetMD5Hash(p));
                }

                //if errors 
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
                return true;
            }
        }
       
      
        /// <summary>
        /// GetMD5Hash computes an MD5Hash for the specified file path if an exception
        /// is encountered during the operation the exception message
        ///  is returned instead of the hash.  This call is needed to account for errors
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private string GetMD5Hash(string path)
        {
           
            try
            {
                             
                return FileUtil.GetMD5Hash(path);
            }
            catch (Exception ex)
            {
                //Catch the error before returning
                Errors.Add("MD5 compute issue with " + path + " " + ex.Message);
                return "Exception: " + ex.Message;
                
            }
           
        }

     
    }
}
