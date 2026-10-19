using System;
using System.Collections.Generic;
using System.Text;

namespace CTDLGT_Buoi02_BoSung_31251021643.Bai3
{
    internal class bai3
    {
        public class Student
        {
            // Lưu mã sinh viên
            public string Id { get; set; } = "";

            // Lưu họ tên sinh viên
            public string FullName { get; set; } = "";

            // Lưu điểm tổng kết từ 0 đến 10
            public double Score { get; set; }
        }

        class Program
        {
            // Danh sách dùng chung để lưu sinh viên
            static List<Student> students = new List<Student>();

            static void Main()
            {
                int choice;

                // Hiện menu cho đến khi người dùng chọn thoát
                do
                {
                    Console.WriteLine("1. Them sinh vien");
                    Console.WriteLine("2. Cap nhat sinh vien");
                    Console.WriteLine("3. Xoa sinh vien");
                    Console.WriteLine("4. Tim kiem theo ho ten");
                    Console.WriteLine("5. Hien thi danh sach");
                    Console.WriteLine("6. Thong ke");
                    Console.WriteLine("0. Thoat");
                    Console.Write("Chon chuc nang: ");

                    if (!int.TryParse(Console.ReadLine(), out choice))
                    {
                        Console.WriteLine("Lua chon khong hop le!");
                        continue;
                    }

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
                            SearchStudent();
                            break;
                        case 5:
                            ShowStudents();
                            break;
                        case 6:
                            ShowStatistics();
                            break;
                        case 0:
                            Console.WriteLine("Da thoat chuong trinh.");
                            break;
                        default:
                            Console.WriteLine("Vui long chon lai!");
                            break;
                    }
                } while (choice != 0);
            }

            // Them sinh vien moi
            static void AddStudent()
            {
                Console.Write("Nhap ma sinh vien: ");
                string id = Console.ReadLine() ?? "";

                // Kiem tra ma co bi trung khong
                for (int i = 0; i < students.Count; i++)
                {
                    if (students[i].Id.Equals(id, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("Ma sinh vien da ton tai!");
                        return;
                    }
                }

                Console.Write("Nhap ho ten: ");
                string name = Console.ReadLine() ?? "";

                Console.Write("Nhap diem tong ket: ");
                if (!double.TryParse(Console.ReadLine(), out double score)
                    || score < 0 || score > 10)
                {
                    Console.WriteLine("Diem phai nam trong khoang 0 den 10!");
                    return;
                }

                // Tao sinh vien va them vao danh sach
                Student student = new Student();
                student.Id = id;
                student.FullName = name;
                student.Score = score;

                students.Add(student);
                Console.WriteLine("Them sinh vien thanh cong!");
            }

            // Tim sinh vien theo ma
            static Student? FindById(string id)
            {
                for (int i = 0; i < students.Count; i++)
                {
                    if (students[i].Id.Equals(id, StringComparison.OrdinalIgnoreCase))
                    {
                        return students[i];
                    }
                }

                return null;
            }

            // Cap nhat ho ten hoac diem theo ma sinh vien
            static void UpdateStudent()
            {
                Console.Write("Nhap ma sinh vien can cap nhat: ");
                string id = Console.ReadLine() ?? "";

                Student? student = FindById(id);

                if (student == null)
                {
                    Console.WriteLine("Khong tim thay sinh vien!");
                    return;
                }

                Console.WriteLine("1. Cap nhat ho ten");
                Console.WriteLine("2. Cap nhat diem");
                Console.Write("Chon: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Lua chon khong hop le!");
                    return;
                }

                if (choice == 1)
                {
                    Console.Write("Nhap ho ten moi: ");
                    student.FullName = Console.ReadLine() ?? "";
                    Console.WriteLine("Cap nhat ho ten thanh cong!");
                }
                else if (choice == 2)
                {
                    Console.Write("Nhap diem moi: ");

                    if (!double.TryParse(Console.ReadLine(), out double score)
                        || score < 0 || score > 10)
                    {
                        Console.WriteLine("Diem phai nam trong khoang 0 den 10!");
                        return;
                    }

                    student.Score = score;
                    Console.WriteLine("Cap nhat diem thanh cong!");
                }
                else
                {
                    Console.WriteLine("Lua chon khong hop le!");
                }
            }

            // Xoa sinh vien theo ma
            static void DeleteStudent()
            {
                Console.Write("Nhap ma sinh vien can xoa: ");
                string id = Console.ReadLine() ?? "";

                Student? student = FindById(id);

                if (student == null)
                {
                    Console.WriteLine("Khong tim thay sinh vien!");
                    return;
                }

                students.Remove(student);
                Console.WriteLine("Xoa sinh vien thanh cong!");
            }

            // Tim sinh vien theo mot phan ho ten
            static void SearchStudent()
            {
                Console.Write("Nhap ten can tim: ");
                string keyword = Console.ReadLine() ?? "";

                bool found = false;

                // Duyet danh sach, khong dung LINQ
                for (int i = 0; i < students.Count; i++)
                {
                    if (students[i].FullName.IndexOf(
                        keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        PrintOneStudent(students[i]);
                        found = true;
                    }
                }

                if (!found)
                {
                    Console.WriteLine("Khong tim thay sinh vien phu hop!");
                }
            }

            // In thong tin mot sinh vien
            static void PrintOneStudent(Student student)
            {
                Console.WriteLine(
                    $"Ma: {student.Id} | Ho ten: {student.FullName} | Diem: {student.Score:F2}");
            }

            // Hien thi toan bo danh sach
            static void ShowStudents()
            {
                if (students.Count == 0)
                {
                    Console.WriteLine("Danh sach sinh vien dang rong!");
                    return;
                }

                for (int i = 0; i < students.Count; i++)
                {
                    PrintOneStudent(students[i]);
                }
            }

            // Tinh diem trung binh va dem sinh vien dat
            static void ShowStatistics()
            {
                // Neu danh sach rong thi khong tinh trung binh
                if (students.Count == 0)
                {
                    Console.WriteLine("Danh sach rong, khong co du lieu thong ke!");
                    return;
                }

                double sum = 0;
                int passed = 0;

                // Duyet danh sach de tinh tong diem va dem sinh vien dat
                for (int i = 0; i < students.Count; i++)
                {
                    sum += students[i].Score;

                    if (students[i].Score >= 5)
                    {
                        passed++;
                    }
                }

                double average = sum / students.Count;

                Console.WriteLine($"Diem trung binh: {average:F2}");
                Console.WriteLine($"So sinh vien dat (diem >= 5): {passed}");
            }
        }
    }
}
