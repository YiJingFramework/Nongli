namespace ConversionTableGenerator.PropertyWriters.Lunar;
internal sealed class NianStartDayNumberTable(int startingYear, int endingYear) : IPropertyWriter
{
    private readonly string itemType = "int";
    private readonly string propertyName = nameof(NianStartDayNumberTable);

    public void WriteDefinition(StreamWriterWithIndent writer)
    {
        writer.WriteLine($"internal static ImmutableArray<{this.itemType}> {this.propertyName} {{ get; }} = [");
        writer.Indent++;
        for (int year = startingYear; year < endingYear; year++)
        {
            var firstDaySolar = global::Lunar.Lunar.FromYmdHms(year, 1, 1).Solar;
            var firstDayDateTime = new DateTime(firstDaySolar.Year, firstDaySolar.Month, firstDaySolar.Day);
            var firstDayDateOnly = DateOnly.FromDateTime(firstDayDateTime);
            writer.WriteLine($"{firstDayDateOnly.DayNumber}, // {firstDayDateOnly:yyyy M-d}");
        }
        writer.Indent--;
        writer.WriteLine($"];");
    }

    public bool RequireInitialization => false;
    public void WriteInitialization(StreamWriterWithIndent writer) { }
}
