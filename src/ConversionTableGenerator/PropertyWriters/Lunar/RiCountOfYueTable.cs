﻿using Lunar;
using System.Diagnostics;
using System.Text;

namespace ConversionTableGenerator.PropertyWriters.Lunar;
internal sealed class RiCountOfYueTable(int startingYear, int endingYear) : IPropertyWriter
{
    private readonly string itemType = "short";
    private readonly string propertyName = nameof(RiCountOfYueTable);

    public void WriteDefinition(StreamWriterWithIndent writer)
    {
        writer.WriteLine($"internal static ImmutableArray<{this.itemType}> {this.propertyName} {{ get; }} = [");
        writer.Indent++;
        for (int year = startingYear; year < endingYear; year++)
        {
            writer.Write($"0b");
            bool hasRunyue = false;

            var comment = new StringBuilder();
            var yues = LunarYear.FromYear(year).MonthsInYear;
            Trace.Assert(yues[^1].Month is 12 or (-12), "不支持非十二个月（不含闰月）者");
            foreach (var yue in yues)
            {
                if (yue.Leap)
                {
                    Trace.Assert(hasRunyue is false, "不支持两个闰月");
                    hasRunyue = true;
                    _ = comment.Append('L');
                }
                else
                {
                    _ = comment.Append('C');
                }

                Trace.Assert(yue.DayCount is 29 or 30);

                var n = yue.DayCount is 29 ? 0 : 1;
                writer.Write($"{n}");
                _ = comment.Append($"{yue.DayCount} ");
            }

            if (!hasRunyue)
                writer.Write($"0");
            writer.WriteLine($", // {year:0000} {comment}");
        }
        writer.Indent--;
        writer.WriteLine($"];");
    }

    public bool RequireInitialization => false;
    public void WriteInitialization(StreamWriterWithIndent writer) { }
}
