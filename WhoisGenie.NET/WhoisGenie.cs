using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArinWhois;
using Whois;
using System.Net;

namespace WhoisGenie.NET
{
    public class WhoisGenie
    {
        static public ARINWhois GetARINWhois(IPAddress LookupIP)
        {
            // Setup variables
            ArinWhois.Client.ArinClient myArinClient;
            ARINWhois myARINResponse = new ARINWhois();

            myArinClient = new ArinWhois.Client.ArinClient();

            // Get IP Info
            try
            {
                // RESTFul Whois
                ArinWhois.Model.Response myResponse = new ArinWhois.Model.Response();
                myResponse = myArinClient.QueryIpAsync(LookupIP).Result;
                myARINResponse.Network = myResponse.Network;
            }
            catch
            {
                return myARINResponse;
            }

            // Get Organization Info
            if (myARINResponse.Network != null &&
                myARINResponse.Network.OrgRef != null &&
                myARINResponse.Network.OrgRef.Handle != null)
            {
                ArinWhois.Model.Response myWhoIsOrgResults = new ArinWhois.Model.Response();

                try
                {
                    myWhoIsOrgResults = myArinClient.QueryResourceAsync(myARINResponse.Network.OrgRef.Handle,
                        ArinWhois.Client.ArinClient.ResourceType.Organization).Result;
                    myARINResponse.Organization = myWhoIsOrgResults.Organization;
                }
                catch
                {
                }
            }

            // Get Customer Info
            if (myARINResponse.Network != null &&
                myARINResponse.Network.CustomerRef != null &&
                myARINResponse.Network.CustomerRef.Handle != null)
            {
                ArinWhois.Model.Response myWhoIsCustomerResults = new ArinWhois.Model.Response();

                try
                {
                    myWhoIsCustomerResults = myArinClient.QueryResourceAsync(myARINResponse.Network.CustomerRef.Handle,
                        ArinWhois.Client.ArinClient.ResourceType.Customer).Result;
                    myARINResponse.Customer = myWhoIsCustomerResults.Customer;
                }
                catch
                {
                }
            }

            return myARINResponse;
        }

        static public RecursiveWhois GetRecursiveWhois(string WhoisQuery)
        {
            RecursiveWhois returnwhois = new RecursiveWhois();
            Whois.NET.WhoisResponse whois;

            try
            {
                // Get Raw WhoIs information
                whois = Whois.NET.WhoisClient.Query(WhoisQuery);
            }
            catch
            {
                return returnwhois;
            }

            returnwhois.AddressRange = whois.AddressRange;
            returnwhois.OrganizationName = whois.OrganizationName;
            returnwhois.RespondedServers = whois.RespondedServers;
            returnwhois.Raw = whois.Raw;

            return returnwhois;
        }

    }
}
