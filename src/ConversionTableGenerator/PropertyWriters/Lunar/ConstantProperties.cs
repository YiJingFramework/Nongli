﻿using Lunar;

namespace ConversionTableGenerator.PropertyWriters.Lunar;
internal sealed class ConstantProperties : IPropertyWriter
{
    private readonly int startingYear;
    public ConstantProperties(int startingYear)
    {
        this.startingYear = startingYear;
    }

    public void WriteDefinition(StreamWriterWithIndent writer)
    {
        var year = LunarYear.FromYear(this.startingYear);
        writer.WriteLine($"internal const int STARTING_NIAN = {this.startingYear};");
        writer.WriteLine($"internal const byte STARTING_NIAN_GAN_INDEX = {year.GanIndex + 1};");
        writer.WriteLine($"internal const byte STARTING_NIAN_ZHI_INDEX = {year.ZhiIndex + 1};");
    }

    public void WriteInitialization(StreamWriterWithIndent writer)
    {
        writer.WriteLine($"// {nameof(ConstantProperties)}");
    }
}