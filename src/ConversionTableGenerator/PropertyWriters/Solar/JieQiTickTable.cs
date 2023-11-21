using Lunar;

namespace ConversionTableGenerator.PropertyWriters.Solar;
internal sealed class JieQiTickTable : IPropertyWriter
{
    private readonly int startingYear;
    private readonly int endingYear;
    public JieQiTickTable(int startingYear, int endingYear)
    {
        this.startingYear = startingYear;
        this.endingYear = endingYear;
    }

    private readonly string itemType = "long";
    private readonly string propertyName = nameof(JieQiTickTable);

    public void WriteDefinition(StreamWriterWithIndent writer)
    {
        writer.WriteLine($"internal static ImmutableArray<{this.itemType}> {this.propertyName} {{ get; }} = [");
        writer.Indent++;
        for (int year = this.startingYear; year < this.endingYear; year++)
        {
            var jieqiList = LunarYear.FromYear(year).JieQiJulianDays
                .Skip(Array.IndexOf(global::Lunar.Lunar.JIE_QI_IN_USE, "立春"))
                .Take(24)
                .Select(x => (long)((x - 1721425.5) * TimeSpan.TicksPerDay))
                .ToArray();

            for (int i = 0; i < 24; i++)
            {
                writer.WriteLine($"{jieqiList[i]}, // {year:0000} {i:00}");
            }
        }
        {
            var jieqiList = LunarYear.FromYear(this.endingYear).JieQiJulianDays
                .Skip(Array.IndexOf(global::Lunar.Lunar.JIE_QI_IN_USE, "立春"))
                .Take(1)
                .Select(x => (long)((x - 1721425.5) * TimeSpan.TicksPerDay))
                .ToArray();
            writer.WriteLine($"{jieqiList[0]}, // {this.endingYear:0000} {1:00}");
        }
        writer.Indent--;
        writer.WriteLine($"];");
    }

    public bool RequireInitialization => false;
    public void WriteInitialization(StreamWriterWithIndent writer) { }
}
