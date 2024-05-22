// See https://aka.ms/new-console-template for more information

Console.WriteLine("Welcome to library management system");

const string startMessage = @"
1. Add a new book store
2. View all books in store
3. View books in store by book name
4. View all books from author
5. Add a new user to system

Enter the number on which operation to be performed : ";

Console.Write(startMessage);
var selectedOption = Console.ReadLine();
Console.WriteLine(selectedOption + "Selected");