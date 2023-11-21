using Lunar;
using System.Diagnostics;

namespace ConversionTableGenerator.PropertyWriters.Lunar;
internal sealed class LunarConstantProperties : IPropertyWriter
{
    private readonly int startingYear;
    public LunarConstantProperties(int startingYear)
    {
        Debug.Assert(startingYear >= 0, "InChineseExtensions 不支持小于零者");
        this.startingYear = startingYear;
    }

    public void WriteDefinition(StreamWriterWithIndent writer)
    {
        var year = LunarYear.FromYear(this.startingYear);
        writer.WriteLine($"internal const int STARTING_NIAN = {this.startingYear};");

        var ganzhi = 6 * (year.GanIndex + 1) - 5 * (year.ZhiIndex + 1);
        ganzhi = (ganzhi + 60) % 60;
        writer.WriteLine($"internal const byte STARTING_NIAN_GANZHI = {ganzhi};");
    }

    public bool RequireInitialization => false;
    public void WriteInitialization(StreamWriterWithIndent writer) { }
}
