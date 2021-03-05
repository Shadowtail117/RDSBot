using System;

namespace RDSBot.Generators
{
    class Room : Generator
    {
        public override string Name { get; set; } = "Room Generator";
        public override string Command { get; set; } = "room";

        public override string Output()
        {
            Random random = new Random();

            int gen = random.Next(1, 75);

            return gen + " (" + gen switch
            {
                int n when n >= 1 && n <= 2 => "Rare Loot",
                int n when n >= 3 && n <= 10 => "Common Loot (5-10 becomes either random enemy, or event, later game)",
                int n when n >= 11 && n <= 14 => "Cursed Loot",
                int n when n >= 15 && n <= 19 => "Weak Enemy",
                int n when n >= 20 && n <= 24 => "Normal Enemy",
                int n when n >= 25 && n <= 28 => "Strong Enemy",
                int n when n >= 29 && n <= 31 => "Boss",
                int n when n >= 32 && n <= 35 => "Trap",
                int n when n >= 36 && n <= 40 => "Object",
                41 => "Room Select (3 Different Rooms for the player to choose, exit is never option)",
                42 => "Lore, Event, or Other",
                int n when n >= 43 && n <= 45 => "Trapped Chest (common loot)",
                46 => "Trapped Chest (rare)",
                47 => "Escape (only if dragon or after 1 boss kill, boss otherwise",
                int n when n >= 48 && n <= 50 => "Trader/Shop",
                int n when n >= 51 && n <= 53 => "Painting",
                int n when n >= 54 && n <= 55 => "Packed Chest (2-3 Rares, 0-1 cursed items, but curse when opened",
                int n when n >= 56 && n <= 58 => "Statue",
                int n when n >= 59 && n <= 60 => "Alter",
                int n when n >= 61 && n <= 65 => "Theme Shift, or Objective",
                int n when n >= 66 && n <= 72 => "Event, or Objective",
                int n when n >= 73 && n <= 74 => "Forsaken, Event, or Objective",
                75 => "Totem",

                _ => "Error in RDS Bot! Please contact the developer!",
            } + ")";
        }
    }
}
