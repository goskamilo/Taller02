using Shared;
using System.Diagnostics;

namespace Backendexercise28
{
    public class Exer28 : IBeamEvaluator
    {
        private static readonly Dictionary<char, int> BaseCapacities = new()
        {
            { '%', 10 },
            { '&', 30 },
            { '#', 90 }
        };

        public BeamEvaluationResult Evaluate(string beam)
        {
            if (string.IsNullOrEmpty(beam) || !BaseCapacities.ContainsKey(beam[0]))
            {
                return new BeamEvaluationResult
                {
                    Message = "La viga está mal construida!",
                    IsValid = false
                };
            }

            int capacity = BaseCapacities[beam[0]];
            int totalWeight = 0;
            int lastSequenceWeight = 0;

            int i = 1;

            while (i < beam.Length)
            {
                char current = beam[i];

                if (current == '=')
                {
                    int sequenceLength = 0;

                    while (i < beam.Length && beam[i] == '=')
                    {
                        sequenceLength++;
                        i++;
                    }

                    lastSequenceWeight = sequenceLength;
                    totalWeight += lastSequenceWeight;
                }
                else if (current == '*')
                {
                    if (lastSequenceWeight == 0 ||
                        (i + 1 < beam.Length && beam[i + 1] == '*'))
                    {
                        return new BeamEvaluationResult
                        {
                            Message = "La viga está mal construida!",
                            IsValid = false
                        };
                    }

                    int connectionWeight = 2 * lastSequenceWeight;
                    totalWeight += connectionWeight;
                    lastSequenceWeight = 0;
                    i++;
                }
                else
                {
                    return new BeamEvaluationResult
                    {
                        Message = "La viga está mal construida!",
                        IsValid = false
                    };
                }
            }

            if (totalWeight <= capacity)
            {
                return new BeamEvaluationResult
                {
                    Message = "La viga soporta el peso!",
                    IsValid = true
                };
            }

            return new BeamEvaluationResult
            {
                Message = "La viga NO soporta el peso!",
                IsValid = true
            };
        }
    }
}