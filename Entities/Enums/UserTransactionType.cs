namespace Entities
{
    /// <summary>
    /// نوع واریزی کاربر
    /// </summary>
    public enum UserTransactionType
    {
        /// <summary>
        /// جهت خرید و فروش محصول
        /// </summary>
        ProductOrder = 1,

        /// <summary>
        /// شارژ کیف پول
        /// </summary>
        ChargeWallet = 2,

        /// <summary>
        /// پرداخت بدهی
        /// </summary>
        Solvency = 3
    }
}
