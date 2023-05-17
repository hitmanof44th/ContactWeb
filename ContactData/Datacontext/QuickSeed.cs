using ContactData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactData.Datacontext
{
    internal class QuickSeed
    {

        public static Contact[] thecontacts = new Contact[] {
        new Contact { Id = 1, FirstName = "Jane", LastName = "Smith",Email="test1@test.com",AddressId = 1},
        new Contact { Id = 2, FirstName = "Kevin", LastName = "Layla",Email="test1@test.com",AddressId = 2 },

        };



        public static Address[] thecaddress = new Address[] {
        new Address { Id = 1,City="Lindnehurst",PostalCode ="11757",State="NY",Street = "410 Indiana Ave"},
        new Address { Id = 2,City="Selden",PostalCode ="11784",State="NY",Street = "10 College Rd"},


        };


    }
}
