using Lunar;
using System.Diagnostics;

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
        writer.WriteLine($"internal static ImmutableArray<{this.itemType}> {this.propertyName} {{ get; }}");
    }

    public void WriteInitialization(StreamWriterWithIndent writer)
    {
        writer.WriteLine($"// {this.propertyName}");
        var count = this.endingYear - this.startingYear;
        writer.WriteLine($"var builder = ImmutableArray.CreateBuilder<{this.itemType}>({count} * 24);");
        for (int year = this.startingYear; year < this.endingYear; year++)
        {
            var jieqiList = LunarYear.FromYear(year).JieQiJulianDays
                .Skip(Array.IndexOf(global::Lunar.Lunar.JIE_QI_IN_USE, "立春"))
                .Take(24)
                .Select(x => DateTime.FromOADate(x - 2415018.5))
                .ToArray();

            for (int i = 0; i < 24; i++)
            {
                writer.WriteLine($"builder.Add({jieqiList[i].Ticks}); // {year:0000} {i:00}");
            }
        }
        writer.WriteLine($"{this.propertyName} = builder.MoveToImmutable();");
    }
}
