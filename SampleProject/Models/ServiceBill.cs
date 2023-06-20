using System.Security.Permissions;

namespace SampleProject.Models
{
    public class ServiceBill
    {
        public Dictionary<string,decimal> ServiceCost { get; set; }
        public decimal Sum { get; set; } = 0;
        public string? ErrorMessage { get; set; } = null;
    }
}
