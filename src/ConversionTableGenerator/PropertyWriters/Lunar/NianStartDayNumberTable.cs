using Lunar;

namespace ConversionTableGenerator.PropertyWriters.Lunar;
internal sealed class NianStartDayNumberTable : IPropertyWriter
{
    private readonly int startingYear;
    private readonly int endingYear;
    public NianStartDayNumberTable(int startingYear, int endingYear)
    {
        this.startingYear = startingYear;
        this.endingYear = endingYear;
    }

    private readonly string itemType = "int";
    private readonly string propertyName = nameof(NianStartDayNumberTable);

    public void WriteDefinition(StreamWriterWithIndent writer)
    {
        writer.WriteLine($"internal static ImmutableArray<{itemType}> {propertyName} {{ get; }}");
    }

    public void WriteInitialization(StreamWriterWithIndent writer)
    {
        writer.WriteLine($"// {propertyName}");
        writer.WriteLine($"var builder = ImmutableArray.CreateBuilder<{itemType}>();");
        for (int year = startingYear; year < endingYear; year++)
        {
            var firstDaySolar = global::Lunar.Lunar.FromYmdHms(year, 1, 1).Solar;
            var firstDayDateTime = new DateTime(firstDaySolar.Year, firstDaySolar.Month, firstDaySolar.Day);
            var firstDayDateOnly = DateOnly.FromDateTime(firstDayDateTime);
            writer.WriteLine($"builder.Add({firstDayDateOnly.DayNumber}); // {firstDayDateOnly:yyyy M-d}");
        }
        writer.WriteLine($"{propertyName} = builder.MoveToImmutable();");
    }
}
