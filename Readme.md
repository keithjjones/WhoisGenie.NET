# Project Description
This is .NET Class library implementing multiple WHOIS clients.

# How to install

To install this library into your application, use the NuGet repository.

```
PM> Install-Package WhoisGenie.NET
```

# Sample source code (C#)
## Recursive Whois on IP Address

```csharp
using WhoisGenie.NET;
...
RecursiveWhois result = WhoisGenie.GetRecursiveWhois("192.41.192.40");

Console.WriteLine("{0} - {1}", result.AddressRange.Begin, result.AddressRange.End);
Console.WriteLine("{0}", result.OrganizationName); 
Console.WriteLine(string.Join(" > ", result.RespondedServers));
```

## Recursive Whois on Domain

```csharp
using WhoisGenie.NET;
...
RecursiveWhois result = WhoisGenie.GetRecursiveWhois("facebook.com");

Console.WriteLine("{0} - {1}", result.AddressRange.Begin, result.AddressRange.End); 
Console.WriteLine("{0}", result.OrganizationName); 
Console.WriteLine(string.Join(" > ", result.RespondedServers)); 
```

## ARIN Whois on IP

```csharp
using WhoisGenie.NET;
...
ARINWhois result = WhoisGenie.GetARINWhois(IPAddress.Parse("69.63.176.0"));
Console.WriteLine("{0}", result.Network.OrgRef.Name);
...
```

# Contributors

* [KeithJJones] (https://github.com/keithjjones) (Keith J. Jones)