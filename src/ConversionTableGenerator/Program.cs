using ConversionTableGenerator;
using ConversionTableGenerator.PropertyWriters.Lunar;
using System.Diagnostics;

{
    var file = new FileInfo("./outputs/LunarTables.txt");
    var properties = new IPropertyWriter[]
    {
        new ConstantProperties(1901),
        new NianStartDayNumberTable(1901, 2100),
        new RunyueIndexTable(1901, 2100),
        new RiCountOfYueTable(1901, 2100),
    };

    using var writer = new StreamWriterWithIndent(file);
    writer.WriteLine($"internal static class LunarTables");
    writer.WriteLine($"{{");
    writer.Indent++;
    foreach (var property in properties)
    {
        property.WriteDefinition(writer);
        writer.WriteLine();
    }
    writer.WriteLine();

    writer.WriteLine($"static LunarTables()");
    writer.WriteLine($"{{");
    writer.Indent++;

    foreach (var property in properties)
    {
        writer.WriteLine($"{{");
        writer.Indent++;

        property.WriteInitialization(writer);

        writer.Indent--;
        writer.WriteLine($"}}");
        writer.WriteLine();
    }

    writer.Indent--;
    writer.WriteLine($"}}");
    writer.Indent--;
    writer.WriteLine($"}}");

    Debug.Assert(writer.Indent is 0);
}
