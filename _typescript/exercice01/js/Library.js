class Library {
    constructor(id, books) {
        this.books = [];
        this.id = id;
        this.books = books;
    }
    addBook(book) {
        this.books.push(book);
    }
    removeBook(book) {
        this.books = this.books.filter(b => b.id !== book.id);
    }
    findBookbyTitle(title) {
        return this.books.find(b => b.title === title);
    }
    listAvailableBooks() {
        return this.books.filter(b => b.isAvailable);
    }
    getBooksByAuthor(authorName) {
        return this.books.filter(b => b.author.name === authorName);
    }
    getLibrary() {
        return `ID : ${this.id}, books : ${this.books}`;
    }
}
