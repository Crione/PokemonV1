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
        public string name { get; set; }
        public int level { get; set; }
        public bool gameOver { get; set; }
        public List<pokemon> team = new List<pokemon>();
}

    class trainer
    {
        public string name { get; set; }
        public List<pokemon> team = new List<pokemon>();
    }

    class pokemon
    {
        public string name { get; set; }
        public int level { get; set; }
        public string type1 { get; set; }
        public string type2 { get; set; }
        public int totalXp { get; set; }
        public int currentXp { get; set; }
        public int baseHp { get; set; }
        public int totalHp { get; set; }
        public int currentHp { get; set; }
        public int baseAttack { get; set; }
        public int attack { get; set; }
        public int baseDefence { get; set; }
        public int defence { get; set; }
        public int baseSpeed { get; set; }
        public int speed { get; set; }
        public int baseSpecial { get; set; }
        public int special { get; set; }
        public List<learnset> learnset = new List<learnset>();
        public List<move> moves = new List<move>();
        public string evolve { get; set; }
        public int evolveLevel { get; set; }
    }

    class learnset
    {
        public move move = new move();
        public int level { get; set; }
    }

    class move
    {
        public string name { get; set; }
        public string type { get; set; }
        public int power { get; set; }
        public int accuracy { get; set; }
        public int totalPp { get; set; }
        public int currentPp { get; set; }
    }

    class Game
    {
        public player _player = new player();
        public Random r = new Random();
        public string invoer;
        public string[] Common = new string[] {"Caterpie","Metapod","Weedle","Kakuna","Pidgey","Pidgeotto","Rattata","Spearow","Sandshrew","Nidoran_F",
            "Nidoran_M","Zubat","Oddish","Gloom","Paras","Venonat","Digglet","Meowth","Psyduck","Mankey","Poliwag","Poliwhirl","Abra","Machop","Bellsprout",
            "Tentacool","Geodude","Ponyta","Slowpoke","Magnemite","Doduo","Seel","Grimer","Shellder","Gastly", "Drowzee", "Krabby", "Voltorb", "Exeggcute",
            "Koffing","Tangela","Horsea","Goldeen","Staryu","Magikarp"};
        public string[] Uncommon = new string[] {"Butterfree","Beedrill","Pidgeot","Raticate","Fearow","Ekans","Arbok","Pikachu","Sandslash","Nidorina",
            "Nidorino","Clefairy","Clefable","Vulpix","Jigglypuff","Golbat","Vileplume","Parasect","Venomoth","Dugtrio","Persian","Primeape","Growlithe",
            "Poliwrath","Kadabra","Machoke","Weepinbell","Tentacruel","Graveler","Rapidash","Farfetchd","Dodrio","Dewgong","Muk","Cloyster","Haunter","Onyx",
            "Hypno","Kingler","Electrode","Cubone","Marowak","Lickitung","Weezing","Rhyhorn","Seadra","Seaking","Starmie","MrMime","Jynx","Electabuzz","Magmar",
            "Pinsir","Ditto","Dratini"};
        public string[] Rare = new string[] {"Nidoqueen","Nidoking","Ninetails","Wigglytuff","Golduck","Arcanine","Alakazam","Machamp",
            "Victreebel","Golem","Slowbro","Magneton","Gengar","Exeggutor","Hitmonlee","Hitmonchan","Rhydon","Chansey","Kangaskhan","Scyter","Tauros",
            "Gyarados","Dragonair"};
        public string[] Legendary = new string[] {"Lapras","Eevee","Vaporeon","Jolteon","Flareon","Porygon","Omanyte","Omastar","Kabuto","Kabutops",
            "Aerodactyl","Snorlax","Dragonite"};
        public string[] TestPokemon = new string[] {"Caterpie","Metapod","Butterfree","Weedle","Kakuna","Beedrill","Pidgey","Pidgeotto","Pidgeot","Rattata",
            "Raticate"};
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
            Staryu, Starmie, MrMime, Scyther, Jynx, Electabuzz, Magmar, Pinsir, Tauros, Magicarp, Gyarados, Lapras, Ditto, Eevee, Vaporeon, Jolteon, Flareon,
            Porygon, Omanyte, Omastar, Kabuto, Kabutops, Aerodactyl, Snorlax, Articuno, Zapdos, Moltres, Dratini, Dragonair, Dragonite, Mewtwo, Mew
        };

        public move Tackle = new move { name = "Tackle", type = "Normal", power = 35, accuracy = 95, totalPp = 35};
        public move Growl = new move { name = "Growl", type = "Normal", accuracy = 100, totalPp = 40 };
        public move Leech_Seed = new move { name = "Leech Seed", type = "Grass", accuracy = 90, totalPp = 10 };
        public move Vine_Whip = new move { name = "Vine Whip", type = "Grass", power = 35, accuracy = 100, totalPp = 10 };
        public move Poison_Powder = new move { name = "Poison Powder", type = "Poison", accuracy = 75, totalPp = 35 };
        public move Razor_Leaf = new move { name = "Razor Leaf", type = "Grass", power = 55, accuracy = 95, totalPp = 25 };
        public move Growth = new move { name = "Growth", type = "Normal", totalPp = 40 };
        public move Sleep_Powder = new move { name = "Sleep Powder", type = "Grass", accuracy = 75, totalPp = 15 };
        public move Solar_Beam = new move { name = "Solar Beam", type = "Grass", power = 120, accuracy = 100, totalPp = 10 };

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
                    WriteLine("[Oak] Right...");
                    WriteLine("      So your name is " + _player.name + "?");
                    WriteLine("");
                    while (invoer != "yes" && invoer != "no")    // Optie of je zeker weet dat het je player name word
                    {
                        WriteLine("      Enter 'yes' or 'no'");
                        invoer = Console.ReadLine();
                    }
                    Console.Clear();
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
            WriteLine("[Oak] Before you go you will need a Pokémon of your own.");
            Console.ReadLine();
            Console.Clear();
            WriteLine("[Oak] Since you don't have a Pokémon yet I will give you one.");
            Console.ReadLine();
            Console.Clear();
            invoer = "";
            while (invoer == "")
            {
                WriteLine("[Oak] Which Pokémon would you like?");
                WriteLine("      Bulbasaur, Charmander or Squirtle?");
                WriteLine("");
                while (invoer != "bulbasaur" && invoer != "charmander" && invoer != "squirtle")
                {
                    WriteLine("      Enter 'bulbasaur' or 'charmander' or 'squirtle'");
                    invoer = Console.ReadLine();
                }
                Console.Clear();
                switch (invoer)
                {
                    case "bulbasaur":
                        WriteLine("[Oak] Bulbasaur, a Grass and Poison type Pokémon.");
                        break;
                    case "charmander":
                        WriteLine("[Oak] Charmander, a Fire type Pokémon.");
                        break;
                    case "squirtle":
                        WriteLine("[Oak] Squirtle, a Water type Pokémon.");
                        break;
                }
                WriteLine("");
                WriteLine("      Are you sure that you want to take this Pokémon?");
                string choice = invoer;
                invoer = "";
                while (invoer != "yes" && invoer != "no")
                {
                    WriteLine("      Enter 'yes' or 'no'");
                    invoer = Console.ReadLine();
                }
                Console.Clear();
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
                    p.learnset = new List<learnset>
                    {
                        new learnset { move = Tackle, level = 1},
                        new learnset { move = Growl, level = 1},
                        new learnset { move = Leech_Seed, level = 7},
                        new learnset { move = Vine_Whip, level = 13},
                        new learnset { move = Poison_Powder, level = 20},
                        new learnset { move = Razor_Leaf, level = 27},
                        new learnset { move = Growth, level = 34},
                        new learnset { move = Sleep_Powder, level = 41},
                        new learnset { move = Solar_Beam, level = 48}
                    };
                    break;
                case "Ivysaur":
                    p.name = "Ivysaur";
                    p.type1 = "Grass";
                    p.type2 = "Poison";
                    p.baseHp = 60;
                    p.baseAttack = 62;
                    p.baseDefence = 63;
                    p.baseSpeed = 60;
                    p.baseSpecial = 80;
                    p.evolve = "Venusaur";
                    p.evolveLevel = 32;
                    break;
                case "Venusaur":
                    p.name = "Venusaur";
                    p.type1 = "Grass";
                    p.type2 = "Poison";
                    p.baseHp = 80;
                    p.baseAttack = 82;
                    p.baseDefence = 83;
                    p.baseSpeed = 80;
                    p.baseSpecial = 100;
                    break;
                case "Charmander":
                    p.name = "Charmander";
                    p.level = 5;
                    p.type1 = "Fire";
                    p.baseHp = 39;
                    p.baseAttack = 52;
                    p.baseDefence = 43;
                    p.baseSpeed = 65;
                    p.baseSpecial = 50;
                    p.evolve = "Charmeleon";
                    p.evolveLevel = 16;
                    break;
                case "Charmeleon":
                    p.name = "Charmeleon";
                    p.type1 = "Fire";
                    p.baseHp = 58;
                    p.baseAttack = 64;
                    p.baseDefence = 58;
                    p.baseSpeed = 80;
                    p.baseSpecial = 65;
                    p.evolve = "Charizard";
                    p.evolveLevel = 36;
                    break;
                case "Charizard":
                    p.name = "Charizard";
                    p.type1 = "Fire";
                    p.type2 = "Flying";
                    p.baseHp = 78;
                    p.baseAttack = 84;
                    p.baseDefence = 78;
                    p.baseSpeed = 100;
                    p.baseSpecial = 85;
                    break;
                case "Squirtle":
                    p.name = "Squirtle";
                    p.level = 5;
                    p.type1 = "Water";
                    p.baseHp = 44;
                    p.baseAttack = 48;
                    p.baseDefence = 65;
                    p.baseSpeed = 43;
                    p.baseSpecial = 50;
                    p.evolve = "Wartortle";
                    p.evolveLevel = 16;
                    break;
                case "Wartortle":
                    p.name = "Wartortle";
                    p.type1 = "Water";
                    p.baseHp = 59;
                    p.baseAttack = 63;
                    p.baseDefence = 80;
                    p.baseSpeed = 58;
                    p.baseSpecial = 65;
                    p.evolve = "Blastoise";
                    p.evolveLevel = 36;
                    break;
                case "Blastoise":
                    p.name = "Blastoise";
                    p.type1 = "Water";
                    p.baseHp = 79;
                    p.baseAttack = 83;
                    p.baseDefence = 100;
                    p.baseSpeed = 78;
                    p.baseSpecial = 85;
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

