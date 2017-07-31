using System;
using System.Collections.Generic;

namespace Task1
{
    public interface IRepository<T> where T : IComparable<T>, IEquatable<T>
    {
        List<T> LoadBooks();

        void Save(IEnumerable<T> books);
    }
}
