using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhoisGenie.NET
{
    /// <summary>
    /// A class containing the response from a recursive whois lookup.
    /// </summary>
    public class RecursiveWhois : Whois.NET.WhoisResponse
    {
        // Forward this model to the user of this library.

        /// <summary>
        /// Copies the input structure into the current structure.
        /// </summary>
        /// <param name="whois">The input structure to copy.</param>
        public void Copy(Whois.NET.WhoisResponse whois)
        {
            AddressRange = whois.AddressRange;
            OrganizationName = whois.OrganizationName;
            RespondedServers = whois.RespondedServers;
            Raw = whois.Raw;
        }
    }
}
