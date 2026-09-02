using Shared;

namespace Exercise37
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = ConsolExtension.ReadString("Ingrese ubicación de los caballos: ");
            if (string.IsNullOrWhiteSpace(input)) return;

            string[] rawPositions = input.Split(',');
            List<string> horses = new List<string>();

            foreach (var raw in rawPositions)
            {
                string trimmed = raw.Trim().ToUpper();
                if (trimmed.Length >= 2)
                {
                    horses.Add(trimmed);
                }

            }

            foreach (var h1 in horses)
            {
                Console.Write($" Analizando Caballo en {h1[1]}{h1[0]} =>");

                List<string> conflicts = new List<string>();
                foreach (var h2 in horses)
                {
                    if (h1 == h2) continue;
                    if (IsConflict(h1, h2))
                    {
                        conflicts.Add($"Conflicto con {h2[1]}{h2[0]}");
                    }
                }

                // El caso de prueba #37 muestra los conflictos agrupados en la misma línea
                foreach (var conflict in conflicts)
                {
                    Console.Write($" {conflict}");
                }

                Console.WriteLine();
            }
        }

        static bool IsConflict(string pos1, string pos2)
        {
            if (pos1.Length < 2 || pos2.Length < 2) return false;

            char x1 = pos1[0];
            char y1 = pos1[1];
            char x2 = pos2[0];
            char y2 = pos2[1];

            int dx = Math.Abs(x1 - x2);
            int dy = Math.Abs(y1 - y2);

            // El caballo se mueve en forma de L: 2 casillas en un eje y 1 en el otro
            return (dx == 1 && dy == 2) || (dx == 2 && dy == 1);
        }
    }
}