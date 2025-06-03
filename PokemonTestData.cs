using System.Collections.Generic;

namespace gottaCatchEmAll
{
    internal static class PokemonTestData
    {
        public static List<Pokemon> GetTestPokemonList()
        {
            // Fire
            var fireAttack1 = new Attack { Name = "Flame Burst", Type = ElementTypes.ElementType.Fire, BasePower = 50 };
            var fireAttack2 = new Attack { Name = "Fire Spin", Type = ElementTypes.ElementType.Fire, BasePower = 40 };
            var firePokemon = new FirePokemon("Eevee", 16, new List<Attack> { fireAttack1, fireAttack2 }, "Flareon");

            // Water
            var waterAttack1 = new Attack { Name = "Water Gun", Type = ElementTypes.ElementType.Water, BasePower = 30 };
            var waterAttack2 = new Attack { Name = "Bubble Beam", Type = ElementTypes.ElementType.Water, BasePower = 35 };
            var waterPokemon = new WaterPokemon("Vaporeon", 12, new List<Attack> { waterAttack1, waterAttack2 }, "Hydreon");

            // Electric
            var electricAttack1 = new Attack { Name = "Thunder Shock", Type = ElementTypes.ElementType.Electric, BasePower = 25 };
            var electricAttack2 = new Attack { Name = "Spark", Type = ElementTypes.ElementType.Electric, BasePower = 40 };
            var electricPokemon = new ElectricPokemon("Pikachu", 5, new List<Attack> { electricAttack1, electricAttack2 }, "Raichu");

            return new List<Pokemon> { firePokemon, waterPokemon, electricPokemon };
        }
    }
}