using Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Phone
    {
        public int id { get; set; }
        public long number { get; set; }
        public string cpfCustomer { get; set; }

        [ForeignKey("cpfCustomer")]
        public virtual Customer Customer { get; set; }
    }
}
