namespace DelegatePractice
{
    internal class Operation
    {
        public event OperationHandler? SumEvent;

        // Implements logic of counting results of methods passed to SumEvent
        public int GetOperationResultSum(int x, int y)
        {
            int sum = 0;

            var ops = SumEvent?.GetInvocationList();

            if (ops is null)
            {
                throw new Exception("SumEvent is null");
            }

            foreach (var op in ops)
            {
                object? o = op.DynamicInvoke(x, y);

                if (o is int i)
                {
                    sum += i;
                }
            }

            return sum;
        }
    }
}
