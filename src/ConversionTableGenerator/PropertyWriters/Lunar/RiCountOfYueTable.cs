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
        writer.WriteLine($"internal static ImmutableArray<{this.itemType}> {this.propertyName} {{ get; }}");
    }

    public void WriteInitialization(StreamWriterWithIndent writer)
    {
        writer.WriteLine($"// {this.propertyName}");
        var count = this.endingYear - this.startingYear;
        writer.WriteLine($"var builder = ImmutableArray.CreateBuilder<{this.itemType}>({count});");
        for (int year = this.startingYear; year < this.endingYear; year++)
        {
            writer.Write($"builder.Add(0b");
            bool hasRunyue = false;

            var comment = new StringBuilder();
            var yues = LunarYear.FromYear(year).MonthsInYear;
            Debug.Assert(yues[^1].Month is 12, "不支持非十二个月（不含闰月）者");
            foreach (var yue in yues)
            {
                if (yue.Leap)
                {
                    Debug.Assert(hasRunyue is false, "不支持两个闰月");
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
        writer.WriteLine($"{this.propertyName} = builder.MoveToImmutable();");
    }
}
