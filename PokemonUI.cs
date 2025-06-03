using System;
using System.Collections.Generic;

namespace gottaCatchEmAll
{
    internal static class PokemonUI
    {
        public static void ShowPokemonMenu(List<Pokemon> pokemonList)
        {
            while (true)
            {
                Console.WriteLine("Select a Pokémon to view its details (enter 0 to exit):");
                for (int i = 0; i < pokemonList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}: {pokemonList[i].Name}");
                }   
                int selectedIndex;
                Console.Write("Enter the number of the Pokémon: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out selectedIndex))
                {
                    if (selectedIndex == 0)
                    {
                        Console.WriteLine("Exiting Pokémon info viewer.");
                        break;
                    }
                    if (selectedIndex >= 1 && selectedIndex <= pokemonList.Count)
                    {
                        Pokemon selectedPokemon = pokemonList[selectedIndex - 1];
                        selectedPokemon.DisplayInfo();
                        Console.WriteLine();

                        while (true)
                        {
                            Console.WriteLine($"What would you like to do with {selectedPokemon.Name}?");
                            Console.WriteLine("1: Select a specific attack to test");
                            Console.WriteLine("2: Use a random attack");
                            if (selectedPokemon is IEvolvable evolvable && !selectedPokemon.IsEvolved && evolvable.CanEvolve)
                            {
                                Console.WriteLine("3: Evolve this Pokémon");
                                Console.WriteLine("4: Add levels");
                                Console.WriteLine("0: Return to Pokémon selection");
                            }
                            else if (selectedPokemon is IEvolvable && !selectedPokemon.IsEvolved)
                            {
                                Console.WriteLine("3: Add levels");
                                Console.WriteLine("0: Return to Pokémon selection");
                            }
                            else
                            {
                                Console.WriteLine("0: Return to Pokémon selection");
                            }

                            Console.Write("Enter your choice: ");
                            string actionInput = Console.ReadLine();

                            // Handle menu options
                            if (actionInput == "1")
                            {
                                Console.WriteLine("Select an attack to use:");
                                for (int i = 0; i < selectedPokemon.Attacks.Count; i++)
                                {
                                    Console.WriteLine($"{i + 1}: {selectedPokemon.Attacks[i].Name} (Power: {selectedPokemon.Attacks[i].BasePower}, Type: {selectedPokemon.Attacks[i].Type})");
                                }
                                Console.Write("Enter the number of the attack: ");
                                string attackChoiceInput = Console.ReadLine();
                                if (int.TryParse(attackChoiceInput, out int attackChoice) &&
                                    attackChoice >= 1 && attackChoice <= selectedPokemon.Attacks.Count)
                                {
                                    selectedPokemon.Attacks[attackChoice - 1].Use(selectedPokemon.Level);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid attack choice.");
                                }
                            }
                            else if (actionInput == "2")
                            {
                                selectedPokemon.RandomAttack();
                            }
                            else if (actionInput == "3" && selectedPokemon is IEvolvable evolvableOption)
                            {
                                if (!selectedPokemon.IsEvolved && evolvableOption.CanEvolve)
                                {
                                    evolvableOption.Evolve();
                                }
                                else if (!selectedPokemon.IsEvolved)
                                {
                                    // Add levels
                                    Console.WriteLine($"How many levels do you want to add to {selectedPokemon.Name}? (Enter 0 to skip)");
                                    string levelInput = Console.ReadLine();
                                    if (int.TryParse(levelInput, out int levelsToAdd) && levelsToAdd > 0)
                                    {
                                        selectedPokemon.RaiseLevel(levelsToAdd);
                                        Console.WriteLine($"{selectedPokemon.Name} is now level {selectedPokemon.Level}.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine($"{selectedPokemon.Name} is already evolved and cannot evolve or gain more levels.");
                                }
                            }
                            else if (actionInput == "4" && selectedPokemon is IEvolvable evolvableOption2 && !selectedPokemon.IsEvolved && evolvableOption2.CanEvolve)
                            {
                                // Add levels
                                Console.WriteLine($"How many levels do you want to add to {selectedPokemon.Name}? (Enter 0 to skip)");
                                string levelInput = Console.ReadLine();
                                if (int.TryParse(levelInput, out int levelsToAdd) && levelsToAdd > 0)
                                {
                                    selectedPokemon.RaiseLevel(levelsToAdd);
                                    Console.WriteLine($"{selectedPokemon.Name} is now level {selectedPokemon.Level}.");
                                }
                            }
                            else if (actionInput == "0")
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid option.");
                            }

                            Console.WriteLine();
                            // Refresh info after any action
                            selectedPokemon.DisplayInfo();
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Try again.");
                }
            }
        }
    }
}