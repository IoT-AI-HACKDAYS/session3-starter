using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace controller.Model
{
  public class Prediction
    {
        private static readonly JsonSerializerOptions JsonOptions = new JsonSerializerOptions
        {
            AllowTrailingCommas = true
        };

        public static Prediction CreateFrom(string message)
        {
            return JsonSerializer.Deserialize<Prediction>(message, JsonOptions);
        }

        [JsonPropertyName("predictions")]
        public PredictionItem[] Predictions { get; set; }

    }

    public class PredictionItem
    {
        //"probability": 0.87712598,
        //       "tagName": "Target",
        //       "tagId": 0,
        //       "boundingBox": {
        //           "width": 0.1361767,
        //           "height": 0.12506402,
        //           "top": 0.85123866,
        //           "left": 0.83831487
        //       }

        [JsonPropertyName("probability")]
        public float Probability { get; set; }

        [JsonPropertyName("tagName")]
        public string TagName { get; set; }

        [JsonPropertyName("boundingBox")]
        public BoundingBox BoundingBox { get; set; }

       
    }

    public class BoundingBox
    {
        [JsonPropertyName("width")]
        public double Width { get; set; }

        [JsonPropertyName("height")]
        public double Height { get; set; }

        [JsonPropertyName("top")]
        public double Top { get; set; }


        [JsonPropertyName("left")]
        public double Left { get; set; }

        /// <summary>
        /// Return [Height , Width] center point of bounding box based on the image actual size
        /// </summary>
        /// <returns>[Height , Width]</returns>
        public Tuple<double, double> FindBoxCenter()
        {
            var x = Width / 2;
            var y = Height / 2;

            return new Tuple<double, double>((Top + y), (Left + x));
        }

    }


}
