using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactData.Models
{
    public class Address
    {
        public int Id { get; set; } = 0;
        public string Street { get; set; } = "n/a";
        public string City { get; set; } = "n/a";
        public string State { get; set; } = "n/a";
        public string PostalCode { get; set; } = "n/a";
        public ICollection<Contact>? Contacts { get; set; }

    }
}
