/* Task Description */
/* 
 *	Create a module for working with books
 *	The module must provide the following functionalities:
 *	Add a new book to category
 *	Each book has unique title, author and ISBN
 *	It must return the newly created book with assigned ID
 *	If the category is missing, it must be automatically created
 *	List all books
 *	Books are sorted by ID
 *	This can be done by author, by category or all
 *	List all categories
 *	Categories are sorted by ID
 *	Each book/catagory has a unique identifier (ID) that is a number greater than or equal to 1
 *	When adding a book/category, the ID is generated automatically
 *	Add validation everywhere, where possible
 *	Book title and category name must be between 2 and 100 characters, including letters, digits and special characters ('!', ',', '.', etc)
 *	Author is any non-empty string
 *	Unique params are Book title and Book ISBN
 *	Book ISBN is an unique code that contains either 10 or 13 digits
 *	If something is not valid - throw Error
 */
function solve() {
    var library = (function () {
        var books = [];
        var categories = [];

        function listBooks(parameter) {
            if(arguments.length > 0) {
                if(typeof parameter.category !== 'undefined') {
                    return typeof categories[parameter.category] !== 'undefined' ?
                        categories[parameter.category].books : [];
                }

                if(typeof parameter.author !== 'undefined') {

                    var booksToList = [];

                    for(var ind = 0, len = books.length; ind < len; ind += 1) {
                        if(books[ind].author === parameter.author) {
                            booksToList.push(books[ind]);
                        }
                    }

                    return booksToList;
                }
            }

            return books;
        }

        function parameterAlreadyExists(name, type) {
            for(var ind = 0, len = books.length; ind < len; ind += 1) {
                if(books[ind][type] === name) {
                    return true;
                }
            }

            return false;
        }

        function throwBookNotUniqueError(parameter) {
            throw new Error('A book with the same ' + parameter + ' already exists.');
        }

        function addCategory(name) {
            categories[name] = {
                books: [],
                ID: categories.length + 1
            };
        }

        function checkAllBookParameters(book, expectedArgumentsLength) {

            if(Object.keys(book).length !== expectedArgumentsLength) {
                throw new Error('All book parameters must be passed');
            }

            for (var param in book) {
                if(typeof book[param] === 'undefined') {
                    throw new Error(param + 'cannot be undefined.');
                }
            }
        }

        function validateAuthor(author) {
            if(author.trim() === '') {
                throw new Error('Invalid author.');
            }
        }

        function validateIsbn(isbn) {
            if(isbn.length !== 10 && isbn.length !== 13) {
                throw new Error('ISBN must be either 10 or 13 digits');
            }
			
				if(!/^[0-9]+$/.test(isbn.toString())) {
					throw new Error('ISBN must be a valid number');
				}
        }

        function validateCategoryAndBookName(name) {
            if(name.length < 2 || name.length > 100) {
                throw new Error('Name is either too short or too long');
            }
        }

        function addBook(book) {
            book.ID = books.length + 1;

            checkAllBookParameters(book, 5);

            if(parameterAlreadyExists(book.title, 'title')) {
                throwBookNotUniqueError('title');
            }

            if(parameterAlreadyExists(book.isbn, 'isbn')) {
                throwBookNotUniqueError('ISBN');
            }

            if(categories.indexOf(book.category) < 0) {
                addCategory(book.category);
            }

            validateAuthor(book.author);
            validateIsbn(book.isbn);
            validateCategoryAndBookName(book.title);
            validateCategoryAndBookName(book.category);

            categories[book.category].books.push(book);

            books.push(book);
            return book;
        }

        function listCategories(category) {

            var categoriesNames = [];
            Array.prototype.push.apply(categoriesNames, Object.keys(categories));

            return categoriesNames;
        }

        return {
            books: {
                list: listBooks,
                add: addBook
            },
            categories: {
                list: listCategories
            }
        };
    } ());
    return library;
}