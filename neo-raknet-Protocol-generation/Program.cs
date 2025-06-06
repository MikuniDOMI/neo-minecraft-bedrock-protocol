using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

class PacketSplitter
{
    static void Main(string[] args)
    {
        string inputFile = "input.cs.#";
        string outputDir = "Output";

        Directory.CreateDirectory(outputDir);

        string content = File.ReadAllText(inputFile);

        string pattern = @"
            public\s+partial\s+class\s+(\w+)\s*:\s*Packet<\w+>\s*
            ({ 
                (?: 
                    [^{}] 
                    | (?<Open>{) 
                    | (?<-Open>}) 
                )* 
                (?(Open)(?!)) 
            })";

        var matches = Regex.Matches(content, pattern,
            RegexOptions.IgnorePatternWhitespace | RegexOptions.Singleline);

        foreach (Match match in matches)
        {
            string className = match.Groups[1].Value;
            string classContent = match.Value;

            classContent = Regex.Replace(
                classContent,
                @":\s*Packet<\w+>\s*",
                ": Packet"
            );

            string outputContent = $"using neo_raknet.Packet; \n namespace neo_raknet.Packet.MinecraftPacket\n{{\n{classContent}\n}}";

            File.WriteAllText(
                Path.Combine(outputDir, $"{className}.cs"),
                outputContent
            );

            Console.WriteLine($"已生成: {className}.cs");
        }
    }
}