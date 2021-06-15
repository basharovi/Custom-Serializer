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
        public Variable Variable { get; set; }
    }

    public class Variable 
    {
        public string TokenSerial { get; set; }
        public string TokenTimestamp { get; set; }
        public string RSSI { get; set; }
    }
}
