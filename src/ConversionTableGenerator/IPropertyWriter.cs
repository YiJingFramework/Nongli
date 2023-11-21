namespace ConversionTableGenerator;

public interface IPropertyWriter
{
    void WriteDefinition(StreamWriterWithIndent writer);
    bool RequireInitialization { get; }
    void WriteInitialization(StreamWriterWithIndent writer);
}
