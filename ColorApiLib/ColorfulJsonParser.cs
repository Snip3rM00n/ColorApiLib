/*
	Color API Lib
	By: Anthony McKeever (GitHub: Snip3rM00n - http://github.com/snip3rm00n)

	A library for retrieving data from The Color API.
	Original code from Color Detector (https://github.com/Snip3rM00n/ColorDetector)

	File: ColorfulJsonParser.cs
	Coded in: C# (Microsoft .Net 5.0 Framework)
	Namespace: ColorApiLib
	API Used: The Color API by Josh Beckman (http://thecolorapi.com).

	Purpose: Used to parse the results from The Color API into a usable collection of classes.
*/

using System.Runtime.Serialization;

namespace ColorApiLib
{
	/// <summary>
	/// A DataContract class for parsing TheColorAPI Json Payloads
	/// </summary>
	[DataContract]
	public class ColorfulJsonParser
	{
		/// <summary>
		/// JSon data for Hex Value.
		/// </summary>
		[DataMember(Name = "hex")]
		public hexData Hex { get; set; }

		/// <summary>
		/// JSon Data for RGB Values and Fractions
		/// </summary>
		[DataMember(Name = "rgb")]
		public rgbData RGB { get; set; }

		/// <summary>
		/// JSon Data for HSL Values and Fractions
		/// </summary>
		[DataMember(Name = "hsl")]
		public hslData HSL { get; set; }

		/// <summary>
		/// JSon Data for HSV Values and Fractions
		/// </summary>
		[DataMember(Name = "hsv")]
		public hsvData HSV { get; set; }

		/// <summary>
		/// JSon Data for Name Values
		/// </summary>
		[DataMember(Name = "name")]
		public nameData Name { get; set; }

		/// <summary>
		/// JSon Data for CMYK Values and Fractions
		/// </summary>
		[DataMember(Name = "cmyk")]
		public cmykData CMYK { get; set; }

		/// <summary>
		/// JSon Data for XYZ Values and Fractions
		/// </summary>
		[DataMember(Name = "XYZ")]
		public xyzData XYZ { get; set; }

		/// <summary>
		/// JSon Data for Image URLs
		/// </summary>
		[DataMember(Name = "image")]
		public imageData Image { get; set; }

		/// <summary>
		/// JSon Data for Hex Values
		/// </summary>
		[DataMember(Name = "contrast")]
		public contrastData Contrast { get; set; }

		/// <summary>
		/// JSon Data for Color Links
		/// </summary>
		[DataMember(Name = "_links")]
		public linksData Links { get; set; }
	}

	#region RGB

	/// <summary>
	/// JSon Data for RGB Values and Fractions
	/// </summary>
	[DataContract]
	public class rgbData
	{
		/// <summary>
		/// JSon Data for RGB Fractions
		/// </summary>
		[DataMember(Name = "fraction")]
		public rgbFraction Fraction { get; set; }

		/// <summary>
		/// Json Data for Red Value
		/// </summary>
		[DataMember(Name = "r")]
		public ushort r { get; set; }

		/// <summary>
		/// Json Data for Green Value
		/// </summary>
		[DataMember(Name = "g")]
		public ushort g { get; set; }

		/// <summary>
		/// Json Data for Blue Value
		/// </summary>
		[DataMember(Name = "b")]
		public ushort b { get; set; }

		/// <summary>
		/// Json Data for Value String
		/// </summary>
		[DataMember(Name = "value")]
		public string value { get; set; }
	}


	/// <summary>
	/// Json Data for Red Fractions
	/// </summary>
	[DataContract]
	public class rgbFraction
	{
		/// <summary>
		/// Json Data for Red Fraction
		/// </summary>
		[DataMember(Name = "r")]
		public decimal r { get; set; }

		/// <summary>
		/// Json Data for Green Fraction
		/// </summary>
		[DataMember(Name = "g")]
		public decimal g { get; set; }

		/// <summary>
		/// Json Data for Blue Fraction
		/// </summary>
		[DataMember(Name = "b")]
		public decimal b { get; set; }
	}

	#endregion

	#region HSL

	/// <summary>
	/// JSon Data for HSL Values and Fractions
	/// </summary>
	[DataContract]
	public class hslData
	{
		/// <summary>
		/// JSon Data for HSL Fractions
		/// </summary>
		[DataMember(Name = "fraction")]
		public hslFraction fraction { get; set; }

		/// <summary>
		/// Json Data for Hue Value
		/// </summary>
		[DataMember(Name = "h")]
		public ushort h { get; set; }

		/// <summary>
		/// Json Data for Saturation Value
		/// </summary>
		[DataMember(Name = "s")]
		public ushort s { get; set; }

		/// <summary>
		/// Json Data for Lightness Value
		/// </summary>
		[DataMember(Name = "l")]
		public ushort l { get; set; }

		/// <summary>
		/// Json Data for Value String
		/// </summary>
		[DataMember(Name = "value")]
		public string value { get; set; }
	}

	/// <summary>
	/// JSon Data for HSL Fractions
	/// </summary>
	[DataContract]
	public class hslFraction
	{
		/// <summary>
		/// Json Data for Hue Fraction
		/// </summary>
		[DataMember(Name = "h")]
		public decimal h { get; set; }

		/// <summary>
		/// Json Data for Saturation Fraction
		/// </summary>
		[DataMember(Name = "s")]
		public decimal s { get; set; }

		/// <summary>
		/// Json Data for Lightness Fraction
		/// </summary>
		[DataMember(Name = "l")]
		public decimal l { get; set; }
	}

	#endregion

	#region HSV

	/// <summary>
	/// JSon Data for HSV Values and Fractions
	/// </summary>
	[DataContract]
	public class hsvData
	{
		/// <summary>
		/// JSon Data for HSV Fractions
		/// </summary>
		[DataMember(Name = "fraction")]
		public hsvFraction fraction { get; set; }

		/// <summary>
		/// Json Data for Hue Value
		/// </summary>
		[DataMember(Name = "h")]
		public ushort h { get; set; }

		/// <summary>
		/// Json Data for Saturation Value
		/// </summary>
		[DataMember(Name = "s")]
		public ushort s { get; set; }

		/// <summary>
		/// Json Data for Value Value
		/// </summary>
		[DataMember(Name = "v")]
		public ushort v { get; set; }

		/// <summary>
		/// Json Data for HSV Value String
		/// </summary>
		[DataMember(Name = "value")]
		public string value { get; set; }
	}

	/// <summary>
	/// JSon Data for HSV Fractions
	/// </summary>
	[DataContract]
	public class hsvFraction
	{
		/// <summary>
		/// Json Data for Hue Fraction
		/// </summary>
		[DataMember(Name = "h")]
		public decimal h { get; set; }

		/// <summary>
		/// Json Data for Saturation Fraction
		/// </summary>
		[DataMember(Name = "s")]
		public decimal s { get; set; }

		/// <summary>
		/// Json Data for Value Fraction
		/// </summary>
		[DataMember(Name = "v")]
		public decimal v { get; set; }
	}

	#endregion

	#region CMYK

	/// <summary>
	/// JSon Data for CMYK Values and Fractions
	/// </summary>
	[DataContract]
	public class cmykData
	{
		/// <summary>
		/// JSon Data for CMYK Fractions
		/// </summary>
		[DataMember(Name = "fraction")]
		public cmykFraction fraction { get; set; }

		/// <summary>
		/// JSon Data for Cyan Value
		/// </summary>
		[DataMember(Name = "c")]
		public ushort c { get; set; }

		/// <summary>
		/// JSon Data for Magenta Value
		/// </summary>
		[DataMember(Name = "m")]
		public ushort m { get; set; }

		/// <summary>
		/// JSon Data for Yellow Value
		/// </summary>
		[DataMember(Name = "y")]
		public ushort y { get; set; }

		/// <summary>
		/// JSon Data for Key (Black) Value
		/// </summary>
		[DataMember(Name = "k")]
		public ushort k { get; set; }

		/// <summary>
		/// Json Data for CMYK Value String
		/// </summary>
		[DataMember(Name = "value")]
		public string value { get; set; }
	}

	/// <summary>
	/// JSon Data for CMYK Fractions
	/// </summary>
	public class cmykFraction
	{
		/// <summary>
		/// JSon Data for Cyan Fraction
		/// </summary>
		[DataMember(Name = "c")]
		public decimal c { get; set; }

		/// <summary>
		/// JSon Data for Magenta Fraction
		/// </summary>
		[DataMember(Name = "m")]
		public decimal m { get; set; }

		/// <summary>
		/// JSon Data for Yellow Fraction
		/// </summary>
		[DataMember(Name = "y")]
		public decimal y { get; set; }

		/// <summary>
		/// JSon Data for Key (Black) Fraction
		/// </summary>
		[DataMember(Name = "k")]
		public decimal k { get; set; }
	}

	#endregion

	#region XYZ

	/// <summary>
	/// JSon Data for XYZ Values and Fractions
	/// </summary>
	[DataContract]
	public class xyzData
	{
		/// <summary>
		/// JSon Data for XYZ Fractions
		/// </summary>
		[DataMember(Name = "fraction")]
		public xyzFraction fraction { get; set; }

		/// <summary>
		/// JSon Data for X Value
		/// </summary>
		[DataMember(Name = "X")]
		public ushort x { get; set; }

		/// <summary>
		/// JSon Data for Y Value
		/// </summary>
		[DataMember(Name = "Y")]
		public ushort y { get; set; }

		/// <summary>
		/// JSon Data for Z Value
		/// </summary>
		[DataMember(Name = "Z")]
		public ushort z { get; set; }

		/// <summary>
		/// Json Data for XYZ Value String
		/// </summary>
		[DataMember(Name = "value")]
		public string value { get; set; }
	}

	/// <summary>
	/// JSon Data for XYZ Fractions
	/// </summary>
	[DataContract]
	public class xyzFraction
	{
		/// <summary>
		/// JSon Data for X Fraction
		/// </summary>
		[DataMember(Name = "X")]
		public decimal x { get; set; }

		/// <summary>
		/// JSon Data for Y Fraction
		/// </summary>
		[DataMember(Name = "Y")]
		public decimal y { get; set; }

		/// <summary>
		/// JSon Data for Z Fraction
		/// </summary>
		[DataMember(Name = "Z")]
		public decimal z { get; set; }
	}

	#endregion

	#region Misc

	/// <summary>
	/// Json Data for Hex Strings
	/// </summary>
	[DataContract]
	public class hexData
	{
		/// <summary>
		/// Json Data for Hex Value String
		/// </summary>
		[DataMember(Name = "value")]
		public string value { get; set; }

		/// <summary>
		/// Json Data for Hex Clean Value String
		/// </summary>
		[DataMember(Name = "clean")]
		public string clean { get; set; }
	}

	/// <summary>
	/// JSon Data for Color Name information
	/// </summary>
	[DataContract]
	public class nameData
	{
		/// <summary>
		/// Json Data for Name Value String
		/// </summary>
		[DataMember(Name = "value")]
		public string value { get; set; }

		/// <summary>
		/// Json Data for the Closest Color Hex Value String
		/// </summary>
		[DataMember(Name = "closest_named_hex")]
		public string closestNamedHex { get; set; }

		/// <summary>
		/// Json Data for Exact Match Boolean
		/// </summary>
		[DataMember(Name = "exact_match_name")]
		public bool exactNameMatch { get; set; }

		/// <summary>
		/// Json Data for Distance Integer 
		/// </summary>
		[DataMember(Name = "distance")]
		public int distance { get; set; }
	}

	/// <summary>
	/// Json Data for Image URLs
	/// </summary>
	[DataContract]
	public class imageData
	{
		/// <summary>
		/// Json Data for Bare Image URL
		/// </summary>
		[DataMember(Name = "bare")]
		public string Bare { get; set; }

		/// <summary>
		/// Json Data for Named Image URL
		/// </summary>
		[DataMember(Name = "named")]
		public string Named { get; set; }
	}

	/// <summary>
	/// Json Data for Contrast
	/// </summary>
	[DataContract]
	public class contrastData
	{
		/// <summary>
		/// Json Data for Contrast Hex Value String
		/// </summary>
		[DataMember(Name = "value")]
		public string value { get; set; }
	}

	/// <summary>
	/// Json Data for Links
	/// </summary>
	[DataContract]
	public class linksData
	{
		/// <summary>
		/// Json Data for Direct Link to Color
		/// </summary>
		[DataMember(Name = "self")]
		public selfData Self { get; set; }
	}

	/// <summary>
	/// Json Data for Self Data
	/// </summary>
	public class selfData
	{
		/// <summary>
		/// Json Data for Direct Link to Color
		/// </summary>
		[DataMember(Name = "href")]
		public string href { get; set; }
	}
	#endregion
}
