using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Customer
    {
        public Customer()
        {
            phones = new List<Phone>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string cpf { get; set; }

        public string name { get; set; }

        public string email { get; set; }

        public string maritalStatus { get; set; }

        public string address { get; set; }

        public virtual ICollection<Phone> phones { get; set; }
    }
}

