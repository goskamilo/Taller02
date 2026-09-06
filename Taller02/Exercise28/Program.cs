using Backendexercise28;
using Shared;

namespace Exercise28
{
    class Program
    {
        static void Main(string[] args)
        {
            IBeamEvaluator evaluator = new Exer28();

            string[] testBeams =
            {
                "%",
                "%=*",
                "%===*",
                "#====*====================*==",
                "&====*====================*=========*======*=====*====",
                "&=====**====**=====!="
            };

            foreach (var beam in testBeams)
            {
                Console.WriteLine($"Viga: {beam}");

                var result = evaluator.Evaluate(beam);

                Console.WriteLine(result.Message);
                Console.WriteLine();
            }

            Console.WriteLine("-----------------------------------");
            Console.Write("Ingrese una viga personalizada: ");

            string? userBeam = Console.ReadLine();

            if (!string.IsNullOrEmpty(userBeam))
            {
                var result = evaluator.Evaluate(userBeam);
                Console.WriteLine(result.Message);
            }
        }
    }
}
