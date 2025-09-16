namespace CleanTeeth.API.Utilities
{
    public static class HttpContextExtensions
    {
        public static void InsertPaginationInformationInHeader(this HttpContext httpContext, int totalAmountOfRecords)
        {
            httpContext.Response.Headers.Append("total-amount-of-records", totalAmountOfRecords.ToString());
        }
    }
}
