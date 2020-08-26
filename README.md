# BO4E-dotnet
BO4E-dotnet is a C# implementation of **B**usiness **O**bjects for **E**nergy ([BO4E](https://www.bo4e.de/)), a standard used to model business objects in the German energy market. This repository contains class definitions and enumerations for most of the Business Objects, however as of today it's not complete yet and pull requests are very welcome. [JSON.net](https://github.com/JamesNK/Newtonsoft.Json) attributes are used to model obligatory and optional fields of the single business objects and components.

The source code in this repository is Open Source and available under a MIT license; see [the license file](LICENSE).

## Nuget Packages and Usage of BO4E-dotnet
The content of this repository is used to build the following nuget packages:
- [Hochfrequenz.BO4Enet](https://www.nuget.org/packages/Hochfrequenz.BO4Enet) contains definitions of the business objects (namespace `BO4E.BO`), compontents (namespace `BO4E.COM`) and enumerations (namespace `BO4E.ENUM`).
- [Hochfrequenz.BO4E.Extensions](https://www.nuget.org/packages/Hochfrequenz.BO4E.Extensions/) contains extension methods for business objects and components (as of now mostly `BO.Energiemenge` and `COM.Verbrauch`, which are heavily used by Hochfrequenz cloud solutions).
- [Hochfrequenz.BO4E.Reporting](https://www.nuget.org/packages/Hochfrequenz.BO4E.Extensions/) contains tools to analyse single business objects and sets of objects.
- [Hochfrequenz.BO4E.Extensions.Encryption](https://www.nuget.org/packages/Hochfrequenz.BO4E.Extensions.Encryption/) provides code to encrypt and anonymize Business Objects and compontents using [libsodium](https://libsodium.org)/[`Sodium`](https://github.com/tabrath/libsodium-core/) and [Bouncy Castle](https://bouncycastle.org/csharp/)/`Org.BouncyCastle` APIs.

## This Repository Is Not Complete Yet
Please see [Issue #29](https://github.com/Hochfrequenz/BO4E-dotnet/issues/29) for a list of Business Objects, that are not yet implemented. Your contributions are very welcome. 

## Detailed Documentation
The docstrings from within the source code are used to automatically generate a [doc.fx based documentation](https://hochfrequenz.github.io/bo4e-livedocs/api/BO4E.BO.html). Please also consider the [official documentation](https://www.bo4e.de/dokumentation) maintained by Interessengemeinschaft Geschäftsobjekte Energiewirtschaft e.V. from which most of the source code docstrings are copied/derived.

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
    LokationsId = "DE0123456789012345678901234567890",
    LokationsTyp = LokationsTyp.MeLo,
    Energieverbrauch = new List<Verbrauch>()
};
```
### Make Use of Built in Validation Methods for German Location IDs
```c#
using BO4E.BO;
using BO4E.ENUM;
// ...
var malo = new Marktlokation()
{
    MarktlokationsId = "1235678901",
    Sparte = Sparte.STROM,
    Energierichtung = Energierichtung.AUSSP
};
Assert.IsFalse(malo.IsValid()); // because the obligatory bilanzierungsmethode is not set
malo.bilanzierungsmethode = Bilanzierungsmethode.SLP;
Assert.IsTrue(malo.IsValid(checkId:false)); // because all obligatory fields are set
Assert.IsFalse(malo.IsValid()); // but the marklokationsId is still wrong
malo.MarktlokationsId = "51238696781"; // matches the appropriate regex and has the right check sum
Assert.IsTrue(malo.IsValid());
```

### Add Custom Fields on the Fly via UserProperties
```c#
using BO4E.BO;
using Newtonsoft.Json;
// ...
string meloJson = @"{'messlokationsId': 'DE0123456789012345678901234567890', 'sparte': 'STROM', 'myCustomInfo': 'some_value_not_covered_by_bo4e', 'myCustomValue': 123.456}";
var melo = JsonConvert.DeserializeObject<Messlokation>(meloJson);
Assert.IsTrue(melo.IsValid());
Assert.IsNotNull(melo.UserProperties);
Assert.AreEqual("some_value_not_covered_by_bo4e", melo.UserProperties["myCustomInfo"].ToObject<string>());
Assert.AreEqual(123.456M, melo.UserProperties["myCustomValue"].ToObject<decimal>());
```

### Don't Write Your Own Logic for Basic Operations
```c#
using BO4E.COM;
using BO4E.ENUM;
// ...
var v1 = new Verbrauch()
{
    Einheit = Mengeneinheit.KWH,
    Obiskennzahl = "1-1:1.8.0",
    Startdatum = new DateTime(2019, 1, 1, 0, 0, 0, DateTimeKind.Utc),
    Enddatum = new DateTime(2020, 1, 1, 0, 0, 0, DateTimeKind.Utc)
};
var v2 = new Verbrauch()
{
    Einheit = Mengeneinheit.KWH,
    Obiskennzahl = "1-1:1.8.0",
    Startdatum = new DateTime(2019, 1, 1, 0, 0, 0, DateTimeKind.Utc),
    Enddatum = new DateTime(2020, 1, 1, 0, 0, 0, DateTimeKind.Utc)
};

Assert.AreEqual(v1, v2);
Assert.IsTrue(v1.Equals(v2));
Assert.AreEqual(v1.GetHashCode(), v2.GetHashCode());
Assert.IsFalse(v1 == v2);
```

### Feature Rich Extension Packages
Using the [Hochfrequenz.BO4E.Extensions](https://www.nuget.org/packages/Hochfrequenz.BO4E.Extensions/) gives you access to powerful analysis methods for Business Objects. We present them directly as minimal working examples in executable show case tests.

* [Energiemenge](/TestBO4E-dotnet-Extensions/ShowCaseTests/EnergiemengeShowCaseTests.cs)
* [Verbrauch](/TestBO4E-dotnet-Extensions/ShowCaseTests/VerbrauchShowCaseTests.cs)
* [CompletenessReport](/TestBO4E-dotnet-Reporting/ShowCaseTests/CompletenessReportShowCaseTests.cs)
* [Encrypted Business Objects](/TestBO4E-dotnet-Encryption/ShowCaseTests/EncryptionShowCaseTests.cs)
* [(Partially) Anonymized Business Objects](/TestBO4E-dotnet-Encryption/ShowCaseTests/AnonymizerShowCaseTests.cs)

### Stable and Reliable Due to Good Test Coverage
(branch coverage as of 2020-04-09, not yet automated)
- ~54% in BO4E main project
- ~69% in the extensions package
- ~66% in the reporting package 

## Batteries Included
We try to make the usage of BO4E in general and this library in particular as smooth as possible. Therefore it not only includes bare C\# files but also some extra ressources that might be usefule to you.

### PlantUML files
The folder [puml-files](puml-files) contains autogenerated PlantUML definitions for Business Objects, COMponents and ENUMs that are currently implemented in this repository. You can use the files provided in this repository or generate them on your own using [PlantUmlClassDiagramGenerator](https://github.com/pierre3/PlantUmlClassDiagramGenerator) by Hirotada Kobayashi aka pierre3. Please find instructions on how to use the tool in their repository. Please especially note that [include.puml](puml-files/include.puml) includes _all_ definitions inside just one file.

### Easy Validation using Json.NET Schema (JSchema)
The folder [json-schema-files](json-schema-files) contains autogenerated JSON.net schemas for all Business Objects that are currently implemented in this repository. Using these schemas allows for easy, transparent and cross plattform validation of your Business Objects. (Find out more about [Json Schema](https://www.newtonsoft.com/jsonschema).)

### Protocol-Buffer Definitions
In the folder [BO4E-dotnet/protobuf-files](BO4E-dotnet/protobuf-files) you can find autogenerated `.proto` files for all implemented Business Objects (except for those with multiple inheritance like e.g. `BO.Marktteilnehmer` or those derived from `BO.Preisblatt` which still causes headache using [protobuf-net](https://github.com/protobuf-net/protobuf-net)). The proto files are embedded into the BO4E nuget package as content files. This allows you to reference them.

## Contributing
Contributions are welcome. Feel free to open a Pull Request against the develop branch of this repository. Please provide unit tests if you contribute logic beyond bare bare business object definitions. We do track our modification proposals to the official BO4E standard in a separate repository: [BO4E-modification-proposals](https://github.com/Hochfrequenz/bo4e-modification-proposals).

## Hochfrequenz
[Hochfrequenz Unternehmensberatung GmbH](https://www.hochfrequenz.de) is a Grünwald (near Munich) based consulting company with offices in Berlin and Bremen. According to [Kununu ratings](https://www.kununu.com/de/hochfrequenz-unternehmensberatung1) Hochfrequenz is among the most attractive employers within the German energy market. Applications of talented developers are welcome at any time! Please consider visiting our [career page](https://www.hochfrequenz.de/index.php/karriere/aktuelle-stellenausschreibungen/full-stack-entwickler) (German only) and our [Stack Overflow profile](https://stackoverflow.com/jobs/companies/hochfrequenz-unternehmensberatung-gmbh) that also contains job openings.
