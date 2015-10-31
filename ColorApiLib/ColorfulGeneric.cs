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
	public class ColorfulGeneric
	{
		public struct RGB<T>
		{
			public T Red;
			public T Green;
			public T Blue;
		}

		public struct HSL<T>
		{
			public T H;
			public T S;
			public T L;
		}

		public struct HSV<T>
		{
			public T H;
			public T S;
			public T V;
		}

		public struct CMYK<T>
		{
			public T C;
			public T M;
			public T Y;
			public T K;
		}

		public struct XYZ<T>
		{
			public T X;
			public T Y;
			public T Z;
		}
	}
}
