namespace LibruaryManagementSys;

public class Book
{
    private int _bookId;
    private string? _title;
    private string _author;
    private string _category;
    
    public Book(int bookId, string? title, string author, string category)
    {
        this._bookId = bookId;
        this._title = title;
        this._author = author;
        this._category = category;
    }

    public int BookId
    {
        get => _bookId;
        set => _bookId = value;
    }

    public string? Title
    {
        get => _title;
        set => _title = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Author
    {
        get => _author;
        set => _author = value;
    }

    public string Category
    {
        get => _category;
        set => _category = value ?? throw new ArgumentNullException(nameof(value));
    }
}