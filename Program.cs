using System.Collections;

namespace hw_10._06_Library
{
    internal class Program
    {
        internal class Book
        {
            private string _name;
            private string _author;
            private string _releaseDate;

            public string Name { get { return _name; } set { _name = value; } }
            public string Author { get { return _author; } set { _author = value; } }
            public string Date { get { return _releaseDate; } set { _releaseDate = value; } }

            public Book(string name, string author, string releaseDate)
            {
                _name = name;
                _author = author;
                _releaseDate = releaseDate;
            }

            public override string ToString()
            {
                return $"Name: {_name}, Author: {_author}, release date: {_releaseDate}";
            }
        }



        internal class Library : IEnumerable<Book>
        {
            private string _name;
            private string _address;
            private List<Book> _books;

            public Library(string name, string address)
            {
                _name = name;
                _address = address;
                _books = new List<Book>();
            }
            public List<Book> Book {  get { return _books; } }

            public void AddBook(Book book)
            {
                _books.Add(book);
            }

            public void RemoveBook(Book book)
            {
                _books.Remove(book);
            }

            public void Clear()
            {
                _books.Clear();
            }

            public bool Contains(Book book)
            {
                return _books.Contains(book);
            }

            public static Library operator +(Library obj, Book book)
            {
                obj.AddBook(book);
                return obj;
            }

            public static Library operator -(Library obj, Book book)
            {
                obj.RemoveBook(book);
                return obj;
            }

            public static bool operator ==(Library obj, Book book)
            {
                return obj._books.Contains(book);
            }

            public static bool operator !=(Library obj, Book book)
            {
                return obj._books.Contains(book);
            }

            public override string ToString()
            {
                string result = "Book List:\n";
                foreach (Book el in _books)
                {
                    result += el.ToString() + "\n";
                }
                return result;
            }


            public Book this[int index]
            {
                get
                {
                    if (index >= 0 && index < _books.Count)
                    {
                        return _books[index];
                    }
                    else
                    {
                        throw new IndexOutOfRangeException();
                    }
                }
                set
                {
                    if (index >= 0 && index < _books.Count)
                    {
                        _books[index] = value;
                    }
                    else
                    {
                        throw new IndexOutOfRangeException();
                    }
                }
            }



            public IEnumerator<Book> GetEnumerator()
            {
                foreach (Book el in _books)
                {
                    yield return el;
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }

        static void Main(string[] args)
        {
            //    2.Створити класс Library. Властивості: ім'я бібліотеки, адрес, список книжок (використовувати створений на
            //практиці клас Book). Реалізувати ітератор. Тест: створити масив книжок, створити об'єкт бібліотекі та
            //перебрати всі книжки, які там є.Використати оператор yield.
            //Додаткове завдання: Спробувати написати свій клас-ітератор(Current, Reset, MoveNext)

            Book book1 = new Book("FirstBook", "FirstAuthor", "1,1,1111");
            Book book2 = new Book("SecondBook", "SecondAuthor", "2,2,2222");
            Book book3 = new Book("ThirdBook", "ThirdAuthor", "1,1,1111");
            Library myLibrary = new Library("Library Name", "LibAddress");
            myLibrary += book1;
            myLibrary += book2;
            myLibrary += book3;
            Console.WriteLine(myLibrary);

            Console.WriteLine("My IEnumerator: ");
            foreach (Book el in myLibrary)
            {
                Console.WriteLine(el.ToString());
            }

            Console.WriteLine("for TEST");
            for (int i = 0; i < myLibrary.Book.Count; i++)
            {
                Console.WriteLine(myLibrary.Book[i]);
            }
        }
    }
}
