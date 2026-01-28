using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolSendMessage.models
{
    public class Customer
    {
        public string MKH { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public decimal Total { get; set; }
        public string Phone { get; set; } = string.Empty;
        public string TotalVnd => FormatVnd(Total, true);

        private static string FormatVnd(decimal amount, bool withSymbol = true)
        {
            var vi = new CultureInfo("vi-VN");
            var formatted = amount.ToString("N0", vi);
            return withSymbol ? $"{formatted} ₫" : formatted;
        }
    }
}
