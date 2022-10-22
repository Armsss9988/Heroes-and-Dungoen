namespace HerovsDungeon
{
    public class HerovsDungeon
    {
        public static void Main(string[] args)
        {
            //Create function
            Town townofPiece = new("Town of Piece");
            Shop shop = Shop.GetShop();
            //Monster
            Monster bat = new( "Bat", "Small and fast", 20, 0.3, 160, 160, 4,10);
            Monster vampire = new( "Vampire", "Cursed Blood Transformation, high speed but low damage", 30, 1, 250, 250, 5, 30);
            Monster golem = new("Golem", "born of stone, weak but very strong", 40, 0.1, 300, 300, 0.5, 50);
            Monster werewolf = new( "Werewolf", "Very strong wolf, human origination", 50, 0.5, 350, 350, 2, 70);
            //Boss
            Monster vampireLord = new( "VampireLord", "Born form hell", 70, 0.8, 400, 400, 4, 100);
            Monster logan = new( "Logan", "Hate the moon", 80, 0.5, 800, 800, 5, 200);
            //Dungeon
            Dungeon forestCave = new("Forest Cave");
            forestCave.Monsters().Add(bat);
            forestCave.Monsters().Add(vampire);
            forestCave.Monsters().Add(vampireLord);
            Dungeon mountainCave = new("Mountain Cave");
            mountainCave.Monsters().Add(golem);
            mountainCave.Monsters().Add(werewolf);
            mountainCave.Monsters().Add(logan);
            townofPiece.ListOfDungeon().Add(forestCave);
            townofPiece.ListOfDungeon().Add(mountainCave);
            //Armor
            //Head
            Head bronzeHeadArmor = new(5, "Bronze Head Armor", "Common armor for chicken", 100);
            Head ironHeadArmor = new(12, "Iron Head Armor", "Common armor for older chicken", 200);
            Head silverHeadArmor = new(20, "Silver Head Armor", "Common armor for legendary chicken", 300);
            shop.Headgears().Add(bronzeHeadArmor);
            shop.Headgears().Add(ironHeadArmor);
            shop.Headgears().Add(silverHeadArmor);
            //Chest
            Chest bronzeChestArmor = new(5, "Bronze Chest Armor", "Common armor for chicken", 100);
            Chest ironChestArmor = new(12, "Iron Chest Armor", "Common armor for older chicken", 200);
            Chest silverChestArmor = new(20, "Silver Chest Armor", "Common armor for legendary chicken", 300);
            shop.ChestGears().Add(bronzeChestArmor);
            shop.ChestGears().Add(ironChestArmor);
            shop.ChestGears().Add(silverChestArmor);
            //Leg
            Leg bronzeLegArmor = new(2, "Bronze Leg Armor", "Common armor for chicken", 100);
            Leg ironLegArmor = new(12, "Iron Leg Armor", "Common armor for older chicken", 200);
            Leg silverLegArmor = new(20, "Silver Leg Armor", "Common armor for legendary chicken", 300);
            shop.Leggears().Add(bronzeLegArmor);
            shop.Leggears().Add(ironLegArmor);
            shop.Leggears().Add(silverLegArmor);
            //Weapon
            //Bow
            Bow woodBow = new("Wood Bow", "brand with a rope", 20, 30, 15, 15, 15);
            Bow adventureBow = new("Adventure Bow", "Common bow for adventurer", 50, 60, 25, 40, 25);
            Bow deadeyeBow = new("Deadeye Bow", "an assasination", 500, 100, 15, 30, 35);
            shop.Bows().Add(woodBow);
            shop.Bows().Add(adventureBow);
            shop.Bows().Add(deadeyeBow);
            //sword
            Sword woodSword = new("Wood Sword", "a brand", 20, 30, 15, 50, 0);
            Sword adventureSword = new("Adventure Sword", "Common sword for adventurer", 100, 35, 25, 90, 10);
            Sword bloodSword = new("Blood Sword", "a bloodthirsty sword", 500, 40, 35, 150, 25);
            shop.Swords().Add(woodSword);
            shop.Swords().Add(adventureSword);
            shop.Swords().Add(bloodSword);

            //MENU
            Menu.MenuMain(townofPiece);

        }
    }
}