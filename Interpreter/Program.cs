namespace Interpreter
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var interpreter = new Interpreter();

            interpreter.GetCommands("P1P2+WP10P1w-");
        }
    }
}
