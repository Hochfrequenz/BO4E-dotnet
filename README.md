# BO4E-dotnet
BO4E-dotnet is a C# implementation of **B**usiness **O**bjects for **E**nergy ([BO4E](https://www.bo4e.de/)), a standard use to model business objects in the German energy market. This repository contains class definitions and enumerations for most of the Business Objects. [JSON.net](https://github.com/JamesNK/Newtonsoft.Json) attributes are used to model obligatory and optional fields of the single business objects and components.

The source code in this repository is Open Source and avaiable under a MIT license; see [the license file](LICENSE).

## Nuget Packages and Usage of BO4E-dotnet
The content of this repository is used to build the following nuget packages:
- [Hochfrequenz.BO4Enet](https://www.nuget.org/packages/Hochfrequenz.BO4Enet) contains definitions of the business objects (namespace `BO4E.BO`), compontents (namespace `BO4E.COM`) and enumerations (namespace `BO4E.ENUM`). This package depends on JSON.net only.
- [Hochfrequenz.BO4E.Extensions](https://www.nuget.org/packages/Hochfrequenz.BO4E.Extensions/) contains extension methods for business objects and components (currently Energiemenge and COM Verbrauch, which are heavily used by Hochfrequenz cloud solutions).
- [Hochfrequenz.BO4E.Reporting](https://www.nuget.org/packages/Hochfrequenz.BO4E.Extensions/) contains tools to analyse single business objects and sets of objects.
- [Hochfrequenz.BO4E.Extensions.Encryption](https://www.nuget.org/packages/Hochfrequenz.BO4E.Extensions.Encryption/) provides code to encrypt and anonymize Business Objects and compontents using [libsodium](https://libsodium.org)/[`Sodium`](https://github.com/tabrath/libsodium-core/) and [Bouncy Castle](https://bouncycastle.org/csharp/)/`Org.BouncyCastle` APIs.


## Detailed Documentation
The docstrings from within the source code are used to automatically generate a [doc.fx based documentation](https://hfinnovation.github.io/bo4e-livedocs/api/BO4E.html). Please also consider the [official documentation](https://www.bo4e.de/dokumentation) maintained by Interessengemeinschaft Geschäftsobjekte Energiewirtschaft e.V. from which most of the source code docstrings are copied/derived.

## Getting Started / Basic Examples
1. install the nuget package [Hochfrequenz.BO4Enet](https://www.nuget.org/packages/Hochfrequenz.BO4Enet)
2. import it
```c#
using BO4E;
```
3. start developing applications based on Business Objects for Energy (BO4E) 

### Create BusinessObjects
```c#
using BO4E.BO;
using BO4E.ENUM;
// ...
var energiemenge = new Energiemenge()
{
    lokationsId = "DE0123456789012345678901234567890",
    lokationsTyp = LokationsTyp.MeLo,
    energieverbrauch = new List<Verbrauch>()
};
```
### Make use of built in validation methods
full source
```c#
using BO4E.BO;
using BO4E.ENUM;
// ...
var malo = new Marktlokation()
{
    marktlokationsId = "1235678901",
    sparte = Sparte.STROM,
    energierichtung = Energierichtung.AUSSP
};
Assert.IsFalse(malo.IsValid()); // because the obligatory bilanzierungsmethode is not set
malo.bilanzierungsmethode = Bilanzierungsmethode.SLP;
Assert.IsTrue(malo.IsValid(checkId:false)); // because all obligatory fields are set
Assert.IsFalse(malo.IsValid()); // but the marklokationsId is still wrong
malo.marktlokationsId = "51238696781"; // matches the appropriate regex and has the right check sum
Assert.IsTrue(malo.IsValid());
```

### Add custom fields via userProperties
```c#
using BO4E.BO;
using Newtonsoft.Json;
// ...
string meloJson = @"{'messlokationsId': 'DE0123456789012345678901234567890', 'sparte': 'STROM', 'myCustomInfo': 'some_value_not_covered_by_bo4e', 'myCustomValue': 123.456}";
var melo = JsonConvert.DeserializeObject<Messlokation>(meloJson);
Assert.IsTrue(melo.IsValid());
Assert.IsNotNull(melo.userProperties);
Assert.AreEqual("some_value_not_covered_by_bo4e", melo.userProperties["myCustomInfo"].ToObject<string>());
Assert.AreEqual(123.456M, melo.userProperties["myCustomValue"].ToObject<decimal>());
```

### Don't write your own logic for basic operations
```c#
using BO4E.COM;
using BO4E.ENUM;
// ...
var v1 = new Verbrauch()
{
    einheit = Mengeneinheit.KWH,
    obiskennzahl = "1-1:1.8.0",
    startdatum = new DateTime(2019, 1, 1, 0, 0, 0, DateTimeKind.Utc),
    enddatum = new DateTime(2020, 1, 1, 0, 0, 0, DateTimeKind.Utc)
};
var v2 = new Verbrauch()
{
    einheit = Mengeneinheit.KWH,
    obiskennzahl = "1-1:1.8.0",
    startdatum = new DateTime(2019, 1, 1, 0, 0, 0, DateTimeKind.Utc),
    enddatum = new DateTime(2020, 1, 1, 0, 0, 0, DateTimeKind.Utc)
};

Assert.AreEqual(v1, v2);
Assert.IsTrue(v1.Equals(v2));
Assert.AreEqual(v1.GetHashCode(), v2.GetHashCode());
Assert.IsFalse(v1 == v2);
```


## Contributing
Contributions are welcome. Feel free to open a Pull Request against the develop branch of this repository. Please provide unit tests if you contribute logic beyond bare bare business object definitions.

## Hochfrequenz
[Hochfrequenz Unternehmensberatung GmbH](https://www.hochfrequenz.de) is a Mannheim based consulting company with offices in Berlin and Bremen. Based on [Kununu ratings](https://www.kununu.com/de/hochfrequenz-unternehmensberatung1) Hochfrequenz is among the most attractive employers within the German energy market. Applications of talented developers are welcome at any time! Please consider visiting our [career page](https://www.hochfrequenz.de/index.php/karriere/aktuelle-stellenausschreibungen/full-stack-entwickler) (German only) and our [Stack Overflow profile](https://stackoverflow.com/jobs/companies/hochfrequenz-unternehmensberatung-gmbh) that also contains job openings.