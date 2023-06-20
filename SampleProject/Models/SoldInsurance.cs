using System.ComponentModel.DataAnnotations.Schema;

namespace SampleProject.Models
{
    public class SoldInsurance
    {
        public int Id { get; set; }

        public int RequestId { get; set; }

        [ForeignKey("RequestId")]
        public virtual Requests Request{ get; set; }


        public int ServiceId { get; set; }

        [ForeignKey("ServiceId")]
        public virtual Services service { get; set; }

        public decimal Capital { get; set; }
        public decimal Cost { get; set; }

    }
}
