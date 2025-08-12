using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        // 设置要扫描的源码目录
        string sourceDirectory = @"E:\source\neo-minecraft-bedrock-protocol\neo-raknet";  // 修改为你的项目路径

        // 设置输出文件
        string outputFile = "methods.txt";

        if (!Directory.Exists(sourceDirectory))
        {
            Console.WriteLine($"目录不存在: {sourceDirectory}");
            return;
        }

        var methodSignatures = new List<string>();

        // 获取所有 .cs 文件
        var csFiles = Directory.GetFiles(sourceDirectory, "Packet.cs", SearchOption.AllDirectories);

        foreach (var file in csFiles)
        {
            try
            {
                string code = File.ReadAllText(file);
                SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
                var root = tree.GetRoot();

                // 查找所有方法声明
                var methods = root.DescendantNodes()
                                  .OfType<MethodDeclarationSyntax>();

                foreach (var method in methods)
                {
                    // 跳过构造函数、析构器、属性访问器等
                    if (method is ConstructorDeclarationSyntax ||
                        method is DestructorDeclarationSyntax ||
                        method.Parent is AccessorDeclarationSyntax)
                        continue;

                    string returnType = method.ReturnType.ToString();
                    string methodName = method.Identifier.Text;

                    // 格式化参数：int a, string b
                    string parameters = string.Join(", ", method.ParameterList.Parameters.Select(p =>
                        $"{p.Type} {p.Identifier}"));

                    // 按格式拼接：$return$ $method$($parameters$)
                    string signature = $"{returnType} {methodName}({parameters})";
                    methodSignatures.Add(signature);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"解析文件出错: {file} - {ex.Message}");
            }
        }

        // 按字母排序
        methodSignatures.Sort();

        // 写入文件
        File.WriteAllLines(outputFile, methodSignatures, System.Text.Encoding.UTF8);

        Console.WriteLine($"✅ 成功提取 {methodSignatures.Count} 个方法签名");
        Console.WriteLine($"📁 已保存到: {Path.GetFullPath(outputFile)}");
    }
}