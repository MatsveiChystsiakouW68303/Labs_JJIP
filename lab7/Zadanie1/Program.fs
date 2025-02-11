module LibrarySystem

open System

type Book(title: string, author: string, pages: int) =
    member this.Title = title
    member this.Author = author
    member this.Pages = pages
    member this.GetInfo() = $"Title: {title}, Author: {author}, Pages: {pages}"

type User(name: string) =
    let mutable borrowedBooks = []
    member this.Name = name
    member this.BorrowedBooks = borrowedBooks

    member this.BorrowBook(book: Book) =
        if borrowedBooks |> List.contains book then
            printfn "%s already borrowed the book: %s" name book.Title
        else
            borrowedBooks <- book :: borrowedBooks
            printfn "%s borrowed the book: %s" name book.Title

    member this.ReturnBook(book: Book) =
        if borrowedBooks |> List.contains book then
            borrowedBooks <- List.filter ((<>) book) borrowedBooks
            printfn "%s returned the book: %s" name book.Title
        else
            printfn "%s did not borrow the book: %s" name book.Title

type Library() =
    let mutable books = []

    member this.AddBook(book: Book) =
        books <- book :: books
        printfn "Book added: %s" (book.GetInfo())

    member this.RemoveBook(book: Book) =
        if books |> List.contains book then
            books <- List.filter ((<>) book) books
            printfn "Book removed: %s" (book.GetInfo())
        else
            printfn "Book not found: %s" book.Title

    member this.ListBooks() =
        if books.IsEmpty then
            printfn "No books available in the library."
        else
            printfn "Books in the library:"
            books |> List.iter (fun book -> printfn "%s" (book.GetInfo()))

[<EntryPoint>]
let main argv =
    let library = Library()
    let user = User("John Doe")

    let book1 = Book("The Great Gatsby", "F. Scott Fitzgerald", 180)
    let book2 = Book("1984", "George Orwell", 328)
    let book3 = Book("To Kill a Mockingbird", "Harper Lee", 281)

    library.AddBook(book1)
    library.AddBook(book2)
    library.AddBook(book3)

    library.ListBooks()

    user.BorrowBook(book1)
    user.BorrowBook(book2)

    printfn "Books borrowed by %s:" user.Name
    user.BorrowedBooks |> List.iter (fun book -> printfn "%s" (book.GetInfo()))

    user.ReturnBook(book1)

    library.ListBooks()

    library.RemoveBook(book1)
    library.ListBooks()

    0
