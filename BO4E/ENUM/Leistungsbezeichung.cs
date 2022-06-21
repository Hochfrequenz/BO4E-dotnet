namespace BO4E.ENUM
{
    /// <summary> </summary>
    public enum Leistungsbezeichung
    {
        /// <summary>Z15 POG bei verbrauchender Marktlokation > 100.000 kWh/a mit iMS</summary>
        POG_VERBRAUCH_IMS_UEBER_100K,
        /// <summary>Z16 POG bei verbrauchender Marktlokation [50.000 kWh/a; 100.000 kWh/a] mit iMS</summary>
        POG_VERBRAUCH_IMS_50K_BIS_100K,
        /// <summary>Z17 POG bei verbrauchender Marktlokation [20.000kWh/a; 50.000 kWh/a] mit iMS</summary>
        POG_VERBRAUCH_IMS_20K_BIS_50K,
        /// <summary>Z18 POG bei verbrauchender Marktlokation [10.000 kWh/a; 20.000 kWh/a] mit iMS</summary>
        POG_VERBRAUCH_IMS_10K_BIS_20K,
        /// <summary>Z19 POG bei verbrauchender Marktlokation mit unterbrechbaren Verbrauchseinrichtung nach § 14a EnWG mit iMS</summary>
        POG_VERBRAUCH_IMS_UNTERBRECHBAR,
        /// <summary>Z20 POG bei verbrauchender Marktlokation [6.000kWh/a; 10.000 kWh/a] mit iMS</summary>
        POG_VERBRAUCH_IMS_6K_BIS_10K,
        /// <summary>Z21 POG bei erzeugender Marktlokation [7 kW; 15kW] mit iMS</summary>
        POG_ERZEUGUNG_IMS_7_BIS_15,
        /// <summary>Z22 POG bei erzeugender Marktlokation [15 kW; 30kW] mit iMS</summary>
        POG_ERZEUGUNG_IMS_15_BIS_30,
        /// <summary>Z23 POG bei erzeugender Marktlokation [30 kW;100 kW] mit iMS</summary>
        POG_ERZEUGUNG_IMS_30_BIS_100,
        /// <summary>Z24 POG bei erzeugender Marktlokation > 100 kW mit iMS</summary>
        POG_ERZEUGUNG_IMS_UEBER_100,
        /// <summary>Z25 POG bei Marktlokation mit mME</summary>
        POG_MME,
        /// <summary>Z28 POG bei verbrauchender Marktlokation [4.000 kWh/a; 6.000 kWh/a] mit iMS</summary>
        POG_VERBRAUCH_IMS_4K_BIS_6K,
        /// <summary>Z29 POG bei verbrauchender Marktlokation [3.000kWh/a; 4.000 kWh/a] mit iMS</summary>
        POG_VERBRAUCH_IMS_3K_BIS_4K,
        /// <summary>Z30 POG bei verbrauchender Marktlokation [2.000kWh/a; 3.000 kWh/a] mit iMS</summary>
        POG_VERBRAUCH_IMS_2K_BIS_3K,
        /// <summary>Z31 POG bei verbrauchender Marktlokation [0 kWh/a;2.000 kWh/a] mit iMS</summary>
        POG_VERBRAUCH_IMS_0_BIS_2K,
        /// <summary>Z32 POG bei optionaler Ausstattung mit iMS von Neuanlagen von erzeugender Marktlokation</summary>
        POG_ERZEUGUNG_IMS_OPTIONAL,
        /// <summary>Z41 Zusatzleistung</summary>
        ZUSATZLEISTUNG,
    }
}