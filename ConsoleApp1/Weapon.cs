/*
    Weapon class to make a weapon object.
*/
using System;

enum WeaopnType
{
    melee,
    magic,
    range,
    defense
}

enum Rarity
{
    common,
    uncommon,
    rare,
    epic,
    legendary,
    mythic
}

class Weapon
{
    public int Damage;
    public string Name;
    public WeaopnType weaponType;
    public Rarity rarity;
    public int Chance;
    public Weapon[] SpellList;

    public Weapon(int damage, string name, WeaopnType weapontype, Rarity rarityType, int chance)
    {
        Damage = damage;
        Name = name;
        weaponType = weapontype;
        rarity = rarityType;
        Chance = chance;
        SpellList = Array.Empty<Weapon>();
    }

    public void showWeapon()
    {
        Console.WriteLine("Weapon Name: " + rarity + " " +  Name);
        Console.WriteLine("Damage: " + Damage);
        Console.WriteLine("Weapon Type: " + weaponType);
    }

    public void useSpell(int index)
    {
        if (weaponType != WeaopnType.magic)
        {
            Console.WriteLine(Name + " cannot use spells.");
            return;
        }
        
        if (SpellList == null || index >= SpellList.Length)
        {
            Console.WriteLine("Spell not available.");
            return;
        }

        Weapon spell = SpellList[index];
        Chance = spell.Chance;
        Console.WriteLine("Casting " + spell.Name + " for " + spell.Damage + " damage!");
        Damage = spell.Damage;
    }
}
