using Newtonsoft.Json;

namespace neo_raknet.Utils;

public class GeometryModel : ICloneable
{
    [JsonProperty(PropertyName = "format_version")]
    public string FormatVersion { get; set; } = "1.12.0";

    [JsonProperty(PropertyName = "minecraft:geometry")]
    public List<Geometry> Geometry { get; set; } = new();

    public object Clone()
    {
        var model = (GeometryModel)MemberwiseClone();
        model.Geometry = new List<Geometry>();
        foreach (var records in Geometry) model.Geometry.Add((Geometry)records.Clone());

        return model;
    }

    public Geometry FindGeometry(string geometryName, bool matchPartial = true)
    {
        var fullName = Geometry.FirstOrDefault(g => matchPartial
                ? g.Description.Identifier.StartsWith(geometryName, StringComparison.InvariantCultureIgnoreCase)
                : g.Description.Identifier.Equals(geometryName, StringComparison.InvariantCultureIgnoreCase))
            ?.Description.Identifier;

        if (fullName == null) return null;

        var geometry = Geometry.First(g => g.Description.Identifier == fullName);
        geometry.Name = fullName;

        //if (fullName.Contains(":"))
        //{
        //	geometry.BaseGeometry = fullName.Split(':')[1];
        //}

        return geometry;
    }

    public Geometry CollapseToDerived(Geometry derived)
    {
        if (derived == null) throw new ArgumentNullException(nameof(derived));

        return derived;

        /*var collapsed = (Geometry) derived.Clone();

        if (collapsed.BaseGeometry != null)
        {
            Geometry baseGeometry = (Geometry) FindGeometry(collapsed.BaseGeometry).Clone();

            foreach (var bone in baseGeometry.Bones)
            {
                if (collapsed.Bones.SingleOrDefault(b => b.Name == bone.Name) == null)
                {
                    collapsed.Bones.Add(bone);
                }
            }
        }

        return collapsed;*/
    }
}