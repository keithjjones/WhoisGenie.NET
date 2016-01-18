using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WhoisGenie.NET;
using System.Net;

namespace WhoisGenie.NET.Tests
{
    [TestClass]
    public class RecursiveWhoisTest
    {
        [TestMethod]
        public void WhoisClientIPTest()
        {
            RecursiveWhois response = WhoisGenie.GetRecursiveWhois("4.4.4.4");
            Assert.AreEqual("Level 3 Communications, Inc. LVLT-STATIC-4-4-16 (NET-4-4-0-0-1)", response.OrganizationName);
            Assert.AreEqual("4.4.0.0-4.4.255.255", response.AddressRange.ToString());
        }

        [TestMethod]
        public void WhoisClientIP2Test()
        {
            RecursiveWhois response = WhoisGenie.GetRecursiveWhois("65.100.170.169");
            Assert.AreEqual("Qwest Communications Company, LLC QWEST-INET-115 (NET-65-100-0-0-1)", response.OrganizationName);
            Assert.AreEqual("65.100.0.0-65.103.255.255", response.AddressRange.ToString());
        }

        [TestMethod]
        public void WhoisClientIP3Test()
        {
            RecursiveWhois response = WhoisGenie.GetRecursiveWhois("108.234.177.20");
            Assert.AreEqual("AT&T Internet Services", response.OrganizationName);
            Assert.AreEqual("108.192.0.0-108.255.255.255", response.AddressRange.ToString());
        }

        [TestMethod]
        public void WhoisClientIP4Test()
        {
            RecursiveWhois response = WhoisGenie.GetRecursiveWhois("190.190.132.64");
            Assert.AreEqual("Prima S.A.", response.OrganizationName);
            Assert.AreEqual("190.0.0.0-190.1.255.255", response.AddressRange.ToString());
        }

        [TestMethod]
        public void WhoisClientIP5Test()
        {
            RecursiveWhois response = WhoisGenie.GetRecursiveWhois("31.116.94.96");
            Assert.AreEqual("EE Limited", response.OrganizationName);
            Assert.AreEqual("31.64.0.0-31.127.255.255", response.AddressRange.ToString());
        }

        [TestMethod]
        public void WhoisClientDomainTest()
        {
            RecursiveWhois response = WhoisGenie.GetRecursiveWhois("facebook.com");
            Assert.AreEqual("Facebook, Inc.", response.OrganizationName);
            Assert.IsNull(response.AddressRange);
        }
    }

    [TestClass]
    public class ARINWhoisTest
    {
        [TestMethod]
        public void ARINWhoisIpFound()
        {
            ARINWhois ipResponse = WhoisGenie.GetARINWhois(IPAddress.Parse("69.63.176.0"));

            Assert.IsNotNull(ipResponse);
            Assert.IsNotNull(ipResponse.Network);

            Assert.IsTrue(ipResponse.Network.TermsOfUse.StartsWith("http"));
            Assert.IsNotNull(ipResponse.Network.RegistrationDate.Value);
            Assert.IsNotNull(ipResponse.Network.NetBlocks[0]);
            Assert.IsNotNull(ipResponse.Network.NetBlocks[0].CidrLength.Value);
            Assert.IsNotNull(ipResponse.Network.NetBlocks[0].Description);

            Assert.IsNotNull(ipResponse.Network.OrgRef.Name);
            Assert.AreEqual("Facebook, Inc.", ipResponse.Network.OrgRef.Name);

            Assert.AreEqual("UNITED STATES", ipResponse.Organization.iso3166_1.Name.Value);
            Assert.AreEqual("Menlo Park", ipResponse.Organization.City.Value);
            Assert.AreEqual("CA", ipResponse.Organization.iso3166_2.Value);
            Assert.AreEqual("94025", ipResponse.Organization.PostalCode.Value);
        }

        [TestMethod]
        public void ARINWhoisIp2Found()
        {
            ARINWhois ipResponse = WhoisGenie.GetARINWhois(IPAddress.Parse("98.155.64.40"));

            Assert.IsNotNull(ipResponse);
            Assert.IsNotNull(ipResponse.Network);

            Assert.IsTrue(ipResponse.Network.TermsOfUse.StartsWith("http"));
            Assert.IsNotNull(ipResponse.Network.RegistrationDate.Value);
            Assert.IsNotNull(ipResponse.Network.NetBlocks[0]);
            Assert.IsNotNull(ipResponse.Network.NetBlocks[0].CidrLength.Value);
            Assert.IsNotNull(ipResponse.Network.NetBlocks[0].Description);

            Assert.IsNotNull(ipResponse.Network.OrgRef.Name);
            Assert.AreEqual("Time Warner Cable Internet LLC", ipResponse.Network.OrgRef.Name);

            Assert.AreEqual("UNITED STATES", ipResponse.Organization.iso3166_1.Name.Value);
            Assert.AreEqual("Herndon", ipResponse.Organization.City.Value);
            Assert.AreEqual("VA", ipResponse.Organization.iso3166_2.Value);
            Assert.AreEqual("20171", ipResponse.Organization.PostalCode.Value);
        }

        [TestMethod]
        public void ARINWhoisIp3Found()
        {
            ARINWhois ipResponse = WhoisGenie.GetARINWhois(IPAddress.Parse("96.21.63.199"));

            Assert.IsNotNull(ipResponse);
            Assert.IsNotNull(ipResponse.Network);

            Assert.IsTrue(ipResponse.Network.TermsOfUse.StartsWith("http"));
            Assert.IsNotNull(ipResponse.Network.RegistrationDate.Value);
            Assert.IsNotNull(ipResponse.Network.NetBlocks[0]);
            Assert.IsNotNull(ipResponse.Network.NetBlocks[0].CidrLength.Value);
            Assert.IsNotNull(ipResponse.Network.NetBlocks[0].Description);

            Assert.IsNull(ipResponse.Network.OrgRef);

            Assert.IsNotNull(ipResponse.Network.CustomerRef);

            Assert.IsNotNull(ipResponse.Network.CustomerRef.Name);
            Assert.AreEqual("Videotron Ltee", ipResponse.Network.CustomerRef.Name);

            Assert.AreEqual("CANADA", ipResponse.Customer.iso3166_1.Name.Value);
            Assert.AreEqual("Montreal", ipResponse.Customer.City.Value);
            Assert.AreEqual("QC", ipResponse.Customer.iso3166_2.Value);
            Assert.AreEqual("H2X 3W4", ipResponse.Customer.PostalCode.Value);
        }

        [TestMethod]
        public void ARINWhoisIp4Found()
        {
            ARINWhois ipResponse = WhoisGenie.GetARINWhois(IPAddress.Parse("98.176.133.1"));

            Assert.IsNotNull(ipResponse);
            Assert.IsNotNull(ipResponse.Network);

            Assert.IsTrue(ipResponse.Network.TermsOfUse.StartsWith("http"));
            Assert.IsNotNull(ipResponse.Network.RegistrationDate.Value);
            Assert.IsNotNull(ipResponse.Network.NetBlocks[0]);
            Assert.IsNotNull(ipResponse.Network.NetBlocks[0].CidrLength.Value);
            Assert.IsNotNull(ipResponse.Network.NetBlocks[0].Description);

            Assert.IsNull(ipResponse.Network.OrgRef);

            Assert.IsNotNull(ipResponse.Network.CustomerRef);

            Assert.IsNotNull(ipResponse.Network.CustomerRef.Name);
            Assert.AreEqual("Cox Communications", ipResponse.Network.CustomerRef.Name);

            Assert.AreEqual("UNITED STATES", ipResponse.Customer.iso3166_1.Name.Value);
            Assert.AreEqual("Atlanta", ipResponse.Customer.City.Value);
            Assert.AreEqual("GA", ipResponse.Customer.iso3166_2.Value);
            Assert.AreEqual("30319", ipResponse.Customer.PostalCode.Value);
        }

        [TestMethod]
        public void ARINWhoisIp5Found()
        {
            ARINWhois ipResponse = WhoisGenie.GetARINWhois(IPAddress.Parse("108.234.177.20"));

            Assert.IsNotNull(ipResponse);
            Assert.IsNotNull(ipResponse.Network);

            Assert.IsTrue(ipResponse.Network.TermsOfUse.StartsWith("http"));
            Assert.IsNotNull(ipResponse.Network.RegistrationDate.Value);
            Assert.IsNotNull(ipResponse.Network.NetBlocks[0]);
            Assert.IsNotNull(ipResponse.Network.NetBlocks[0].CidrLength.Value);
            Assert.IsNotNull(ipResponse.Network.NetBlocks[0].Description);

            Assert.IsNotNull(ipResponse.Network.OrgRef);

            Assert.IsNotNull(ipResponse.Network.OrgRef.Name);
            Assert.AreEqual("AT&T Internet Services", ipResponse.Network.OrgRef.Name);

            Assert.AreEqual("UNITED STATES", ipResponse.Organization.iso3166_1.Name.Value);
            Assert.AreEqual("Richardson", ipResponse.Organization.City.Value);
            Assert.AreEqual("TX", ipResponse.Organization.iso3166_2.Value);
            Assert.AreEqual("75082", ipResponse.Organization.PostalCode.Value);
        }

        [TestMethod]
        public void ARINWhoisIp6Found()
        {
            ARINWhois ipResponse = WhoisGenie.GetARINWhois(IPAddress.Parse("174.65.101.118"));

            Assert.IsNotNull(ipResponse);
            Assert.IsNotNull(ipResponse.Network);

            Assert.IsTrue(ipResponse.Network.TermsOfUse.StartsWith("http"));
            Assert.IsNotNull(ipResponse.Network.RegistrationDate.Value);
            Assert.IsNotNull(ipResponse.Network.NetBlocks[0]);
            Assert.IsNotNull(ipResponse.Network.NetBlocks[0].CidrLength.Value);
            Assert.IsNotNull(ipResponse.Network.NetBlocks[0].Description);

            Assert.IsNull(ipResponse.Network.OrgRef);

            Assert.IsNotNull(ipResponse.Network.CustomerRef);

            Assert.IsNotNull(ipResponse.Network.CustomerRef.Name);
            Assert.AreEqual("Cox Communications", ipResponse.Network.CustomerRef.Name);

            Assert.AreEqual("UNITED STATES", ipResponse.Customer.iso3166_1.Name.Value);
            Assert.AreEqual("Atlanta", ipResponse.Customer.City.Value);
            Assert.AreEqual("GA", ipResponse.Customer.iso3166_2.Value);
            Assert.AreEqual("30319", ipResponse.Customer.PostalCode.Value);
        }

    }
}
