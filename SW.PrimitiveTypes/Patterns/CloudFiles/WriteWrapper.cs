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
        private HttpWebResponse httpWebResponse;

        public WriteWrapper(HttpWebRequest httpWebRequest)
        {
            Stream = httpWebRequest.GetRequestStream();
            this.httpWebRequest = httpWebRequest;
        }

        public Stream Stream { get; }

        async public Task CompleteRequestAsync()
        {
            httpWebResponse = (HttpWebResponse)(await httpWebRequest.GetResponseAsync());
            httpWebResponse.Close();
        }

        public void Dispose()
        {
            Stream.Dispose();
            httpWebResponse?.Dispose();
        }

    }
}
