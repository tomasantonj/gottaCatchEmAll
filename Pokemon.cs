using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static gottaCatchEmAll.ElementTypes;

namespace gottaCatchEmAll
{
    internal class Pokemon : IEvolvable
    {
        public string Name { get; protected set; }
        public int Level { get; protected set; }
        public ElementType ElementType { get; private set; }
        public List<Attack> Attacks { get; private set; }
        // EvolvedName property to hold the name of the Pokémon after evolution
        public string EvolvedName { get; private set; } 
        // Declare the required level for evolution & boolean property to check if the Pokémon can evolve to be used in the interface
        public const int requiredLevel = 16;
        public bool CanEvolve => Level >= requiredLevel;
        public bool IsEvolved => !string.IsNullOrWhiteSpace(EvolvedName) && Name == EvolvedName && Level >= requiredLevel;

        private static readonly Random _random = new Random();

        // Constructor to initialize the Pokémon with its name, level, element type, attacks, and optional evolved names and checks for valid inputs
        public Pokemon(string name, int level, ElementType elementType, List<Attack> attacks, string evolvedName = null)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length < 2 || name.Length > 15)
                throw new ArgumentException("Name must be between 2 and 15 characters.");
            if (level < 1)
                throw new ArgumentException("Level must be at least 1.");
            if (attacks == null || attacks.Count == 0)
                throw new ArgumentException("Attacks list cannot be null or empty.");

            Name = name;
            Level = level;
            ElementType = elementType;
            Attacks = attacks;
            // Set the evolved name, check if pokemon is evolved, if it is set EvolvedName to the current name

            EvolvedName = evolvedName;
            if (string.IsNullOrWhiteSpace(EvolvedName) && Level >= requiredLevel)
                // If the Pokémon is at or above the required level for evolution, set EvolvedName to current name
                EvolvedName = evolvedName ?? name;

        }
        // Method to perform a random attack from the Pokémon's available attacks
        public void RandomAttack()
        {
            int index = _random.Next(Attacks.Count);
            Attacks[index].Use(Level);
        }
        // Method to perform an attack, allowing the user to choose from available attacks
        public void Attack()
        {
            Console.WriteLine($"Choose an attack for {Name}:");
            for (int i = 0; i < Attacks.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {Attacks[i].Name}");
            }
            int choice;
            while (true)
            {
                Console.Write("Enter the number of the attack: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out choice) && choice >= 1 && choice <= Attacks.Count)
                    break;
                Console.WriteLine("Invalid choice. Try again.");
            }
            Attacks[choice - 1].Use(Level);
        }
        // Method to raise the level of the Pokémon, default increment is 1 but can be specified
        public void RaiseLevel(int increment = 1)
        {
            Level += increment;
            Console.WriteLine($"{Name} has leveled up to level {Level}!");
        }

        // Method to evolve the Pokémon if it meets the requirements
        public void Evolve()
        {
            if (CanEvolve)
            {
                Console.WriteLine($"{Name} is evolving!");
                RaiseLevel();
                if (!string.IsNullOrWhiteSpace(EvolvedName) && EvolvedName != Name)
                {
                    Name = EvolvedName;
                    Console.WriteLine($"Congratulations! Your Pokémon evolved into {Name}!");
                }
            }
            else
            {
                Console.WriteLine($"{Name} cannot evolve yet!");
            }
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Level: {Level}");
            Console.WriteLine("Available Attacks:");
            for (int i = 0; i < Attacks.Count; i++)
            {
                Console.WriteLine($"  {i + 1}: {Attacks[i].Name} (Power: {Attacks[i].BasePower}, Type: {Attacks[i].Type})");
            }

            if (IsEvolved)
            {
                Console.WriteLine("Pokemon is at its max evolution!");
            }
            else if (CanEvolve)
            {
                Console.WriteLine($"{Name} can evolve!");
            }
            else
            {
                Console.WriteLine($"{Name} cannot evolve yet (needs to be at least level {requiredLevel}).");
            }
        }
    }


    // subclasses of pokemon that implement IEvolvable interface to be able to evolve
    internal class FirePokemon : Pokemon, IEvolvable
    {
        public FirePokemon(string name, int level, List<Attack> attacks, string evolvedName = null)
            : base(name, level, ElementType.Fire, attacks, evolvedName) { }
    }

    internal class WaterPokemon : Pokemon, IEvolvable
    {
        public WaterPokemon(string name, int level, List<Attack> attacks, string evolvedName = null)
            : base(name, level, ElementType.Water, attacks, evolvedName) { }
    }

    internal class ElectricPokemon : Pokemon, IEvolvable
    {
        public ElectricPokemon(string name, int level, List<Attack> attacks, string evolvedName = null)
            : base(name, level, ElementType.Electric, attacks, evolvedName) { }
    }
}
