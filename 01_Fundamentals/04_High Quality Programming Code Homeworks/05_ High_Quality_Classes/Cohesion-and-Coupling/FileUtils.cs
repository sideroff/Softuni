namespace CohesionAndCoupling
{
    using CohesionAndCoupling.Interfaces;
    public class FileUtils : IFileUtility
    {
        public FileUtils()
        {
            
        }
        public string GetFileExtension(string fileName)
        {
            int indexOfLastDot = fileName.LastIndexOf(".");
            if (indexOfLastDot == -1)
            {
                return "";
            }

            string extension = fileName.Substring(indexOfLastDot + 1);
            return extension;
        }

        public string GetFileNameWithoutExtension(string fileName)
        {
            int indexOfLastDot = fileName.LastIndexOf(".");
            if (indexOfLastDot == -1)
            {
                return fileName;
            }

            string extension = fileName.Substring(0, indexOfLastDot);
            return extension;
        }

    }
}