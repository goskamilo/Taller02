using Shared;
using System.Text;
using System.Linq;

namespace BackendExercise37
{
    public class Exer37 : IBeamEvaluator
    {
        // Constructor
        public Exer37()
        {
        }

        // Analiza los caballos y genera el reporte.
        public BeamEvaluationResult Evaluate(string input)
        {
            string[] positions = input
                .Split(',')
                .Select(x => x.Trim().ToUpper())
                .ToArray();

            StringBuilder report = new();

            foreach (string knight in positions)
            {
                List<string> conflicts = new();

                foreach (string other in positions)
                {
                    if (knight == other)
                        continue;

                    if (HasConflict(knight, other))
                    {
                        conflicts.Add(other);
                    }
                }

                if (conflicts.Count == 0)
                {
                    report.AppendLine(
                        $"Analizando Caballo en {knight} => Sin conflicto");
                }
                else
                {
                    report.AppendLine(
                        $"Analizando Caballo en {knight} => Conflicto con {string.Join(", ", conflicts)}");
                }
            }

            return new BeamEvaluationResult
            {
                Message = report.ToString(),
                IsValid = true
            };
        }

        // Verifica si dos caballos pueden atacarse.
        private bool HasConflict(string p1, string p2)
        {
            int col1 = char.ToUpper(p1[0]) - 'A';
            int row1 = p1[1] - '1';

            int col2 = char.ToUpper(p2[0]) - 'A';
            int row2 = p2[1] - '1';

            int dx = Math.Abs(col1 - col2);
            int dy = Math.Abs(row1 - row2);

            return (dx == 2 && dy == 1)
                || (dx == 1 && dy == 2);
        }
    }
}