using Lunar;
using System.Diagnostics;
using System.Text;

namespace ConversionTableGenerator.PropertyWriters.Lunar;
internal sealed class RiCountOfYueTable : IPropertyWriter
{
    private readonly int startingYear;
    private readonly int endingYear;
    public RiCountOfYueTable(int startingYear, int endingYear)
    {
        this.startingYear = startingYear;
        this.endingYear = endingYear;
    }

    private readonly string itemType = "short";
    private readonly string propertyName = nameof(RiCountOfYueTable);

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
            writer.Write($"builder.Add(0b");
            bool hasRunyue = false;

            var comment = new StringBuilder();
            foreach (var yue in LunarYear.FromYear(year).MonthsInYear)
            {
                if (yue.Leap)
                {
                    Debug.Assert(hasRunyue is false);
                    hasRunyue = true;
                    _ = comment.Append('L');
                }
                else
                {
                    _ = comment.Append('C');
                }

                Debug.Assert(yue.DayCount is 29 or 30);

                var n = yue.DayCount is 29 ? 0 : 1;
                writer.Write($"{n}");
                _ = comment.Append($"{yue.DayCount} ");
            }

            if (!hasRunyue)
                writer.Write($"0");
            writer.WriteLine($"); // {year:0000} {comment}");
        }
        writer.WriteLine($"{propertyName} = builder.MoveToImmutable();");
    }
}
