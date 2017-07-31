using System;
using System.Collections.Generic;

namespace Task1
{
    public sealed class BookListService
    {
        public IRepository<Book> Repository { get; }

        public List<Book> BookList { get; }

        public BookListService(IRepository<Book> repository)
        {
            Repository = repository;
            BookList = Repository.LoadBooks() ?? new List<Book>();
        }

        public void AddBook(Book book)
        {
	        if (book == null)
	        {
		        throw new ArgumentNullException(nameof(book));
	        }

	        if (BookList.Contains(book))
	        {
		        throw new ArgumentException("Element is contains in repository " + nameof(book));
	        }

            BookList.Add(book);
        }

        public void DeleteBook(Book book)
        {
	        if (book == null)
	        {
		        throw new ArgumentNullException(nameof(book));
	        }

	        if (!BookList.Contains(book))
	        {
		        throw new ArgumentException("Element is not contains in repository" + nameof(book));
	        }

            BookList.Remove(book);
        }

        public void Sort(IComparer<Book> comparer)
        {
	        if (comparer == null)
	        {
		        throw new ArgumentNullException(nameof(comparer));
	        }

            BookList.Sort(comparer);
        }

        public IEnumerable<Book> FindBooksByTags(Predicate<Book> tags) => BookList.FindAll(tags);
    }
}
