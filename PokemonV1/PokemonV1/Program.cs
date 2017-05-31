using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokémon
{
    class Program
    {
        static void Main(string[] args)
        {
            Game g = new Pokémon.Game();
            g.Start();
        }
    }


    class player
    {
        public string name;
        public int level;
        public bool gameOver;
        public List<pokemon> team = new List<pokemon>();
    }

    class trainer
    {
        public string name;
        public List<pokemon> team = new List<pokemon>();
    }

    class pokemon
    {
        public string name;
        public int level;
        public string type1;
        public string type2;
        public int totalXp;
        public int currentXp;
        public int baseHp;
        public int totalHp;
        public int currentHp;
        public int baseAttack;
        public int attack;
        public int baseDefence;
        public int defence;
        public int baseSpeed;
        public int speed;
        public int baseSpecial;
        public int special;
        public List<moves> moves = new List<moves>();
        public string evolve;
        public int evolveLevel;
    }

    class moves
    {
        public string name;
        public string type;
        public int damage;
        public int accuracy;
    }

    class Game
    {
        public player _player = new player();
        public Random r = new Random();
        public string invoer;
        public enum Types { Normal, Fire, Water, Electric, Grass, Ice, Fighting, Poison, Ground, Flying, Psychic, Bug, Rock, Ghost, Dragon };
        public enum Pokemon
        {
            Bulbasaur, Ivysaur, Venusaur, Charmander, Charmeleon, Charizard, Squirtle, Wartortle, Blastoise, Caterpie, Metapod, Butterfree,
            Weedle, Kakuna, Beedrill, Pidgey, Pidgeotto, Pidgeot, Rattata, Raticate, Spearow, Fearow, Ekans, Arbok, Pikachu, Raichu, Sandshrew, Sandslash,
            Nidoran_F, Nidorina, Nidoqueen, Nidoran_M, Nidorino, Nidoking, Clefairy, Clefable, Vulpix, Ninetails, Jigglypuff, Wigglytuff, Zubat, Golbat,
            Oddish, Gloom, Vileplume, Paras, Parasect, Venonat, Venomoth, Diglett, Dugtrio, Meowth, Persian, Psyduck, Golduck, Mankey, Primeape,
            Growlithe, Arcanine, Poliwag, Poliwhirl, Poliwrath, Abra, Kadabra, Alakazam, Machop, Machoke, Machamp, Bellsprout, Weepinbell, Victreebel,
            Tentacool, Tentacruel, Geodude, Graveler, Golem, Ponyta, Rapidash, Slowpoke, Slowbro, Magnemite, Magneton, Farfetchd, Doduo, Dodrio, Seel, Dewgong,
            Grimer, Muk, Shellder, Cloyster, Gastly, Haunter, Gengar, Onyx, Drowzee, Hypno, Krabby, Kingler, Voltorb, Electrode, Exeggcute, Exeggutor,
            Cubone, Marowak, Hitmonlee, Hitmonchan, Lickitung, Koffing, Weezing, Rhyhorn, Rhydon, Chansey, Tangela, Kangaskhan, Horsea, Seadra, Goldeen, Seaking,
            Staryu, Starme, MrMime, Scyther, Jynx, Electabuzz, Magmar, Pinsir, Tauros, Magicarp, Gyarados, Lapras, Ditto, Eevee, Vaporeon, Jolteon, Flareon,
            Porygon, Omanyte, Omastar, Kabuto, Kabutops, Aerodactyl, Snorlax, Articuno, Zapdos, Moltres, Dratini, Dragonair, Dragonite, Mewtwo, Mew
        };

        static void WriteLine(string text, ConsoleColor color = ConsoleColor.Gray, bool endline = true)     // Andere style van text output
        {
            Console.ForegroundColor = color;
            for (int t = 0; t < text.Length; t++)
            {
                Console.Write(text[t]);
                System.Threading.Thread.Sleep(15);
            }
            Console.ResetColor();
            if (endline == true)
            {
                System.Threading.Thread.Sleep(200);
                Console.WriteLine();
            }
        }

        public void Start()
        {
            _player.level = 1;
            _player.gameOver = false;
            beginGame();
            while (_player.gameOver == false)
            {
                int percentage = r.Next(1, 101);
                if (percentage > 0 && percentage <= 30)                      //30%
                {
                    trainerBattle();
                }
                else if (percentage > 30 && percentage <= 100)              //70%
                {
                    pokemonBattle();
                }
            }
        }

        public void beginGame()    //Begin Sequence
        {
            WriteLine("[???] Hello, there!");
            WriteLine("      Glad to meet you!");
            Console.ReadLine();
            Console.Clear();
            WriteLine("[???] Welcome to the world of Pokémon!");
            WriteLine("      My name is Oak.");
            Console.ReadLine();
            Console.Clear();
            WriteLine("[Oak] People affectionately refer to me as the Pokémon Proffesor.");
            Console.ReadLine();
            Console.Clear();
            WriteLine("[Oak] This world...");
            System.Threading.Thread.Sleep(500);
            Console.Clear();
            WriteLine("[Oak] ...is inhabited far and wide by creatures called Pokémon.");
            Console.ReadLine();
            Console.Clear();
            WriteLine("[Oak] For some people, Pokémon are pets.");
            WriteLine("      Others use them for battling.");
            Console.ReadLine();
            Console.Clear();
            WriteLine("[Oak] As for myself...");
            WriteLine("      I study Pokémon as a profession.");
            Console.ReadLine();
            Console.Clear();
            WriteLine("[Oak] But first, tell me a little about yourself.");
            Console.ReadLine();
            Console.Clear();
            invoer = "";
            while (invoer == "")    // Checked of er wat ingevult word
            {
                WriteLine("[Oak] What is your name?");
                invoer = Console.ReadLine();
                Console.Clear();
                while (invoer != "" && invoer != "yes")
                {
                    _player.name = invoer;
                    while (invoer != "yes" && invoer != "no")    // Optie of je zeker weet dat het je player name word
                    {
                        WriteLine("[Oak] Right...");
                        WriteLine("      So your name is " + _player.name + "?");
                        WriteLine("");
                        WriteLine("      Enter 'yes' or 'no'");
                        invoer = Console.ReadLine();
                        Console.Clear();
                        break;
                    }
                    switch (invoer)    // Gemaakte keuze bepaalt of je verder gaat
                    {
                        case "yes":
                            WriteLine("[Oak] " + _player.name + ", I remember it now!");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        case "no":
                            invoer = "";
                            break;
                        default:
                            invoer = "";
                            break;
                    }
                }
            }
            WriteLine("[Oak] Before you go you will need a pokemon of your own.");
            Console.ReadLine();
            Console.Clear();
            WriteLine("[Oak] Since you don't have a pokemon yet I will give you one.");
            Console.ReadLine();
            Console.Clear();
            invoer = "";
            while (invoer == "")
            {
                WriteLine("[Oak] Which Pokemon would you like?");
                WriteLine("      Bulbasaur, Charmander or Squirtle?");
                WriteLine("");
                while (invoer != "bulbasaur" && invoer != "charmander" && invoer != "squirtle")
                {
                    WriteLine("      Enter 'bulbasaur' or 'charmander' or 'squirtle'");
                    invoer = Console.ReadLine();
                    Console.Clear();
                }
                switch (invoer)
                {
                    case "bulbasaur":
                        WriteLine("[Oak] Ah, Bulbasaur a Grass and Poison type Pokemon.");
                        WriteLine("      He looks at you funny.");
                        break;
                    case "charmander":
                        WriteLine("[Oak] Hmm Charmander, a Fire type Pokemon.");
                        WriteLine("      He seems to be very confident.");
                        break;
                    case "squirtle":
                        WriteLine("[Oak] Squirtle, a Water type Pokemon.");
                        WriteLine("      She is a little shy.");
                        break;
                }
                WriteLine("");
                WriteLine("      Are you sure that you want to take this pokemon?");
                string choice = invoer;
                invoer = "";
                while (invoer != "yes" && invoer != "no")
                {
                    WriteLine("      Enter 'yes' or 'no'");
                    invoer = Console.ReadLine();
                    Console.Clear();
                }
                switch (invoer)
                {
                    case "yes":
                        switch (choice)
                        {
                            case "bulbasaur":
                                _player.team.Add(getPokemon("Bulbasaur"));
                                WriteLine("      Bulbasaur has been added to your Pokémon team!");
                                break;
                            case "charmander":
                                _player.team.Add(getPokemon("Charmander"));
                                WriteLine("      Charmander has been added to your Pokémon team!");
                                break;
                            case "squirtle":
                                _player.team.Add(getPokemon("Squirtle"));
                                WriteLine("      Squirtle has been added to your Pokémon team!");
                                break;
                        }
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "no":
                        invoer = "";
                        break;
                }
            }
            WriteLine("[Oak] " + _player.name + "!");
            System.Threading.Thread.Sleep(200);
            WriteLine("      Your very own Pokémon legend is about to unfold!");
            Console.ReadLine();
            Console.Clear();
            WriteLine("[Oak] A world of dreams and adventures with Pokémon awaits!");
            WriteLine("      Let's go!");
            Console.ReadLine();
            Console.Clear();
        }

        public pokemon getPokemon(string _pokemon)
        {
            pokemon p = new pokemon();
            p.level = (r.Next(_player.level - 5, (_player.level + 5) + 1)) + 5;
            switch (_pokemon)
            {
                case "Bulbasaur":
                    p.name = "Bulbasaur";
                    p.level = 5;
                    p.type1 = "Grass";
                    p.type2 = "Poison";
                    p.baseHp = 45;
                    p.baseAttack = 49;
                    p.baseDefence = 49;
                    p.baseSpeed = 45;
                    p.baseSpecial = 65;
                    p.evolve = "Ivysaur";
                    p.evolveLevel = 16;
                    break;
                case "Charmander":
                    p.name = "Charmander";
                    p.level = 5;
                    p.type1 = "Fire";
                    p.type2 = "";
                    p.baseHp = 39;
                    p.baseAttack = 52;
                    p.baseDefence = 43;
                    p.baseSpeed = 65;
                    p.baseSpecial = 50;
                    p.evolve = "Charmeleon";
                    p.evolveLevel = 16;
                    break;
                case "Squirtle":
                    p.name = "Squirtle";
                    p.level = 5;
                    p.type1 = "Water";
                    p.type2 = "";
                    p.baseHp = 44;
                    p.baseAttack = 48;
                    p.baseDefence = 65;
                    p.baseSpeed = 43;
                    p.baseSpecial = 50;
                    p.evolve = "Wartortle";
                    p.evolveLevel = 16;
                    break;
            }
            p.totalHp = (p.baseHp + ((p.baseHp / 50) * p.level));
            p.currentHp = p.totalHp;
            p.attack = (p.baseAttack + ((p.baseAttack / 50) * p.level));
            p.defence = (p.baseDefence + ((p.baseDefence / 50) * p.level));
            p.speed = (p.baseSpeed + ((p.baseSpeed / 50) * p.level));
            p.special = (p.baseSpecial + ((p.baseSpecial / 50) * p.level));
            p.totalXp = p.level * p.level * p.level;
            p.currentXp = 0;
            return p;
        }

        public trainer getTrainer()
        {
            trainer t = new trainer();
            return t;
        }

        public void pokemonBattle()
        {

        }

        public void trainerBattle()
        {
            getTrainer();
        }
    }
}

