using Lunar;

namespace ConversionTableGenerator.PropertyWriters.Solar;
internal sealed class SolarConstantProperties : IPropertyWriter
{
    private readonly int startingYear;
    public SolarConstantProperties(int startingYear)
    {
        this.startingYear = startingYear;
    }

    public void WriteDefinition(StreamWriterWithIndent writer)
    {
        var year = LunarYear.FromYear(this.startingYear);
        writer.WriteLine($"internal const int STARTING_NIAN = {this.startingYear};");

        var ganzhi = 6 * (year.GanIndex + 1) - 5 * (year.ZhiIndex + 1);
        ganzhi = (ganzhi + 60) % 60;
        writer.WriteLine($"internal const byte STARTING_NIAN_GANZHI = {ganzhi};");

        writer.WriteLine($"internal const byte RI_GANZHI_GUIHAI = " +
            $"{(new DateOnly(1949, 10, 1).DayNumber - 1) % 60};");
    }

    public void WriteInitialization(StreamWriterWithIndent writer)
    {
        writer.WriteLine($"// {nameof(SolarConstantProperties)}");
    }
}
