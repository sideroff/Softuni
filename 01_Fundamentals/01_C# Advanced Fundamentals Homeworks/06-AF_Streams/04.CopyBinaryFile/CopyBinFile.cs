using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace _04.CopyBinaryFile
{
    class CopyBinFile
    {
        static void Main(string[] args)
        {
            FileStream source = new FileStream("yuhunicemoon.jpg", FileMode.Open);
            FileStream destination = new FileStream("../../destionation.jpg", FileMode.Create);
            using (source)
            {
                using (destination)
                {
                    byte[] buffer = new byte[4096];
                    while (true)
                    {
                        int readBytes = source.Read(buffer, 0, buffer.Length);
                        if (readBytes == 0)
                            break;

                        destination.Write(buffer, 0, readBytes);

                    }
                }
            }
        }
    }
}
