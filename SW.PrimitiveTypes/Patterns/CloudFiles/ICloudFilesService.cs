using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SW.PrimitiveTypes
{ 
    public interface ICloudFilesService
    {
        /// <summary>
        ///  Method to write a file asynchronously (privately or publicly)
        /// </summary>
        /// <param name="inputStream"></param>
        /// <param name="settings"></param>
        /// <returns></returns>
        Task WriteAcync(Stream inputStream, WriteFileSettings settings);
       

    }
}
