using neo_raknet.Packet.MinecraftPacket.neo_raknet.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neo_raknet.Packet.MinecraftPacket
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;  // For Color/RGBA (replace with your actual RGBA type if different)
    using System.Net.Sockets;
    // Assuming necessary namespaces for Vector3 (mgl32.Vec3) and Color (color.RGBA)
    // You might need to adjust these based on your actual libraries.
    // Example assumptions:
    using System.Numerics; // For Vector3 (replace with your actual Vec3 type if different)

    namespace neo_raknet.Protocol // Or your relevant namespace
    {
        /// <summary>
        /// Represents the different types of shapes that can be drawn by the debug drawer.
        /// </summary>
        public enum ScriptDebugShapeType : byte // Go's iota defaults to int, but uint8 is specified in DebugDrawerShape.Type
        {
            /// <summary>
            /// Represents a line shape.
            /// </summary>
            Line = 0,

            /// <summary>
            /// Represents a box shape.
            /// </summary>
            Box = 1,

            /// <summary>
            /// Represents a sphere shape.
            /// </summary>
            Sphere = 2,

            /// <summary>
            /// Represents a circle shape.
            /// </summary>
            Circle = 3,

            /// <summary>
            /// Represents a text shape.
            /// </summary>
            Text = 4,

            /// <summary>
            /// Represents an arrow shape.
            /// </summary>
            Arrow = 5
        }

        /// <summary>
        /// DebugDrawerShape represents a shape that can be drawn by the debug drawer.
        /// </summary>
        public class DebugDrawerShape
        {
            /// <summary>
            /// NetworkID is the network ID of the shape.
            /// </summary>
            public ulong NetworkID { get; set; } // uint64 -> ulong

            /// <summary>
            /// Type is the type of the shape.
            /// </summary>
            public Optional<byte> Type { get; set; } // protocol.Optional[uint8] -> Optional<byte>
                                                     // Note: If you prefer to use the enum directly, you could define it as Optional<ScriptDebugShapeType>
                                                     // and handle the conversion (byte <-> enum) during serialization if needed by the protocol.

            /// <summary>
            /// Location is the location of the shape.
            /// </summary>
            public Optional<Vector3> Location { get; set; } // protocol.Optional[mgl32.Vec3] -> Optional<Vector3>

            /// <summary>
            /// Scale is the scale of the shape.
            /// </summary>
            public Optional<float> Scale { get; set; } // protocol.Optional[float32] -> Optional<float>

            /// <summary>
            /// Rotation is the rotation of the shape.
            /// </summary>
            public Optional<Vector3> Rotation { get; set; } // protocol.Optional[mgl32.Vec3] -> Optional<Vector3>

            /// <summary>
            /// TotalTimeLeft is the total time left of the shape.
            /// </summary>
            public Optional<float> TotalTimeLeft { get; set; } // protocol.Optional[float32] -> Optional<float>

            /// <summary>
            /// Colour is the ARGB colour of the shape.
            /// </summary>
            public Optional<Int32> Colour { get; set; } // protocol.Optional[color.RGBA] -> Optional<Color>
                                                        // Note: Ensure your Color/RGBA type maps correctly. System.Drawing.Color is one option,
                                                        // or you might have a custom RGBA struct. The serialization method (Write/Read ARGB)
                                                        // from methods.txt should be compatible.

            /// <summary>
            /// Text is the text of the shape.
            /// </summary>
            public Optional<string> Text { get; set; } // protocol.Optional[string] -> Optional<string>

            /// <summary>
            /// BoxBound is the box bound of the shape.
            /// </summary>
            public Optional<Vector3> BoxBound { get; set; } // protocol.Optional[mgl32.Vec3] -> Optional<Vector3>

            /// <summary>
            /// LineEndLocation is the line end location of the shape.
            /// </summary>
            public Optional<Vector3> LineEndLocation { get; set; } // protocol.Optional[mgl32.Vec3] -> Optional<Vector3>

            /// <summary>
            /// ArrowHeadLength is the arrow head length of the shape.
            /// </summary>
            public Optional<float> ArrowHeadLength { get; set; } // protocol.Optional[float32] -> Optional<float>

            /// <summary>
            /// ArrowHeadRadius is the arrow head radius of the shape.
            /// </summary>
            public Optional<float> ArrowHeadRadius { get; set; } // protocol.Optional[float32] -> Optional<float>

            /// <summary>
            /// Segments is the number of segments of the shape.
            /// </summary>
            public Optional<byte> Segments { get; set; } // protocol.Optional[byte] -> Optional<byte>

            /// <summary>
            /// Initializes a new instance of the DebugDrawerShape class.
            /// </summary>
            public DebugDrawerShape()
            {
                // Optional<T> fields are initialized to their default (unset) state by the Optional<T> struct itself.
                // Value-type fields like NetworkID are initialized to 0.
            }
        }
    }
    public class McbeServerScriptDebugDrawer : Packet
    {
        public List<DebugDrawerShape> Shapes { get; set; } = new List<DebugDrawerShape>(); // List of shapes to be drawn by the debug drawer

        public McbeServerScriptDebugDrawer()
        {
            Id = 328; // Assuming this is the correct ID for ServerScriptDebugDrawer
            IsMcpe = true; // Marking this as a MCPE 
        }

        protected override void EncodePacket()
        {
            base.EncodePacket();
            WriteUnsignedVarInt((uint)Shapes.Count); // Write the number of shapes
            foreach (var shape in Shapes)
            {
                Write(shape.NetworkID);
                // Write Type (Optional<uint8> -> Optional<byte>)
                Write(shape.Type.HasValue);
                if (shape.Type.HasValue)
                {
                    Write(shape.Type.Value); // Write the byte value
                }

                // Write Location (Optional<Vector3>)
                Write(shape.Location.HasValue);
                if (shape.Location.HasValue)
                {
                    Write(shape.Location.Value); // Assumes Write(Vector3) exists
                }
                Write(shape.Scale.HasValue);
                if (shape.Scale.HasValue)
                {
                    Write(shape.Scale.Value); // Write float
                }

                // Write Rotation (Optional<Vector3>)
                Write(shape.Rotation.HasValue);
                if (shape.Rotation.HasValue)
                {
                   Write(shape.Rotation.Value); // Assumes Write(Vector3) exists
                }

                // Write TotalTimeLeft (Optional<float32> -> Optional<float>)
                Write(shape.TotalTimeLeft.HasValue);
                if (shape.TotalTimeLeft.HasValue)
                {
                    Write(shape.TotalTimeLeft.Value); // Write float
                }

                // Write Colour (Optional<color.RGBA> -> Optional<Color>)
                Write(shape.Colour.HasValue);
                if (shape.Colour.HasValue)
                {
                    // Assumes Packet has a Write method for your Color/RGBA type that writes ARGB.
                    // If not, you might need WriteARGB(shape.Colour.Value) or similar.
                   Write(shape.Colour.Value);
                }

                // Write Text (Optional<string>)
                Write(shape.Text.HasValue); // Write bool indicating if Text is set
                if (shape.Text.HasValue)
                {
                  Write(shape.Text.Value); // Write string
                }

                // Write BoxBound (Optional<Vector3>)
                Write(shape.BoxBound.HasValue); // Write bool indicating if BoxBound is set
                if (shape.BoxBound.HasValue)
                {
                   Write(shape.BoxBound.Value); // Assumes Write(Vector3) exists
                }

                // Write LineEndLocation (Optional<Vector3>)
                Write(shape.LineEndLocation.HasValue); // Write bool indicating if LineEndLocation is set
                if (shape.LineEndLocation.HasValue)
                {
                   Write(shape.LineEndLocation.Value); // Assumes Write(Vector3) exists
                }

                // Write ArrowHeadLength (Optional<float32> -> Optional<float>)
                Write(shape.ArrowHeadLength.HasValue); // Write bool indicating if ArrowHeadLength is set
                if (shape.ArrowHeadLength.HasValue)
                {
                   Write(shape.ArrowHeadLength.Value); // Write float
                }

                // Write ArrowHeadRadius (Optional<float32> -> Optional<float>)
             Write(shape.ArrowHeadRadius.HasValue); // Write bool indicating if ArrowHeadRadius is set
                if (shape.ArrowHeadRadius.HasValue)
                {
                    Write(shape.ArrowHeadRadius.Value); // Write float
                }

                // Write Segments (Optional<byte>)
                Write(shape.Segments.HasValue);
                if (shape.Segments.HasValue)
                {
                  Write(shape.Segments.Value); // Write byte
                }

            }
        }

        protected override void DecodePacket()
        {
            base.DecodePacket();
            var count = ReadUnsignedVarLong();
            Shapes = new List<DebugDrawerShape>();
            Shapes.Clear(); // Clear existing shapes before reading new ones
            for (int i = 0; i < count; i++)
            {
                var shape = new DebugDrawerShape();

                // Read NetworkID (ulong)
                shape.NetworkID = ReadUlong(); // methods.txt: ulong ReadUlong()

                // Read Type (Optional<byte>)
                bool hasType = ReadBool(); // methods.txt: bool ReadBool()
                if (hasType)
                {
                    shape.Type = new Optional<byte>(ReadByte()); // methods.txt: byte ReadByte()
                }

                // Read Location (Optional<Vector3>)
                bool hasLocation = ReadBool();
                if (hasLocation)
                {
                    shape.Location = new Optional<Vector3>(ReadVector3()); // methods.txt: Vector3 ReadVector3()
                }

                // Read Scale (Optional<float>)
                bool hasScale = ReadBool();
                if (hasScale)
                {
                    shape.Scale = new Optional<float>(ReadFloat()); // methods.txt: float ReadFloat()
                }

                // Read Rotation (Optional<Vector3>)
                bool hasRotation = ReadBool();
                if (hasRotation)
                {
                    shape.Rotation = new Optional<Vector3>(ReadVector3()); // methods.txt: Vector3 ReadVector3()
                }

                // Read TotalTimeLeft (Optional<float>)
                bool hasTotalTimeLeft = ReadBool();
                if (hasTotalTimeLeft)
                {
                    shape.TotalTimeLeft = new Optional<float>(ReadFloat()); // methods.txt: float ReadFloat()
                }

                // Read Colour (Optional<Color>)
                bool hasColour = ReadBool();
                if (hasColour)
                {
                    // Assumes Packet has a Read method for your Color/RGBA type that reads ARGB.
                    // If not, you might need ReadARGB() or similar.
                    shape.Colour = new Optional<Int32>(ReadInt()); // Placeholder - Replace with actual method
                                                                           // If methods.txt has specific color read methods like ReadARGB, use that.
                                                                           // Example: shape.Colour = new Optional<Color>(ReadARGB());
                }

                // Read Text (Optional<string>)
                bool hasText = ReadBool();
                if (hasText)
                {
                    shape.Text = new Optional<string>(ReadString()); // methods.txt: string ReadString()
                }

                // Read BoxBound (Optional<Vector3>)
                bool hasBoxBound = ReadBool();
                if (hasBoxBound)
                {
                    shape.BoxBound = new Optional<Vector3>(ReadVector3()); // methods.txt: Vector3 ReadVector3()
                }

                // Read LineEndLocation (Optional<Vector3>)
                bool hasLineEndLocation = ReadBool();
                if (hasLineEndLocation)
                {
                    shape.LineEndLocation = new Optional<Vector3>(ReadVector3()); // methods.txt: Vector3 ReadVector3()
                }

                // Read ArrowHeadLength (Optional<float>)
                bool hasArrowHeadLength = ReadBool();
                if (hasArrowHeadLength)
                {
                    shape.ArrowHeadLength = new Optional<float>(ReadFloat()); // methods.txt: float ReadFloat()
                }

                // Read ArrowHeadRadius (Optional<float>)
                bool hasArrowHeadRadius = ReadBool();
                if (hasArrowHeadRadius)
                {
                    shape.ArrowHeadRadius = new Optional<float>(ReadFloat()); // methods.txt: float ReadFloat()
                }

                // Read Segments (Optional<byte>)
                bool hasSegments = ReadBool();
                if (hasSegments)
                {
                    shape.Segments = new Optional<byte>(ReadByte()); // methods.txt: byte ReadByte()
                }
            }
        }
    }
}
