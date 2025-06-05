### Reflection Questions
# Answer the following questions based on the code you’ve written and tested:

- F: When you create a Pokémon and try to access its fields directly – does it work? Why or why not?

Yes, it works because the properties are defined as public allowing access outside the class. I used "private" on the setter which I think prevents any changes to the values programmatically unless through an allowed method.

- F: If you later want to add a new property that applies to all Electric-type Pokémon, where should you place it to avoid repetition?

It should placed in the pokemon class, as all pokemon related properties should be cointained in the pokemon class. Parent-children type relationship.

- F: If instead the new property should apply to all Pokémon, where would be the correct place to define it?

I should still be put in the pokemon class as a public property.

- F: What happens if you try to add a Charmander to a list that only allows WaterPokemon?

Depends if Charmander is defined as a FirePokemon by "ElementType" or by "Name", but generally it should check for ElementType and throw and error if it doesn't match.

- F: You want to store different types of Pokémon – Charmander, Squirtle, and Pikachu – in the same list. What type should the list have for that to work?

I would use a List< Pokemon > to allow for handling all kinds of pokemon, current and future potential subclasses.

- F: When you loop through the list and call Attack(), what ensures that the correct attack behavior is executed for each Pokémon?

It is through polymorphism, each pokemon has "their own" Attack() method and when the method is called the method uses the specific pokemons implementation of Attack(). 

- F: If you create a method that only exists on Pikachu, why can’t you call it directly when it’s stored in a List<Pokemon>? How could you still access it?

Same as previous answer, but the opposite sort of. The Attack() method does not know about the Pikachu specific method so it cant be called directly. I am unsure about the syntax, something like pokemon.pikachu.pikachuMethod() but I dont know if that works in practice.