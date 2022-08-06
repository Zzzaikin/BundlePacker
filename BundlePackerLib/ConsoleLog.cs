namespace BundlePackerLib
{
    public class ConsoleLog
    {
        public void Success(string message)
        {
            ValidateMessage(message);
            WriteColorfulMessage(message, ConsoleColor.Green);
        }

        public void Error(string message)
        {
            ValidateMessage(message);
            WriteColorfulMessage(message, ConsoleColor.Red);
        }

        public void Warn(string message)
        {
            ValidateMessage(message);
            WriteColorfulMessage(message, ConsoleColor.Yellow);
        }

        private void WriteColorfulMessage(string message, ConsoleColor consoleColor)
        {
            Console.ForegroundColor = consoleColor;
            Console.WriteLine($"{message}");
            Console.ResetColor();
        }

        private void ValidateMessage(string message)
        {
            if (string.IsNullOrEmpty(message)) 
                throw new ArgumentException(nameof(message));
        }
    }
}
