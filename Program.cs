namespace csh_dynamic_hello;

class Program
{
    // Словарь для хранения уже вычисленных чисел Фибоначчи (Memoization)
    static Dictionary<long, long> memo = new Dictionary<long, long>();

    // Подпрограмма: Рекурсивная функция для вычисления числа Фибоначчи с мемоизацией
    static long Fibonacci(long n)
    {
        if (n < 0)
        {
            throw new ArgumentException("Число не может быть отрицательным.");
        }
        if (n == 0) return 0; // Базовый случай 1
        if (n == 1) return 1; // Базовый случай 2

        // Проверка, если уже вычислено
        if (memo.ContainsKey(n))
        {
            return memo[n]; // Возврат сохраненного значения
        }

        // Вычисляем и сохраняем в словарь
        long result = Fibonacci(n - 1) + Fibonacci(n - 2);
        memo[n] = result;

        return result;
    }

    // Подпрограмма: Ввод данных с проверкой на корректность
    static long InputNumber()
    {
        long n;
        while (true)
        {
            Console.Write("Введите положительное целое число: ");
            string input = Console.ReadLine();
            if (long.TryParse(input, out n) && n >= 0)
            {
                break;
            }
            Console.WriteLine("Ошибка! Введите корректное положительное число.");
        }
        return n;
    }

    // Подпрограмма: Вывод результата
    static void OutputResult(long n, long result)
    {
        Console.WriteLine($"Число Фибоначчи для {n} равно {result}");
    }


    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        try
        {
            // Ввод данных
            long number = InputNumber();

            // Вычисление числа Фибоначчи
            long fibonacciNumber = Fibonacci(number);

            // Вывод результата
            OutputResult(number, fibonacciNumber);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }

        Console.ReadKey();
    }
}
