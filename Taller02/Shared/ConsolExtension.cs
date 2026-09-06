namespace Shared
{
    public class BeamEvaluationResult
    {
        public string Message { get; set; } = string.Empty;
        public bool IsValid { get; set; }
    }

    public interface IBeamEvaluator
    {
        BeamEvaluationResult Evaluate(string beam);
    }

    public static class ConsolExtension
    {
        public static string ReadString(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine() ?? string.Empty;
        }
    }
}


