using Microsoft.Azure.CognitiveServices.ContentModerator;
using Microsoft.Azure.CognitiveServices.ContentModerator.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace ContentModeratorImages
{
    /// <summary>
    /// This sample is the code presented in this tutorial by CodeStories.gr
    /// For more tutorials and news find me:
    /// Blog: http://www.codestories.gr
    /// Facebook: https://www.facebook.com/codestoriesgr/
    /// Twitter: https://twitter.com/GeorgiaKalyva
    /// LinkedIn: https://www.linkedin.com/in/georgiakalyva
    /// </summary>
    class Program
    {
        public static string SampleImage1 = "http://codestories.gr/wp-content/uploads/2019/03/sample1.jpeg";
        public static string SampleImage2 = "http://codestories.gr/wp-content/uploads/2019/03/sample2.jpg";

        static void Main(string[] args)
        {

            List<EvaluationData> evaluationData = new List<EvaluationData>();

            // Create an instance of the Content Moderator API wrapper.
            using (var client = Clients.NewClient())
            {
                
                EvaluationData imageData = EvaluateImage(client, SampleImage1);
                evaluationData.Add(imageData);
                imageData = EvaluateImage(client, SampleImage2);
                evaluationData.Add(imageData);

            }
            Console.WriteLine(JsonConvert.SerializeObject(
                               evaluationData, Formatting.Indented));
            Console.ReadLine();

        }
        private static EvaluationData EvaluateImage(ContentModeratorClient client, string imageUrl)
        {
            var url = new BodyModel("URL", imageUrl.Trim());

            var imageData = new EvaluationData();

            imageData.ImageUrl = url.Value;
            
            imageData.ImageModeration =
                client.ImageModeration.EvaluateUrlInput("application/json", url, true);
            Thread.Sleep(1000);
            
            imageData.TextDetection =
                client.ImageModeration.OCRUrlInput("eng", "application/json", url, true);
            Thread.Sleep(1000);
            
            imageData.FaceDetection =
                client.ImageModeration.FindFacesUrlInput("application/json", url, true);
            Thread.Sleep(1000);

            return imageData;
        }
    }
}
