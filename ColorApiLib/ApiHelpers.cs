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
*/

using System;
using System.Diagnostics;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace ColorApiLib
{
	/// <summary>
	/// A collection of static API helpers for retreiving colors from various data points.
	/// </summary>
	public static class ApiHelpers
	{
		#region Instance Variables

		private const string apiUrl = "http://www.thecolorapi.com/id?{0}";
		private const string rgbUrlParams = "rgb=rgb({0},{1},{2})";
		private const string cmykUrlParams = "cmyk=cmyk({0},{1},{2},{3})";
		private const string hslUrlParams = "hsl=hsl({0},{1}{3},{2}{3})";
		private const string hexUrlParams = "hex={0}";

		#endregion

		#region RGB Api Helpers

		/// <summary>
		/// Gets the jSon Object for TheColorAPI data using ColorfulJsonParser.
		/// </summary>
		/// <param name="r">Value for Red</param>
		/// <param name="g">Value for Blue</param>
		/// <param name="b">Value for Green</param>
		/// <returns>(ColorfulJsonParser)object with data relating to RGB values provided</returns>
		public static async Task<object> getColorApiJson(int r, int g, int b)
		{
			string url = string.Format(apiUrl, rgbUrlParams);
			url = string.Format(url, r, g, b);

			return await hitApiWithUrl(url);
		}

		/// <summary>
		/// Gets the ColorfulRestProperty for a color.
		/// </summary>
		/// <param name="r">Value for Red</param>
		/// <param name="g">Value for Blue</param>
		/// <param name="b">Value for Green</param>
		/// <returns>ColorfulRestProperty with the data relating to provided RGB values</returns>
		public static async Task<ColorfulRestProperty> getColorfulRestProperty(int r, int g, int b)
		{
			object json = await getColorApiJson(r, g, b);
			return new ColorfulRestProperty(json);
		}

		#endregion

		#region CMYK Api Helpers

		/// <summary>
		/// Gets the jSon Object for TheColorAPI data using ColorfulJsonParser.
		/// </summary>
		/// <param name="c">Value for Cyan</param>
		/// <param name="m">Value for Magenta</param>
		/// <param name="y">Value for Yellow</param>
		/// <param name="k">Value for Key (black)</param>
		/// <returns>(ColorfulJsonParser)object with data relating to CMYK values provided</returns>
		public static async Task<object> getColorApiJson(int c, int m, int y, int k)
		{
			string url = string.Format(apiUrl, cmykUrlParams);
			url = string.Format(url, c, m, y, k);

			return await hitApiWithUrl(url);
		}

		/// <summary>
		/// Gets the ColorfulRestProperty for a color.
		/// </summary>
		/// <param name="c">Value for Cyan</param>
		/// <param name="m">Value for Magenta</param>
		/// <param name="y">Value for Yellow</param>
		/// <param name="k">Value for Key (black)</param>
		/// <returns>ColorfulRestProperty with the data relating to provided CMYK values</returns>
		public static async Task<ColorfulRestProperty> getColorfulRestProperty(int c, int m, int y, int k)
		{
			object json = await getColorApiJson(c, m, y, k);
			return new ColorfulRestProperty(json);
		}

		#endregion

		#region HSL Api Helpers

		/// <summary>
		/// Gets the jSon Object for TheColorAPI data using ColorfulJsonParser.
		/// </summary>
		/// <param name="h">Value for Hue</param>
		/// <param name="s">Value for Saturation</param>
		/// <param name="l">Value for Lightness</param>
		/// <param name="c">Character for the S and L values.  Pass null for default '%'.</param>
		/// <returns>(ColorfulJsonParser)object with data relating to HSL values provided</returns>
		public static async Task<object> getColorApiJson(int h, int s, int l, char? c)
		{
			char ch = c ?? '%';

			string url = string.Format(apiUrl, hslUrlParams);
			url = string.Format(url, h, s, l, c);

			return await hitApiWithUrl(url);
		}

		/// <summary>
		/// Gets the jSon Object for TheColorAPI data using ColorfulJsonParser.
		/// </summary>
		/// <param name="h">Value for Hue</param>
		/// <param name="s">Value for Saturation</param>
		/// <param name="l">Value for Lightness</param>
		/// <param name="c">Character for the S and L values.  Pass null for default '%'.</param>
		/// <returns>(ColorfulJsonParser)object with data relating to HSL values provided.</returns>
		public static async Task<ColorfulRestProperty> getColorfulRestProperty(int h, int s, int l, char? c)
		{
			object json = await getColorApiJson(h, s, l, c);
			return new ColorfulRestProperty(json);
		}

		#endregion

		#region Hex Api Helpers

		/// <summary>
		/// Gets the jSon Object for TheColorAPI data using ColorfulJsonParser.
		/// </summary>
		/// <param name="hexVal">String representing the hexidecimal value (HTML Code)</param>
		/// <returns>(ColorfulJsonParser)object with data relating to the hexidecimal value provided.</returns>
		public static async Task<object> getColorApiJson(string hexVal)
		{
			string url = string.Format(apiUrl, hexUrlParams);
			url = string.Format(url, hexVal);

			return await hitApiWithUrl(url);
		}

		/// <summary>
		/// Gets the ColorfulRestProperty for a color.
		/// </summary>
		/// <param name="hexVal">String representing the hexidecimal value (HTML Code)</param>
		/// <returns>ColorfulRestProperty with the data relating to the hexidecimal value provided.</returns>
		public static async Task<ColorfulRestProperty> getColorfulRestProperty(string hexVal)
		{
			object json = await getColorApiJson(hexVal);
			return new ColorfulRestProperty(json);
		}

		#endregion

		/// <summary>
		/// Hits the URL to get the ColorfulJsonParser object.
		/// </summary>
		/// <param name="url">The URL to hit.</param>
		/// <returns>(ColorfulJsonParser)object.</returns>
		private static async Task<object> hitApiWithUrl(string url)
		{
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
				throw new Exception(string.Format("Call to TheColorAPI (URL: {0}) failed: {1}", url, e.Message), e);
			}
		}
	}
}
