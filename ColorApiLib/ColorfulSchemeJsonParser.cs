using System.Runtime.Serialization;

namespace ColorApiLib
{
	[DataContract]
	public class ColorfulSchemeJsonParser
	{
		[DataMember(Name = "mode")]
		public string Mode { get; set; }

		[DataMember(Name = "count")]
		public int Count { get; set; }

		public colors[] Colors { get; set; }
	}

	[DataContract]
	public class colors
	{
		//TODO: Utilize ColorfulJsonParser to handle this since the attributes are the same.
	}
}
