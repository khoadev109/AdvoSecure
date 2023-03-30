namespace AdvoSecure.Common.Configuration
{
    public class AzureAdOptions
    {
        public AzureAdOptions()
        {
            Asymmetric = new AsymmetricEncryptionOptions();
        }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string PostLogoutRedirectUri { get; set; }
        public string WebApiResourceId { get; set; }

        public AsymmetricEncryptionOptions Asymmetric { get; set; }

    }
}
