using System;
using System.Collections.Generic;
using System.Text;

namespace CTDLGT_Buoi02_BoSung_31251021643.Bai1
{
    internal class bai1
    {
        static void Main(string[] args)
        {
            // nhap so luong phan tu n
            Console.Write("Nhap n: ");
            int n = int.Parse(Console.ReadLine());
            //rang buoc n thuoc pham vi de bai , neu sai quay ve 
            if (n < 1 || n > 100000)
            {
                Console.WriteLine("n phai nam trong khoang tu 1 den 100000");
                return;
            }
            // tao mang
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Nhap a[{i}]: ");
                arr[i] = int.Parse(Console.ReadLine());
            }
            //long tinh tong
            long sum = 0;
            // min max , am duong 
            int min = arr[0];
            int max = arr[0];
            int soAm = 0;
            int soDuong = 0;
            int soKhong = 0;
            // duyet mang 
            for (int i = 0;i < n; i++) 
            {
                //cong don
                sum += arr[i];
                //neu nho hon min thi cap nhap min moi
                if (arr[i] < min)
                {
                    min = arr[i];
                }
                //neu lon hon max thi cap nhap max moi
                if (arr[i] > max)
                {
                    max = arr[i];
                }
                // phan loai am , duong , =0
                if (arr[i] < 0)
                {
                    soAm++;
                }
                else if (arr[i] > 0)
                {
                    soDuong++;
                }
                else { soKhong++; }
            }
            // tinh trung binh cong
            double trungbinh = (double)sum / n;
            // in ket qua
            Console.WriteLine($"Tong = {sum}");
            Console.WriteLine($"min = {min}");
            Console.WriteLine($"max = {max}");
            Console.WriteLine($"Trung binh cong = {trungbinh:F2}");
            Console.WriteLine($"am = {soAm}");
            Console.WriteLine($"duong = {soDuong}");
            Console.WriteLine($"bang 0 = {soKhong}");
            //dao mang bang hia chi so left , right 
            int left = 0;
            int right = n - 1;
            //khi hai so gap nhau thi dung lai
            while (left < right) 
            {
                // Luu phan tu ben trai vao bien tam de tranh mat
                int temp = arr[left];
                // Dua phan tu ben phai sang vi tri ben trai
                arr[left] = arr[right];
                // Dua gia tri da luu trong temp sang vi tri ben phai
                arr[right] = temp;
                // Sau moi lan doi cho thì tien left sang phai 1 vi tri
                left++;
                //Dong thoi lui right sang trai mot vi tri
                right--;
            }
            // in mang sau khi dao
            Console.Write("Mang sau khi dao: ");
            for (int i = 0; i < n; i++) 
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
