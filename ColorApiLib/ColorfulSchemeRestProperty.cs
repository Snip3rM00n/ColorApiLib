/*
	Color API Lib
	By: Anthony McKeever (GitHub: Snip3rM00n - http://github.com/snip3rm00n)

	A library for retrieving data from The Color API.

	File: ColorfulSchemeRestProperty.cs
	Coded in: C# (Microsoft .Net 5.0 Framework)
	Namespace: ColorApiLib
	API Used: The Color API by Josh Beckman (http://thecolorapi.com).

	Purpose: Creates an object that represents the color scheme data from The Color API.  This object can be created as empty
			 (ColorfulSchemeRestProperty()) or from a ColorfulSchemeJsonParser object (ColorfulSchemeRestProperty(json)). 
	
	Use:
 		Creating Empty: 
 			ColorfulSchemeRestProperty color = new ColorfulSchemeRestProperty(); 
 			//	DO STUFF 
  
 		Creating from Object: 
 			DataContractJsonSerializer jSonSerializer = new DataContractJsonSerializer(typeof(ColorfulSchemeJsonParser)); 
 			object json = jSonSerializer.ReadObject(stream); 
  
 			ColorfulSchemeRestProperty color = new ColorSchemefulRestProperty(json); 
 			//	DO STUFF 
	
	TODO: Testing! -- This code us as of yet untested.  Use at your own risk (for now).
*/

using System;
using System.Collections.Generic;

namespace ColorApiLib
{
	/// <summary>
	/// An object that represents a color scheme from TheColorAPI.
	/// </summary>
	public class ColorfulSchemeRestProperty
	{
		#region Scheme Identity Constructors
		/// <summary>
		/// The links for the various images returned by the api.
		/// </summary>
		public struct Images
		{
			/// <summary>
			/// The color image without the name string appended on it.
			/// </summary>
			public string Bare;
			/// <summary>
			/// The color image with the name string appended on it.
			/// </summary>
			public string Named;

			/// <summary>
			/// Creates image link data from user defined strings.
			/// </summary>
			/// <param name="_bare">String for the bare image.</param>
			/// <param name="_named">String for the named image.</param>
			public Images(string _bare, string _named)
			{
				Bare = _bare;
				Named = _named;
			}

			/// <summary>
			/// Creates image link data from a ColorfulSchemeJsonParser schemeImageData object.
			/// </summary>
			/// <param name="jsonData">ColorfulSchemeJsonParser.schemeImageData object </param>
			public Images(object jsonData)
			{
				var imageData = (schemeImageData)jsonData;
				Bare = imageData.Bare;
				Named = imageData.Named;
			}
		}

		/// <summary>
		/// The links to the other color schemes available for the Seed.
		/// </summary>
		public struct links
		{
			/// <summary>
			/// The link for the current scheme.
			/// </summary>
			public string Self;

			/// <summary>
			/// Structures the scheme links into their own object collection (this format emulates the API's data structure).
			/// </summary>
			public struct schemes
			{
				/// <summary>
				/// A scheme of colors for the Seed in a monochrome palet.
				/// </summary>
				public string Monochrome;
				/// <summary>
				/// A scheme of colors for the Seed in a dark themed monochrome palet.
				/// </summary>
				public string MonochromeDark;
				/// <summary>
				/// A scheme of colors for the Seed in a light themed monochrome palet.
				/// </summary>
				public string MonochromeLight;
				/// <summary>
				/// A scheme of colors for the Seed that are similar to eachother (this is the default scheme).
				/// </summary>
				public string Analogic;
				/// <summary>
				/// A scheme of colors for the Seed that complement eachother (these may or may not include the original seed).
				/// </summary>
				public string Complement;
				/// <summary>
				/// A scheme of colors for the Seed that complement eachother and are similar to the Seed (these may or may not include the original seed).
				/// </summary>
				public string AnalogicComplement;
				/// <summary>
				/// A scheme of colors for the Seed that ???
				/// </summary>
				//	TODO: Look up what Triad means in the context of color.
				public string Triad;
				/// <summary>
				/// A scheme of colors for the Seed that ???
				/// </summary>
				//	TODO: Look up what Quad means in the context of color.
				public string Quad;
			}

			/// <summary>
			/// A collection of available color schemes for the seed.
			/// </summary>
			public schemes Schemes/* = new schemes()*/;

			/// <summary>
			/// Creates the links object from user defined strings.
			/// </summary>
			/// <param name="_self">String for the link to the current scheme</param>
			/// <param name="_monochrome">String for the link to the Monochrome Scheme</param>
			/// <param name="_monoDark">String for the link to the Monochrome Dark Scheme</param>
			/// <param name="_monoLight">String for the link to the Monochrome Light Scheme</param>
			/// <param name="_analogic">String for the link to the Analogic Scheme</param>
			/// <param name="_complement">String for the link to the Complement Scheme</param>
			/// <param name="_anacomp">String for the link to the Analogic Complement Scheme</param>
			/// <param name="_triad">String for the link to the Triad Scheme</param>
			/// <param name="_quad">String for the link to the Quad Scheme</param>
			public links (string _self, string _monochrome, string _monoDark, string _monoLight, string _analogic, string _complement, string _anacomp, string _triad, string _quad)
			{
				Self = _self;
				Schemes.Monochrome = _monochrome;
				Schemes.MonochromeDark = _monoDark;
				Schemes.MonochromeLight = _monoLight;
				Schemes.Analogic = _analogic;
				Schemes.Complement = _complement;
				Schemes.AnalogicComplement = _anacomp;
				Schemes.Triad = _triad;
				Schemes.Quad = _quad;
			}

			/// <summary>
			/// Creates links object from ColorfulSchemeJsonParser.schemeLinks object.
			/// </summary>
			/// <param name="jsonData">ColorfulSchemeJsonParser.schemeLinks Object</param>
			public links(object jsonData)
			{
				var linksData = (schemeLinks)jsonData;
				Self = linksData.Self;
				Schemes.Monochrome = linksData.Schemes.Monochrome;
				Schemes.MonochromeDark = linksData.Schemes.MonochromeDark;
				Schemes.MonochromeLight = linksData.Schemes.MonochromeLight;
				Schemes.Analogic = linksData.Schemes.Analogic;
				Schemes.Complement = linksData.Schemes.Complement;
				Schemes.AnalogicComplement = linksData.Schemes.AnalogicComplement;
				Schemes.Triad = linksData.Schemes.Triad;
				Schemes.Quad = linksData.Schemes.Quad;
			}
		}

		#endregion

		#region Instance Variables
		/// <summary>
		/// A string representing the mode for the scheme.
		/// </summary>
		public string Mode;

		/// <summary>
		/// An integer representing how many colors are in the scheme
		/// </summary>
		public int Count;

		/// <summary>
		/// A list of the colors returned by the API parsed into ColorfulRestProperties.
		/// </summary>
		public List<ColorfulRestProperty> Colors;

		/// <summary>
		/// The seed color used to generate the scheme parsed into a ColorfulRestProperty.
		/// </summary>
		public ColorfulRestProperty Seed;

		/// <summary>
		/// The collection of links to the various schemes.
		/// </summary>
		public links Links;

		#endregion

		#region Instantiate ColorfulSchemeRestProperty

		/// <summary>
		/// Initializes an empty ColorfulSchemeRestProperty object.
		/// </summary>
		public ColorfulSchemeRestProperty()
		{
			initEmpty();
		}

		/// <summary>
		/// Initializes the ColorfulSchemeRestProperty object from a ColorfulSchemeJsonParser object.
		/// </summary>
		/// <param name="json">(ColorfulSchemeJsonParser)object from API call.</param>
		public ColorfulSchemeRestProperty(object json)
		{
			var schemeData = (ColorfulSchemeJsonParser)json;
		}

		private void initEmpty()
		{
			Seed = new ColorfulRestProperty();
			Colors = new List<ColorfulRestProperty>();//Colors();
			Links = new links();
			Count = 0;
			Mode = string.Empty;
		}
		#endregion
	}
}
