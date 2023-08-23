using Lunar;
using System.Diagnostics;
using System.Text;

Directory.CreateDirectory("./outputs");

{
    using var output = new StreamWriter("./outputs/LunarTables.txt");
    output.WriteLine($"internal static class LunarTables");
    output.WriteLine($"{{");

    var startingYear = 1901;
    {
        var year = LunarYear.FromYear(startingYear);
        output.WriteLine($"    internal const int STARTING_NIAN = {startingYear};");
        output.WriteLine($"    internal const byte STARTING_NIAN_GAN_INDEX = {year.GanIndex + 1};");
        output.WriteLine($"    internal const byte STARTING_NIAN_ZHI_INDEX = {year.ZhiIndex + 1};");
        output.WriteLine();
    }

    {
        output.WriteLine($"    internal static int[] NianStartDateTable {{ get; }} =");
        output.WriteLine($"    {{");
        for (int year = startingYear; year < 2100; year++)
        {
            var firstDaySolar = Lunar.Lunar.FromYmdHms(year, 1, 1).Solar;
            var firstDayDateTime = new DateTime(firstDaySolar.Year, firstDaySolar.Month, firstDaySolar.Day);
            var firstDayDateOnly = DateOnly.FromDateTime(firstDayDateTime);
            output.WriteLine($"        {firstDayDateOnly.DayNumber}, // {firstDayDateOnly:yyyy M-d}");
        }
        output.WriteLine($"    }};");
        output.WriteLine();
    }

    {
        output.WriteLine($"    internal static byte[] RunyueIndexTable {{ get; }} =");
        output.WriteLine($"    {{");
        for (int year = startingYear; year < 2100; year++)
        {
            var runyue = LunarYear.FromYear(year).LeapMonth;
            output.WriteLine($"        {runyue}, // {year}");
        }
        output.WriteLine($"    }};");
        output.WriteLine();
    }

    {
        output.WriteLine($"    internal static short[] RiCountInYueTable {{ get; }} =");
        output.WriteLine($"    {{");
        for (int year = startingYear; year < 2100; year++)
        {
            output.Write($"        0b");
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
                output.Write($"{n}");
                _ = comment.Append($"{yue.DayCount} ");
            }

            if(!hasRunyue)
                output.Write($"0");
            output.WriteLine($", // {year:0000} {comment}");
        }
        output.WriteLine($"    }};");
        output.WriteLine();
    }

    output.WriteLine($"}}");
}
