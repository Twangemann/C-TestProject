using System.Collections.Generic;

// A class to create a dictionary of all possible weapons.
class WeaponData
{
    public static Dictionary<string, Weapon> GetWeapons()
    {
        var spells = GetSpell();
        
        var weapons = new Dictionary<string, Weapon>
        {
            // first string is how to find what it is, then weapon object is after
            {"Sword", new Weapon(
                10, 
                "sword", 
                WeaopnType.melee,
                Rarity.common,
                12)},

            {"Bow", new Weapon(
                8, 
                "Bow", 
                WeaopnType.range,
                Rarity.common,
                11)},

            {"Axe", new Weapon(
                15, 
                "Axe", 
                WeaopnType.melee,
                Rarity.common,
                9)},

            {"Staff", new Weapon(
                20, 
                "Staff", 
                WeaopnType.magic,
                Rarity.common,
                20)},
                
            {"Dagger", new Weapon(
                5, 
                "Dagger", 
                WeaopnType.melee,
                Rarity.common,
                14)},

            {"Sword and Shield", new Weapon(
                8, 
                "Sword and Shield", 
                WeaopnType.defense,
                Rarity.common,
                12)},

            {"Default", new Weapon(
                5, 
                "Club", 
                WeaopnType.melee, 
                Rarity.common,
                15)},

            {"Bow Staff", new Weapon(
                7,
                "Bow Staff",
                WeaopnType.melee,
                Rarity.common,
                11)},

            {"Magic Book", new Weapon(
                12,
                "Magic Book",
                WeaopnType.magic,
                Rarity.common,
                20)}
        };

        weapons["Staff"].SpellList = new Weapon[] {
            spells["Fireball"],
            spells["Iceball"],
            spells["Lightning Strike"]
        };

        weapons["Magic Book"].SpellList = new Weapon[]
        {
            spells["Skull Attack"],
            spells["Magic Bolt"]
        };

        return weapons;
    }

    public static Dictionary<string, Weapon> GetSpell(){
        return new Dictionary<string, Weapon>
        {
            {"Fireball", new Weapon(
                20,
                "Fireball",
                WeaopnType.magic,
                Rarity.common,
                14
            )},

            {"Iceball", new Weapon(
                23,
                "Iceball",
                WeaopnType.magic,
                Rarity.common,
                13
            )},

            {"Lightning Strike", new Weapon(
                40,
                "Lightning Strike",
                WeaopnType.magic,
                Rarity.uncommon,
                8
            )},

            {"Skull Attack", new Weapon(
                20, 
                "Skull Attack",
                WeaopnType.magic,
                Rarity.uncommon,
                10
            )},

            {"Magic Bolt", new Weapon(
                25,
                "Magic Bolt",
                WeaopnType.magic,
                Rarity.common,
                12
            )}
        };
    }
}