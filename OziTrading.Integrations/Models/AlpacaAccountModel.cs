using System;

namespace OziTrading.Integrations.Models
{
    public class AlpacaAccountModel
    {
        public Guid Id { get; set; }
        public string AccountantNumber { get; set; }
        public string Status { get; set; }
        public string Currency { get; set; }
        public decimal TradableCash { get; set; }
        public decimal WithdrawableCash { get; set; }
    }
}
