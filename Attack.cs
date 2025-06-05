using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gottaCatchEmAll
{
    internal class Attack
    {
        public required string Name { get; set; }
        public ElementTypes.ElementType Type { get; set; }
        public int BasePower { get; set; }
        public void Use(int level)
        {
            Console.WriteLine($"{Name} hits with total power {BasePower * level}");
        }
    }
}
