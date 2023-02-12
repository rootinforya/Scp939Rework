using System.Collections.Generic;
using Neuron.Core.Meta;
using Syml;

namespace Scp939Rework
{
    [Automatic]
    [DocumentSection("Scp939Rework")]
    public class Scp939ReworkConfig : IDocumentSection
    {
        public float DamageMultiplier { get; set; } = 1;
        public int Scp939Replace096Chance { get; set; } = 50;
    }
}