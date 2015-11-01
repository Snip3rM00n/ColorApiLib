/*
	Color API Lib
	By: Anthony McKeever (GitHub: Snip3rM00n - http://github.com/snip3rm00n)

	A library for retrieving data from The Color API.
	Original code from Color Detector (https://github.com/Snip3rM00n/ColorDetector)

	File: ColorfulJsonParser.cs
	Coded in: C# (Microsoft .Net 5.0 Framework)
	Namespace: ColorApiLib
	API Used: The Color API by Josh Beckman (http://thecolorapi.com).

	Purpose: Creates an object that represents all data from The Color API.  This object can be created as empty (ColorfulRestProperty()) 
			 or from a ColorfulJsonParser object (ColorfulRestProperty(json)). 
  
 	Use: 
 		Creating Empty: 
 			ColorfulRestProperty color = new ColorfulRestProperty(); 
 			//	DO STUFF 
  
 		Creating from Object: 
 			DataContractJsonSerializer jSonSerializer = new DataContractJsonSerializer(typeof(ColorfulJsonParser)); 
 			object json = jSonSerializer.ReadObject(stream); 
  
 			ColorfulRestProperty color = new ColorfulRestProperty(json); 
 			//	DO STUFF 
*/

using System;

namespace ColorApiLib
{
	/// <summary>
	/// An object that represents a color from TheColorAPI.
	/// </summary>
	public class ColorfulRestProperty
	{
		#region Color Identity Constructors

		/// <summary>
		/// The Hex Data for the Color Object
		/// </summary>
		public struct hexvalue
		{
			/// <summary>
			/// Hexidecimal (HTML) value for the color. (Includes #)
			/// </summary>
			public string Value;
			/// <summary>
			/// Clean Hexidecimal (HTML) value for the color.
			/// </summary>
			public string CleanValue;

			/// <summary>
			/// Creates the Hex data from user provided values.
			/// </summary>
			/// <param name="value">The hexidecimal value for a color (Example: #01A1B1)</param>
			/// <param name="cvalue">The clean hexidecimal value for a color (Example: 01A1B1)</param>
			public hexvalue(string value, string cvalue)
			{
				Value = value;
				CleanValue = cvalue;
			}

			/// <summary>
			/// Creates the Hex data from ColorfulJsonParser hex data.
			/// </summary>
			/// <param name="jsonData">ColorfulJsonParser.hexData object</param>
			public hexvalue(object jsonData)
			{
				var hexData = (hexData)jsonData;
				Value = hexData.value;
				CleanValue = hexData.clean;
			}
		}

		/// <summary>
		/// The RGB (Red, Green Blue) Color Space Data for the Color Object
		/// </summary>
		public struct rgb
		{
			/// <summary>
			/// The collection of RGB values in ushort. (Base: ColorfulGeneric.RGB(ushort))
			/// </summary>
			public ColorfulGeneric.RGB<ushort> Values;
			/// <summary>
			/// The collection of RGB fractions in decimal. (Base: ColorfulGeneric.RGB(decimal))
			/// </summary>
			public ColorfulGeneric.RGB<decimal> Fraction;

			/// <summary>
			/// Gets a string representing the RGB values.
			/// </summary>
			/// <returns>Returns a string representing the RGB values.</returns>
			public override string ToString()
			{
				return string.Format("rgb({0},{1},{2})", Values.Red, Values.Green, Values.Blue);
			}

			/// <summary>
			/// Gets the API URL to query TheColorApi for this color using RGB method.
			/// </summary>
			/// <returns>The API Url.</returns>
			public string ToApiUrl()
			{
				string apiUrl = string.Format(ApiUrl, "rgb={0}");
				return string.Format(apiUrl, ToString());
			}

			/// <summary>
			/// Creates RGB Data from ColorfulJsonParser RGB data
			/// </summary>
			/// <param name="jsonData">ColorfulJsonParser.rgbData object</param>
			public rgb(object jsonData)
			{
				var _rgbData = (rgbData)jsonData;

				Values = new ColorfulGeneric.RGB<ushort>();
				Values.Red = _rgbData.r;
				Values.Green = _rgbData.g;
				Values.Blue = _rgbData.b;

				Fraction = new ColorfulGeneric.RGB<decimal>();
				Fraction.Red = _rgbData.Fraction.r;
				Fraction.Green = _rgbData.Fraction.g;
				Fraction.Blue = _rgbData.Fraction.b;
			}

			/// <summary>
			/// Creates RBG Data from user provided arrays of ushorts and decimals.
			/// </summary>
			/// <param name="values">An array of ushorts representing RGB values ([0]:Red, [1]:Green, [2]:Blue)</param>
			/// <param name="fraction">An array of decimals representing RGB fractions ([0]:Red, [1]:Green, [2]:Blue)</param>
			public rgb(ushort[] values, decimal[] fraction)
			{
				Values = new ColorfulGeneric.RGB<ushort>();
				Fraction = new ColorfulGeneric.RGB<decimal>();

				Values.Red = values[0];
				Values.Green = values[1];
				Values.Blue = values[2];

				Fraction.Red = fraction[0];
				Fraction.Green = fraction[1];
				Fraction.Blue = fraction[2];
			}
		}

		/// <summary>
		/// The HSL (Hue, Saturation, Lightness) Color Space Data for the Color Object
		/// </summary>
		public struct hsl
		{
			/// <summary>
			/// The collection of HSL values in ushort. (Base: ColorfulGeneric.HSL(ushort))
			/// </summary>
			public ColorfulGeneric.HSL<ushort> Values;
			/// <summary>
			/// The collection of HSL fractions in decimal. (Base: ColorfulGeneric.HSL(decimal))
			/// </summary>
			public ColorfulGeneric.HSL<decimal> Fraction;

			/// <summary>
			/// Gets a string representing the HSL values.
			/// </summary>
			/// <returns>Returns a string representing the HSL values.</returns>
			public override string ToString()
			{
				return string.Format("hsl({0},{1}%,{2}%)", Values.H, Values.S, Values.L);
			}

			/// <summary>
			/// Gets the API URL to query TheColorApi for this color using HSL method.
			/// </summary>
			/// <returns>The API Url.</returns>
			public string ToApiUrl()
			{
				string apiUrl = string.Format(ApiUrl, "hsl={0}");
				return string.Format(apiUrl, ToString());
			}

			/// <summary>
			/// Creates HSL Data from ColorfulJsonParser HSL data
			/// </summary>
			/// <param name="jsonData">ColorfulJsonParser.hslData object</param>
			public hsl(object jsonData)
			{
				var _hslData = (hslData)jsonData;

				Values = new ColorfulGeneric.HSL<ushort>();
				Values.H = _hslData.h;
				Values.S = _hslData.s;
				Values.L = _hslData.l;

				Fraction = new ColorfulGeneric.HSL<decimal>();
				Fraction.H = _hslData.fraction.h;
				Fraction.S = _hslData.fraction.s;
				Fraction.L = _hslData.fraction.l;
			}

			/// <summary>
			/// Creates HSL Data from user provided arrays of ushorts and decimals.
			/// </summary>
			/// <param name="values">An array of ushorts representing HSL values ([0]:Hue, [1]:Saturation, [2]:Lightness)</param>
			/// <param name="fraction">An array of decimals representing HSL fractions ([0]:Hue, [1]:Saturation, [2]:Lightness)</param>
			public hsl(ushort[] values, decimal[] fraction)
			{
				Values = new ColorfulGeneric.HSL<ushort>();
				Fraction = new ColorfulGeneric.HSL<decimal>();

				Values.H = values[0];
				Values.S = values[1];
				Values.L = values[2];

				Fraction.H = fraction[0];
				Fraction.S = fraction[1];
				Fraction.L = fraction[2];
			}
		}

		/// <summary>
		/// The HSV (Hue, Saturation, Value) Color Space Data for the Color Object
		/// </summary>
		public struct hsv
		{
			/// <summary>
			/// The collection of HSV values in ushort. (Base: ColorfulGeneric.HSV(ushort))
			/// </summary>
			public ColorfulGeneric.HSV<ushort> Values;
			/// <summary>
			/// The collection of HSV fractions in decimal. (Base: ColorfulGeneric.HSV(decimal))
			/// </summary>
			public ColorfulGeneric.HSV<decimal> Fraction;

			/// <summary>
			/// Gets a string representing the HSV values.
			/// </summary>
			/// <returns>Returns a string representing the HSV values.</returns>
			public override string ToString()
			{
				return string.Format("hsv({0},{1}%,{2}%)", Values.H, Values.S, Values.V);
			}

			/// <summary>
			/// Gets the API URL to query TheColorApi for this color using HSV method.  This method is not currently supported by the API.
			/// </summary>
			/// <returns>The API Url.</returns>
			[Obsolete("TheColorAPI currently does not support retrieving color via HSV.  Consider an alterative method.", true)]
			public string ToApiUrl()
			{
				string apiUrl = string.Format(ApiUrl, "hsv={0}");
				return string.Format(apiUrl, ToString());
			}

			/// <summary>
			/// Creates HSV Data from ColorfulJsonParser HSV data
			/// </summary>
			/// <param name="jsonData">ColorfulJsonParser.hsvData object</param>
			public hsv(object jsonData)
			{
				var _hsvData = (hsvData)jsonData;

				Values = new ColorfulGeneric.HSV<ushort>();
				Values.H = _hsvData.h;
				Values.S = _hsvData.s;
				Values.V = _hsvData.v;

				Fraction = new ColorfulGeneric.HSV<decimal>();
				Fraction.H = _hsvData.fraction.h;
				Fraction.S = _hsvData.fraction.s;
				Fraction.V = _hsvData.fraction.v;
			}

			/// <summary>
			/// Creates HSV Data from user provided arrays of ushorts and decimals.
			/// </summary>
			/// <param name="values">An array of ushorts representing HSV values ([0]:Hue, [1]:Saturation, [2]:Value)</param>
			/// <param name="fraction">An array of decimals representing HSV fractions ([0]:Hue, [1]:Saturation, [2]:Value)</param>
			public hsv(ushort[] values, decimal[] fraction)
			{
				Values = new ColorfulGeneric.HSV<ushort>();
				Values.H = values[0];
				Values.S = values[1];
				Values.V = values[2];

				Fraction = new ColorfulGeneric.HSV<decimal>();
				Fraction.H = fraction[0];
				Fraction.S = fraction[1];
				Fraction.V = fraction[2];
			}

		}

		/// <summary>
		/// The CMYK (Cyan, Magenta, Yellow, Key (Black)) Color Space Data for the Color Object
		/// </summary>
		public struct cmyk
		{
			/// <summary>
			/// The collection of CMYK values in ushort. (Base: ColorfulGeneric.CMYK(ushort))
			/// </summary>
			public ColorfulGeneric.CMYK<ushort> Values;
			/// <summary>
			/// The collection of CMYK fractions in decimal. (Base: ColorfulGeneric.CMYK(decimal))
			/// </summary>
			public ColorfulGeneric.CMYK<decimal> Fraction;

			/// <summary>
			/// Gets a string representing the CMYK values.
			/// </summary>
			/// <returns>Returns a string representing the CMYK values.</returns>
			public override string ToString()
			{
				return string.Format("cmyk({0},{1},{2},{3})", Values.C, Values.M, Values.Y, Values.K);
			}

			/// <summary>
			/// Gets the API URL to query TheColorApi for this color using CMYK method.
			/// </summary>
			/// <returns>The API Url.</returns>
			public string ToApiUrl()
			{
				string apiUrl = string.Format(ApiUrl, "cmyk={0}");
				return string.Format(apiUrl, ToString());
			}

			/// <summary>
			/// Creates CMYK Data from ColorfulJsonParser CMYK data
			/// </summary>
			/// <param name="jsonData">ColorfulJsonParser.cmykData object</param>
			public cmyk(object jsonData)
			{
				var _cmykData = (cmykData)jsonData;

				Values = new ColorfulGeneric.CMYK<ushort>();
				Values.C = _cmykData.c;
				Values.M = _cmykData.m;
				Values.Y = _cmykData.y;
				Values.K = _cmykData.k;

				Fraction = new ColorfulGeneric.CMYK<decimal>();
				Fraction.C = _cmykData.fraction.c;
				Fraction.M = _cmykData.fraction.m;
				Fraction.Y = _cmykData.fraction.y;
				Fraction.K = _cmykData.fraction.k;
			}

			/// <summary>
			/// Creates CMYK Data from user provided arrays of ushorts and decimals.
			/// </summary>
			/// <param name="values">An array of ushorts representing CMYK values ([0]:Cyan, [1]:Magenta, [2]:Yellow [3]:Key)</param>
			/// <param name="fraction">An array of decimals representing CMYK fractions ([0]:Cyan, [1]:Magenta, [2]:Yellow [3]:Key)</param>
			public cmyk(ushort[] values, decimal[] fraction)
			{
				Values = new ColorfulGeneric.CMYK<ushort>();
				Values.C = values[0];
				Values.M = values[1];
				Values.Y = values[2];
				Values.K = values[3];

				Fraction = new ColorfulGeneric.CMYK<decimal>();
				Fraction.C = fraction[0];
				Fraction.M = fraction[1];
				Fraction.Y = fraction[2];
				Fraction.K = fraction[3];
			}
		}

		/// <summary>
		/// The XYZ (CIE 1931) Color Space Data for the Color Object
		/// </summary>
		public struct xyz
		{
			/// <summary>
			/// The collection of XYZ values in ushort. (Base: ColorfulGeneric.XYZ(ushort))
			/// </summary>
			public ColorfulGeneric.XYZ<ushort> Values;
			/// <summary>
			/// The collection of XYZ fractions in decimal. (Base: ColorfulGeneric.XYZ(decimal))
			/// </summary>
			public ColorfulGeneric.XYZ<decimal> Fraction;

			/// <summary>
			/// Gets a string representing the XYZ values.
			/// </summary>
			/// <returns>Returns a string representing the XYZ values.</returns>
			public override string ToString()
			{
				return string.Format("XYZ({0},{1},{2})", Values.X, Values.Y, Values.Z);
			}

			/// <summary>
			/// Gets the API URL to query TheColorApi for this color using XYZ method.  This method is not currently supported by the API.
			/// </summary>
			/// <returns>The API Url.</returns>
			[Obsolete("The Color API currently does not support retrieving color with XYZ via direct URL, use a Json payload to query API instead.", true)]
			public string ToApiUrl()
			{
				string apiUrl = string.Format(ApiUrl, "xyz={0}");
				return string.Format(apiUrl, ToString());
			}

			/// <summary>
			/// Creates XYZ Data from ColorfulJsonParser XYZ data
			/// </summary>
			/// <param name="jsonData">ColorfulJsonParser.xyzData object</param>
			public xyz(object jsonData)
			{
				var _xyzData = (xyzData)jsonData;

				Values = new ColorfulGeneric.XYZ<ushort>();
				Values.X = _xyzData.x;
				Values.Y = _xyzData.y;
				Values.Z = _xyzData.z;

				Fraction = new ColorfulGeneric.XYZ<decimal>();
				Fraction.X = _xyzData.fraction.x;
				Fraction.Y = _xyzData.fraction.y;
				Fraction.Z = _xyzData.fraction.z;
			}

			/// <summary>
			/// Creates XYZ Data from user provided arrays of ushorts and decimals.
			/// </summary>
			/// <param name="values">An array of ushorts representing XYZ values ([0]:X, [1]:Y, [2]:Z)</param>
			/// <param name="fraction">An array of decimals representing XYZ fractions ([0]:X, [1]:Y, [2]:Z)</param>
			public xyz(ushort[] values, decimal[] fraction)
			{
				Values = new ColorfulGeneric.XYZ<ushort>();
				Values.X = values[0];
				Values.Y = values[1];
				Values.Z = values[2];

				Fraction = new ColorfulGeneric.XYZ<decimal>();
				Fraction.X = fraction[0];
				Fraction.Y = fraction[1];
				Fraction.Z = fraction[2];
			}
		}

		/// <summary>
		/// The Name data for the Color Object
		/// </summary>
		public struct name
		{
			/// <summary>
			/// A string representing the name of the color.
			/// </summary>
			public string Value;
			/// <summary>
			/// A string representing the closest color in hexidecimal.
			/// </summary>
			public string ClosestNamedHex;
			/// <summary>
			/// A boolean representing if this color exactly matches the closet named color.
			/// </summary>
			public bool ExactMatchName;
			/// <summary>
			/// The distance to the Closest named color.
			/// </summary>
            public int Distance;

			/// <summary>
			/// Creates Name Data from ColorfulJsonParser Name data
			/// </summary>
			/// <param name="jsonData">ColorfulJsonParser.nameData object</param>
			public name(object jsonData)
			{
				var _nameData = (nameData)jsonData;

				Value = _nameData.value;
				ClosestNamedHex = _nameData.closestNamedHex;
				ExactMatchName = _nameData.exactNameMatch;
				Distance = _nameData.distance;
			}

			/// <summary>
			/// reates Name Data from user provided parameters.
			/// </summary>
			/// <param name="value">The name of the color</param>
			/// <param name="closestHex">The closest color in Hexidecimal</param>
			/// <param name="exactMatch">Does this color match its closest match</param>
			/// <param name="dist">Distance to the nearest color</param>
			public name(string value, string closestHex, bool exactMatch, int dist)
			{
				Value = value;
				ClosestNamedHex = closestHex;
				ExactMatchName = exactMatch;
				Distance = dist;
			}
		}

		/// <summary>
		/// The Image Data for the Color Object
		/// </summary>
		public struct image
		{
			/// <summary>
			/// The URL to the image without text.
			/// </summary>
			public string Bare;
			/// <summary>
			/// The URL to the image with text.
			/// </summary>
			public string Named;

			/// <summary>
			/// Creates Image Data from ColorfulJsonParser Image data
			/// </summary>
			/// <param Image="jsonData">ColorfulJsonParser.ImageData object</param>
			public image(object jsonData)
			{
				var _imageData = (imageData)jsonData;
				Bare = _imageData.Bare;
				Named = _imageData.Named;
			}

			/// <summary>
			/// Creates Image Data from user provided strings.
			/// </summary>
			/// <param name="bare">The URL to the image without text.</param>
			/// <param name="named">The URL to the image with text.</param>
			public image(string bare, string named)
			{
				Bare = bare;
				Named = named;
			}
		}

		#endregion

		#region Instance Variables

		private const string ApiUrl = "http://www.thecolorapi.com/id?{0}";

		/// <summary>
		/// The Hex Data for the current Color Object
		/// </summary>
		public hexvalue HexValue;
		/// <summary>
		/// The RGB (Red, Green Blue) Color Space Data for the current Color Object
		/// </summary>
		public rgb RGB;
		/// <summary>
		/// The HSL (Hue, Saturation, Lightness) Color Space Data for the current Color Object
		/// </summary>
		public hsl HSL;
		/// <summary>
		/// The HSV (Hue, Saturation, Value) Color Space Data for the current Color Object
		/// </summary>
		public hsv HSV;
		/// <summary>
		/// The CMYK (Cyan, Magenta, Yellow, Key (Black)) Color Space Data for the current Color Object
		/// </summary>
		public cmyk CMYK;
		/// <summary>
		/// The XYZ (CIE 1931) Color Space Data for the current Color Object
		/// </summary>
		public xyz XYZ;
		/// <summary>
		/// The Name data for the current Color Object
		/// </summary>
		public name Name;
		/// <summary>
		/// The Image Data for the current Color Object
		/// </summary>
		public image Image;
		/// <summary>
		/// The Contrast Data for the current Color Object
		/// </summary>
		public string Contrast;

		#endregion

		#region Instantiate ColorfulRestProperty

		/// <summary>
		/// Initializes an empty ColorfulRestProperty object.
		/// </summary>
		public ColorfulRestProperty()
		{
			initEmpty();
		}

		/// <summary>
		/// Initializes a ColorfulRestProperty object from ColorfulJsonParse object.
		/// </summary>
		/// <param name="json">(ColorfulJsonParser)object from API call.</param>
		public ColorfulRestProperty(object json)
		{
			var colorData = (ColorfulJsonParser)json;

			HexValue = new hexvalue(colorData.Hex);
			RGB = new rgb(colorData.RGB);
			HSL = new hsl(colorData.HSL);
			HSV = new hsv(colorData.HSV);
			CMYK = new cmyk(colorData.CMYK);
			XYZ = new xyz(colorData.XYZ);
			Name = new name(colorData.Name);
			Image = new image(colorData.Image);
			Contrast = colorData.Contrast.value;
		}

		private void initEmpty()
		{
			HexValue = new hexvalue();
			RGB = new rgb();
			HSL = new hsl();
			HSV = new hsv();
			CMYK = new cmyk();
			XYZ = new xyz();
			Name = new name();
			Image = new image();
			Contrast = string.Empty;
		}

		#endregion

		/// <summary>
		/// Gets the name of the current color object
		/// </summary>
		/// <returns>Returns the name of the color.</returns>
		public override string ToString()
		{
			return Name.Value;
		}

		/// <summary>
		/// Gets data relating to hte color object.
		/// </summary>
		/// <param name="allData">Bool representing if all data is needed.</param>
		/// <returns>allData = True - Gets the RGB, HSL, HSV, XYZ and CMYK colorspace data for the object in string form
		///			 allData = False - Gets the name of the color
		/// </returns>
		public string ToString(bool allData)
		{
			if (allData)
			{
				string cData = "Name: {0}\r\nRGB: {1}\r\nCMYK: {2}\r\nHSV: {3}\r\nHSL: {4}\r\nXYZ: {5}";

				string _nameData = "\r\n\tValue: {0}\r\n\tClosest Named Match: {1}\r\n\tExact Match: {2}\r\n\tDistance: {3}";
				_nameData = string.Format(_nameData, Name.Value, Name.ClosestNamedHex, Name.ExactMatchName, Name.Distance);

				string _rgbData = "\r\n\tR: {0}\t(Fraction: {1})\r\n\tG: {2}\t(Fraction: {3})\r\n\tB: {4}\t(Fraction: {5})";
				_rgbData = string.Format(_rgbData, RGB.Values.Red, RGB.Fraction.Red, RGB.Values.Green, RGB.Fraction.Green, RGB.Values.Blue, RGB.Fraction.Blue);

				string _hsvData = "\r\n\tH: {0}\t(Fraction: {1})\r\n\tS: {2}\t(Fraction: {3})\r\n\tV: {4}\t(Fraction: {5})";
				_hsvData = string.Format(_hsvData, HSV.Values.H, HSV.Fraction.H, HSV.Values.S, HSV.Fraction.S, HSV.Values.V, HSV.Fraction.V);

				string _hslData = "\r\n\tH: {0}\t(Fraction: {1})\r\n\tS: {2}\t(Fraction: {3})\r\n\tL: {4}\t(Fraction: {5})";
				_hslData = string.Format(_hslData, HSL.Values.H, HSL.Fraction.H, HSL.Values.S, HSL.Fraction.S, HSL.Values.L, HSL.Fraction.L);

				string _xyzData = "\r\n\tX: {0}\t(Fraction: {1})\r\n\tY: {2}\t(Fraction: {3})\r\n\tZ: {4}\t(Fraction: {5})";
				_xyzData = string.Format(_xyzData, XYZ.Values.X, XYZ.Fraction.X, XYZ.Values.Y, XYZ.Fraction.Y, XYZ.Values.Z, XYZ.Fraction.Z);

				string _cmykData = "\r\n\tC: {0}\t(Fraction: {1})\r\n\tM: {2}\t(Fraction: {3})\r\n\tY: {4}\t(Fraction: {5})\r\n\tK: {6}\t(Fraction: {7})";
				_cmykData = string.Format(_cmykData, CMYK.Values.C, CMYK.Fraction.C, CMYK.Values.M, CMYK.Fraction.M, CMYK.Values.Y, CMYK.Fraction.Y, CMYK.Values.K, CMYK.Fraction.K);

				return string.Format(cData, _nameData, _rgbData, _cmykData, _hsvData, _hslData, _xyzData);
			}
			else return ToString();
		}
	}
}
