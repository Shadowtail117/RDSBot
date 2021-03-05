using System;
using System.Collections.Generic;
using System.Text;

namespace RDSBot.Generators
{
    class Loot : Generator
    {
        public override string Name { get; set; } = "Loot Table";
        public override string Command { get; set; } = "loot";

        public override string Output(string[] args)
        {
            Random random = new Random();

            if(args.Length == 0)
            {
                return "No arguments specified!";
            }

            int gen;

            switch(args[0])
            {
                case "common":
                case "rare":
                    gen = random.Next(1, 30);
                    break;
                case "cursed":
                    gen = random.Next(1, 76);
                    break;

                default:
                    return "Invalid argument! Please choose common, rare, or cursed.";
            }

            return $"{Capitalize(args[0])} - " + gen + " (" + args[0] switch
            {
                "common" => gen switch
                {
                    1 => "Rusty Sword",
                    2 => "Rusty Axe",
                    3 => "Rusty Dagger",
                    4 => "Decrepit Armor",
                    5 => "Decrepit Shield",
                    6 => "Leather Tunic",
                    7 => "Necklace of Resist Fire",
                    8 => "Ring of Resist Frost",
                    9 => "Wooden Bow",
                    10 => "Decrepit Helmet",
                    11 => "Awkward Flail",
                    12 => "Broom",
                    13 => "Brick of Brick",
                    14 => "Scroll of a Random Spell",
                    15 => "Flask with Something",
                    16 => "Rusted Kobold Sword",
                    17 => "Flimsy Rapier",
                    18 => "Poorly Balanced Mace",
                    19 => "Chipped Spear",
                    20 => "Ring of Mundane",
                    int n when n >= 21 && n <= 25 => "10 Gold",
                    int n when n >= 26 && n <= 27 => "Drugs",
                    28 => "Bucket",
                    29 => "Crude Map",
                    30 => "Frying Pan",
                    _ => "Error in RDS Bot! Please contact the developer!",
                },
                "rare" => gen switch
                {
                    1 => "Sharpened Sword",
                    2 => "Sharpened Axe",
                    3 => "Sharpened Dagger",
                    4 => "Plate Armor",
                    5 => "Plate Shield",
                    6 => "Ring of Resist Magic",
                    7 => "Necklace of Sense Curse",
                    8 => "Greater Health Potion",
                    9 => "Intricate Crossbow",
                    10 => "Plate Helmet",
                    11 => "Balanced Flail",
                    12 => "Sharpened Spear",
                    13 => "Tome of a random spell",
                    14 => "Trinket of Soul Steal",
                    15 => "Kobold Sword",
                    16 => "Wand of something",
                    17 => "Balanced Rapier",
                    18 => "Battle-Hardened Mace",
                    19 => "Master-Crafted Staff",
                    20 => "Ring of Life",
                    int n when n >= 21 && n <= 25 => "50 Gold",
                    int n when n >= 26 && n <= 27 => "Druugs",
                    28 => "Upgrade Material",
                    29 => "Wisp in a Jar",
                    30 => "Dragon Blood Vial",
                    _ => "Error in RDS Bot! Please contact the developer!",
                },
                "cursed" => gen switch
                {
                    _ => "Error in RDS Bot! Please contact the developer!",
                }
            } + ")";


            static string Capitalize(string s)
            {
                return char.ToUpper(s[0]) + s[1..];
            }
        }
    }
}
