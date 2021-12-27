using System;

namespace SW.PrimitiveTypes
{
    public class CloudFilesOptions
    {

        public const string ConfigurationSection = "CloudFiles";
        public string Driver { get; set; } = "S3";
        public string AccessKeyId { get; set; }
        public string SecretAccessKey { get; set; }
        public string BucketName { get; set; }
        public string ServiceUrl { get; set; }
    }
}
