using Lunar;

namespace ConversionTableGenerator.PropertyWriters.Lunar;
internal sealed class RunyueIndexTable : IPropertyWriter
{
    private readonly int startingYear;
    private readonly int endingYear;
    public RunyueIndexTable(int startingYear, int endingYear)
    {
        this.startingYear = startingYear;
        this.endingYear = endingYear;
    }

    private readonly string itemType = "byte";
    private readonly string propertyName = nameof(RunyueIndexTable);

    public void WriteDefinition(StreamWriterWithIndent writer)
    {
        writer.WriteLine($"internal static ImmutableArray<{this.itemType}> {this.propertyName} {{ get; }}");
    }

    public void WriteInitialization(StreamWriterWithIndent writer)
    {
        writer.WriteLine($"// {this.propertyName}");
        writer.WriteLine($"var builder = ImmutableArray.CreateBuilder<{this.itemType}>();");
        for (int year = this.startingYear; year < this.endingYear; year++)
        {
            var runyue = LunarYear.FromYear(year).LeapMonth;
            writer.WriteLine($"builder.Add({runyue}); // {year:0000}");
        }
        writer.WriteLine($"{this.propertyName} = builder.MoveToImmutable();");
        writer.WriteLine();
    }
}
