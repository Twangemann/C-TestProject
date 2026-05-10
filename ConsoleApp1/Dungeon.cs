using System;
using System.Linq;

class Dungeon
{
    int Rooms;
    Player mainPlayer;

    private static Random rand = new Random();

    public Dungeon(int rooms, Player mainplayer)
    {
        Rooms = rooms;
        mainPlayer = mainplayer;
    }

    // function to handle player encounters in dungeon rooms
    public void Encounter(Player player, Player enemy)
    {
        WriteLine(player.Name + " encounters " + enemy.Name + "!\n");

        // loop during encounter
        do
        {
            if(player.Health <= 0) {
                WriteLine(player.Name + " has died!\n");
                Environment.Exit(0);
                break;
            }

            WriteLine("What would you like to do?: ");
            WriteLine("[1] Attack");
            WriteLine("[2] Run");
            WriteLine("[3] Show stats");
            WriteLine("[4] Quit");
            int choice = int.Parse(Console.ReadLine() ?? "");
            WriteLine("");

            if(choice == 1)
            {
                // player swings, checks if enemy is dead, and then enemy attacks
                WriteLine(player + " attacks!");
                if (player.EquippedWeapon.weaponType == WeaopnType.magic)
                {
                    int i = 1;
                    Console.WriteLine("Which spell would you like to use?");
                    foreach(var spell in player.EquippedWeapon.SpellList)
                    {
                        Console.WriteLine($"[{i}] " + player.EquippedWeapon.SpellList[i-1].Name);
                        i++;
                    }
                    int choice1 = int.Parse(Console.ReadLine() ?? "1");
                    player.EquippedWeapon.useSpell(choice1-1);
                }
                enemy.isFoughtBy(player);

                if(enemy.Health <= 0) {
                    WriteLine(enemy.Name + " has died.\n");
                    // chance to get a new weapon from enemy
                    Weapon newWeapon = GiveWeapon(player, enemy);

                    if (newWeapon != player.EquippedWeapon) {
                        WriteLine("Would you like to pick up " + newWeapon.rarity 
                        + " " + newWeapon.Name + "? (y/n)");
                        var answer = Console.ReadLine() ?? "";

                        if (answer.ToUpper() == "Y")
                        {
                            WriteLine("You picked up " + newWeapon.Name + ".\n");
                            player.EquippedWeapon = newWeapon;
                        } else
                        {
                            WriteLine("You skipped the " + newWeapon.Name + ".\n");
                        }
                    }
                    break;
                }

                WriteLine(enemy.Name + " swings back!");
                player.isFoughtBy(enemy);
            }
            else if (choice == 2)
            {
                // random chance to escape from encounter, based on health.
                WriteLine("You try to escapre!");
                int result = rand.Next(1, 101);

                if (result < player.getMissingHealth()) // uses percentage of missing health
                {
                    WriteLine(player.Name + " escaped!\n");
                    break;
                }
                // if you don't escape enemy attacks
                WriteLine("You weren't able to escape.");
                WriteLine(enemy.Name + " attacks in retaliation.");
                player.isFoughtBy(enemy);
            }
            else if (choice == 3)
            {
                // shows both player stats
                player.ShowPlayer();
                enemy.ShowPlayer();
            }
            else if (choice == 4)
            {
                // leaves game
                WriteLine("You have quit. Goodbye!");
                Environment.Exit(0);
            }
            else
            {
                WriteLine("That's not an option.\n");
            }

        } while(enemy.Health > 0 && player.Health > 0);
    }

    // simple function to make writeline easier
    private void WriteLine(string whataver)
    {
        Console.WriteLine(whataver);
    }

    // creates the number of rooms for the dungeon from rooms
    // rooms are random encounters or healing stops
    public void createRooms()
    {
        for(int i = 0; i < Rooms; i++)
        {
            var enemies = EnemyList.GetEnemy();
            Player[] enemy = new Player[]
            {
                enemies["Skeleton"],
                enemies["Goblin"],
                enemies["Ork"]
            };

            // grabs a random enemy
            int list = rand.Next(0,enemy.Length + 1);

            if (list < enemy.Length)
            {
                Encounter(mainPlayer, enemy[list]);
            }
            // will go to a healing stop
            else if (i != 0)
            {
                int amount = rand.Next(30, 70);
                mainPlayer.healPlayer(amount);
            } 
        }
    }

    // Gives a random weapon based on player's class.
    private Weapon GiveWeapon(Player player, Player enemy)
    {
        int result = rand.Next(0, enemy.maxHealth + 20);

        var weapons = WeaponData.GetWeapons();

        var allowedTypes = player.showWeaponType();

        var validWeapons = weapons.Values
            .Where(w => allowedTypes.Contains(w.weaponType))
            .ToList();

        if (validWeapons.Count == 0)
        {
            throw new Exception("This class has no weapon types.");
        }

        if (result <= enemy.maxHealth)
        {
            Random rnd = new Random();
            WriteLine(enemy.Name + " dropped a new weapon!");
            return validWeapons[rnd.Next(validWeapons.Count)];
        }
        else
        {
            return player.EquippedWeapon;
        }
    }
}
