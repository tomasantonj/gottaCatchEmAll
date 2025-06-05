using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gottaCatchEmAll
{
    // Interface for evolvable entities
    internal interface IEvolvable
    {
        bool CanEvolve { get; }

        void DisplayPokemonInfo();
        void Evolve();
    }

    internal class EvolvingPokemon : Pokemon, IEvolvable
    {
        public EvolvingPokemon(string name, int level, ElementTypes.ElementType elementType, List<Attack> attacks)
            : base(name, level, elementType, attacks) { }
    }
}
