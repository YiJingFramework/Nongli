﻿namespace ConversionTableGenerator.PropertyWriters.Lunar;
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
        writer.WriteLine($"internal static ImmutableArray<{this.itemType}> {this.propertyName} {{ get; }}");
    }

    public void WriteInitialization(StreamWriterWithIndent writer)
    {
        writer.WriteLine($"// {this.propertyName}");
        var count = this.endingYear - this.startingYear;
        writer.WriteLine($"var builder = ImmutableArray.CreateBuilder<{this.itemType}>({count});");
        for (int year = this.startingYear; year < this.endingYear; year++)
        {
            var firstDaySolar = global::Lunar.Lunar.FromYmdHms(year, 1, 1).Solar;
            var firstDayDateTime = new DateTime(firstDaySolar.Year, firstDaySolar.Month, firstDaySolar.Day);
            var firstDayDateOnly = DateOnly.FromDateTime(firstDayDateTime);
            writer.WriteLine($"builder.Add({firstDayDateOnly.DayNumber}); // {firstDayDateOnly:yyyy M-d}");
        }
        writer.WriteLine($"{this.propertyName} = builder.MoveToImmutable();");
    }
}
