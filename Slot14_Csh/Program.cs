using Slot14_Csh.asm14;
class Program
{
  static   List<Student> students = new List<Student>();
    static void Main(string[] args)
    {
        int choice;

        do
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Thêm sinh viên.");
            Console.WriteLine("2. Cập nhật thông tin sinh viên.");
            Console.WriteLine("3. Xóa sinh viên.");
            Console.WriteLine("4. Tìm kiếm sinh viên theo tên.");
            Console.WriteLine("5. Sắp xếp sinh viên theo điểm trung bình (GPA).");
            Console.WriteLine("6. Sắp xếp sinh viên theo tên.");
            Console.WriteLine("7. Sắp xếp sinh viên theo ID.");
            Console.WriteLine("8. Hiển thị danh sách sinh viên.");
            Console.WriteLine("9. Thoát.");
            Console.Write("Nhập lựa chọn: ");
            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddStudent();
                    break;
                case 2:
                    UpdateStudent();
                    break;
                case 3:
                    DeleteStudent();
                    break;
                case 4:
                    SearchStudentByName();
                    break;
                case 5:
                    SortByAverageScore();
                    break;
                case 6:
                    SortByName();
                    break;
                case 7:
                    SortById();
                    break;
                case 8:
                    DisplayStudents();
                    break;
                case 9:
                    Console.WriteLine("Kết thúc chương trình.");
                    break;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ.");
                    break;
            }

        } while (choice != 9);
    }
    static void AddStudent()
    {
        Console.WriteLine("Nhập thông tin sinh viên mới:");

        Console.Write("ID: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Console.Write("Tên: ");
        string name = Console.ReadLine();

        Console.Write("Giới tính: ");
        string gender = Console.ReadLine();

        Console.Write("Tuổi: ");
        int age = Convert.ToInt32(Console.ReadLine());

        Console.Write("Điểm Toán: ");
        double mathScore = Convert.ToDouble(Console.ReadLine());

        Console.Write("Điểm Lý: ");
        double physicsScore = Convert.ToDouble(Console.ReadLine());

        Console.Write("Điểm Hóa: ");
        double chemistryScore = Convert.ToDouble(Console.ReadLine());

        Student newStudent = new Student
        {
            Id = id,
            Name = name,
            Gender = gender,
            Age = age,
            MathScore = mathScore,
            PhysicsScore = physicsScore,
            ChemistryScore = chemistryScore
        };

      students.Add(newStudent);

        Console.WriteLine("Sinh viên đã được thêm thành công.");
    }
    static void UpdateStudent()
    {
        Console.Write("Nhập ID của sinh viên cần cập nhật: ");
        int idToUpdate = Convert.ToInt32(Console.ReadLine());

        Student studentToUpdate = students.FirstOrDefault(student => student.Id == idToUpdate);

        if (studentToUpdate != null)
        {
            Console.WriteLine("Nhập thông tin cập nhật cho sinh viên:");

            Console.Write("Tên: ");
            studentToUpdate.Name = Console.ReadLine();

            Console.Write("Giới tính: ");
            studentToUpdate.Gender = Console.ReadLine();

            Console.Write("Tuổi: ");
            studentToUpdate.Age = Convert.ToInt32(Console.ReadLine());

            Console.Write("Điểm Toán: ");
            studentToUpdate.MathScore = Convert.ToDouble(Console.ReadLine());

            Console.Write("Điểm Lý: ");
            studentToUpdate.PhysicsScore = Convert.ToDouble(Console.ReadLine());

            Console.Write("Điểm Hóa: ");
            studentToUpdate.ChemistryScore = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Thông tin sinh viên đã được cập nhật thành công.");
        }
        else
        {
            Console.WriteLine("Không tìm thấy sinh viên có ID cần cập nhật.");
        }
    }
    static void DeleteStudent()
    {
        Console.Write("Nhập ID của sinh viên cần xóa: ");
        int idToDelete = Convert.ToInt32(Console.ReadLine());

        Student studentToDelete = students.FirstOrDefault(student => student.Id == idToDelete);

        if (studentToDelete != null)
        {
            students.Remove(studentToDelete);
            Console.WriteLine("Sinh viên đã được xóa thành công.");
        }
        else
        {
            Console.WriteLine("Không tìm thấy sinh viên có ID cần xóa.");
        }
    }
    static void SearchStudentByName()
    {
        Console.Write("Nhập tên sinh viên cần tìm: ");
        string nameToSearch = Console.ReadLine();

        List<Student> matchedStudents = students.Where(student => student.Name.Contains(nameToSearch, StringComparison.OrdinalIgnoreCase)).ToList();

        if (matchedStudents.Count > 0)
        {
            Console.WriteLine("Kết quả tìm kiếm:");
            foreach (var student in matchedStudents)
            {
                Console.WriteLine($"ID: {student.Id}, Tên: {student.Name}, Giới tính: {student.Gender}, Tuổi: {student.Age}");
            }
        }
        else
        {
            Console.WriteLine("Không tìm thấy sinh viên nào có tên phù hợp.");
        }
    }
    static void SortByAverageScore()
    {
        List<Student> sortedStudents = students.OrderBy(student => student.AverageScore).ToList();

        Console.WriteLine("Danh sách sinh viên sau khi sắp xếp theo điểm trung bình:");
        DisplayStudentList(sortedStudents);
    }
    static void SortByName()
    {
        List<Student> sortedStudents = students.OrderBy(student => student.Name).ToList();

        Console.WriteLine("Danh sách sinh viên sau khi sắp xếp theo tên:");
        DisplayStudentList(sortedStudents);
    }
    static void SortById()
    {
        List<Student> sortedStudents = students.OrderBy(student => student.Id).ToList();

        Console.WriteLine("Danh sách sinh viên sau khi sắp xếp theo ID:");
        DisplayStudentList(sortedStudents);
    }
    static void DisplayStudents()
    {
        Console.WriteLine("Danh sách sinh viên:");

        if (students.Count > 0)
        {
            DisplayStudentList(students);
        }
        else
        {
            Console.WriteLine("Không có sinh viên nào trong danh sách.");
        }
    }
    static void DisplayStudentList(List<Student> studentList)
    {
        foreach (var student in studentList)
        {
            Console.WriteLine($"ID: {student.Id}, Tên: {student.Name}, Giới tính: {student.Gender}, Tuổi: {student.Age}");
            Console.WriteLine($"Điểm Toán: {student.MathScore}, Điểm Lý: {student.PhysicsScore}, Điểm Hóa: {student.ChemistryScore}");
            Console.WriteLine($"Điểm trung bình: {student.AverageScore}, Học lực: {student.AcademicPerformance}");
            Console.WriteLine("---------------------------------------------");
        }
    }
}
