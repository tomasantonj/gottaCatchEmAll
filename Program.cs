using System.IO;

namespace gottaCatchEmAll
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Get test data from PokemonTestData
            List<Pokemon> pokemonList = PokemonTestData.GetTestPokemonList();
            // Run pokemon UI
            PokemonUI.ShowPokemonMenu(pokemonList);
        }
    }
}
