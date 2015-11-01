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

namespace ColorApiLib
{
	/// <summary>
	/// A collection of generic structures to build ColorfulRestProperties
	/// </summary>
	public class ColorfulGeneric
	{
		/// <summary>
		/// A collection of generics for RGB Color Space
		/// </summary>
		/// <typeparam name="T">Typically use int, ushort, decimal, or float.</typeparam>
		public struct RGB<T>
		{
			/// <summary>
			/// Generic for Red
			/// </summary>
			public T Red;
			/// <summary>
			/// Generic for Green
			/// </summary>
			public T Green;
			/// <summary>
			/// Generic for Blue
			/// </summary>
			public T Blue;
		}

		/// <summary>
		/// A collection of generics for HSL Color Space
		/// </summary>
		/// <typeparam name="T">Typically use int, ushort, decimal, or float.</typeparam>
		public struct HSL<T>
		{
			/// <summary>
			/// Generic for Hue
			/// </summary>
			public T H;
			/// <summary>
			/// Generic for Saturation
			/// </summary>
			public T S;
			/// <summary>
			/// Generic for Lightness
			/// </summary>
			public T L;
		}

		/// <summary>
		/// A collection of generics for HSV Color Space
		/// </summary>
		/// <typeparam name="T">Typically use int, ushort, decimal, or float.</typeparam>
		public struct HSV<T>
		{
			/// <summary>
			/// Generic for Hue
			/// </summary>
			public T H;
			/// <summary>
			/// Generic for Saturation
			/// </summary>
			public T S;
			/// <summary>
			/// Generic for Value
			/// </summary>
			public T V;
		}

		/// <summary>
		/// A collection of generics for CMYK Color Space
		/// </summary>
		/// <typeparam name="T">Typically use int, ushort, decimal, or float.</typeparam>
		public struct CMYK<T>
		{
			/// <summary>
			/// Generic for Cyan
			/// </summary>
			public T C;
			/// <summary>
			/// Generic for Magenta
			/// </summary>
			public T M;
			/// <summary>
			/// Generic for Yellow
			/// </summary>
			public T Y;
			/// <summary>
			/// Generic for Key (Black)
			/// </summary>
			public T K;
		}

		/// <summary>
		/// Generic for CIE 1931 Color Space (XYZ).
		/// </summary>
		/// <typeparam name="T">Typically use int, ushort, decimal, or float.</typeparam>
		public struct XYZ<T>
		{
			/// <summary>
			/// Generic for X
			/// </summary>
			public T X;
			/// <summary>
			/// Generic for Y
			/// </summary>
			public T Y;
			/// <summary>
			/// Generic for Z
			/// </summary>
			public T Z;
		}
	}
}
