using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.CognitiveServices.ContentModerator;
using Newtonsoft.Json;
using System.IO;
using System.Threading;

namespace ContentModeratorImages
{

    public static class Clients
    {
        // The region/location for your Content Moderator account
        private static readonly string AzureRegion = "westeurope";

        // The base URL fragment for Content Moderator calls.
        private static readonly string AzureBaseURL =
            $"https://{AzureRegion}.api.cognitive.microsoft.com";

        // Your Content Moderator subscription key.
        private static readonly string CMSubscriptionKey = "";

        // Returns a new Content Moderator client for your subscription.
        public static ContentModeratorClient NewClient()
        {
            // Create and initialize an instance of the Content Moderator API wrapper.
            ContentModeratorClient client = new ContentModeratorClient(new ApiKeyServiceClientCredentials(CMSubscriptionKey));

            client.Endpoint = AzureBaseURL;
            return client;
        }
    }
}
