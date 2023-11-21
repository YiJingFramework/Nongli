using ConversionTableGenerator;
using ConversionTableGenerator.PropertyWriters.Lunar;
using ConversionTableGenerator.PropertyWriters.Solar;
using System.Diagnostics;

#if !DEBUG
Console.WriteLine("不在 Debug 模式下启动可能导致检查不生效。");
#endif

var minYear = 1901;
var maxYear = 2200;

{
    var file = new FileInfo("./outputs/LunarTables.txt");
    var properties = new IPropertyWriter[]
    {
        new LunarConstantProperties(minYear),
        new NianStartDayNumberTable(minYear, maxYear),
        new RunyueIndexTable(minYear, maxYear),
        new RiCountOfYueTable(minYear, maxYear),
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

    bool constructorWritten = false;
    foreach (var property in properties)
    {
        if (property.RequireInitialization)
        {
            if(!constructorWritten)
            {
                constructorWritten = true;
                writer.WriteLine();
                writer.WriteLine($"static LunarTables()");
                writer.WriteLine($"{{");
                writer.Indent++;
            }

            writer.WriteLine($"{{");
            writer.Indent++;

            property.WriteInitialization(writer);

            writer.Indent--;
            writer.WriteLine($"}}");
            writer.WriteLine();
        }
    }

    if(constructorWritten)
    {
        writer.Indent--;
        writer.WriteLine($"}}");
    }

    writer.Indent--;
    writer.WriteLine($"}}");

    Debug.Assert(writer.Indent is 0);
}

{
    var file = new FileInfo("./outputs/SolarTables.txt");
    var properties = new IPropertyWriter[]
    {
        new SolarConstantProperties(minYear),
        new JieQiTickTable(minYear, maxYear)
    };

    using var writer = new StreamWriterWithIndent(file);
    writer.WriteLine($"internal static class SolarTables");
    writer.WriteLine($"{{");
    writer.Indent++;
    foreach (var property in properties)
    {
        property.WriteDefinition(writer);
        writer.WriteLine();
    }

    bool constructorWritten = false;
    foreach (var property in properties)
    {
        if (property.RequireInitialization)
        {
            if (!constructorWritten)
            {
                constructorWritten = true;
                writer.WriteLine();
                writer.WriteLine($"static SolarTables()");
                writer.WriteLine($"{{");
                writer.Indent++;
            }

            writer.WriteLine($"{{");
            writer.Indent++;

            property.WriteInitialization(writer);

            writer.Indent--;
            writer.WriteLine($"}}");
            writer.WriteLine();
        }
    }

    if (constructorWritten)
    {
        writer.Indent--;
        writer.WriteLine($"}}");
    }

    writer.Indent--;
    writer.WriteLine($"}}");

    Debug.Assert(writer.Indent is 0);
}
