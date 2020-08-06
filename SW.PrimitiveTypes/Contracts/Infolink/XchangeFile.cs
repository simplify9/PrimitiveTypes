using System;
using System.Security.Cryptography;
using System.Text;

namespace SW.PrimitiveTypes
{
    public class XchangeFile : ValueObject
    {


        public XchangeFile(string data, string fileName = null)
        {
            Data = data ?? throw new SWException("Invalid file data.");
            Filename = fileName;
            using (SHA1Managed sha1 = new SHA1Managed())
                Hash = BitConverter.ToString(sha1.ComputeHash(Encoding.UTF8.GetBytes(Data))).Replace("-", "").ToLower();

        }

        public string Filename { get; }
        public string Data { get; }
        public string Hash { get; }

        //public XchangeFileDto ToXchangeFileDto()
        //{
        //    return new XchangeFileDto
        //    {
        //        Data = Data,
        //        Filename = Filename
        //    };
        //}

        //public static XchangeFile FromXchangeFileDto(XchangeFileDto fileDto)
        //{
        //    return new XchangeFile(fileDto.Data, fileDto.Filename);
        //}

    }
}
