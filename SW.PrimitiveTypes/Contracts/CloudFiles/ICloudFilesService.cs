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
        Task<RemoteBlob> WriteAsync(Stream inputStream, WriteFileSettings settings);

        /// <summary>
        ///  Method to write a text file asynchronously (private or public)
        /// </summary>
        /// <param name="text"></param>
        /// <param name="settings"></param>
        /// <returns></returns>
        Task<RemoteBlob> WriteTextAsync(string text, WriteFileSettings settings);

        /// <summary>
        /// Get a public url for the a file with an a specific expiry
        /// </summary>
        /// <param name="key"></param>
        /// <param name="expiry"></param>
        /// <returns></returns>
        string GetSignedUrl(string key, TimeSpan expiry);

        /// <summary>
        /// Get a url that only works for public files
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        string GetUrl(string key);

        /// <summary>
        /// Method to open and update a file 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        WriteWrapper OpenWrite(WriteFileSettings settings);

        /// <summary>
        /// Method to read a file
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<Stream> OpenReadAsync(string key);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prefix"></param>
        /// <returns></returns>
        Task<IEnumerable<CloudFileInfo>> ListAsync(string prefix);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<IReadOnlyDictionary<string, string>> GetMetadataAsync(string key);

        /// <summary>
        /// Deletes File.
        /// </summary>
        /// <param name="key"></param>
        /// <returns>True if file is successfully deleted, false if not successfully deleted</returns>
        Task<bool> DeleteAsync(string key);



    }
}
