using Lunar;

namespace ConversionTableGenerator.PropertyWriters.Lunar;
internal sealed class RunyueIndexTable(int startingYear, int endingYear) : IPropertyWriter
{
    private readonly string itemType = "byte";
    private readonly string propertyName = nameof(RunyueIndexTable);

    public void WriteDefinition(StreamWriterWithIndent writer)
    {
        writer.WriteLine($"internal static ImmutableArray<{this.itemType}> {this.propertyName} {{ get; }} = [");
        writer.Indent++;
        for (int year = startingYear; year < endingYear; year++)
        {
            var runyue = LunarYear.FromYear(year).LeapMonth;
            writer.WriteLine($"{runyue}, // {year:0000}");
        }
        writer.Indent--;
        writer.WriteLine($"];");
    }

    public bool RequireInitialization => false;
    public void WriteInitialization(StreamWriterWithIndent writer) { }
}
