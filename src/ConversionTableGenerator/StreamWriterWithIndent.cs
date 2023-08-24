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
        if (this.isNewLine)
        {
            for (int i = 0; i < this.Indent * 4; i++)
                this.writer.Write(' ');
            this.isNewLine = false;
        }
        this.writer.Write(s);
    }
    public void WriteLine(string? s = null)
    {
        if (this.isNewLine)
        {
            for (int i = 0; i < this.Indent * 4; i++)
                this.writer.Write(' ');
        }
        this.writer.WriteLine(s);
        this.isNewLine = true;
    }
    public void Dispose()
    {
        this.writer.Dispose();
    }
}
