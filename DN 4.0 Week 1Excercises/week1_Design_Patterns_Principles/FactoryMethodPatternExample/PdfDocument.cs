using System;

// IDocument.cs
public interface IDocument
{
    void Open();
}

// WordDocument.cs
public class WordDocument : IDocument
{
    public void Open()
    {
        Console.WriteLine("Opening Word document");
    }
}

// PdfDocument.cs
public class PdfDocument : IDocument
{
    public void Open()
    {
        Console.WriteLine("Opening PDF document");
    }
}

// ExcelDocument.cs
public class ExcelDocument : IDocument
{
    public void Open()
    {
        Console.WriteLine("Opening Excel document");
    }
}

// DocumentFactory.cs
public abstract class DocumentFactory
{
    public abstract IDocument CreateDocument();
}

// WordDocumentFactory.cs
public class WordDocumentFactory : DocumentFactory
{
    public override IDocument CreateDocument()
    {
        return new WordDocument();
    }
}

// PdfDocumentFactory.cs
public class PdfDocumentFactory : DocumentFactory
{
    public override IDocument CreateDocument()
    {
        return new PdfDocument();
    }
}

// ExcelDocumentFactory.cs
public class ExcelDocumentFactory : DocumentFactory
{
    public override IDocument CreateDocument()
    {
        return new ExcelDocument();
    }
}

// Program.cs
public class Program
{
    public static void Main(string[] args)
    {
        DocumentFactory wordFactory = new WordDocumentFactory();
        IDocument wordDoc = wordFactory.CreateDocument();
        wordDoc.Open();

        DocumentFactory pdfFactory = new PdfDocumentFactory();
        IDocument pdfDoc = pdfFactory.CreateDocument();
        pdfDoc.Open();

        DocumentFactory excelFactory = new ExcelDocumentFactory();
        IDocument excelDoc = excelFactory.CreateDocument();
        excelDoc.Open();
    }
}
