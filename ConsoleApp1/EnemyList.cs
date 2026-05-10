using System.Collections.Generic;

// list of all enemies created using player class
class EnemyList
{
    public static Dictionary<string, Player> GetEnemy()
    {
        var weapons = WeaponData.GetWeapons();

        return new Dictionary<string, Player>
        {
            {
                "Skeleton",
                new Player(
                    "Skeleton",
                    PlayerClass.Rouge,
                    weapons["Default"],
                    -80
                )
            },

            {
                "Goblin",
                new Player(
                    "Goblin",
                    PlayerClass.Archer,
                    weapons["Bow"],
                    -60
                )
            },

            {
                "Ork",
                new Player(
                    "Ork",
                    PlayerClass.Barbarian,
                    weapons["Sword"],
                    -60
                )
            }
        };
    }
}