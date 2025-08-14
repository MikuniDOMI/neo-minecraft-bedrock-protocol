using System;
using System.Collections.Generic;
using System.Numerics; // Example for Vector3 - ADJUST BASED ON YOUR PROJECT
using neo_raknet.Packet; // Assuming base Packet class is here or adjust accordingly

namespace neo_raknet.Packet.MinecraftPacket
{
    // --- Enums ---
    /// <summary>
    /// Represents the type of action for the ClientBoundDebugRenderer packet.
    /// </summary>
    public enum ClientBoundDebugRendererType : uint
    {
        /// <summary>
        /// Indicates that existing debug renderers should be cleared.
        /// </summary>
        Clear = 1, // iota + 1 -> 1

        /// <summary>
        /// Indicates that a new cube debug renderer should be added.
        /// </summary>
        AddCube = 2 // iota + 1 -> 2
    }

    /// <summary>
    /// ClientBoundDebugRenderer is sent by the server to spawn an outlined cube on client-side.
    /// </summary>
    public class McpeClientBoundDebugRenderer : Packet
    {
        /// <summary>
        /// Type is the type of action. It is one of the constants (enum values) defined by ClientBoundDebugRendererType.
        /// </summary>
        public ClientBoundDebugRendererType Type { get; set; }

        /// <summary>
        /// Text is the text that is displayed above the debug.
        /// </summary>
        public string Text { get; set; } = string.Empty;

        /// <summary>
        /// Position is the position to spawn the debug on.
        /// </summary>
        public Vector3 Position { get; set; }

        /// <summary>
        /// Red is the red value from the RGBA colour rendered on the debug. This value is in the range 0-1.
        /// </summary>
        public float Red { get; set; }

        /// <summary>
        /// Green is the green value from the RGBA colour rendered on the debug. This value is in the range 0-1.
        /// </summary>
        public float Green { get; set; }

        /// <summary>
        /// Blue is the blue value from the RGBA colour rendered on the debug. This value is in the range 0-1.
        /// </summary>
        public float Blue { get; set; }

        /// <summary>
        /// Alpha is the alpha value from the RGBA colour rendered on the debug. This value is in the range 0-1.
        /// </summary>
        public float Alpha { get; set; }

        /// <summary>
        /// Duration is how long the debug will last in the world for. It is measured in milliseconds.
        /// </summary>
        public ulong Duration { get; set; } // uint64 in Go maps to ulong in C#

        /// <summary>
        /// Initializes a new instance of the McpeClientBoundDebugRenderer class.
        /// </summary>
        public McpeClientBoundDebugRenderer()
        {
            Id = 164; // IDClientBoundDebugRenderer
            IsMcpe = true;
        }

        /// <summary>
        /// Encodes the packet data.
        /// </summary>
        protected override void EncodePacket()
        {
            base.EncodePacket();

            Write((uint)Type); // Writes uint32 (void Write(uint value))
                               // Cast enum to its underlying uint value for writing

            if (Type == ClientBoundDebugRendererType.AddCube)
            {
                Write(Text);        // Writes string (void Write(string value))
                Write(Position);    // Writes Vector3 (void Write(Vector3 vec))
                Write(Red);         // Writes float (void Write(float value))
                Write(Green);       // Writes float (void Write(float value))
                Write(Blue);        // Writes float (void Write(float value))
                Write(Alpha);       // Writes float (void Write(float value))
                Write(Duration);    // Writes uint64/ulong (void Write(ulong value))
            }
        }

        /// <summary>
        /// Decodes the packet data.
        /// </summary>
        protected override void DecodePacket()
        {
            base.DecodePacket();

            Type = (ClientBoundDebugRendererType)ReadUint(); // Reads uint32 (uint ReadUint())
                                                             // Cast the read uint value to the enum type

            if (Type == ClientBoundDebugRendererType.AddCube)
            {
                Text = ReadString();        // Reads string (string ReadString())
                Position = ReadVector3();   // Reads Vector3 (Vector3 ReadVector3())
                Red = ReadFloat();          // Reads float (float ReadFloat())
                Green = ReadFloat();        // Reads float (float ReadFloat())
                Blue = ReadFloat();         // Reads float (float ReadFloat())
                Alpha = ReadFloat();        // Reads float (float ReadFloat())
                Duration = ReadUlong();     // Reads uint64/ulong (ulong ReadUlong())
            }
            // No else block
        }

        /// <summary>
        /// Resets the packet data to default values.
        /// </summary>
        protected override void ResetPacket()
        {
            base.ResetPacket();
            Type = 0; // Resets enum to its default (0), which is not one of the defined values.
                      // Consider if resetting to a specific defined value (like Clear) is more appropriate,
                      // or if 0 is acceptable as an "unset" state.
            Text = string.Empty;
            Position = Vector3.Zero;
            Red = 0.0f;
            Green = 0.0f;
            Blue = 0.0f;
            Alpha = 0.0f;
            Duration = 0;
        }
    }
}