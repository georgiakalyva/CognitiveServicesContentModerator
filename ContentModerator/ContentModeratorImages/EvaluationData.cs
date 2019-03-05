using Microsoft.Azure.CognitiveServices.ContentModerator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContentModeratorImages
{
    public class EvaluationData
    {
        public string ImageUrl { get; set; }

        public Evaluate ImageModeration { get; set; }

        public OCR TextDetection { get; set; }

        public FoundFaces FaceDetection { get; set; }
    }
}
