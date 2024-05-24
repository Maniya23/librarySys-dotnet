// See https://aka.ms/new-console-template for more information

using LibruaryManagementSys;

Console.WriteLine("Welcome to library management system");

List<Book> bookList = new List<Book>();
const string startMessage = @"
1. Add a new book store
2. View all books in store
3. View books in store by book name
4. View all books from author
5. Add a new user to system

Enter the number on which operation to be performed : ";
bool validInput = false;
int selectedOptionInt = 0;

while (true)
{
    while (!validInput)
    {
        try
        {
            Console.Write(startMessage);
            var selectedOption = Console.ReadLine();

            if (int.TryParse(selectedOption, out selectedOptionInt) & selectedOptionInt >= 0 & selectedOptionInt < 6)
            {
                validInput = true;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error occured " + e.Message);
        }
    }
    
    if (selectedOptionInt == 0)
    {
        break;
    }

    switch (selectedOptionInt)
    {
        case 1:
            AddBook();
            validInput = false;
            break;
        case 2:
            ViewBooks();
            validInput = false;
            break;
        case 3:
            // code for viewing books by name
            break;
        case 4:
            // code for viewing books by author
            break;
        case 5:
            // code for adding new user
            break;
        default:
            Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
            break;
    }
}

void AddBook()
{
    while (true){
        try
        {
            Console.Write("Enter book id : ");
            string? bookId = Console.ReadLine();
            Console.Write("Enter book title : ");
            string? title = Console.ReadLine();
            Console.Write("Enter book author : ");
            string? author = Console.ReadLine();
            Console.Write("Enter book category : ");
            string? category = Console.ReadLine();
            
            if (string.IsNullOrEmpty(bookId) || string.IsNullOrEmpty(title) || string.IsNullOrEmpty(author) || string.IsNullOrEmpty(category))
            {
                Console.WriteLine("Please enter valid values for title, author and category.");
                continue;
            }
            
            Book book = new Book(bookId, title, author, category);
            // Book book = new Book("b001", "Book Title", "Author Name", "Category");
            bookList.Add(book);
            break;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}

void ViewBooks()
{
    foreach (var book in bookList)
    {
        Console.WriteLine($"" +
                          $"Book Id : {book.BookId}\n" +
                          $"Title : {book.Title}\n" +
                          $"Author : {book.Author}\n" +
                          $"Category : {book.Category}\n"
                          );
    }
    // Console.WriteLine(bookList[0].ToString());

}