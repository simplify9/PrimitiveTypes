using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace SW.PrimitiveTypes
{
    public class XchangeFile 
    {

        //public XchangeFile(string data, string fileName, string contentType, bool badData) : this(data, fileName, badData)
        //{
        //    ContentType = contentType;
        //}

        public XchangeFile(string data, string fileName = null, bool badData = false)
        {
            Data = data ?? throw new SWException("Invalid file data.");
            Filename = fileName;
            BadData = badData;

            using (SHA1Managed sha1 = new SHA1Managed())
                Hash = BitConverter.ToString(sha1.ComputeHash(Encoding.UTF8.GetBytes(Data))).Replace("-", "").ToLower();

        }

        public string Filename { get; }
        public string Data { get; }
        public string Hash { get; }
        public bool BadData { get; }
        public string ContentType { get; set; }

        public override bool Equals(object obj)
        {
            return obj is XchangeFile file &&
                   Filename == file.Filename &&
                   Data == file.Data;
        }

        public override int GetHashCode()
        {
            int hashCode = -1744428883;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Filename);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Data);
            return hashCode;
        }
    }
}
