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
            Console.ForegroundColor = ConsoleColor.Gray;
            Game g = new Pokémon.Game();
            g.Start();
        }
    }


    class player
    {
        public string name { get; set; }
        public int level { get; set; }
        public int coins { get; set; }
        public bool gameOver { get; set; }
        public List<pokemon> team = new List<pokemon>();
    }

    class bag
    {
        public List<potion> potions = new List<potion>();
        public List<revive> revives = new List<revive>();
        public List<pokeball> pokeballs = new List<pokeball>();
    }

    class item
    {
        public string type { get; set; }
        public int cost { get; set; }
        public int unlock { get; set; }
        public int amount { get; set; }
    }

    class potion : item
    {
        public int recover { get; set; }
    }

    class pokeball : item
    {
        public int catchrate { get; set; }
    }

    class revive : item
    {
        public int recover { get; set; }
    }

    class rival
    {
        public string name { get; set; }
        public List<pokemon> team = new List<pokemon>();
    }

    class town
    {
        public string name { get; set; }
    }

    class trainer
    {
        public int level { get; set; }
        public string prefix { get; set; }
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
        public bool faint { get; set; }
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
        #region
        public player _player = new player();
        public bag b = new bag();
        public rival _rival = new rival();
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

        public string[] TPrefix = new string[] {"Pokémon Trainer"};
        public string[] TName = new string[] {"Gordon", "Annette", "Shaun", "Anna", "Sara", "Max", "Charlotte", "Fernandez", "Tom", "Todd", "Hugh", "Cloudia", "Pablo",
            "Bruce", "Walter", "Jane", "Courtney", "Karla", "Bryan", "Laura", "Cindy", "Oscar", "Amber", "Lauren", "Marco", "Tina", "Patrick", "Mike", "Rick", "Luther"};

        public town pallet_town = new town { name = "Pallet Town"};
        public town viridian_city = new town { name = "Viridian City"};
        public town pewter_city = new town { name = "Pewter City"};
        public town cerulean_city = new town { name = "Cerulean City"};
        public town vermilion_city = new town { name = "Vermilion City"};
        public town lavender_town = new town { name = "Lavender Town"};
        public town celadon_city = new town { name = "Celadon City"};
        public town fuchsia_city = new town { name = "Fuchsia City"};
        public town saffron_city = new town { name = "Saffron City"};
        public town cinnabar_island = new town { name = "Cinnabar Island"};

        public pokeball pokeball = new pokeball { type = "Poké Ball", catchrate = 256, cost = 200, unlock = 1, amount = 0};
        public pokeball great_ball = new pokeball { type = "Great Ball", catchrate = 201, cost = 600, unlock = 15, amount = 0 };
        public pokeball ultra_ball = new pokeball { type = "Ultra Ball", catchrate = 151, cost = 1200, unlock = 30, amount = 0 };
        public pokeball master_ball = new pokeball { type = "Master Ball", catchrate = 1, unlock = 50, amount = 0 };

        public potion potion = new potion { type = "Potion", recover = 20, cost = 200, unlock = 1, amount = 0 };
        public potion super_potion = new potion { type = "Super Potion", recover = 50, cost = 700, unlock = 15, amount = 0 };
        public potion hyper_potion = new potion { type = "Hyper Potion", recover = 200, cost = 1500, unlock = 30, amount = 0 };
        public potion max_potion = new potion { type = "Max Potion", recover = 0, cost = 2500, unlock = 40, amount = 0 };

        public revive revive = new revive { type = "Revive", recover = 50, cost = 1500, unlock = 20, amount = 0 };
        public revive max_revive = new revive { type = "Max Revive", recover = 100, cost = 5000, unlock = 40, amount = 0 };

        public move Tackle = new move { name = "Tackle", type = "Normal", power = 35, accuracy = 95, totalPp = 35};
        public move Growl = new move { name = "Growl", type = "Normal", accuracy = 100, totalPp = 40 };
        public move Leech_Seed = new move { name = "Leech Seed", type = "Grass", accuracy = 90, totalPp = 10 };
        public move Vine_Whip = new move { name = "Vine Whip", type = "Grass", power = 35, accuracy = 100, totalPp = 10 };
        public move Poison_Powder = new move { name = "Poison Powder", type = "Poison", accuracy = 75, totalPp = 35 };
        public move Razor_Leaf = new move { name = "Razor Leaf", type = "Grass", power = 55, accuracy = 95, totalPp = 25 };
        public move Growth = new move { name = "Growth", type = "Normal", totalPp = 40 };
        public move Sleep_Powder = new move { name = "Sleep Powder", type = "Grass", accuracy = 75, totalPp = 15 };
        public move Solar_Beam = new move { name = "Solar Beam", type = "Grass", power = 120, accuracy = 100, totalPp = 10 };
        public move Scratch = new move { name = "Scratch", type = "Normal", power = 40, accuracy = 100, totalPp = 35 };
        public move Ember = new move { name = "Ember", type = "Fire", power = 40, accuracy = 100, totalPp = 25 };
        public move Leer = new move { name = "Leer", type = "Normal", accuracy = 100, totalPp = 30 };
        public move Rage = new move { name = "Rage", type = "Normal", power = 20, accuracy = 100, totalPp = 20 };
        public move Slash = new move { name = "Slash", type = "Normal", power = 70, accuracy = 100, totalPp = 20 };
        public move Flamethrower = new move { name = "Flamethrower", type = "Fire", power = 95, accuracy = 100, totalPp = 15 };
        public move Fire_Spin = new move { name = "Fire Spin", type = "Fire", power = 15, accuracy = 70, totalPp = 15 };
        public move Tail_Whip = new move { name = "Tail Whip", type = "Normal", accuracy = 100, totalPp = 30 };
        public move Bubble = new move { name = "Bubble", type = "Water", power = 20, accuracy = 100, totalPp = 30 };
        public move Water_Gun = new move { name = "Water_Gun", type = "Water", power = 40, accuracy = 100, totalPp = 25 };
        public move Bite = new move { name = "Bite", type = "Normal", power = 60, accuracy = 100, totalPp = 25 };
        public move Withdraw = new move { name = "Withdraw", type = "Water", totalPp = 40 };
        public move Skull_Bash = new move { name = "Skull Bash", type = "Normal", power = 100, accuracy = 100, totalPp = 15 };
        public move Hydro_Pump = new move { name = "Hydro Pump", type = "Water", power = 120, accuracy = 80, totalPp = 5 };
        public move String_Shot = new move { name = "String Shot", type = "Normal", power = 0, accuracy = 95, totalPp = 40 };
        public move Harden = new move { name = "Harden", type = "Normal", accuracy = 100, totalPp = 30 };
        public move Confusion = new move { name = "Confusion", type = "Psychic", power = 50, accuracy = 100, totalPp = 25 };
        public move Stun_Spore = new move { name = "Stun Spore", type = "Grass", accuracy = 75, totalPp = 30 };
        public move Supersonic = new move { name = "Supersonic", type = "Normal", accuracy = 55, totalPp = 20 };
        public move Whirlwind = new move { name = "Whirlwind", type = "Normal", accuracy = 100, totalPp = 20 };
        public move Psybeam = new move { name = "Psybeam", type = "Psychic", power = 65, accuracy = 100, totalPp = 20 };
        public move Poison_Sting = new move { name = "Poison Sting", type = "Poison", power = 15, accuracy = 100, totalPp = 35 };
        public move Fury_Attack = new move { name = "Fury Attack", type = "Normal", power = 15, accuracy = 85, totalPp = 20 };
        public move Focus_Energy = new move { name = "Focus Energy", type = "Normal", totalPp = 30 };
        public move Twineedle = new move { name = "Twineedle", type = "Bug", power = 25, accuracy = 100, totalPp = 20 };
        public move Pin_Missile = new move { name = "Pin Missile", type = "Bug", power = 14, accuracy = 85, totalPp = 20 };
        public move Agility = new move { name = "Agility", type = "Psychic", totalPp = 30 };
        public move Gust = new move { name = "Gust", type = "Normal", power = 40, accuracy = 100, totalPp = 35 };
        public move Sand_Attack = new move { name = "Sand Attack", type = "Normal", accuracy = 100, totalPp = 15 };
        public move Quick_Attack = new move { name = "Quick Attack", type = "Normal", power = 40, accuracy = 100, totalPp = 30 };
        public move Wing_Attack = new move { name = "Wing Attack", type = "Flying", power = 35, accuracy = 100, totalPp = 35 };
        public move Mirror_Move = new move { name = "Mirror Move", type = "Flying", totalPp = 20 };
        public move Hyper_Fang = new move { name = "Hyper Fang", type = "Normal", power = 80, accuracy = 90, totalPp = 15 };
        public move Super_Fang = new move { name = "Super_Fang", type = "Normal", accuracy = 90, totalPp = 10 };
        #endregion                                     //Alle aanroepingen

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

        public bag fillBag()
        {
            b.pokeballs.Add(pokeball);
            b.pokeballs.Add(great_ball);
            b.pokeballs.Add(ultra_ball);
            b.pokeballs.Add(master_ball);
            b.potions.Add(potion);
            b.potions.Add(super_potion);
            b.potions.Add(hyper_potion);
            b.potions.Add(max_potion);
            b.revives.Add(revive);
            b.revives.Add(max_revive);
            b.pokeballs.Where(pokeball => pokeball.type == "Poké Ball").ToList().ForEach(pokeball => pokeball.amount = pokeball.amount + 5);
            b.potions.Where(potion => potion.type == "Potion").ToList().ForEach(potion => potion.amount = potion.amount + 1);
            return b;
        }

        public void Start()
        {
            _player.level = 1;
            _player.gameOver = false;
            bag b = fillBag();
            //beginGame();
            while (_player.gameOver == false)
            {
                invoer = Console.ReadLine();
                if(invoer == "")
                {
                    int percentage = r.Next(1, 101);
                    if (percentage > 0 && percentage <= 28)                      //28%
                    {
                        trainer t = getTrainer();
                        WriteLine(t.prefix + " " + t.name + " wants to battle!");
                    }else if(percentage > 28 && percentage <= 95)              //67%
                    {
                        pokemon e = getPokemon(_player.level);
                        WriteLine("A wild " + e.name + " appeared!");
                    }else if(percentage > 95 && percentage <= 100)
                    {

                    }
                }else
                {
                    command(invoer);
                }
            }
        }
        
        public void command(string invoer)
        {
            int count;
            Console.WriteLine();
            switch (invoer)
            {
                case "/generate":
                    _player.team.Add(generatePokemon("Charmander", _player.level));
                    break;
                case "/team":
                    int t = 1;
                    Console.WriteLine("0------TEAM------0");
                    foreach (pokemon p in _player.team)
                    {
                        if (t != 1)
                        {
                            Console.WriteLine("|----------------|");
                        }
                        count = p.name.Count();
                        Console.Write("|" + p.name);
                        for (int i = 0; i <= (15 - count); i++)
                        {
                            Console.Write(" ");
                        }
                        Console.WriteLine("|");
                        Console.Write("|LEVEL");
                        count = p.level.ToString().Count();
                        for (int i = 0; i <= (10 - count); i++)
                        {
                            Console.Write(" ");
                        }
                        Console.WriteLine(p.level + "|");
                        Console.Write("|HP");
                        count = p.baseHp.ToString().Count() + p.currentHp.ToString().Count() + 1;
                        for (int i = 0; i <= (13 - count); i++)
                        {
                            Console.Write(" ");
                        }
                        Console.WriteLine(p.baseHp + "/" + p.currentHp + "|");
                        t++;
                    }
                    Console.WriteLine("0----------------0");
                    break;
                case "/bag !p":
                    Console.Write("0--");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("POKEBALLS");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("--0");
                    foreach(pokeball p in b.pokeballs)
                    {
                        if(p.amount != 0)
                        {
                            Console.Write("|" + p.type);
                            count = (p.type + p.amount.ToString()).Count();
                            for (int i = 0; i <= (12 - count); i++)
                            {
                                Console.Write(" ");
                            }
                            Console.WriteLine(p.amount + "|");
                        }
                    }
                    Console.WriteLine("0-------------0");
                    break;
                case "/bag !m":
                    Console.Write("0---");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("MEDICINE");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("---0");
                    foreach (potion p in b.potions)
                    {
                        if (p.amount != 0)
                        {
                            Console.Write("|" + p.type);
                            count = (p.type + p.amount.ToString()).Count();
                            for (int i = 0; i <= (13 - count); i++)
                            {
                                Console.Write(" ");
                            }
                            Console.WriteLine(p.amount + "|");
                        }
                    }
                    foreach (revive r in b.revives)
                    {
                        if (r.amount != 0)
                        {
                            Console.Write("|" + r.type);
                            count = (r.type + r.amount.ToString()).Count();
                            for (int i = 0; i <= (13 - count); i++)
                            {
                                Console.Write(" ");
                            }
                            Console.WriteLine(r.amount + "|");
                        }
                    }

                    Console.WriteLine("0--------------0");
                    break;
                default:
                    Console.WriteLine("Unknow command, please type '/help' for a list of commands.");
                    break;
            }
        }                                      //Alle invoerbare commands

        public void beginGame()
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
            WriteLine("[Oak] First you will need a Pokémon of your own.");
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
                WriteLine("      Are you sure that you want to take this Pokémon?");
                WriteLine("");
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
                                _player.team.Add(generatePokemon("Bulbasaur", _player.level));
                                WriteLine("Bulbasaur has been added to your Pokémon team!");
                                break;
                            case "charmander":
                                _player.team.Add(generatePokemon("Charmander", _player.level));
                                WriteLine("Charmander has been added to your Pokémon team!");
                                break;
                            case "squirtle":
                                _player.team.Add(generatePokemon("Squirtle", _player.level));
                                WriteLine("Squirtle has been added to your Pokémon team!");
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
            invoer = "";
            /*WriteLine("[Oak] This is your rival, right?");
              Console.ReadLine();
              Console.Clear();
              while (invoer == "")
              {
                  WriteLine("[Oak] What was his name again?");
                  invoer = Console.ReadLine();
                  Console.Clear();
                  while (invoer != "" && invoer != "yes")
                  {
                      _rival.name = invoer;
                      WriteLine("[Oak] So his name is " + _rival.name + "?");
                      WriteLine("");
                      while (invoer != "yes" && invoer != "no")
                      {
                          WriteLine("      Enter 'yes' or 'no'");
                          invoer = Console.ReadLine();
                      }
                      Console.Clear();
                      switch (invoer)
                      {
                          case "yes":
                              WriteLine("[Oak] I remember it now!");
                              WriteLine("      His name is " + _rival.name + "!");
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
              invoer = "";*/
            WriteLine("[Oak] Before you go you should have some items...");
            WriteLine("      Here take this backpack, there are also some items in there for you.");
            Console.ReadLine();
            Console.Clear();
            WriteLine("Received the backpack from Proffesor Oak!");
            WriteLine("Type '/bag ![pocket]' to acces it.");
            Console.ReadLine();
            Console.Clear();
            WriteLine("5 Poké balls have been added to the Pokéballs pocket [!p]");
            Console.ReadLine();
            WriteLine("1 potion has been added to the Medicine pocket [!m]");
            Console.ReadLine();
            Console.Clear();
            WriteLine("[Oak] " + _player.name + "!");
            System.Threading.Thread.Sleep(200);
            WriteLine("      Your very own Pokémon legend is about to unfold!");
            Console.ReadLine();
            Console.Clear();
            WriteLine("[Oak] A world of dreams and adventures with Pokémon awaits!");
            WriteLine("      Let's go!");
            Console.ReadLine();
            Console.Clear();
        }                                                 //Begin game met prof. Oak

        public pokemon generatePokemon(string _pokemon, int level)
        {
            pokemon p = new pokemon();
            p.level = (r.Next(level - 5, (level + 5) + 1)) + 5;
            if(p.level < 5)
            {
                p.level = 5;
            }
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
                        new learnset { move = Tackle, level = 1 },
                        new learnset { move = Growl, level = 1 },
                        new learnset { move = Leech_Seed, level = 7 },
                        new learnset { move = Vine_Whip, level = 13 },
                        new learnset { move = Poison_Powder, level = 20 },
                        new learnset { move = Razor_Leaf, level = 27 },
                        new learnset { move = Growth, level = 34 },
                        new learnset { move = Sleep_Powder, level = 41 },
                        new learnset { move = Solar_Beam, level = 48 }
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
                    p.learnset = new List<learnset>
                    {
                        new learnset { move = Tackle, level = 1},
                        new learnset { move = Growl, level = 1 },
                        new learnset { move = Leech_Seed, level = 7 },
                        new learnset { move = Vine_Whip, level = 13 },
                        new learnset { move = Poison_Powder, level = 22 },
                        new learnset { move = Razor_Leaf, level = 30 },
                        new learnset { move = Growth, level = 38 },
                        new learnset { move = Sleep_Powder, level = 46 },
                        new learnset { move = Solar_Beam, level = 54 }
                    };
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
                    p.learnset = new List<learnset>
                    {
                        new learnset { move = Tackle, level = 1 },
                        new learnset { move = Growl, level = 1 },
                        new learnset { move = Leech_Seed, level = 7 },
                        new learnset { move = Vine_Whip, level = 13 },
                        new learnset { move = Poison_Powder, level = 22 },
                        new learnset { move = Razor_Leaf, level = 30 },
                        new learnset { move = Growth, level = 43 },
                        new learnset { move = Sleep_Powder, level = 55 },
                        new learnset { move = Solar_Beam, level = 65 }
                    };
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
                    p.learnset = new List<learnset>
                    {
                        new learnset { move = Scratch, level = 1 },
                        new learnset { move = Growl, level = 1 },
                        new learnset { move = Ember, level = 9 },
                        new learnset { move = Leer, level = 15 },
                        new learnset { move = Rage, level = 22 },
                        new learnset { move = Slash, level = 30 },
                        new learnset { move = Flamethrower, level = 38 },
                        new learnset { move = Fire_Spin, level = 46 }
                    };
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
                    p.learnset = new List<learnset>
                    {
                        new learnset { move = Scratch, level = 1 },
                        new learnset { move = Growl, level = 1 },
                        new learnset { move = Ember, level = 9 },
                        new learnset { move = Leer, level = 15 },
                        new learnset { move = Rage, level = 24 },
                        new learnset { move = Slash, level = 33 },
                        new learnset { move = Flamethrower, level = 42 },
                        new learnset { move = Fire_Spin, level = 56 }
                    };
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
                    p.learnset = new List<learnset>
                    {
                        new learnset { move = Scratch, level = 1 },
                        new learnset { move = Growl, level = 1 },
                        new learnset { move = Ember, level = 9 },
                        new learnset { move = Leer, level = 15 },
                        new learnset { move = Rage, level = 24 },
                        new learnset { move = Slash, level = 36 },
                        new learnset { move = Flamethrower, level = 46 },
                        new learnset { move = Fire_Spin, level = 55 }
                    };
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
                    p.learnset = new List<learnset>
                    {
                        new learnset { move = Tackle, level = 1 },
                        new learnset { move = Tail_Whip, level = 1 },
                        new learnset { move = Bubble, level = 8 },
                        new learnset { move = Water_Gun, level = 15 },
                        new learnset { move = Bite, level = 22 },
                        new learnset { move = Withdraw, level = 28 },
                        new learnset { move = Skull_Bash, level = 35 },
                        new learnset { move = Hydro_Pump, level = 42 }
                    };
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
                    p.learnset = new List<learnset>
                    {
                        new learnset { move = Tackle, level = 1 },
                        new learnset { move = Tail_Whip, level = 1 },
                        new learnset { move = Bubble, level = 8 },
                        new learnset { move = Water_Gun, level = 15 },
                        new learnset { move = Bite, level = 24 },
                        new learnset { move = Withdraw, level = 31 },
                        new learnset { move = Skull_Bash, level = 39 },
                        new learnset { move = Hydro_Pump, level = 47 }
                    };
                    break;
                case "Blastoise":
                    p.name = "Blastoise";
                    p.type1 = "Water";
                    p.baseHp = 79;
                    p.baseAttack = 83;
                    p.baseDefence = 100;
                    p.baseSpeed = 78;
                    p.baseSpecial = 85;
                    p.learnset = new List<learnset>
                    {
                        new learnset { move = Tackle, level = 1 },
                        new learnset { move = Tail_Whip, level = 1 },
                        new learnset { move = Bubble, level = 8 },
                        new learnset { move = Water_Gun, level = 15 },
                        new learnset { move = Bite, level = 24 },
                        new learnset { move = Withdraw, level = 31 },
                        new learnset { move = Skull_Bash, level = 42 },
                        new learnset { move = Hydro_Pump, level = 52 }
                    };
                    break;
                case "Caterpie":
                    p.name = "Caterpie";
                    p.type1 = "Bug";
                    p.baseHp = 45;
                    p.baseAttack = 30;
                    p.baseDefence = 35;
                    p.baseSpeed = 45;
                    p.baseSpecial = 20;
                    p.learnset = new List<learnset>
                    {
                        new learnset { move = Tackle, level = 1 },
                        new learnset { move = String_Shot, level = 1 }
                    };
                    break;
                case "Metapod":
                    p.name = "Metapod";
                    p.type1 = "Bug";
                    p.baseHp = 50;
                    p.baseAttack = 20;
                    p.baseDefence = 55;
                    p.baseSpeed = 30;
                    p.baseSpecial = 25;
                    p.learnset = new List<learnset>
                    {
                        new learnset { move = Harden, level = 1 }
                    };
                    break;
                case "Butterfree":
                    p.name = "Butterfree";
                    p.baseHp = 60;
                    p.type1 = "Bug";
                    p.type2 = "Flying";
                    p.baseAttack = 45;
                    p.baseDefence = 50;
                    p.baseSpeed = 70;
                    p.baseSpecial = 80;
                    p.learnset = new List<learnset>
                    {
                        new learnset { move = Confusion, level = 1},
                        new learnset { move = Poison_Powder, level = 15 },
                        new learnset { move = Stun_Spore, level = 16 },
                        new learnset { move = Sleep_Powder, level = 17 },
                        new learnset { move = Supersonic, level = 21 },
                        new learnset { move = Whirlwind, level = 26 },
                        new learnset { move = Psybeam, level = 32 }
                    };
                    break;
                case "Weedle":
                    p.name = "Weedle";
                    p.type1 = "Bug";
                    p.type2 = "Poison";
                    p.baseHp = 40;
                    p.baseAttack = 35;
                    p.baseDefence = 30;
                    p.baseSpeed = 50;
                    p.baseSpecial = 20;
                    p.learnset = new List<learnset>
                    {
                        new learnset { move = Poison_Sting, level = 1 },
                        new learnset { move = String_Shot, level = 1 }
                    };
                    break;
                case "Kakuna":
                    p.name = "Kakuna";
                    p.type1 = "Bug";
                    p.type2 = "Poison";
                    p.baseHp = 45;
                    p.baseAttack = 25;
                    p.baseDefence = 50;
                    p.baseSpeed = 35;
                    p.baseSpecial = 25;
                    p.learnset = new List<learnset>
                    {
                        new learnset { move = Harden, level = 1 }
                    };
                    break;
                case "Beedrill":
                    p.name = "Beedrill";
                    p.type1 = "Bug";
                    p.type2 = "Poison";
                    p.baseHp = 65;
                    p.baseAttack = 80;
                    p.baseDefence = 40;
                    p.baseSpeed = 75;
                    p.baseSpecial = 45;
                    p.learnset = new List<learnset>
                    {
                        new learnset { move = Fury_Attack, level = 1 },
                        new learnset { move = Focus_Energy, level = 16 },
                        new learnset { move = Twineedle, level = 20 },
                        new learnset { move = Rage, level = 25 },
                        new learnset { move = Pin_Missile, level = 30 },
                        new learnset { move = Agility, level = 35 }
                    };
                    break;
                case "Pidgey":
                    p.name = "Pidgey";
                    p.type1 = "Normal";
                    p.type2 = "Flying";
                    p.baseHp = 40;
                    p.baseAttack = 45;
                    p.baseDefence = 40;
                    p.baseSpeed = 56;
                    p.baseSpecial = 35;
                    p.learnset = new List<learnset>
                    {
                        new learnset { move = Gust, level = 1 },
                        new learnset { move = Sand_Attack, level = 5},
                        new learnset { move = Quick_Attack, level = 12 },
                        new learnset { move = Whirlwind, level = 19 },
                        new learnset { move = Wing_Attack, level = 28 },
                        new learnset { move = Agility, level = 36 },
                        new learnset { move = Mirror_Move, level = 44 }
                    };
                    break;
                case "Pidgeotto":
                    p.name = "Pidgeotto";
                    p.type1 = "Normal";
                    p.type2 = "Flying";
                    p.baseHp = 63;
                    p.baseAttack = 60;
                    p.baseDefence = 55;
                    p.baseSpeed = 71;
                    p.baseSpecial = 50;
                    p.learnset = new List<learnset>
                    {
                        new learnset { move = Gust, level = 1 },
                        new learnset { move = Sand_Attack, level = 5},
                        new learnset { move = Quick_Attack, level = 12 },
                        new learnset { move = Whirlwind, level = 21 },
                        new learnset { move = Wing_Attack, level = 31 },
                        new learnset { move = Agility, level = 40 },
                        new learnset { move = Mirror_Move, level = 49 }
                    };
                    break;
                case "Pigeot":
                    p.name = "Pigeot";
                    p.type1 = "Normal";
                    p.type2 = "Flying";
                    p.baseHp = 83;
                    p.baseAttack = 80;
                    p.baseDefence = 75;
                    p.baseSpeed = 91;
                    p.baseSpecial = 70;
                    p.learnset = new List<learnset>
                    {
                        new learnset { move = Gust, level = 1 },
                        new learnset { move = Sand_Attack, level = 5},
                        new learnset { move = Quick_Attack, level = 12 },
                        new learnset { move = Whirlwind, level = 21 },
                        new learnset { move = Wing_Attack, level = 31 },
                        new learnset { move = Agility, level = 44 },
                        new learnset { move = Mirror_Move, level = 54 }
                    };
                    break;
                case "Rattata":
                    p.name = "Rattata";
                    p.type1 = "Normal";
                    p.baseHp = 30;
                    p.baseAttack = 56;
                    p.baseDefence = 35;
                    p.baseSpeed = 72;
                    p.baseSpecial = 25;
                    p.learnset = new List<learnset>
                    {
                        new learnset { move = Tackle, level = 1 },
                        new learnset { move = Tail_Whip, level = 1},
                        new learnset { move = Quick_Attack, level = 7 },
                        new learnset { move = Hyper_Fang, level = 14 },
                        new learnset { move = Focus_Energy, level = 23 },
                        new learnset { move = Super_Fang, level = 34 },
                    };
                    break;
                case "Raticate":
                    p.name = "Raticate";
                    p.type1 = "Normal";
                    p.baseHp = 55;
                    p.baseAttack = 81;
                    p.baseDefence = 60;
                    p.baseSpeed = 97;
                    p.baseSpecial = 50;
                    p.learnset = new List<learnset>
                    {
                        new learnset { move = Tackle, level = 1 },
                        new learnset { move = Tail_Whip, level = 1},
                        new learnset { move = Quick_Attack, level = 7 },
                        new learnset { move = Hyper_Fang, level = 14 },
                        new learnset { move = Focus_Energy, level = 27 },
                        new learnset { move = Super_Fang, level = 41 },
                    };
                    break;
                default:
                    p.name = "Pidgey";
                    p.type1 = "Normal";
                    p.type2 = "Flying";
                    p.baseHp = 40;
                    p.baseAttack = 45;
                    p.baseDefence = 40;
                    p.baseSpeed = 56;
                    p.baseSpecial = 35;
                    p.learnset = new List<learnset>
                    {
                        new learnset { move = Gust, level = 1 },
                        new learnset { move = Sand_Attack, level = 5},
                        new learnset { move = Quick_Attack, level = 12 },
                        new learnset { move = Whirlwind, level = 19 },
                        new learnset { move = Wing_Attack, level = 28 },
                        new learnset { move = Agility, level = 36 },
                        new learnset { move = Mirror_Move, level = 44 }
                    };
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
            foreach (learnset l in p.learnset)
            {
                if(p.level >= l.level)
                {
                    if(p.moves.Count == 4)
                    {
                        int index = r.Next(0, 5);
                        p.moves.RemoveAt(index);
                    }
                    p.moves.Add(l.move);
                }
            }
            p.faint = false;
            return p;
        }              //Generate stats voor een bepaalde pokemon

        public trainer getTrainer()
        {
            int count;
            trainer t = new trainer();
            t.level = r.Next(_player.level - 2, _player.level + 4);
            if(t.level <= 0)
            {
                t.level = 1;
            }
            count = r.Next(0, TPrefix.Count());
            t.prefix = TPrefix[count];
            count = r.Next(0, TName.Count());
            t.name = TName[count];
            int p = 0;
            if(t.level < 10)
            {
                p = 2;
            }else if(t.level >= 10 && t.level < 15)
            {
                p = 3;
            }else if(t.level >= 15 && t.level < 20)
            {
                p = 4;
            }else if(t.level >= 20 && t.level < 25)
            {
                p = 5;
            }else if(t.level >= 25)
            {
                p = 6;
            }
            for(int i = 1; i <= p; i++)
            {
                count = r.Next(0, TestPokemon.Count());     //Alleen voor testen, functie randomPokemon() is de uiteindelijke code
                string pokemon = TestPokemon[count];
                pokemon a = generatePokemon(pokemon, _player.level);
                t.team.Add(a);
            }
            return t;
        }                                             //Random Trainer

        public pokemon getPokemon(int l)    //Random Pokemon
        {
            int count = r.Next(0, TestPokemon.Count());     //Alleen voor testen, functie randomPokemon() is de uiteindelijke code
            string pokemon = TestPokemon[count];
            pokemon e = generatePokemon(pokemon, _player.level);
            return e;
        }                                        

        public string randomPokemon(int l)
        {
            string p = "";
            int percentage = r.Next(0, 101);
            if (l < 15)
            {
                int count = r.Next(0, Common.Count());
                string pokemon = Common[count];
            }
            else if (l >= 15 && l < 30)
            {
                if (percentage <= 70)
                {
                    int count = r.Next(0, Common.Count());
                    string pokemon = Common[count];
                }
                else if (percentage > 70)
                {
                    int count = r.Next(0, Uncommon.Count());
                    string pokemon = Uncommon[count];
                }
            }
            else if (l >= 30 && l < 50)
            {
                if (percentage <= 63)
                {
                    int count = r.Next(0, Common.Count());
                    string pokemon = Common[count];
                }
                else if (percentage > 63 && percentage <= 90)
                {
                    int count = r.Next(0, Uncommon.Count());
                    string pokemon = Uncommon[count];
                }
                else if (percentage > 90)
                {
                    int count = r.Next(0, Rare.Count());
                    string pokemon = Rare[count];
                }
            }
            else if (l >= 50)
            {
                if (percentage <= 60)
                {
                    int count = r.Next(0, Common.Count());
                    string pokemon = Common[count];
                }
                else if (percentage > 60 && percentage <= 85)
                {
                    int count = r.Next(0, Uncommon.Count());
                    string pokemon = Uncommon[count];
                }
                else if (percentage > 85 && percentage <= 95)
                {
                    int count = r.Next(0, Rare.Count());
                    string pokemon = Rare[count];
                }
                else if (percentage > 95)
                {
                    int count = r.Next(0, Legendary.Count());
                    string pokemon = Legendary[count];
                }
            }
            return p;
        }                                      //Random Pokemon string, aan de hand van player/trainerlevel

        public void battle(trainer t, pokemon e)
        {

        }
    }
}

