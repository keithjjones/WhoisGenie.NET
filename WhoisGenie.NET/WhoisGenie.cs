﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArinWhois;
using Whois;
using System.Net;

namespace WhoisGenie.NET
{
    /// <summary>
    /// A class containing the operations for whois lookups.
    /// </summary>
    public class WhoisGenie
    {
        /// <summary>
        /// Uses the ARIN Whois facility to collect whois information into a structure.
        /// </summary>
        /// <param name="LookupIP">The IP address to be queried.</param>
        /// <returns>ARINWhois structure contains the results of the queries.</returns>
        static public ARINWhois GetARINWhois(IPAddress LookupIP)
        {
            // Setup variables
            ArinWhois.Client.ArinClient myArinClient;
            ARINWhois myARINResponse = new ARINWhois();

            // We will copy portions of this structure based upon
            // several lookups.
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

        /// <summary>
        /// Uses recursion to retrieve whois data for an IP address or domain.
        /// </summary>
        /// <param name="WhoisQuery">The domain or IP address to be queried.</param>
        /// <returns>The structure containing the whois lookup content.</returns>
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

            returnwhois.Copy(whois);

            return returnwhois;
        }

    }
}
