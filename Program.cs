// See https://aka.ms/new-console-template for more information

using System.Text.Json;
using LibruaryManagementSys;

Console.WriteLine("Welcome to library management system");

List<Book>? bookList = new List<Book>();
List<User>? userList = new List<User>();
Book book1 = new Book("b001", "Famous Five", "Enid Blyton", "Novel");
bookList.Add(book1);
const string startMessage = @"
1. Add a new book store
2. View all books in store
3. View books in store by book name
4. View all books from author
5. View books from category
6. Add a new user to system
7. Search user by name
8. Save books to file

Enter the number on which operation to be performed : ";
bool validInput = false;
int selectedOptionInt = 0;
LoadBookList();
LoadUserList();


while (true)
{
    while (!validInput)
    {
        try
        {
            Console.Write(startMessage);
            var selectedOption = Console.ReadLine();

            if (int.TryParse(selectedOption, out selectedOptionInt) & selectedOptionInt >= 0 & selectedOptionInt < 10)
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
            ViewAllBooks();
            validInput = false;
            break;
        
        case 3:
            ViewBooksByName();
            validInput = false;
            break;
        
        case 4:
            ViewBooksByAuthor();
            validInput = false;
            break;
        
        case 5:
            ViewBooksByCategory();
            validInput = false;
            break;
        
        case 6:
            AddNewUser();
            validInput = false;
            break;
        
        case 7:
            SearchUserByName();
            validInput = false;
            break;
        
        case 8:
            SaveBooksToFile();
            validInput = false;
            break;
        
        case 9:
            SaveUsersToFile();
            validInput = false;
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

void ViewAllBooks()
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

void ViewBooksByName()
{
    string? bookNameInput;
    bool foundBook = false;
    while (true)
    {
        try
        {
            Console.Write("Enter book name : ");
            bookNameInput = Console.ReadLine();

            if (!string.IsNullOrEmpty(bookNameInput))
            {
                break;

            }
            else
            {
                Console.WriteLine("Please enter a valid book title.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    foreach (var book in bookList)
    {
        if (string.Equals(book.Title, bookNameInput, StringComparison.CurrentCultureIgnoreCase))
        {
            Console.WriteLine(book.ToString());
            foundBook = true;
        }
    }

    if (!foundBook)
    {
        Console.WriteLine("No book found with the title " + bookNameInput);
    }
}

void ViewBooksByAuthor()
{
    string? authorNameInput;
    bool foundBook = false;
    while(true){
        try
        {
            Console.Write("Enter author name : ");
            authorNameInput = Console.ReadLine();

            if (!string.IsNullOrEmpty(authorNameInput))
            {
                break;
            }

            Console.WriteLine("Please enter a valid author name.");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    foreach (var book in bookList)
    {
        if (string.Equals(book.Author, authorNameInput, StringComparison.CurrentCultureIgnoreCase))
        {
            Console.WriteLine(book.ToString());
            foundBook = true;
        }
    }
    
    if (!foundBook)
    {
        Console.WriteLine("No book found with the category " + authorNameInput);
    }
}

void ViewBooksByCategory()
{
    string? categoryInput;
    bool foundBook = false;
    while(true){
        try
        {
            Console.Write("Enter category : ");
            categoryInput = Console.ReadLine();

            if (!string.IsNullOrEmpty(categoryInput))
            {
                break;
            }

            Console.WriteLine("Please enter a valid category.");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    foreach (var book in bookList)
    {
        if (string.Equals(book.Category, categoryInput, StringComparison.CurrentCultureIgnoreCase))
        {
            Console.WriteLine(book.ToString());
            foundBook = true;
        }
    }
    if (!foundBook)
    {
        Console.WriteLine("No book found with the category " + categoryInput);
    }
}

void AddNewUser()
{
    int userId;
    
    // Generate user ID
    if (userList.Count == 0)
    {
        userId = 1;
        Console.WriteLine("User ID : "+userId);
        
    }
    else
    {
        userId = userList[-1].UserId + 1;
    }

    // Get user values
    while (true)
    {
        try
        {
            Console.Write("Please enter your name : ");
            string? name = Console.ReadLine();

            Console.Write("Please enter your email : ");
            string? email = Console.ReadLine();

            Console.Write("Please enter your contact number : ");
            string? contact = Console.ReadLine();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(contact))
            {
                Console.WriteLine("Please enter valid values for name, email and contact.");
                continue;
            }
            
            // Create new user
            User user = new User(userId, name, email, contact);
            userList.Add(user);
            break;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}

void SearchUserByName()
{
    bool foundUser = false;
    string? userName;
    while (true)
    {
        try
        {
            Console.WriteLine();
            Console.WriteLine("Please enter the name of the user : ");
            userName = Console.ReadLine();

            if (string.IsNullOrEmpty(userName))
            {
                Console.WriteLine("Please enter a valid name.");
                continue;
            }
            break;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    foreach (var user in userList)
    {
        if (string.Equals(user.Name, userName, StringComparison.CurrentCultureIgnoreCase))
        {
            Console.WriteLine(user.ToString());
            foundUser = true;
        }
    }

    if (!foundUser)
    {
        Console.WriteLine("No user found with the name " + userName);
    }
}

void SaveBooksToFile()
{
    try
    {
        if (bookList.Count != 0)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(bookList, options);

            File.WriteAllText("bookList.json", jsonString);
            Console.WriteLine("Books successfully saved to file.");
        }
        else
        {
            Console.WriteLine("No books are created.\nCreate books to save to a file.");
        }
    }
    catch (Exception e)
    {
        Console.WriteLine("Error occured while saving books to file : " + e.Message);
    }
}

void SaveUsersToFile()
{
    try
    {
        if (userList.Count != 0)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(userList, options);

            File.WriteAllText("userList.json", jsonString);
            Console.WriteLine("Users successfully saved to file.");
        }
        else
        {
            Console.WriteLine("No users are created.\nCreate users to save to a file.");
        }
    }
    catch (Exception e)
    {
        Console.WriteLine("Error occured while saving users to file : " + e.Message);
        throw;
    }
}

void LoadBookList()
{
    try
    {
        if (File.Exists("bookList.json"))
        {
            string jsonString = File.ReadAllText("bookList.json");
            bookList = JsonSerializer.Deserialize<List<Book>>(jsonString);
        }
        else
        {
            Console.WriteLine("Books file not found");
        }
    }
    catch (Exception e)
    {
        Console.WriteLine("Error occured while loading books from file : " + e.Message);
    }
}

void LoadUserList()
{
    try
    {
        if (File.Exists("userList.json"))
        {
            string jsonString = File.ReadAllText("userList.json");
            userList = JsonSerializer.Deserialize<List<User>>(jsonString);
        }
        else
        {
            Console.WriteLine("User file not found");
        }
    }
    catch (Exception e)
    {
        Console.WriteLine("Error occured while loading books from file : " + e.Message);
        throw;
    }
}