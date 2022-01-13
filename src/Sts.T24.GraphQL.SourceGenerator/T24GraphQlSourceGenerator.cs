using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Text;
using Sts.T24.GraphQL.Core.Model;

namespace Sts.T24.GraphQL.SourceGenerator;

[Generator]
public class T24GraphQlSourceGenerator : ISourceGenerator
{
    private string CreateXmlRecordClass(StandardSelectionXmlRecord standardSelection, string className)
    {
        var sbXml = new StringBuilder();
        sbXml.AppendLine("using System;");
        sbXml.AppendLine("using System.Xml.Serialization;");
        sbXml.AppendLine("using System.Linq;");
        sbXml.AppendLine("using System.Globalization;");
        sbXml.AppendLine($"using {typeof(T24XmlField).Namespace};");
        sbXml.AppendLine(@$"
                [Serializable]
                [XmlRoot(""row"")]
                public sealed partial class {className} : T24XmlRecord
                {{
            ");

        // Prepare fields' set
        for (var i = 1; i < standardSelection.TagNumbers.Length; i++)
        {
            // Check data flag
            if (standardSelection.DataFlags[i].Value != "D") continue;
            if (standardSelection.Names[i].Value.StartsWith("RESERVED")) continue;
            if (standardSelection.Names[i].Value == "LOCAL.REF") continue; // TODO Add LOCAL.REF support
            if (!int.TryParse(standardSelection.TagNumbers[i].Value, out var t24TagNumber)) continue;

            var t24FieldName = standardSelection.Names[i].Value;
            var t24FieldType = standardSelection.InputTypes[i].Value;
            var isMultiValue = standardSelection.MultiValueTypes[i].Value == "M";
            var propertyName = ConvertT24NameToCamelCase(t24FieldName);

            var xmlFieldType = t24FieldType switch
            {
                "IN2R" or "IN2AMT" => typeof(T24XmlDecimalField),
                _ => typeof(T24XmlStringField)
            };

            if (isMultiValue)
                sbXml.AppendLine(
                    @$"[XmlElement(ElementName = ""c{t24TagNumber}"")] public {xmlFieldType.Name}[] {propertyName} {{get;set;}} = Array.Empty<{xmlFieldType.Name}>();");
            else if(t24TagNumber != 0)
                sbXml.AppendLine(@$"[XmlElement(ElementName = ""c{t24TagNumber}"")] public {xmlFieldType.Name} {propertyName} {{get;set;}} = T24XmlField.Empty<{xmlFieldType.Name}>();");
        }

        sbXml.AppendLine("}");

        return sbXml.ToString();
    }

    private string ConvertT24NameToCamelCase(string name)
    {
        var parts = name.Split('.').Select(s => s.ToLowerInvariant());

        var sb = new StringBuilder();

        foreach (var part in parts)
        {
            var partSpan = part.AsSpan();
            sb.Append(char.ToUpper(partSpan[0]));
            if (partSpan.Length > 1)
                sb.Append(partSpan.Slice(1).ToArray());
        }

        return sb.ToString();
    }

    public string FormatUsingRoslyn(string sourceCode)
    {
        var tree = CSharpSyntaxTree.ParseText(sourceCode);
        var root = tree.GetRoot().NormalizeWhitespace();
        return root.ToFullString();
    }

    #region Implementation of ISourceGenerator

    /// <inheritdoc />
    public void Initialize(GeneratorInitializationContext context)
    {
    }

    /// <inheritdoc />
    public void Execute(GeneratorExecutionContext context)
    {
#if DEBUG
        if (!Debugger.IsAttached)
        {
            //Debugger.Launch();
        }
#endif

        // Find the main method
        var mainMethod = context.Compilation.GetEntryPoint(context.CancellationToken)!;

        var serializer = new XmlSerializer(typeof(StandardSelectionXmlRecord));

        foreach (var xml in context.AdditionalFiles
                     .Where(additionalText => Path.GetExtension(additionalText.Path) == ".xml")
                     .Select(additionalFile => File.ReadAllText(additionalFile.Path)))
        {
            using var reader = new StringReader(xml);
            if (serializer.Deserialize(reader) is not StandardSelectionXmlRecord standardSelection) throw new InvalidCastException();
            var baseClassName = ConvertT24NameToCamelCase(standardSelection.Id);
            var xmlClassName = baseClassName + "XmlRecord";
            var xmlSourceCode = FormatUsingRoslyn(CreateXmlRecordClass(standardSelection, xmlClassName));
            var sourceText = SourceText.From(xmlSourceCode, Encoding.UTF8);
            context.AddSource($"{xmlClassName}.g.cs", sourceText);
        }
    }

    #endregion
}