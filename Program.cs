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
            // - review weapon selections and output, not sure if it works as intended
            // - review class properties and methods, not sure if they got the correct encapsulation and access modifiers- should be able to make them less exposed
            // - add some code comments to make it easier to understand in a week or two
            // - Answer the questions given in the README.md file

        }
    }
}
