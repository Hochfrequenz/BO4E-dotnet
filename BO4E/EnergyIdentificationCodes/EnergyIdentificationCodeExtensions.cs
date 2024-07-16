using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace BO4E.EnergyIdentificationCodes;

/// <summary>
/// Types of the EIC codes
/// </summary>
/// <remarks>See https://eepublicdownloads.entsoe.eu/clean-documents/EDI/Library/EIC_Short_Guide_and_FAQ_V3_Approved%20April%202016.pdf line 15</remarks>
public enum EicType
{
    /// <summary>
    /// object type “Y”, Areas for inter System Operator data interchange 
    /// </summary>
    [EnumMember(Value = "AREA")]
    AREA,

    /// <summary>
    /// object type “Z”, Energy Metering points
    /// </summary>

    [EnumMember(Value = "AREA")]
    MEASURING_POINT,

    /// <summary>
    /// object type "W", such as Production plants, consumption units, etc.
    /// </summary>
    [EnumMember(Value = "RESOURCE_OBJECT")]
    RESOURCE_OBJECT,

    /// <summary>
    /// object type "T", International tie lines between areas
    /// </summary>
    [EnumMember(Value = "TIE_LINES")]
    TIE_LINES,

    /// <summary>
    /// object type "V", Physical or logical place where a market participant or IT system is located
    /// </summary>
    [EnumMember(Value = "LOCATION")]
    LOCATION,

    /// <summary>
    /// object type "A"
    /// </summary>
    [EnumMember(Value = "SUBSTATION")]
    SUBSTATION,

    /// <summary>
    /// Parties - object type "X"
    /// </summary>
    [EnumMember(Value = "MARKET_PARTICIPANT")]
    MARKET_PARTICIPANT
}

/// <summary>
/// Extension class to validate strings that are thought to be Energy Identification Codes (EIC)
/// </summary>
public static class EnergyIdentificationCodeExtensions
{
    /// <summary>
    /// Energy Identification Code Regular Expression
    /// </summary>
    /// <remarks>https://regex101.com/r/LpyuKX/1</remarks>
    internal static readonly Regex EicRegex = new Regex("(?<vergabestelle>\\d{2})(?<typ>A|T|V|W|X|Y|Z)([-A-Z\\d]{12})(?<pruefziffer>[A-Z0-9])", RegexOptions.Compiled);

    /// <summary>
    /// Converts a object type string <paramref name="type"/> to a <see cref="EicType"/>
    /// </summary>
    /// <param name="type">character specifying the type. e.g. 'X' or 'A'</param>
    /// <returns></returns>
    public static EicType GetEICType(string type)
    {
        if (string.IsNullOrWhiteSpace(type))
        {
            throw new ArgumentNullException(nameof(type));
        }

        return type switch
        {
            "A" => EicType.SUBSTATION,
            "T" => EicType.TIE_LINES,
            "V" => EicType.LOCATION,
            "W" => EicType.RESOURCE_OBJECT,
            "X" => EicType.MARKET_PARTICIPANT,
            "Y" => EicType.AREA,
            "Z" => EicType.MEASURING_POINT,
            _ => throw new ArgumentException($"The type '{type}' is not a valid EIC type character.")
        };
    }

    /// <summary>
    /// returns true iff <paramref name="eicCandidate"/> obeys the "Bildungsvorschrift" according to https://bdew-codes.de/Content/Files/EIC/Awh_20171218_EIC-Vergabe_V1-0.pdf section 2.2.1
    /// </summary>
    /// <param name="eicCandidate"></param>
    /// <returns>true iff it obeys the "Allgemeine Bildungsvorschrift"</returns>
    public static bool IsValidEIC(this string eicCandidate)
    {
        if (string.IsNullOrWhiteSpace(eicCandidate))
        {
            return false;
        }

        if (!EicRegex.IsMatch(eicCandidate))
        {
            return false;
        }

        var actualCheckCharacter = eicCandidate.Last();
        var expectedCheckCharacter = GetEICCheckCharacter(eicCandidate[..15]);
        return actualCheckCharacter == expectedCheckCharacter;
    }

    /// <summary>
    /// returns true iff <paramref name="eicCandidate"/> adheres <see cref="IsValidEIC"/> and the "Vergabestelle" is 11=BDEW
    /// </summary>
    /// <param name="eicCandidate"></param>
    /// <returns>true iff BDEW is the "Vergeber"</returns>
    public static bool IsValidEICBDEW(this string eicCandidate)
    {
        if (!IsValidEIC(eicCandidate))
        {
            return false;
        }

        var match = EicRegex.Match(eicCandidate); // we know it's

        return match.Groups["vergabestelle"].Value == "11";
    }

    /// <summary>
    /// returns true iff the <paramref name="bilanzierungsGebietEic"/> is valid EIC by BDEW (<see cref="IsValidEICBDEW"/>) and does obey the rules for Bilanzierungsgebiete.
    /// </summary>
    /// <param name="bilanzierungsGebietEic"></param>
    /// <returns></returns>
    /// <remarks>See https://bdew-codes.de/Content/Files/EIC/Awh_20171218_EIC-Vergabe_V1-0.pdf section 2.2.2</remarks>
    public static bool IsValidBilanzierungsGebietId(this string bilanzierungsGebietEic)
    {
        if (!IsValidEICBDEW(bilanzierungsGebietEic))
        {
            return false;
        }

        var eicType = GetEICType(EicRegex.Match(bilanzierungsGebietEic).Groups["typ"].Value);
        return eicType == EicType.AREA && GermanControlAreas.ContainsKey(bilanzierungsGebietEic.Substring(3, 1));
    }

    /// <summary>
    /// returns true if <paramref name="eicCode"/> is a German Control Area / Regelzone
    /// </summary>
    /// <param name="eicCode"></param>
    /// <returns></returns>
    public static bool IsGermanControlArea(this string eicCode) => GermanControlAreas.Values.Contains(eicCode);

    private static readonly Dictionary<string, string> GermanControlAreas = new()
    {
        // they won't change in foreseeable time
        { "N", "10YDE-EON------1" }, // tennet
        { "R", "10YDE-RWENET---I" }, // amprion
        { "V", "10YDE-VE-------2" }, // 50Hz
        { "W", "10YDE-ENBW-----N" } // transnet BW
    };

    /// <summary>
    /// calculates the check character according to the EIC rules (ENTSO-E)
    /// </summary>
    /// <param name="eicWithoutChecksum"></param>
    /// <remarks>See https://eepublicdownloads.entsoe.eu/clean-documents/EDI/Library/cim_based/02%20EIC%20Code%20implementation%20guide_final.pdf line 461 (section 7.1)</remarks>
    /// <returns></returns>
    private static char GetEICCheckCharacter(string eicWithoutChecksum)
    {
        if (string.IsNullOrWhiteSpace(eicWithoutChecksum))
        {
            throw new ArgumentNullException(nameof(eicWithoutChecksum));
        }

        if (eicWithoutChecksum.Length != 15)
        {
            throw new ArgumentException($"The {nameof(eicWithoutChecksum)} has to be exactly 15 characters long.", nameof(eicWithoutChecksum));
        }

        List<int> numericValues;
        {
            // step 2
            numericValues = eicWithoutChecksum.ToCharArray().Select(CharacterToNumberEic).ToList();
        }
        {
            // steps 3&4
            var i = 0;
            foreach (var numericValue in numericValues.Select(x => x).ToList()) // iterate over copy of list
            {
                var positionWeight = 16 - i;
                numericValues[i] = numericValue * positionWeight;
                i++;
            }
        }
        var sum = numericValues.Sum(); // step 5
        char checkCharacter;
        {
            // step 6
            var checkNumber = 36 - (sum - 1) % 37;
            if (checkNumber < 10)
            {
                checkCharacter = checkNumber.ToString().ToCharArray()[0];
            }
            else
            {
                checkCharacter = NumberToEicCharacter(checkNumber);
                if (checkCharacter == '-')
                {
                    throw new ArgumentException(
                        $"The check character must not be {checkCharacter}. Please choose other 15 characters to start with than '{eicWithoutChecksum}'");
                    // https://eepublicdownloads.entsoe.eu/clean-documents/EDI/Library/cim_based/02%20EIC%20Code%20implementation%20guide_final.pdf line 509
                }
            }
        }
        return checkCharacter;
    }

    /// <summary>
    /// converts the character <paramref name="character"/> to a number according to the ENTSO-E/EIC algorithm
    /// </summary>
    /// <param name="character"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException">if the character is not A-Z or "-"</exception>
    private static int CharacterToNumberEic(char character)
    {
        if (character == '-')
        {
            return 36;
        }

        return character switch
        {
            '0' => 0,
            '1' => 1,
            '2' => 2,
            '3' => 3,
            '4' => 4,
            '5' => 5,
            '6' => 6,
            '7' => 7,
            '8' => 8,
            '9' => 9,
            _ => character - 55 // in ASCII 65=A but in ENTSO 10=A
        };
    }

    /// <summary>
    /// converts the number <paramref name="number"/> to a character accordint to the ENTSO-E/EIC algorithm,
    /// </summary>
    /// <remarks>basically reverts <see cref="CharacterToNumberEic"/></remarks>
    /// <param name="number"></param>
    /// <returns></returns>
    private static char NumberToEicCharacter(int number)
    {
        return number switch
        {
            < 10 or > 36 => throw new ArgumentOutOfRangeException(nameof(number), "Only the range [10,36] is supported."),
            36 => '-',
            _ => (char)(number + 55)
        };
    }
}
