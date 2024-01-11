namespace Application.DTOs.Enums
{/// <summary>
 /// Define the Type of Credit .
 /// </summary>
    public enum CreditType
    {
        /// <summary>
        /// Direct. 2% tax
        /// </summary>
        Direct = 0,

        /// <summary>
        /// Consigned. 1% tax
        /// </summary>
        PayRoll = 1,

        /// <summary>
        /// Legal Person. 5% tax
        /// </summary>
        Business = 2,

        /// <summary>
        /// Natural Person. 3% tax
        /// </summary>
        Personal = 3,

        /// <summary>
        /// Real Estate. 9% tax
        /// </summary>
        RealEstate = 4,
    }
}
