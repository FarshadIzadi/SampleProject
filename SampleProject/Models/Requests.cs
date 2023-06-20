using System.ComponentModel.DataAnnotations.Schema;

namespace SampleProject.Models
{
    public class Requests
    {
        public int Id { get; set; }
        public string RequestTitle { get; set; }
        public decimal CapitalSum { get; set; }
        public decimal BillTotal { get; set; }

        [NotMapped]
        public ICollection<SoldInsurance> SoldInsurances { get; set; }
    }
}
