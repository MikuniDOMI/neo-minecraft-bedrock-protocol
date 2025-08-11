using neo_raknet.Packet.MinecraftStruct;
using Version = neo_raknet.Packet.MinecraftStruct.Version;

namespace neo_raknet.Packet.MinecraftPacket;

public class EnumData
{
    public EnumData(string name, string[] values)
    {
        Name = name;
        Values = values;
    }

    public string Name { get; set; }
    public string[] Values { get; set; }
}

public class McpeAvailableCommands : Packet
{
    public McpeAvailableCommands()
    {
        Id = 0x4c;
        IsMcpe = true;
    }

    public CommandSet CommandSet { get; set; }

    public List<Command> CommandList { get; set; } = new();

    protected override void EncodePacket()
    {
        base.EncodePacket();


        try
        {
            if (CommandSet == null || CommandSet.Count == 0)
            {
                WriteUnsignedVarInt(0); // enum value size
                WriteUnsignedVarInt(0); // ch subcom value
                WriteUnsignedVarInt(0); // postfix size
                WriteUnsignedVarInt(0); // enums size
                WriteUnsignedVarInt(0); // subcom data
                WriteUnsignedVarInt(0); // command size
                WriteUnsignedVarInt(0); // soft enum size
                WriteUnsignedVarInt(0); // enum constraints
                return;
            }

            var commands = CommandSet;

            var stringList = new List<string>();
            {
                foreach (var command in commands.Values)
                {
                    var aliases = command.Versions[0].Aliases.Concat(new[] { command.Name }).ToArray();
                    foreach (var alias in aliases)
                        if (!stringList.Contains(alias))
                            stringList.Add(alias);

                    var overloads = command.Versions[0].Overloads;
                    foreach (var overload in overloads.Values)
                    {
                        var parameters = overload.Input.Parameters;
                        if (parameters == null) continue;
                        foreach (var parameter in parameters)
                            if (parameter.Type == "stringenum")
                            {
                                if (parameter.EnumValues == null) continue;
                                foreach (var enumValue in parameter.EnumValues)
                                    if (!stringList.Contains(enumValue))
                                        stringList.Add(enumValue);
                            }
                    }
                }

                WriteUnsignedVarInt((uint)stringList.Count); // Enum values
                foreach (var s in stringList) Write(s);
                //Log.Debug($"String: {s}, {(short) stringList.IndexOf(s)} ");
            }

            WriteUnsignedVarInt(0); // subcommand values
            WriteUnsignedVarInt(0); // Postfixes

            var enumList = new List<string>();
            foreach (var command in commands.Values)
            {
                if (command.Versions[0].Aliases.Length > 0)
                {
                    var aliasEnum = command.Name + "CommandAliases";
                    if (!enumList.Contains(aliasEnum)) enumList.Add(aliasEnum);
                }

                var overloads = command.Versions[0].Overloads;
                foreach (var overload in overloads.Values)
                {
                    var parameters = overload.Input.Parameters;
                    if (parameters == null) continue;
                    foreach (var parameter in parameters)
                        if (parameter.Type == "stringenum")
                        {
                            if (parameter.EnumValues == null) continue;

                            if (!enumList.Contains(parameter.EnumType)) enumList.Add(parameter.EnumType);
                        }
                }
            }

            //WriteUnsignedVarInt(0); // Enum indexes
            WriteUnsignedVarInt((uint)enumList.Count); // Enum indexes
            var writtenEnumList = new List<string>();
            foreach (var command in commands.Values)
            {
                if (command.Versions[0].Aliases.Length > 0)
                {
                    var aliases = command.Versions[0].Aliases.Concat(new[] { command.Name }).ToArray();
                    var aliasEnum = command.Name + "CommandAliases";
                    if (!enumList.Contains(aliasEnum)) continue;
                    if (writtenEnumList.Contains(aliasEnum)) continue;

                    Write(aliasEnum);
                    WriteUnsignedVarInt((uint)aliases.Length);
                    foreach (var enumValue in aliases)
                    {
                        if (!stringList.Contains(enumValue))
                            Console.WriteLine($"Expected enum value: {enumValue} in string list, but didn't find it.");
                        if (stringList.Count <= byte.MaxValue)
                            Write((byte)stringList.IndexOf(enumValue));
                        else if (stringList.Count <= short.MaxValue)
                            Write((short)stringList.IndexOf(enumValue));
                        else
                            Write(stringList.IndexOf(enumValue));

                        //Log.Debug($"EnumType: {aliasEnum}, {enumValue}, {stringList.IndexOf(enumValue)} ");
                    }
                }

                var overloads = command.Versions[0].Overloads;
                foreach (var overload in overloads.Values)
                {
                    var parameters = overload.Input.Parameters;
                    if (parameters == null) continue;
                    foreach (var parameter in parameters)
                        if (parameter.Type == "stringenum")
                        {
                            if (parameter.EnumValues == null) continue;

                            if (!enumList.Contains(parameter.EnumType)) continue;
                            if (writtenEnumList.Contains(parameter.EnumType)) continue;

                            writtenEnumList.Add(parameter.EnumType);

                            Write(parameter.EnumType);
                            WriteUnsignedVarInt((uint)parameter.EnumValues.Length);
                            foreach (var enumValue in parameter.EnumValues)
                            {
                                if (!stringList.Contains(enumValue))
                                    Console.WriteLine(
                                        $"Expected enum value: {enumValue} in string list, but didn't find it.");
                                if (stringList.Count <= byte.MaxValue)
                                    Write((byte)stringList.IndexOf(enumValue));
                                else if (stringList.Count <= short.MaxValue)
                                    Write((short)stringList.IndexOf(enumValue));
                                else
                                    Write(stringList.IndexOf(enumValue));
                                //Log.Debug($"EnumType: {parameter.EnumType}, {enumValue}, {stringList.IndexOf(enumValue)} ");
                            }
                        }
                }
            }

            WriteUnsignedVarInt(0); // chained subcommands

            WriteUnsignedVarInt((uint)commands.Count);
            foreach (var command in commands.Values)
            {
                Write(command.Name);
                Write(command.Versions[0].Description);
                Write((short)0); // flags
                Write((byte)command.Versions[0].CommandPermission); // permissions

                if (command.Versions[0].Aliases.Length > 0)
                {
                    var aliasEnum = command.Name + "CommandAliases";
                    Write(enumList.IndexOf(aliasEnum));
                }
                else
                {
                    Write(-1); // Enum index
                }

                //Log.Warn($"Writing command {command.Name}");

                WriteUnsignedVarInt(0);
                var overloads = command.Versions[0].Overloads;
                WriteUnsignedVarInt((uint)overloads.Count); // Overloads
                foreach (var overload in overloads.Values)
                {
                    Write(false);
                    //Log.Warn($"Writing command: {command.Name}");

                    var parameters = overload.Input.Parameters;
                    if (parameters != null)
                        foreach (var parameter in parameters)
                            if (parameter.Type == "softenum" || parameter.Type == "value" ||
                                parameter.Type == "blockpos" || parameter.Type == "entitypos")
                                parameters = null;

                    if (parameters == null)
                    {
                        WriteUnsignedVarInt(0); // Parameter count
                        continue;
                    }

                    WriteUnsignedVarInt((uint)parameters.Length);
                    foreach (var parameter in parameters)
                        //Log.Debug($"Writing command overload parameter {command.Name}, {parameter.Name}, {parameter.Type}");
                        if (parameter.Type == "stringenum" && parameter.EnumValues != null)
                        {
                            Write(parameter.Name); // parameter name
                            Write(0x200000 | enumList.IndexOf(parameter.EnumType));
                            Write(parameter.Optional); // optional
                            Write((byte)0); // unknown
                        }
                        else if (parameter.Type == "softenum" && parameter.EnumValues != null)
                        {
                            //todo
                        }
                        else
                        {
                            Write(parameter.Name); // parameter name
                            Write(0x100000 | GetParameterTypeId(parameter.Type)); // param type
                            Write(parameter.Optional); // optional
                            Write((byte)0); // unknown
                        }
                }
            }

            WriteUnsignedVarInt(0); //TODO: soft enums

            WriteUnsignedVarInt(0); //TODO: constraints
        }
        catch (Exception e)
        {
            Console.WriteLine("Sending commands", e);
            //throw;
        }
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        var enumValueCount = ReadUnsignedVarInt();
        for (var i = 0; i < enumValueCount; i++)
        {
            var str = ReadString();
        }

        var chainedValueCount = ReadUnsignedVarInt();
        for (var i = 0; i < chainedValueCount; i++)
        {
            var str = ReadString();
        }

        var postfixCount = ReadUnsignedVarInt();
        for (var i = 0; i < postfixCount; i++)
        {
            var str = ReadString();
        }

        var enumDataCount = ReadUnsignedVarInt();
        for (var i = 0; i < enumDataCount; i++)
        {
            var str = ReadString();
            var valuesCount = ReadUnsignedVarInt();
            var enumValue = 0;
            for (var a = 0; a < valuesCount; a++)
                if (enumValueCount <= byte.MaxValue)
                    enumValue = ReadByte();
                else if (enumValueCount <= short.MaxValue)
                    enumValue = ReadShort();
                else
                    enumValue = ReadInt();
        }

        var chainedValueData = ReadUnsignedVarInt();
        for (var i = 0; i < chainedValueData; i++)
        {
            var str = ReadString();
            var valuesCount = ReadUnsignedVarInt();
            for (var a = 0; a < valuesCount; a++)
            {
                var subcommandData1 = ReadShort();
                var subcommandData2 = ReadShort();
            }
        }

        var commandCount = ReadUnsignedVarInt();
        for (var i = 0; i < commandCount; i++)
        {
            var name = ReadString();
            var description = ReadString();
            var flags = ReadShort();
            var permission = ReadByte();
            var alias = ReadInt();

            var subcmdIndex = ReadUnsignedVarInt();
            for (var a = 0; a < subcmdIndex; a++)
            {
                var index = ReadShort();
            }

            var overloads = ReadUnsignedVarInt();
            for (var a = 0; a < overloads; a++)
            {
                var changing = ReadBool();
                var parametrs = ReadUnsignedVarInt();
                for (var b = 0; b < parametrs; b++)
                {
                    var prameterName = ReadString();
                    var symbol = ReadInt();
                    var optional = ReadBool();
                    var options = ReadByte();
                }
            }

            var data = new Version();
            data.Description = description;

            var command = new Command();
            command.Name = name;
            command.Versions = [data];

            CommandList.Add(command);
        }

        var softEnumCount = ReadUnsignedVarInt();
        for (var a = 0; a < softEnumCount; a++)
        {
            var enumName = ReadString();
            var optionCount = ReadUnsignedVarInt();
            for (var b = 0; b < optionCount; b++)
            {
                var value = ReadString();
            }
        }

        var constraintsCount = ReadUnsignedVarInt();
        for (var a = 0; a < constraintsCount; a++)
        {
            var symbol = ReadInt();
            var symbolValue = ReadInt();
            var constraintIndices = ReadUnsignedVarInt();
            for (var b = 0; b < constraintIndices; b++)
            {
                var index = ReadByte();
            }
        }
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();
    }

    private int GetParameterTypeId(string type)
    {
        return type switch
        {
            "enum"            => -1,
            "unknown"         => 0,
            "int"             => 0x01,
            "float"           => 0x03,
            "mixed"           => 0x04,
            "wildcardint"     => 0x05,
            "operator"        => 0x06,
            "operatorcompare" => 0x06,
            "target"          => 0x08,
            "wildcardtarget"  => 0x0A,
            "filename"        => 0x11,
            "fullintrange"    => 0x17,
            "equipmentslot"   => 0x2B,
            "string"          => 0x2C,
            "blockpositon"    => 0x34,
            "pos"             => 0x35,
            "message"         => 0x37,
            "rawtext"         => 0x3A,
            "json"            => 0x3E,
            "blockstates"     => 0x47,
            "command"         => 0x4A,
            _                 => 0
        };
    }

    private string GetParameterTypeName(int type)
    {
        return type switch
        {
            -1   => "enum",
            0    => "unknown",
            0x01 => "int",
            0x03 => "float",
            0x04 => "mixed",
            0x05 => "wildcardint",
            0x06 => "operator",
            0x07 => "operatorcompare",
            0x08 => "target",
            0x0A => "wildcardtarget",
            0x11 => "filename",
            0x17 => "fullintrange",
            0x2B => "equipmentslot",
            0x2C => "string",
            0x34 => "blockpositon",
            0x35 => "pos",
            0x37 => "message", // kick, me, etc
            0x3A => "rawtext", // kick, me, etc
            0x3E => "json", // give, replace
            0x47 => "blockstates",
            0x4A => "command",
            _    => $"undefined({type})"
        };
    }
}