namespace Shared
{
    public class ConsolExtension
    {
        public static string ReadString(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine() ?? string.Empty;

        }
    }
}
