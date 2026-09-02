using Shared;

namespace Exercise28
{
    class Program
    {
        static void Main(string[] args)
        {
            string viga = ConsolExtension.ReadString("Ingrese la viga: ");

            if (!IsValid(viga))
            {
                Console.WriteLine(" La viga está mal construida!");

                return;
            }

            int capacity = 0;
            if (viga[0] == '%') capacity = 10;
            else if (viga[0] == '&') capacity = 30;
            else if (viga[0] == '#') capacity = 90;

            int totalWeight = 0;
            int currentSeqWeight = 0;
            int currentSeqLength = 0;

            for (int i = 1; i < viga.Length; i++)
            {
                if (viga[i] == '=')
                {
                    currentSeqLength++;
                    currentSeqWeight += currentSeqLength;
                    totalWeight += currentSeqLength;
                }
                else if (viga[i] == '*')
                {
                    totalWeight += 2 * currentSeqWeight;
                    currentSeqLength = 0;
                    currentSeqWeight = 0;
                }
            }

            if (totalWeight <= capacity)
            {
                Console.WriteLine(" La viga soporta el peso!");
            }
            else
            {
                Console.WriteLine(" La viga NO soporta el peso!");
            }
        }

        static bool IsValid(string viga)
        {
            if (string.IsNullOrEmpty(viga)) return false;

            char baseChar = viga[0];
            if (baseChar != '%' && baseChar != '&' && baseChar != '#') return false;

            for (int i = 1; i < viga.Length; i++)
            {
                char c = viga[i];
                if (c != '=' && c != '*') return false;

                // No puede haber dos o más conexiones seguidas
                if (c == '*' && viga[i - 1] == '*') return false;

                // Las conexiones solamente pueden conectarse con largueros (no directamente a la base)
                if (c == '*' && viga[i - 1] != '=') return false;
            }

            return true;
        }
    }
}
