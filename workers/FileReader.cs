using System;
using System.IO;

namespace WordScambler.workers
{
    public class FileReader
    {
        public string[] Read(string filename)
        {
            string[] filecontent;
            try
            {
                filecontent = File.ReadAllLines(filename);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return filecontent;
        }
    }
}
