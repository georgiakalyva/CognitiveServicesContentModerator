using System;
using Microsoft.Azure.CognitiveServices.ContentModerator;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace ContentModerator
{
    class Program
    {
        /// <summary>
        /// This sample is the code presented in this tutorial by CodeStories.gr
        /// For more tutorials and news find me:
        /// Blog: http://www.codestories.gr
        /// Facebook: https://www.facebook.com/codestoriesgr/
        /// Twitter: https://twitter.com/GeorgiaKalyva
        /// LinkedIn: https://www.linkedin.com/in/georgiakalyva
        /// </summary>
        static void Main(string[] args)
        {
            // Load the input text.
            string text = "Damn it. Lzay dog is cute. Is this a grabage or crap email abcdef@test.com, phone: 6657789887, IP: 255.255.255.255, 1 Microsoft Way, Redmond, WA 98052. These are all UK phone numbers, the last two being Microsoft UK support numbers: +44 870 608 4000 or 0344 800 2400 or 0800 820 3300. Also, 999-99-9999 looks like a social security number (SSN).";

            Console.WriteLine("Screening {0}", text);

            text = text.Replace(System.Environment.NewLine, " ");
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(text);
            MemoryStream stream = new MemoryStream(byteArray);
            // Create a Content Moderator client and evaluate the text.
            using (var client = Clients.NewClient())
            {
                // Screen the input text: check for profanity,
                // autocorrect text, check for personally identifying
                // information (PII), and classify the text into three categories
                var screenResult =
                client.TextModeration.ScreenText("text/plain", stream, "eng", true, true, null, true);
                Console.WriteLine(
                        JsonConvert.SerializeObject(screenResult, Formatting.Indented));
            }
            Console.ReadLine();
        }

    }
}
