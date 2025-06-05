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
            // TODO
            // - Use the getters and setters on pokemons, let user add new pokemons, remove pokemons, etc.
            // - Add a save/load functionality to save the pokemon list to a file and load it back
            // - Add a feature to sort the pokemon list by level or type
            // - Add a feature to search for a pokemon by name
            // - Add a feature to filter the pokemon list by type
            // - Add a feature to display the top 5 strongest pokemons based on their level and attacks
            // - Resolve all the warnings
            // - Move all Todos to a TODO-file :)

        }
    }
}
