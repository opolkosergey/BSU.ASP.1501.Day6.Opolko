using System.Collections.Generic;

namespace Task1
{
    public class BookComparer : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
	        if (x == null)
	        {
		        return -1;
	        }

	        if (y == null)
	        {
		        return 1;
	        }

	        if (x.Pages > y.Pages)
	        {
		        return 1;
	        }

	        if (x.Pages < y.Pages)
	        {
		        return -1;
	        }

            return 0;
        }
    }
}
