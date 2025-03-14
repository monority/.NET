
class Library {
    id: number
    books : Book[] = []

    constructor(id: number, books: Book[]) {
		this.id = id
		this.books = books

    }

   addBook(book: Book){
		this.books.push(book)
   }
   removeBook(book: Book){
		this.books = this.books.filter(b => b.id !== book.id)
   }
   findBookbyTitle (title : string) : Book | undefined {
		return this.books.find(b => b.title === title)
   }
   listAvailableBooks() : Book[] {	
		return this.books.filter(b => b.isAvailable)
   }

   getBooksByAuthor(authorName : string) : Book[] {
		return this.books.filter(b => b.author.name === authorName)
   }
   getLibrary(): string {
	return `ID: ${this.id}, books: ${JSON.stringify(this.books, null, 2)}`;

}

}


interface Author {
    id: number,
    name: string,	
    birthYear :string,
    genres : string[],
}

interface Book{
	id : number,
	title : string,
	author : Author,
	pages : number,
	isAvailable : boolean,
}


function createBook (author : Author, title : string, pages : number) : Book {
	return {
		id : Math.floor(Math.random()*100),
		title,
		author,
		pages,
		isAvailable : true
	}
}

function toggleAvailability(book : Book) : Book {
	return {
		...book,
		isAvailable : !book.isAvailable
	}
}

let Library01 = new Library(1, [])
let book01 = createBook({id: 1, name: "Stephen King", birthYear: "1947", genres: ["Horror", "Fantasy"]}, "The Shining", 447)
let book02 = createBook({id: 2, name: "Stephen King", birthYear: "1947", genres: ["Horror", "Fantasy"]}, "The Stand", 1153)
let book03 = createBook({id: 3, name: "J.K. Rowling", birthYear: "1965", genres: ["Fantasy"]}, "Harry Potter and the Philosopher's Stone", 223)
let book04 = createBook({id: 4, name: "George Orwell", birthYear: "1903", genres: ["Dystopian", "Political Fiction"]}, "1984", 328)
let book05 = createBook({id: 5, name: "J.R.R. Tolkien", birthYear: "1892", genres: ["Fantasy"]}, "The Hobbit", 310)
let book06 = createBook({id: 6, name: "F. Scott Fitzgerald", birthYear: "1896", genres: ["Tragedy"]}, "The Great Gatsby", 180)
let book07 = createBook({id: 7, name: "Harper Lee", birthYear: "1926", genres: ["Southern Gothic", "Bildungsroman"]}, "To Kill a Mockingbird", 281)

Library01.addBook(book01)
Library01.addBook(book02)
Library01.removeBook(book01)
Library01.addBook(book03)
console.log(Library01.getLibrary())
