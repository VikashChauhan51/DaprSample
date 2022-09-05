namespace SampleAPI.Configurations
{
    public class DaprConfiguration
    {
        public string StatestoreName { get; set; } = string.Empty;
        public string SecretstoreName { get; set; } = string.Empty;
        public PubsubConfig PubsubConfig { get; set; } = new();
        
    }

    public class PubsubConfig
    {
        public string Topic { get; set; } = string.Empty;
        public string PubsubName { get; set; } = string.Empty;
    }
}
