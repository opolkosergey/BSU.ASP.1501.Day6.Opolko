using System;
using System.Collections.Generic;
using System.IO;

namespace Task1
{
	public class FileBookRepository : IRepository<Book>
    {
        private string Path { get; }

        public FileBookRepository(string path)
        {
            Path = path;
        }

        public List<Book> LoadBooks()
        {
            var books = new List<Book>();

            var sourceFile = new FileStream(Path, FileMode.OpenOrCreate, FileAccess.Read);

            var reader = new BinaryReader(sourceFile);
            try
            {
                while (reader.PeekChar() > -1)
                {
                    var author = reader.ReadString();
                    var title = reader.ReadString();
                    var price = reader.ReadDouble();
                    var pages = reader.ReadInt32();
                    books.Add(new Book(author, title, price, pages));
                }
                return books;
            }
            catch (Exception)
            {
                return null;
            }

            finally
            {
                reader.Dispose();
                sourceFile.Close();
            }
        }

        public void Save(IEnumerable<Book> books)
        {
	        if (books == null)
	        {
		        throw new ArgumentNullException(nameof(books));
	        }

            var file = new FileStream(Path, FileMode.Truncate, FileAccess.Write);
            var writer = new BinaryWriter(file);

			try
            {
                foreach (var item in books)
                {
                    writer.Write(item.Author);
                    writer.Write(item.Title);
                    writer.Write(item.Price);
                    writer.Write(item.Pages);
                }
            }
            catch (Exception)
            {
                // ignored
            }

            finally
            {
                writer.Dispose();
                file.Close();
            }
        }
    }
}
