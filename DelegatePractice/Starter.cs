namespace DelegatePractice
{
    public delegate int OperationHandler(int x, int y);
    internal class Starter
    {
        public static void Run()
        {
            ColoredConsoleWriteLine("\t\t\t\t\t\tDelegate Practice\n\n", ConsoleColor.Green);

            int num1 = 24;
            int num2 = 2;

            Console.WriteLine($"Num1: {num1}\nNum2: {num2}\n");
            ColoredConsoleWriteLine("Subsribing to SumEvent with Sum() twice\n\ninvoking GetSumResults()\n", ConsoleColor.Green);

            var operation = new Operation();
            operation.SumEvent += Sum;
            operation.SumEvent += Sum;

            int? res = GetSumResults(operation, num1, num2);

            if (res is not null)
            {
                Console.WriteLine($"Result: ({num1} + {num2}) * 2 = {res.Value}\n");
            }

            operation.SumEvent -= Sum;
            operation.SumEvent -= Sum;

            ColoredConsoleWriteLine("Unsubsribing from SumEvent with Sum() twice\n\ninvoking GetSumResults()\n", ConsoleColor.Red);

            res = GetSumResults(operation, num1, num2);

            if (res is not null)
            {
                Console.WriteLine($"Result: ({num1} + {num2}) * 2 = {res.Value}");
            }
        }

        private static int Sum(int x, int y) => x + y;

        private static int? GetSumResults(Operation operation, int x, int y)
        {
            int? res = null;

            try
            {
                res = operation.GetOperationResultSum(x, y);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception! {ex.Message}");
            }

            return res;
        }

        private static void ColoredConsoleWriteLine(string data, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(data);
            Console.ResetColor();
        }
    }
}
