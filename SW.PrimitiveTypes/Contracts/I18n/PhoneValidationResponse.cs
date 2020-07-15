namespace SW.PrimitiveTypes
{
    public class PhoneValidationResponse
    {
        public long PhoneNumber { get; set; }
        public long PhoneNumberShort { get; set; }
        public string CountryCode { get; set; }
        public PhoneType PhoneType { get; set; }
        public PhoneValidationStatus Status { get; set; }
    }


}
