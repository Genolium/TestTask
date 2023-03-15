using System.IO;

namespace TestTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Получаем ввод
            string input = Console.ReadLine();
            // Разбиваем строку на отдельные числа и переводим их в массив int
            string[] stringArray = input.Split(' ');
            int[] array = new int[stringArray.Length];

            for (int i = 0; i < stringArray.Length; i++)
            {
                array[i] = int.Parse(stringArray[i]);
            }
            // Применяем алгоритм и выводим полученные расстояния
            int[] zeros = NearestZeros(array);
            for (int i = 0; i < zeros.Length; i++)
            {
                Console.Write(zeros[i] + " ");
            }

            // Запись результата в файл
            using (StreamWriter sw = new StreamWriter($@"output_{DateTime.Now.Ticks}.txt"))
            {
                for (int i = 0; i < zeros.Length; i++)
                {
                    sw.Write(zeros[i] + " ");
                }
            }
        }

        static int[] NearestZeros(int[] array)
        {
            int n = array.Length;
            int[] result = new int[n];

            // Проходим слева направо, вычисляя расстояние до ближайшего нуля
            int lastZero = -n;
            for (int i = 0; i < n; i++)
            {
                if (array[i] == 0)
                    lastZero = i;
                result[i] = i - lastZero;
            }

            // Проходим справа налево, вычисляя расстояние до ближайшего нуля
            lastZero = 2 * n;
            for (int i = n - 1; i >= 0; i--)
            {
                if (array[i] == 0)
                    lastZero = i;
                result[i] = Math.Min(result[i], lastZero - i);
            }

            return result;
        }

    }
}