/*
	Color API Lib
	By: Anthony McKeever (GitHub: Snip3rM00n - http://github.com/snip3rm00n)

	A library for retrieving data from The Color API.
	Original code from Color Detector (https://github.com/Snip3rM00n/ColorDetector)

	File: ColorfulJsonParser.cs
	Coded in: C# (Microsoft .Net 5.0 Framework)
	Namespace: ColorApiLib
	API Used: The Color API by Josh Beckman (http://thecolorapi.com).

	Purpose: Provides a static class of API Helpers for hitting the color API.

	TODO: Add support for hitting API with other color code types (CMYK, HSL, HSV).
*/

using System;
using System.Diagnostics;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace ColorApiLib
{
	public static class ApiHelpers
	{
		const string apiUrl = "http://www.thecolorapi.com/id?{0}";
		const string rgbUrlParams = "rgb=rgb({0},{1},{2})";

		#region RGB Api Helpers
  		
		public static async Task<object> getColorApiJson(int r, int g, int b)
		{
			string url = string.Format(apiUrl, rgbUrlParams);
			url = string.Format(url, r, g, b);

			try
			{
				HttpClient client = new HttpClient();
				System.IO.Stream s = await client.GetStreamAsync(url);

				DataContractJsonSerializer jSonSerializer = new DataContractJsonSerializer(typeof(ColorfulJsonParser));
				object jObject = jSonSerializer.ReadObject(s);

				return jObject;
			}
			catch (Exception e)
			{
				Debug.WriteLine(string.Format("Call to TheColorAPI (URL: {0}) failed: {1}", url, e.Message));
				return null;
			}
		}

		public static async Task<ColorfulRestProperty> getColorfulRestProperty(int r, int g, int b)
		{
			object json = await getColorApiJson(r, g, b);

			return new ColorfulRestProperty(json);
		}

		#endregion

		#region CMYK Api Helpers
		//TODO: Code CMYK Helpers
		#endregion

		#region HSL Api Helpers
		//TODO: Code HSL Helpers
		#endregion

		#region HSV Api Helpers
		//TODO: Code HSV Helpers
		#endregion
	}
}
