namespace ConversionTableGenerator;

public interface IPropertyWriter
{
    void WriteDefinition(StreamWriterWithIndent writer);
    void WriteInitialization(StreamWriterWithIndent writer);
}
