using BackendExercise37;
using Shared;

namespace Exercise37
{
    class Program
    {
        static void Main(string[] args)
        {
            // Se crea el evaluador.
            IBeamEvaluator evaluator = new Exer37();

            // Solicita las posiciones.
            Console.Write(
                "Ingrese ubicación de los caballos: ");

            string? input = Console.ReadLine();

            if (!string.IsNullOrEmpty(input))
            {
                // Ejecuta el análisis.
                var result = evaluator.Evaluate(input);

                Console.WriteLine();
                Console.WriteLine(result.Message);
            }
        }
    }
}