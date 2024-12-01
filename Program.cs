using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public bool IsAvailable { get; set; }

        public Book(string title, string author, bool isAvailable)
        {
            Title = title;
            Author = author;
            IsAvailable = isAvailable;
        }
    }

    public class Library
    {
        private List<Book> books;

        public Library()
        {
            books = new List<Book>();
        }

        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public List<Book> SearchByTitle(string title)
        {
            return books.Where(b => b.Title.ToLower().Contains(title.ToLower())).ToList();
        }

        public List<Book> SearchByAuthor(string author)
        {
            return books.Where(b => b.Author.ToLower().Contains(author.ToLower())).ToList();
        }

        public void CheckAvailability(string title)
        {
            var book = books.FirstOrDefault(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (book != null)
            {
                Console.WriteLine($"{book.Title} by {book.Author} is {(book.IsAvailable ? "available" : "not available")}");
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            library.AddBook(new Book("The Lord of the Rings", "J.R.R. Tolkien", true));
            library.AddBook(new Book("Pride and Prejudice", "Jane Austen", false));
            library.AddBook(new Book("To Kill a Mockingbird", "Harper Lee", true));

            while (true)
            {
                Console.WriteLine("\nLibrary Menu:");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Search by Title");
                Console.WriteLine("3. Search by Author");
                Console.WriteLine("4. Check Availability");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter book title: ");
                            string title = Console.ReadLine();
                            Console.Write("Enter author: ");
                            string author = Console.ReadLine();
                            Console.Write("Is the book available? (true/false): ");
                            bool isAvailable = bool.Parse(Console.ReadLine());
                            library.AddBook(new Book(title, author, isAvailable));
                            Console.WriteLine("Book added successfully.");
                            break;

                        case 2:
                            Console.Write("Enter title to search: ");
                            string searchTitle = Console.ReadLine();
                            var foundBooksByTitle = library.SearchByTitle(searchTitle);
                            if (foundBooksByTitle.Any())
                            {
                                Console.WriteLine("Books found:");
                                foreach (var book in foundBooksByTitle)
                                {
                                    Console.WriteLine($"- {book.Title} by {book.Author}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("No books found.");
                            }
                            break;

                        case 3:
                            Console.Write("Enter author to search: ");
                            string searchAuthor = Console.ReadLine();
                            var foundBooksByAuthor = library.SearchByAuthor(searchAuthor);
                            if (foundBooksByAuthor.Any())
                            {
                                Console.WriteLine("Books found:");
                                foreach (var book in foundBooksByAuthor)
                                {
                                    Console.WriteLine($"- {book.Title} by {book.Author}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("No books found.");
                            }
                            break;

                        case 4:
                            Console.Write("Enter the title of the book to check availability: ");
                            string checkTitle = Console.ReadLine();
                            library.CheckAvailability(checkTitle);
                            break;

                        case 5:
                            Console.WriteLine("Exiting the program.");
                            return;

                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }
    }
}