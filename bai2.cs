using System;
using System.Collections.Generic;
using System.Text;

namespace CTDLGT_Buoi02_BoSung_31251021643.Bai2
{
    internal class bai2
    {
        // Chèn value vào vị trí index
        static void Insert(int[] data, ref int count, int index, int value)
        {
            // Kiểm tra index có hợp lệ không
            if (index < 0 || index > count)
                throw new ArgumentOutOfRangeException(nameof(index));

            // Kiểm tra mảng còn chỗ trống không
            if (count == data.Length)
                throw new InvalidOperationException("Mang da day");

            // Dời các phần tử sang phải để tạo chỗ trống
            for (int i = count; i > index; i--)
            {
                data[i] = data[i - 1];
            }

            // Đặt giá trị mới vào vị trí cần chèn
            data[index] = value;

            // Tăng số phần tử hợp lệ lên 1
            count++;
        }

        // Xóa phần tử tại vị trí index
        static void RemoveAt(int[] data, ref int count, int index)
        {
            // Kiểm tra index có nằm trong phần tử hợp lệ không
            if (index < 0 || index >= count)
                throw new ArgumentOutOfRangeException(nameof(index));

            // Dời các phần tử phía sau sang trái
            for (int i = index; i < count - 1; i++)
            {
                data[i] = data[i + 1];
            }

            // Giảm số phần tử hợp lệ đi 1
            count--;
        }

        // In các phần tử hợp lệ của mảng
        static void PrintArray(int[] data, int count)
        {
            Console.Write("[");
            for (int i = 0; i < count; i++)
            {
                Console.Write(data[i]);
                if (i < count - 1) Console.Write(", ");
            }
            Console.WriteLine("]");
        }

        static void Main()
        {
            // Tạo mảng có 8 ô, nhưng ban đầu chỉ có 5 phần tử hợp lệ
            int[] data = new int[8] { 4, 7, 2, 9, 5, 0, 0, 0 };
            int count = 5;

            // Chèn 99 vào vị trí 2
            Insert(data, ref count, 2, 99);
            PrintArray(data, count);

            // Xóa phần tử tại vị trí 1
            RemoveAt(data, ref count, 1);
            PrintArray(data, count);
            //Chèn tại đầu mảng
            int[] a = new int[6] { 4, 7, 2, 9, 5, 0 };
            int countA = 5;

            Insert(a, ref countA, 0, 99);
            Console.Write("Chen dau: ");
            PrintArray(a, countA);

            //Chèn tại cuối mảng
            int[] b = new int[6] { 4, 7, 2, 9, 5, 0 };
            int countB = 5;

            Insert(b, ref countB, countB, 99);
            Console.Write("Chen cuoi: ");
            PrintArray(b, countB);

            //Xóa tại đầu mảng
            int[] c = new int[5] { 4, 7, 2, 9, 5 };
            int countC = 5;

            RemoveAt(c, ref countC, 0);
            Console.Write("Xoa dau: ");
            PrintArray(c, countC);

            //Xóa phần tử cuối
            int[] d = new int[5] { 4, 7, 2, 9, 5 };
            int countD = 5;

            RemoveAt(d, ref countD, countD - 1);
            Console.Write("Xoa cuoi: ");
            PrintArray(d, countD);

            //Thử index âm khi chèn
            int[] e = new int[6] { 4, 7, 2, 9, 5, 0 };
            int countE = 5;

            try
            {
                Insert(e, ref countE, -1, 99);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Dung: Tu choi index am khi chen.");
            }

            //Thử index bằng count khi xóa
            int[] f = new int[5] { 4, 7, 2, 9, 5 };
            int countF = 5;

            try
            {
                RemoveAt(f, ref countF, countF);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Dung: Tu choi index = count khi xoa.");
            }

            // Thử chèn khi mảng đã đầy
            int[] g = new int[5] { 4, 7, 2, 9, 5 };
            int countG = 5;

            try
            {
                Insert(g, ref countG, 2, 99);
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Dung: Tu choi chen khi mang da day.");
            }
        }
    }
}
