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
		}

		/// <summary>
		/// The links to the other color schemes available for the Seed.
		/// </summary>
		public struct Links
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

		}
		#endregion
	}
}
