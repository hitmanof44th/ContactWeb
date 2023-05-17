using ContactData.Interfaces;
using ContactData.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ContactData.Data
{
    public class GoogleAddressValidator : IAdressValidator
    {

        private static string _apiKey;

        public GoogleAddressValidator(string apikey)
        {
            _apiKey = apikey;
        }


        public static bool ValidateAddress(string address)
        {

            try
            {
                string encodedAddress = HttpUtility.UrlEncode(address);
                string apiUrl = $"https://maps.googleapis.com/maps/api/geocode/json?address={encodedAddress}&key=" + _apiKey;
                using (var client = new WebClient())
                {
                    try
                    {
                        string response = client.DownloadString(apiUrl);
                        JObject jsonObject = JObject.Parse(response);
                        JToken status = jsonObject.GetValue("status");
                        if (status.ToString() == "OK")
                        {
                            JToken results = jsonObject.GetValue("results");
                            return results.HasValues;
                        }
                        else
                        {

                            string errorMessage = jsonObject.GetValue("error_message").ToString();
                            Console.WriteLine($"failed: {errorMessage}");
                            return false;
                        }
                    }
                    catch (WebException ex)
                    {
                        Console.WriteLine($"failed: {ex.Message}");
                        return false;
                    }
                }
            }
            catch
            {
                return false;
            }
        }


        public bool AddressValidate(Contact contact)
        {
            try
            {
                return ValidateAddress(contact.Address.Street + " " + contact.Address.City + " " + contact.Address.State + " " + contact.Address.PostalCode);
            }
            catch
            {

                return false;
            }
        }
    }
}
