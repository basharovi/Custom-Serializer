namespace CustomSerializer.Model
{
    public class JsonModel
    {
        public string Timestamp { get; set; }
        public string TimeSeries { get; set; }
        public string Endpoint { get; set; }
        public string Tenant { get; set; }
        public string LocationName { get; set; }
        public string LocationLabel { get; set; }
        public Variables Variables { get; set; }
    }

    public class Variables 
    {
        public string TokenSerial { get; set; }
        public string TokenTimestamp { get; set; }
        public int RSSI { get; set; }
    }

    public class CsvModel
    {
        public string LocationId { get; set; }
        public string DeviceId { get; set; }
        public string TokenSerial { get; set; }
        public string TokenRssi { get; set; }
        public string TokenTime { get; set; }
        public string GatewayTime { get; set; }
        public string CreatedTime { get; set; }


    }
}
