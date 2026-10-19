using System;
using System.Collections.Generic;
using System.Text;

namespace CTDLGT_Buoi02_BoSung_31251021643.Bai4
{
    internal class bai4
    {
        public class DynamicArray<T>
        {
            private T[] items;

            public int Count { get; private set; }
            public int Capacity => items.Length;

            // Khởi tạo mảng với capacity mặc định là 4
            public DynamicArray(int capacity = 4)
            {
                if (capacity < 0)
                    throw new ArgumentOutOfRangeException(nameof(capacity));

                items = new T[capacity];
                Count = 0;
            }

            // Thêm phần tử vào cuối mảng
            public void Add(T item)
            {
                if (Count == Capacity)
                    EnsureCapacity();

                items[Count] = item;
                Count++;
            }

            // Tăng dung lượng khi mảng đầy
            private void EnsureCapacity()
            {
                int newCapacity = Capacity == 0 ? 4 : Capacity * 2;
                T[] newItems = new T[newCapacity];

                // Sao chép đúng số phần tử đang sử dụng
                for (int i = 0; i < Count; i++)
                {
                    newItems[i] = items[i];
                }

                items = newItems;
            }

            // Truy cập hoặc cập nhật phần tử theo chỉ số
            public T this[int index]
            {
                get
                {
                    if (index < 0 || index >= Count)
                        throw new ArgumentOutOfRangeException(nameof(index));

                    return items[index];
                }
                set
                {
                    if (index < 0 || index >= Count)
                        throw new ArgumentOutOfRangeException(nameof(index));

                    items[index] = value;
                }
            }
        }

        class Program
        {
            static void Main()
            {
                DynamicArray<int> arr = new DynamicArray<int>();

                Console.WriteLine("THEM CAC SO TU 1 DEN 10");

                for (int i = 1; i <= 10; i++)
                {
                    int oldCapacity = arr.Capacity;
                    arr.Add(i);

                    Console.WriteLine(
                        $"Them {i}: Count = {arr.Count}, Capacity = {arr.Capacity}");

                    if (arr.Capacity != oldCapacity)
                    {
                        Console.WriteLine(
                            $"Mo rong: {oldCapacity} -> {arr.Capacity}, " +
                            $"so phan tu duoc sao chep = {arr.Count - 1}");
                    }
                }

                // In các phần tử để kiểm tra thứ tự dữ liệu
                Console.Write("Du lieu: ");
                for (int i = 0; i < arr.Count; i++)
                {
                    Console.Write(arr[i] + " ");
                }
                Console.WriteLine();

                // Đọc phần tử bằng indexer
                Console.WriteLine("Phan tu index 2: " + arr[2]);

                // Cập nhật phần tử bằng indexer
                arr[2] = 99;
                Console.WriteLine("Sau khi cap nhat index 2: " + arr[2]);

                // Kiểm tra index âm
                try
                {
                    Console.WriteLine(arr[-1]);
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Tu choi index am.");
                }

                // Kiểm tra index bằng Count
                try
                {
                    Console.WriteLine(arr[arr.Count]);
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Tu choi index bang Count.");
                }

                // Kiểm tra capacity âm
                try
                {
                    DynamicArray<int> invalid = new DynamicArray<int>(-1);
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Tu choi capacity am.");
                }
            }
        }
    }
}