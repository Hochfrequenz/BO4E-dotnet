namespace BO4E.ENUM.EDI.UTILMD
{
    /// <summary>
    /// Zur Angabe eines Status. Dieses Segment wird benutzt um den Transaktionsgrund mitzuteilen.
    /// Der Transaktionsgrund beschreibt den Geschäftsvorfall zur Kategorie genauer. Dies dient der
    /// Plausibilisierung und Prozesssteuerung.Die Erläuterung zu den einzelnen Transaktionsgründen
    /// ist im DE9013 beschrieben
    /// </summary>
    public enum UTILMD9013
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

        /// <summary>Ein/Auszug (Umzug)</summary>
        /// Kunde verlässt oder bezieht eine schon bestehende Marktlokation
        E01,

        /// <summary>Einzug/Neuanlage</summary>
        /// Kunde bezieht erstmals eine Marktlokation (z.B. Neubau)
        E02,

        /// <summary>Wechsel</summary>
        /// <list type="bullet">
        /// <item>Kunde bleibt an der Marktlokation, hat nur den Marktpartner gewechselt</item>
        /// <item>Marktpartner hat den Kunden gekündigt</item>
        /// </list>
        E03,

        E05,
        E06,

        /// <summary>Ablehnung (Messproblem)</summary>
        /// Der Absender lehnt die Transaktion ab. Der Marktpartner fordert ein Messverfahren, was in diesem Fall nicht möglich ist bzw. nicht mit dem Leistungsumfang vereinbar ist.
        E11,

        /// <summary>Zustimmung ohne Korrekturen</summary>
        /// Der Absender stimmt der Meldung und den Inhalten des Vorgangs voll zu. Er hat keine Änderungen an den gesendeten Daten vorgenommen. Er kann allerdings Daten gem. seiner Aufgabe im Prozess vervollständigt haben (z.B. der NB bei einer Anmeldung mit dem Standardlastprofil). In diesen Fällen ist Z43 oder Z44 nicht zu verwenden
        E15,

        /// <summary>Ablehnung wg. Fristüberschreitung</summary>
        /// Der Absender lehnt die Transaktion ab. Eine einzuhaltende Frist ist überschritten worden. Bei der Übermittlung von bilanzierungsrelevanten Stammdatenänderungen wird auch eine Ablehnung erfolgen, wenn das Änderungsdatum kein Monatserster ist.
        E17,

        /// <summary>
        /// Zustimmung mit Terminänderung
        /// </summary>
        /// Der Absender stimmt der Meldung zu einem abweichenden Termin zu. Mit dieser Kennzeichnung übermittelt der Absender dem Sender der ursprünglichen Meldung, dass diese abgelehnt wurde (Ablehnung zum alten Termin), jedoch eine Zustimmung zu einem abweichenden Termin erfolgte.
        Z01,

        /// <summary>
        /// Ablehnung (Transaktionsgrund unplausibel)
        /// </summary>
        /// Der Absender lehnt die Transaktion ab. Transaktionsgrund und mitgelieferte Daten passen nicht zusammen.
        Z09,

        Z15,
        Z26,

        /// <summary>
        /// Ablehnung (kein Vertragsverhältnis mehr vorhanden)
        /// </summary>
        /// Der Absender lehnt die Transaktion ab. Der Kunde wurde zur betreffenden Marktlokation, Messlokation bzw. Tranche identifiziert, das Vertragsverhältnis wurde bereits zu einem früheren Zeitpunkt schon beendet.
        Z29,

        Z33,
        Z37,

        Z38,

        Z39,
        Z40,
        Z41,

        /// <summary>
        /// Zustimmung mit Korrektur von nicht bilanzierungsrel. Daten
        /// </summary>
        /// Die Zustimmung erfolgt mit Korrektur von nicht bilanzierungsrelevanten Daten in der Antwortnachricht. Die Bilanzierungsrelevanz leitet sich aus der Übersicht der Änderungsmeldungen ab.
        Z44,

        Z69,
        ZB2,
        ZB3,

        /// <summary>
        /// Erforderliche Versicherung fehlt
        /// </summary>
        ZB6,

        ZC6,
        ZC7,
        ZC8,
        ZG9,
        ZH0,
        ZH1,
        ZH2,
        ZD0,
        ZD9,
        ZE3,
        ZE4,
        ZE5,
        ZE6,
        ZE7,
        ZE8,
        ZE9,
        ZF0,
        ZF1,
        ZF2,
        ZF3,
        ZF4,
        ZF5,
        ZF6,
        ZF7,
        ZF8,
        ZG5,
        ZG6,
        ZG7,
        ZG8,
        ZI8,
        ZI9,
        ZJ0,
        ZJ1,

        /// <summary>
        /// Übernahme aufgrund nicht erfolgtem iMS-Einbau
        /// </summary>
        ZJ4
    }

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}