using System;

namespace OziTrading.Integrations.Models
{
    public class AlpacaAssestModel
    {
        public Guid AssetId { get; set; }
        public string Class { get; set; }
        public string Exchange { get; set; }
        public string Symbol { get; set; }
        public string Status { get; set; }
        public bool IsTradable { get; set; }
        public bool Marginable { get; set; }
        public bool Shortable { get; set; }
        public bool EasyToBorrow { get; set; }
    }
}
