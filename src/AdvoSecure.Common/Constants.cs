namespace AdvoSecure.Common
{
    public static class Constants
    {
        public static readonly string IssuerFormat = "https://sts.windows.net/{0}/";
        public static readonly string AuthEndpointPrefix = "https://login.microsoftonline.com/organizations/";
        public const int DefaultPageSize = 100;
        public const int MaxPageSize = 1000;
    }
}
