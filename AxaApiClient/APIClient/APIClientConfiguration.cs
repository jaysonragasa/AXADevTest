namespace AXADevTest.APIClient
{
    public enum DevelopmentEnvironment
    {
        LOCAL,
        PRODUCTION,
        TEST
    }

    public class APIClientConfiguration
    {
        const string BaseServer = "https://goodmorning-axa-dev.azure-api.net/";
        const DevelopmentEnvironment DevEnv = DevelopmentEnvironment.TEST;

        public static string ApiServer
        {
            get
            {
                var devEnv = DevEnv switch
                {
                    DevelopmentEnvironment.LOCAL        => "http://10.0.1.1/",
                    DevelopmentEnvironment.PRODUCTION   => "https://goodmorning-axa-dev.azure-api.net/",
                    DevelopmentEnvironment.TEST         => "https://goodmorning-axa-dev.azure-api.net/",
                    _ => BaseServer
                };

                return devEnv;
            }
        }

        public static string AxaApiKey => "yourapikey";
    }
}
