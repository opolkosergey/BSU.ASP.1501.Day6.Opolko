# BSU.ASP.1501.Day6.Opolko

Задание 1.

Для выполнения основных операций с коллекцией книг, который можно загрузить (и, если возникнет необходимость, сохранить) из некоторого хранилища (например, двоичный файл) разработать класс BookListService (как сервис для работы с коллекцией книг) с функциональностью:

AddBook (добавить книгу, если такой книги нет, в противном случае выбросить исключение);
RemoveBook (удалить книгу, если она есть, в противном случае выбросить исключение);
FindByTag(найти книгу по заданному критерию);
SortBooksByTag (отсортировать список книг по заданному критерию).
Для работы с файлами использовать только классы BinaryReader, BinaryWriter.

Реализовать возможность логирования сообщений различного уровня с помощью NLog
Работу классов продемонстрировать на примере консольного приложения.
Задание 2.

Выполнить рефакторинг класса (с целью сокращения повторного кода) с алгоритмами Евклида (для рефакторинга использовать делегаты, рефакторинг возможен только в случае, когда все метод находятся в одном классе!). Интерфейс класса измениться не должен.

Задание 3.

В класс с алгоритмом сортировки непрямоугольной матрицы (заменить пользовательский интерфейс на IComparer!) добавить метод, принимающий как параметр делегат, инкапсулирующий логику сравнения строк матрицы. Протестировать работу разработанного метода на примере сортировки матрицы, используя прежние критерии сравнения.

Класс реализовать двумя способами, «замкнув» в первом варианте реализацию метода сортировки с делегатом на метод с интерфейсом, во втором – наоборот.
