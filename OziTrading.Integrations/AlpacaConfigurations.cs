namespace OziTrading.Integrations
{
    public interface IAlpacaConfigurations
    {
        public string AlpacaEndPoint { get; set; }
        public string ApiKeyId { get; set; }
        public string ApiSecretKey { get; set; }
    }
    public class AlpacaConfigurations : IAlpacaConfigurations
    {
        public string AlpacaEndPoint { get; set; }
        public string ApiKeyId { get; set; }
        public string ApiSecretKey { get; set; }
    }
}
