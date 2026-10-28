using System;
using System.Collections.Generic;
using System.Linq;
class Pokemon
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Type { get; set; }
    public int Level { get; set; }
    // Attack is the base attack stat for this Pokemon
    public int Attack { get; set; }
}
class PokemonLINQLab
{
    static void Main()
    {
        // Sample data: list of Pokemon
        var pokemons = new List<Pokemon>
        {
            new Pokemon { Id = 1, Name = "Bulbasaur", Type = "Grass", Level = 15, Attack = 49 },
            new Pokemon { Id = 2, Name = "Charmander", Type = "Fire", Level = 36, Attack = 52 },
            new Pokemon { Id = 3, Name = "Squirtle", Type = "Water", Level = 10, Attack = 48 },
            new Pokemon { Id = 4, Name = "Pikachu", Type = "Electric", Level = 22, Attack = 55 },
            new Pokemon { Id = 5, Name = "Eevee", Type = "Normal", Level = 25, Attack = 55 },
            new Pokemon { Id = 6, Name = "Psyduck", Type = "Water", Level = 20, Attack = 52 },
            new Pokemon { Id = 7, Name = "Geodude", Type = "Rock", Level = 18, Attack = 80 },
            new Pokemon { Id = 8, Name = "Machop", Type = "Fighting", Level = 12, Attack = 80 }
        };
        // LINQ Query: find Pokemon ready to evolve (level 16 for first evolution)
        var readyToEvolve = from p in pokemons
                            where p.Level >= 16
                            orderby p.Level
                            select p;
        // Execute the query and display the results
        Console.WriteLine("Pokemon Ready to Evolve:");
        foreach (var p in readyToEvolve)
        {
            Console.WriteLine($"Name: {p.Name}, Type: {p.Type}, Level: {p.Level}");
        }

        // Query 1: keep only the Pokemon with a high Attack
        var strongPokemon = (from p in pokemons
                             where p.Attack >= 50
                             select p).ToList();

        // Query 2: sort the strong Pokemon by name
        var sortedPokemon = (from p in strongPokemon
                             orderby p.Name
                             select p).ToList();

        // Display the strong Pokemon in alphabetical order
        Console.WriteLine("Strong Pokemon:");
        foreach (var p in sortedPokemon)
        {
            Console.WriteLine($"Name: {p.Name}, Type: {p.Type}, Attack: {p.Attack}");
        }

        // Query 3: find the Water type Pokemon, highest Level first
        var waterPokemon = (from p in pokemons
                            where p.Type == "Water"
                            orderby p.Level descending
                            select p).ToList();

        // Display the Water type Pokemon
        Console.WriteLine("Water Type Pokemon:");
        foreach (var p in waterPokemon)
        {
            Console.WriteLine($"Name: {p.Name}, Type: {p.Type}, Level: {p.Level}");
        }
    }
}
