using ContactData.Data;
using ContactData.Interfaces;
using ContactData.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactData.Services
{
    public class AddressService : IAdressValidator
    {
        private readonly IConfiguration _configuration;
        private static string apikey;
        private IAdressValidator ads;

        public AddressService(IConfiguration configuration)
        {
            _configuration = configuration;
            apikey = _configuration["AppSettings:ApiKey"];
            ads = new GoogleAddressValidator(apikey);
            Debug.WriteLine("apkeu" + apikey);
        }


        public bool AddressValidate(Contact contact)
        {
            return ads.AddressValidate(contact);
        }
    }
}
