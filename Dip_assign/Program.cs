namespace Dip_assign
{
    class Program
    {
        static void Main(string[] args)
        {
            // Dependency Injection based on user type

            // Student Manager (only borrowable actions)
            var student = new Student();
            var studentManager = new UserManager(borrowable: student);
            studentManager.BorrowBook("C# Programming");

            // Teacher Manager (borrowable and reservable actions)
            var teacher = new Teacher();
            var teacherManager = new UserManager(borrowable: teacher, reservable: teacher);
            teacherManager.BorrowBook("Design Patterns");
            teacherManager.ReserveBook("Advanced Algorithms");

            // Librarian Manager (inventory management actions)
            var librarian = new Librarian();
            var librarianManager = new UserManager(inventoryManageable: librarian);
            librarianManager.AddBook("New Book on .NET Core");
            librarianManager.RemoveBook("Old Book on Java");
        }
    }

}
