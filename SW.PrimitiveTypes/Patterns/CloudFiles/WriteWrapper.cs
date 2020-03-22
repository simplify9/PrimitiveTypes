using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SW.PrimitiveTypes
{
    public class WriteWrapper : IDisposable
    {
        private readonly HttpWebRequest httpWebRequest;
        private readonly ICloudFilesService cloudFilesService;
        private readonly WriteFileSettings writeFileSettings;
        private HttpWebResponse httpWebResponse;
        private Stream stream;

        public WriteWrapper(HttpWebRequest httpWebRequest, ICloudFilesService cloudFilesService, WriteFileSettings writeFileSettings)
        {
            //Stream = httpWebRequest.GetRequestStream();
            this.httpWebRequest = httpWebRequest;
            this.cloudFilesService = cloudFilesService;
            this.writeFileSettings = writeFileSettings;
        }

        async public Task<Stream> GetStreamAsync()
        {
            stream = await httpWebRequest.GetRequestStreamAsync();
            return stream; 
        }

        async public Task<RemoteBlob> CompleteRequestAsync()
        {
            var contentLength = stream.Length;
            httpWebResponse = (HttpWebResponse)(await httpWebRequest.GetResponseAsync());

            httpWebResponse.Close();

            return new RemoteBlob
            {
                Location = writeFileSettings.Public ? cloudFilesService.GetUrl(writeFileSettings.Key) : cloudFilesService.GetSignedUrl(writeFileSettings.Key, TimeSpan.FromHours(1)),
                MimeType = writeFileSettings.ContentType,
                Name = writeFileSettings.Key,
                Size = Convert.ToInt32(contentLength)
            };
        }

        public void Dispose()
        {
            stream?.Dispose();
            httpWebResponse?.Dispose();
        }

    }
}
