using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace neo_raknet.Utils
{
	public class PersonaPiece
	{
		public string PieceId { get; set; }
		public string PieceType { get; set; }
		public string PackId { get; set; }
		public bool IsDefaultPiece { get; set; }
		public string ProductId { get; set; }
	}
	public class SkinPiece
	{
		public string PieceType { get; set; }
		public List<string> Colors { get; set; } = new List<string>();
	}
	public class SkinResourcePatch : ICloneable
	{
		public GeometryIdentifier Geometry { get; set; }

		[JsonProperty(PropertyName = "persona_reset_resource_definitions")]
		public bool PersonaResetResourceDefinitions { get; set; }

		public object Clone()
		{
			var cloned = (SkinResourcePatch)MemberwiseClone();
			cloned.Geometry = (GeometryIdentifier)Geometry?.Clone();

			return cloned;
		}
	}

	public class GeometryIdentifier : ICloneable
	{
		public string Default { get; set; }

		[JsonProperty(PropertyName = "animated_face")]
		public string AnimatedFace { get; set; }

		public object Clone()
		{
			return MemberwiseClone();
		}
	}

	public class Skin : ICloneable
	{
		public bool Slim { get; set; }
		public bool IsPersonaSkin { get; set; }
		public bool IsPremiumSkin { get; set; }

		public Cape Cape { get; set; } = new Cape();
		public string SkinId { get; set; }

		public string PlayFabId { get; set; }

		public string ResourcePatch { get; set; } // contains GeometryName

		public SkinResourcePatch SkinResourcePatch
		{
			get => ToJSkinResourcePatch(ResourcePatch);
			set => ResourcePatch = ToJson(value);
		} // contains GeometryName

		public int Height { get; set; }
		public int Width { get; set; }
		public byte[] Data { get; set; }
		public string GeometryName { get; set; }
		public string GeometryData { get; set; }
		public string GeometryDataVersion { get; set; } = "0.0.0";

		public string ArmSize { get; set; }

		public string SkinColor { get; set; }

		public string AnimationData { get; set; }
		public List<Animation> Animations { get; set; } = new List<Animation>();

		public List<PersonaPiece> PersonaPieces { get; set; } = new List<PersonaPiece>();
		public List<SkinPiece> SkinPieces { get; set; } = new List<SkinPiece>();
		public bool IsVerified { get; set; }
		public bool IsPrimaryUser { get; set; }
		public bool isOverride { get; set; } = true;

		public static byte[] GetTextureFromFile(string filename)
		{
			var bitmap = Image.Load<Rgba32>(filename);// new Image<Rgba32>(filename);

			var size = bitmap.Height * bitmap.Width * 4;

			if (size != 0x2000 && size != 0x4000 && size != 0x10000)
				return null;

			byte[] bytes = new byte[size];

			int i = 0;
			for (int y = 0; y < bitmap.Height; y++)
			{
				for (int x = 0; x < bitmap.Width; x++)
				{
					var color = bitmap[x, y];
					bytes[i++] = color.R;
					bytes[i++] = color.G;
					bytes[i++] = color.B;
					bytes[i++] = color.A;
				}
			}

			return bytes;
		}

		public static void SaveTextureToFile(string filename, byte[] bytes)
		{
			var size = bytes.Length;

			int width = size == 0x10000 ? 128 : 64;
			var height = size == 0x2000 ? 32 : (size == 0x4000 ? 64 : 128);

			var bitmap = new Image<Rgba32>(width, height);

			int i = 0;
			for (int y = 0; y < bitmap.Height; y++)
			{
				for (int x = 0; x < bitmap.Width; x++)
				{
					byte r = bytes[i++];
					byte g = bytes[i++];
					byte b = bytes[i++];
					byte a = bytes[i++];

					bitmap[x, y] = new Rgba32(r, g, b, a);
				}
			}

			bitmap.Save(filename);
		}

		public static GeometryModel Parse(string json)
		{
			var settings = new JsonSerializerSettings();
			settings.NullValueHandling = NullValueHandling.Ignore;
			settings.DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate;
			settings.MissingMemberHandling = MissingMemberHandling.Error;
			settings.Formatting = Formatting.Indented;
			settings.ContractResolver = new CamelCasePropertyNamesContractResolver();

			return JsonConvert.DeserializeObject<GeometryModel>(json, settings);
		}

		public static string ToJson(GeometryModel geometryModel)
		{
			var settings = new JsonSerializerSettings();
			settings.NullValueHandling = NullValueHandling.Ignore;
			settings.DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate;
			settings.MissingMemberHandling = MissingMemberHandling.Error;
			//settings.Formatting = Formatting.Indented;
			settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
			settings.Converters.Add(new StringEnumConverter { NamingStrategy = new CamelCaseNamingStrategy() });

			return JsonConvert.SerializeObject(geometryModel, settings);
		}


		public static string ToJson(SkinResourcePatch model)
		{
			var settings = new JsonSerializerSettings();
			settings.NullValueHandling = NullValueHandling.Ignore;
			settings.DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate;
			settings.MissingMemberHandling = MissingMemberHandling.Error;
			//settings.Formatting = Formatting.Indented;
			settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
			settings.Converters.Add(new StringEnumConverter
			{
				NamingStrategy = new CamelCaseNamingStrategy()
			});

			string json = JsonConvert.SerializeObject(model, settings);

			return json;
		}

		public static SkinResourcePatch ToJSkinResourcePatch(string json)
		{
			var settings = new JsonSerializerSettings();
			settings.NullValueHandling = NullValueHandling.Ignore;
			settings.DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate;
			settings.MissingMemberHandling = MissingMemberHandling.Error;
			//settings.Formatting = Formatting.Indented;
			settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
			settings.Converters.Add(new StringEnumConverter
			{
				NamingStrategy = new CamelCaseNamingStrategy()
			});

			var obj = JsonConvert.DeserializeObject<SkinResourcePatch>(json, settings);

			return obj;
		}

		public object Clone()
		{
			var clonedSkin = (Skin)MemberwiseClone();
			clonedSkin.Data = Data?.Clone() as byte[];
			clonedSkin.Cape = Cape?.Clone() as Cape;
			clonedSkin.SkinResourcePatch = SkinResourcePatch?.Clone() as SkinResourcePatch;

			foreach (Animation animation in Animations)
			{
				clonedSkin.Animations.Add((Animation)animation.Clone());
			}

			return clonedSkin;
		}
	}
}
