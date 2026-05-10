using System;

// an enum that holds on the classes possible. 
enum PlayerClass
{
    Paladin, // 150 health
    Mage, // 75 health
    Archer, // 90 health
    Rouge, // 100 health
    Barbarian, // 120 health
    Monk, // 100 heallth
    Sorcerer // 80 health
}

// player class to create a player with stats.
class Player
{
    public string Name;
    public PlayerClass playerClass; // uses the enum
    public Weapon EquippedWeapon; // uses the weapon class
    public int maxHealth;
    public int Health;

    // initiallizer 
    public Player(string name, PlayerClass playerclass, Weapon weapon, int extraHealth)
    {
        Name = name;
        playerClass = playerclass;
        maxHealth = PlayerHealth() + extraHealth;
        Health = maxHealth;

        if (CanUseWeapon(playerClass, weapon))
            EquippedWeapon = weapon;
        else
        {
            Console.WriteLine(playerClass + " cannot use " + weapon.Name + "\n");
            var weapons = WeaponData.GetWeapons();
            EquippedWeapon = weapons["Default"];
        }
    }
    
    // function to show all of the players stats at once.
    public void ShowPlayer()
    {
        Console.WriteLine("Name: " + Name + " as " + playerClass);
        Console.WriteLine("Health: " + Health);
        Console.WriteLine("Equipped weapon: " + EquippedWeapon.Name);
        Console.WriteLine("Weapon Damage: " + EquippedWeapon.Damage + "\n");

        if(EquippedWeapon.weaponType == WeaopnType.magic)
        {
            Console.WriteLine(EquippedWeapon.Name + " has spell(s)");
            foreach(var spell in EquippedWeapon.SpellList)
            {
                Console.WriteLine(spell.Name + ": " + spell.Damage + " damage.");
            }
            Console.WriteLine();
        }
    }

    // fucntion to determine which weapons a class can use
    private bool CanUseWeapon(PlayerClass pClass, Weapon weapon)
    {
        if ((pClass == PlayerClass.Paladin) && 
        (weapon.weaponType != WeaopnType.defense && weapon.weaponType != WeaopnType.melee))
            return false;

        if ((pClass == PlayerClass.Mage) && (weapon.weaponType != WeaopnType.magic))
            return false;

        if ((pClass == PlayerClass.Archer) && (weapon.weaponType != WeaopnType.range))
            return false;

        if ((pClass == PlayerClass.Rouge) && 
        (weapon.weaponType != WeaopnType.melee && weapon.weaponType != WeaopnType.range))
            return false;
        
        if ((pClass == PlayerClass.Barbarian) && (weapon.weaponType != WeaopnType.melee))
            return false;

        if ((pClass == PlayerClass.Monk) && (weapon.weaponType != WeaopnType.melee))
            return false;

        if ((pClass == PlayerClass.Sorcerer) && (weapon.weaponType != WeaopnType.magic))
            return false;

        return true;
    }

    // function to determine player health
    private int PlayerHealth()
    {
        switch(playerClass) 
        {
        case PlayerClass.Paladin: return 150;
        case PlayerClass.Mage: return 75;
        case PlayerClass.Archer: return 90;
        case PlayerClass.Rouge: return 100;
        case PlayerClass.Barbarian: return 120;
        case PlayerClass.Monk: return 100;
        case PlayerClass.Sorcerer: return 80;
        default: return 100;
        }
    }

    // fucntion to intitiate damage between players
    public void isFoughtBy(Player attacker)
    {
        // picks number between 0-20
        Random rand = new Random();
        int result = rand.Next(1,21);

        if (result >= (20 - attacker.EquippedWeapon.Chance))
        {
            // outputs who does what damage to who
            Console.WriteLine(
                attacker.Name + " deals " + attacker.EquippedWeapon.Damage 
                + " damage to " + Name + " with " + attacker.EquippedWeapon.rarity 
                + " " + attacker.EquippedWeapon.Name + "\n"
            );
            // updates player health
            Health -= attacker.EquippedWeapon.Damage;
            Console.WriteLine(Name + " now has " + Health + " health\n");
        } else
        {
            Console.WriteLine(attacker.Name + " missed!\n");
        }        
    }

    // function to determine what percentage of missing health there is.
    public double getMissingHealth()
    {
        return (1.0 - ((double)Health/ maxHealth)) * 100;
    }

    // function to heal the player
    public void healPlayer(int amount)
    {
        Health += amount;
        Console.WriteLine("You stop at a campfire to heal");
        if (Health > maxHealth)
        {
            Health = maxHealth;
            Console.WriteLine(Name + " is at full health!\n");
        } else {
            Console.WriteLine(Name + " heals " + amount + " health\n");
        }
    }

    // shows the player class's weapon types
    public WeaopnType[] showWeaponType()
    {
        switch(playerClass)
        {
            case PlayerClass.Paladin: 
                return new[] {WeaopnType.defense, WeaopnType.melee};
            case PlayerClass.Mage:
                return new[] {WeaopnType.magic};
            case PlayerClass.Archer:
                return new[] {WeaopnType.range};
            case PlayerClass.Rouge:
                return new[] {WeaopnType.melee, WeaopnType.range};
            case PlayerClass.Barbarian:
                return new[] {WeaopnType.melee};
            case PlayerClass.Monk:
                return new[] {WeaopnType.melee};
            case PlayerClass.Sorcerer:
                return new[] {WeaopnType.magic};
            default: 
                return new[] 
                    {WeaopnType.melee, WeaopnType.range, WeaopnType.magic, WeaopnType.defense};

        }
    }
}