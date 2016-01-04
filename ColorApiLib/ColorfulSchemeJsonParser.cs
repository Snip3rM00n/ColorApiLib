/*
	Color API Lib
	By: Anthony McKeever (GitHub: Snip3rM00n - http://github.com/snip3rm00n)

	A library for retrieving data from The Color API.

	File: ColorfulSchemeJsonParser.cs
	Coded in: C# (Microsoft .Net 5.0 Framework)
	Namespace: ColorApiLib
	API Used: The Color API by Josh Beckman (http://thecolorapi.com).

	Purpose: Used to parse the scheme results from The Color API into a usable collection of classes.

	This calls the ColorfulJsonParser to get the various colors.  The only new items added are the scheme specific details.

	TODO: Testing! -- This code us as of yet untested.  Use at your own risk (for now).
*/

using System.Runtime.Serialization;
using System.Collections.Generic;

namespace ColorApiLib
{
	/// <summary>
	/// The data for the scheme returned.
	/// </summary>
	[DataContract]
	public class ColorfulSchemeJsonParser
	{
		/// <summary>
		/// Defines the Mode of the scheme returned.  For example: "analogic"
		/// </summary>
		[DataMember(Name = "mode")]
		public string Mode { get; set; }

		/// <summary>
		/// Defines the total number of colors returned.
		/// </summary>
		[DataMember(Name = "count")]
		public int Count { get; set; }

		/// <summary>
		/// Defines the colors returned for the scheme.  This comes in the form of multiple ColorfulJsonParser objects.
		/// </summary>
		[DataMember(Name = "colors")]
		public List<ColorfulJsonParser> Colors { get; set; }
		//public List<colors> Colors { get; set; }

		/// <summary>
		/// Gets the seed color for the scheme.  This is the same as a ColorfulJsonParser object.
		/// </summary>
		[DataMember(Name = "seed")]
		public ColorfulJsonParser Seed { get; set; }

		/// <summary>
		/// Gets the image details for the scheme.
		/// </summary>
		[DataMember(Name = "images")]
		public schemeImageData images { get; set; }
	}

	/// <summary>
	/// Composes the image data.
	/// </summary>
	[DataContract]
	public class schemeImageData
	{
		/// <summary>
		/// Contains the data for the images without names.
		/// </summary>
		[DataMember(Name = "bare")]
		public string Bare { get; set; }

		/// <summary>
		/// Contains the data for the images with names.
		/// </summary>
		[DataMember(Name = "named")]
		public string Named { get; set; }
	}

	/// <summary>
	/// Gets the link details for the scheme
	/// </summary>
	[DataContract]
	public class schemeLinks
	{
		/// <summary>
		/// Gets the self referencing link for the scheme. (The link that was queried through the API)
		/// </summary>
		[DataMember(Name = "self")]
		public string Self { get; set; }

		/// <summary>
		/// Gets a collection of all the available schemes for a given color.
		/// </summary>
		[DataMember(Name = "schemes")]
		public schemeLinkSchemes Schemes { get; set; }
	}

	/// <summary>
	/// Defines the various scheme links for the color.
	/// </summary>
	[DataContract]
	public class schemeLinkSchemes
	{
		/// <summary>
		/// Gets the link for the Monochrome scheme.
		/// </summary>
		[DataMember(Name = "monochrome")]
		public string Monochrome { get; set; }

		/// <summary>
		/// Gets the link for the Monochrome-Dark scheme.
		/// </summary>
		[DataMember(Name = "monochrome-dark")]
		public string MonochromeDark { get; set; }

		/// <summary>
		/// Gets the link for the Monochrome-Light scheme.
		/// </summary>
		[DataMember(Name = "monochrome-light")]
		public string MonochromeLight { get; set; }

		/// <summary>
		/// Gets the link for the Analogic scheme.
		/// </summary>
		[DataMember(Name = "analogic")]
		public string Analogic { get; set; }

		/// <summary>
		/// Gets the link for the Complement scheme.
		/// </summary>
		[DataMember(Name = "complement")]
		public string Complement { get; set; }

		/// <summary>
		/// Gets the link for the Analogic-Complement scheme.
		/// </summary>
		[DataMember(Name = "analogic-complement")]
		public string AnalogicComplement { get; set; }

		/// <summary>
		/// Gets the link for the triad scheme.
		/// </summary>
		[DataMember(Name = "triad")]
		public string Triad { get; set; }

		/// <summary>
		/// Gets the link for the quad scheme.
		/// </summary>
		[DataMember(Name = "quad")]
		public string Quad { get; set; }
	}

	/*	DEBUG/TEMP CODE
		TODO: Clean up.
	/// <summary>
	/// A class defining the values for each color.
	/// </summary>
	[DataContract]
	public class colors
	{
		ColorfulJsonParser color = new ColorfulJsonParser();
	}
	*/
}
