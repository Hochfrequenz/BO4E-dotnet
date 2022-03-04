namespace BO4E.meta
{
    /// <summary>
    ///     The DataCategory is supposed to be used as an attribute on Business Object fields to specify what type of data they
    ///     contain.
    /// </summary>
    /// <seealso cref="DataCategoryAttribute" />
    public enum DataCategory
    {
        /// <summary>
        ///     address data (city, street, house number, postbox)
        /// </summary>
        ADDRESS,

        /// <summary>
        ///     device master data like device number or lokale Kennzeichnung
        /// </summary>
        DEVICE,

        /// <summary>
        ///     financial information like bank account numbers
        /// </summary>
        FINANCE,

        /// <summary>
        ///     legal and tax relevant information like handelsregisternummer
        /// </summary>
        LEGAL,

        /// <summary>
        ///     names of persons
        /// </summary>
        NAME,

        /// <summary>
        ///     metering values.
        /// </summary>
        METER_READING,

        /// <summary>
        ///     points of delivery (market Location, measuring location, tranche)
        /// </summary>
        POD,

        /// <summary>
        ///     the <see cref="BO.BusinessObject.UserProperties" /> might be handled separately with this DataCategory
        /// </summary>
        USER_PROPERTIES
    }
}