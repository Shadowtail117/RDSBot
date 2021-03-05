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
                    1 => "Ring of Curse Attraction",
                    2 => "Ring of Dog Friendship",
                    3 => "Spider Mask",
                    4 => "Happy Helmet",
                    5 => "Goopy Cheeseburger",
                    6 => "Goblin King's Crown",
                    7 => "Sweaty Headband",
                    8 => "Gloves of Infinity",
                    9 => "Keystone Ring",
                    10 => "Helix Ring",
                    11 => "Magic Mirror",
                    12 => "Vial of Blood",
                    13 => "Teeth Necklace",
                    14 => "Cursed Amulet of Soul Stealing",
                    15 => "Raptor Skull Helmet",
                    16 => "Cursed Amulet of Sense Curse",
                    17 => "Ring of Wish",
                    18 => "Helm of the Water Seeker",
                    19 => "Ring of the Fool",
                    20 => "\"Special\" Ring",
                    21 => "Witches Eye",
                    22 => "Cursed Will",
                    23 => "Ring of Tomorrow",
                    24 => "Evil Doll",
                    25 => "Vial of Curse",
                    26 => "Xal's Helmet",
                    27 => "Soul Lens",
                    28 => "Mirror of Many Faces",
                    29 => "Gem of Unity",
                    30 => "Standard Ring",
                    31 => "Cursed Gold",
                    32 => "Redeemer",
                    33 => "Cursed Bird Flute",
                    34 => "Foul Helmet",
                    35 => "Shrunken Goat Hed of Juxidos",
                    36 => "Die of Fate",
                    37 => "Controller",
                    38 => "Painter's Brush",
                    39 => "Amulet of Mimic Friendship",
                    40 => "Odd Quartz",
                    41 => "Rabbit's Paw",
                    42 => "Tilted Coin",
                    43 => "Beast Collar",
                    44 => "Neko Surplus!",
                    45 => "Eye of Beholder",
                    46 => "Cursed Fancy Shoes",
                    47 => "Snake Skin Bracer",
                    48 => "Sketchbook of Horrors",
                    49 => "Charged Staff of Yoli",
                    50 => "Royal Jelly",
                    51 => "Blind Buff",
                    52 => "Necklace of the Deal",
                    53 => "Bracelet of the Monster",
                    54 => "Chalice",
                    55 => "Training Scroll",
                    56 => "Cursed Feather Duster",
                    57 => "Hubert's Box",
                    58 => "Wooden Spider Spoon",
                    59 => "Rosebud",
                    60 => "Rusted Knife",
                    61 => "Neko's Ears",
                    62 => "Lost Journal",
                    63 => "Cool Sunglasses",
                    64 => "The Perfect Record",
                    65 => "Poker Chip",
                    66 => "Belt of Feeding",
                    67 => "Fake Horns",
                    68 => "Wooden Keepsake Box",
                    69 => "Love Letter",
                    70 => "Danger Locket",
                    71 => "Lytri Leash",
                    72 => "Crawler Bracers",
                    73 => "Tattoo Kit",
                    74 => "A banana filled with spiders",
                    75 => "Cursed Dragon's Blood",
                    76 => "Drool Collar",
                    _ => "Error in RDS Bot! Please contact the developer!",
                },
                _ => "Error in RDS Bot! Please contact the developer!",
            } + ")";


            static string Capitalize(string s)
            {
                return char.ToUpper(s[0]) + s[1..];
            }
        }
    }
}
