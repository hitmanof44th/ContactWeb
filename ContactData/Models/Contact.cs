using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactData.Models
{
    public class Contact
    {
        public int Id { get; set; } = 0;
        public string FirstName { get; set; } = "n/a";
        public string LastName { get; set; } = "n/a";
        public string Email { get; set; } = "n/a";
        public Address Address { get; set; }
        public int AddressId { get; set; } = 0;

    }
}
