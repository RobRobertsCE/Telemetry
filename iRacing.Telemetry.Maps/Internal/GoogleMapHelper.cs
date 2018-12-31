using iRacing.Telemetry.Maps.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace iRacing.Telemetry.Maps.Internal
{
    internal static class GoogleMapHelper
    {
        /// <summary>
        /// Google account API key
        /// </summary>
        internal static string ApiKey { get; } = "AIzaSyDXQGes6eNVFioWly0s--o0T9mqfrVtaTw";

        /// <summary>
        /// Converts GoogleImageFormat enum value to parameter string
        /// </summary>
        /// <param name="format">The image format enum value.</param>
        /// <returns>Parameter string for the given format</returns>
        public static string GetGoogleFormatString(GoogleImageFormat format)
        {
            switch (format)
            {
                case (GoogleImageFormat.PNG):
                    {
                        return "png";
                    }
                case (GoogleImageFormat.PNG32):
                    {
                        return "png32";
                    }
                case (GoogleImageFormat.GIF):
                    {
                        return "gif";
                    }
                case (GoogleImageFormat.JPG):
                    {
                        return "jpg";
                    }
                case (GoogleImageFormat.JPGBaseline):
                    {
                        return "jpg-baseline";
                    }
                default:
                    {
                        return "jpg-baseline";
                    }
            }
        }

        /// <summary>
        /// Converts GoogleMapType enum value to parameter string
        /// </summary>
        /// <param name="mapType">The map type enum value.</param>
        /// <returns>Parameter string for the given map type</returns>
        public static string GetGoogleMapTypeString(GoogleMapType mapType)
        {
            switch (mapType)
            {
                case (GoogleMapType.RoadMap):
                    {
                        return "roadmap";
                    }
                case (GoogleMapType.Satellite):
                    {
                        return "satellite";
                    }
                case (GoogleMapType.Terrain):
                    {
                        return "terrain";
                    }
                case (GoogleMapType.Hybrid):
                    {
                        return "hybrid";
                    }
                default:
                    {
                        return "roadmap";
                    }
            }
        }

        /// <summary>
        /// Encodes the list of coordinates to a Google Maps encoded coordinate string.
        /// </summary>
        /// <param name="coordinates">The coordinates.</param>
        /// <returns>Encoded coordinate string</returns>
        public static string EncodeCoordinates(IList<Coordinate> coordinates)
        {
            int plat = 0;
            int plng = 0;
            StringBuilder encodedCoordinates = new StringBuilder();
            foreach (Coordinate coordinate in coordinates)
            {
                // Round to 5 decimal places and drop the decimal
                int late5 = (int)Math.Round((double)coordinate.Latitude * 1e5, MidpointRounding.AwayFromZero);
                int lnge5 = (int)Math.Round((double)coordinate.Longitude * 1e5, MidpointRounding.AwayFromZero);
                // Encode the differences between the coordinates
                encodedCoordinates.Append(EncodeSignedNumber(late5 - plat));
                encodedCoordinates.Append(EncodeSignedNumber(lnge5 - plng));
                // Store the current coordinates
                plat = late5;
                plng = lnge5;
            }
            return encodedCoordinates.ToString();
        }

        /// <summary>
        /// Encode a signed number in the encode format.
        /// </summary>
        /// <param name="num">The signed number</param>
        /// <returns>The encoded string</returns>
        private static string EncodeSignedNumber(int num)
        {
            int sgn_num = num << 1; //shift the binary value
            if (num < 0) //if negative invert
            {
                sgn_num = ~(sgn_num);
            }
            return (EncodeNumber(sgn_num));
        }

        /// <summary>
        /// Encode an unsigned number in the encode format.
        /// </summary>
        /// <param name="num">The unsigned number</param>
        /// <returns>The encoded string</returns>
        private static string EncodeNumber(int num)
        {
            StringBuilder encodeString = new StringBuilder();
            while (num >= 0x20)
            {
                encodeString.Append((char)((0x20 | (num & 0x1f)) + 63));
                num >>= 5;
            }
            encodeString.Append((char)(num + 63));
            // All backslashes needs to be replaced with double backslashes
            // before being used in a Javascript string.
            return encodeString.ToString().Replace(@"\", @"\\");
        }
    }
}
