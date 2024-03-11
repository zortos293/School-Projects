using System;
using System.Collections.Generic;

abstract class Pokemon
{
    public string Nickname { get; set; }
    public string Strength { get; protected set; }
    public string Weakness { get; protected set; }

    protected Pokemon(string nickname, string strength, string weakness)
    {
        Nickname = nickname;
        Strength = strength;
        Weakness = weakness;
    }

    public abstract void BattleCry();
}

class Squirtle : Pokemon
{
    public Squirtle(string nickname) : base(nickname, "Water", "Leaf")
    {
    }

    public override void BattleCry()
    {
        Console.WriteLine($"{Nickname}, Squirtle!");
    }
}

class Bulbasaur : Pokemon
{
    public Bulbasaur(string nickname) : base(nickname, "Grass", "Fire")
    {
    }

    public override void BattleCry()
    {
        Console.WriteLine($"{Nickname}, Bulbasaur!");
    }
}

class Charmander : Pokemon
{
    public Charmander(string nickname) : base(nickname, "Fire", "Water")
    {
    }

    public override void BattleCry()
    {
        Console.WriteLine($"{Nickname}, Charmander!");
    }
}

class Pokeball
{
    public Pokemon ContainedPokemon { get; private set; }

    public Pokeball(Pokemon pokemon)
    {
        ContainedPokemon = pokemon;
    }

    public void Throw()
    {
        if (ContainedPokemon != null)
        {
            Console.WriteLine($"{ContainedPokemon.Nickname} I choose you!");
            ContainedPokemon.BattleCry();
        }
    }

    public Pokemon RetrievePokemon()
    {
        var pokemon = ContainedPokemon;
        ContainedPokemon = null;
        return pokemon;
    }

    public void ReturnPokemon(Pokemon pokemon)
    {
        if (ContainedPokemon == null)
        {
            ContainedPokemon = pokemon;
        }
    }
}

class Trainer
{
    public string Name { get; set; }
    public List<Pokeball> Belt { get; private set; }

    public Trainer(string name, List<Pokemon> pokemons)
    {
        if (pokemons.Count > 6) throw new ArgumentException("You can only have up to 6 Pokemons.");

        Name = name;
        Belt = new List<Pokeball>();

        foreach (var pokemon in pokemons)
        {
            Belt.Add(new Pokeball(pokemon));
        }
    }

    public void ThrowPokeball(int index)
    {
        if (index < Belt.Count)
        {
            Belt[index].Throw();
        }
    }

    public Pokemon RetrievePokemonFromPokeball(int index)
    {
        if (index < Belt.Count)
        {
            return Belt[index].RetrievePokemon();
        }
        return null; // No pokemon to retrieve
    }

    public void ReturnPokemonToPokeball(Pokemon pokemon, int index)
    {
        if (index < Belt.Count)
        {
            Belt[index].ReturnPokemon(pokemon);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Setup trainers and their pokemons
        List<Pokemon> pokemonsForTrainer1 = new List<Pokemon>
        {
            new Charmander("Charlie"),
            new Squirtle("Squirty"),
            new Bulbasaur("Buddy"),
            new Charmander("Charm"),
            new Squirtle("Turtle"),
            new Bulbasaur("Leafy")
        };

        List<Pokemon> pokemonsForTrainer2 = new List<Pokemon>
        {
            new Charmander("Flame"),
            new Squirtle("Splash"),
            new Bulbasaur("Green"),
            new Charmander("Spark"),
            new Squirtle("Wave"),
            new Bulbasaur("Bloom")
        };

        Trainer trainer1 = new Trainer("Ash", pokemonsForTrainer1);
        Trainer trainer2 = new Trainer("Gary", pokemonsForTrainer2);

        // Simulate the battle
        for (int i = 0; i < 6; i++)
        {
            Console.WriteLine($"{trainer1.Name} throws a Pokeball!");
            trainer1.ThrowPokeball(i);
            Console.WriteLine($"{trainer2.Name} throws a Pokeball!");
            trainer2.ThrowPokeball(i);

            Pokemon pokemon1 = trainer1.RetrievePokemonFromPokeball(i);
            Pokemon pokemon2 = trainer2.RetrievePokemonFromPokeball(i);

            // Add battle logic here

            trainer1.ReturnPokemonToPokeball(pokemon1, i);
            trainer2.ReturnPokemonToPokeball(pokemon2, i);
        }

        // Game loop for starting, quitting, or restarting the game could be implemented here
    }
}
