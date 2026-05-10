/*
    Author: Tanner Wangemann
    Date: 5/2/26
    File. Program
    Purpose, main class to run program.
*/
using System;
using System.Runtime.InteropServices.Marshalling;
using System.Xml;

// class initiallized
class Program
{
    // main function to run program
    static void Main()
    {
        WriteLine("Welcome to my RPG game test!\n");

        // creates the player
        Player mainPlayer = CreatePlayer();
        
        // creates first dungeon
        Dungeon dungeon1 = new Dungeon(4, mainPlayer);

        dungeon1.createRooms();
    }
// function to create a new player
    static Player CreatePlayer()
    {
        // asks for the player name.
        var weapons = WeaponData.GetWeapons();
        
        WriteLine("What would you like your name to be?: ");
        string playerName = Console.ReadLine() ?? "No Name";
        WriteLine("");

        // printouts out each classa and gets input
        int i = 1;
        WriteLine("Ok " + playerName + ", what class would you like to be?");

        foreach(var pClass in Enum.GetValues<PlayerClass>())
        {
            WriteLine("[" + i + "] " + pClass);
            i++;
        }
        int choice = int.Parse(Console.ReadLine() ?? "3");
        PlayerClass playClass;
        Weapon EquipWeapon;

        // switch to set up class and weapon
        switch(choice)
        {
            case 1: 
                playClass = PlayerClass.Paladin;
                EquipWeapon = weapons["Sword and Shield"];
                break;
            case 2: 
                playClass = PlayerClass.Mage;
                EquipWeapon = weapons["Staff"];
                break;
            case 3:
                playClass = PlayerClass.Archer;
                EquipWeapon = weapons["Bow"];
                break;
            case 4: 
                playClass = PlayerClass.Rouge;
                EquipWeapon = weapons["Dagger"];
                break;
            case 5: 
                playClass = PlayerClass.Barbarian;
                EquipWeapon = weapons["Axe"];
                break;
            case 6:
                playClass = PlayerClass.Monk;
                EquipWeapon = weapons["Bow Staff"];
                break;
            case 7: 
                playClass = PlayerClass.Sorcerer;
                EquipWeapon = weapons["Magic Book"];
                break;
            default: 
                playClass = PlayerClass.Archer;
                EquipWeapon = weapons["Bow"];
                break;
        }
        WriteLine("");

        // bu(ilds player
        return new Player(playerName, playClass, EquipWeapon, 0);
    }

    // simple function so I dont have to write Console.WriteLine() everytime
    static void WriteLine(string whataver)
    {
        Console.WriteLine(whataver);
    }
}