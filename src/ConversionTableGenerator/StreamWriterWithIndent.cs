namespace ConversionTableGenerator;

public sealed class StreamWriterWithIndent : IDisposable
{
    private readonly StreamWriter writer;
    private bool isNewLine = true;
    public int Indent { get; set; } = 0;
    public StreamWriterWithIndent(FileInfo file)
    {
        file.Directory?.Create();
        this.writer = new StreamWriter(file.FullName, false);
    }
    public void Write(string s)
    {
        if (isNewLine)
        {
            for (int i = 0; i < Indent * 4; i++)
                writer.Write(' ');
            isNewLine = false;
        }
        writer.Write(s);
    }
    public void WriteLine(string? s = null)
    {
        if (isNewLine)
        {
            for (int i = 0; i < Indent * 4; i++)
                writer.Write(' ');
        }
        writer.WriteLine(s);
        isNewLine = true;
    }
    public void Dispose()
    {
        this.writer.Dispose();
    }
}
