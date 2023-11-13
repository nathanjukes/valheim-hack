using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using UnityEngine;

namespace ValheimHack223
{
    internal class SpawnSystem : MonoBehaviour
    {
        public static int round = 0;
        public static int baseSpawnCount = 2;
        public static int zombieSpawnCount;

        public static int difficultyMultiplier;

        public static bool started = false;

        public static bool finished = false;

        //Will re-add players deaths after re-adding spawning
        public static Dictionary<Player, int> playerDeaths = new Dictionary<Player, int>();

        public static List<Character> enemyList = new List<Character>();

        private static int currentLevel = 1;
        private static float initialSpeed = 5f;
        private static float initialHealth = 1f;

        //[boar, gray dwarf, gd elite, gd shaman, stoneGolem, troll]
        private static int[] prefabMobsForest = { -1670867714, -137741679, -1374218359, 762782418, 1814827443, 425751481 };

        // [skeleton, ghost, wraith, drauger, Draugr Elite]
        private static int[] prefabMobsUndead = { -1035090735, -696918929, 68955605, 505464631, 437915453 };

        // [goblin, goblin shaman, goblin brute, deathsquito, lox]
        private static int[] prefabMobsPlains = { -137741679, -315180887, -939999423, -1609638819, 1502599715 };

        // [Eikthyr, ElderBark, Bonemass, dragon, wraith]
        private static int[] prefabBosses = { -938588874, 938726216, -146537656, -408509179, 68955605 };

        private static int[][] roundMobs = { prefabMobsForest, prefabMobsPlains, prefabMobsUndead, prefabBosses };


        public static void Start(int difficulty)
        {
            difficultyMultiplier = difficulty;

            string message = $"Difficulty multiplier set to: {difficulty}";
            GameFunctions.GetLocalPlayer().Message(MessageHud.MessageType.Center, message);

            //Add all players to keep track of their deaths
            List<Player> players = Player.GetAllPlayers();
            for (int i = 0; i < players.Count; i++)
            {
                playerDeaths.Add(players[i], 0);
            }

            StartSpawning();

            PrintGoodLuckMessage();

            started = true;
        }

        public static void CheckForSkeletonsAlive()
        {
            for (int i = 0; i < enemyList.Count; i++)
            {
                Character skeleton = enemyList[i];
                if (skeleton.IsDead())
                {
                    //Remove enemy from the list if killed
                    zombieSpawnCount--;
                    enemyList.RemoveAt(i);
                }
            }
        }

        public static void StartSpawning()
        {
            if (finished == false)
            {
                round++;

                List<Player> players = Player.GetAllPlayers();
                zombieSpawnCount = (round * players.Count()) * difficultyMultiplier;

                SpawnMob();
            }
        }

        public static void SpawnMob()
        {
            Player localPlayer = GameFunctions.GetLocalPlayer();
            //List<int[]> roundMobId = new List<int[]>();

            //Decide which enemy to spawn
            int spawner = round % 4;
            //roundMobId.Add(roundMobs[spawner]);
            int limit = (round / 4) % 21;

            //Increase stats based on round
            initialHealth = initialHealth + 1;
            initialSpeed = initialSpeed + 1;
            currentLevel = round;

            for (int i = 0; i < zombieSpawnCount; i++)
            {
                //GameObject prefab = ZNetScene.instance.GetPrefab(roundMobId[0][limit]);
                GameObject prefab = ZNetScene.instance.GetPrefab(prefabMobsUndead[0]);

                Character enemy = Instantiate(prefab, localPlayer.transform.position + localPlayer.transform.forward * 10.0f + Vector3.forward + (Random.insideUnitSphere * 0.5f), Quaternion.identity).GetComponent<Character>();
                
                //Update enemy stats
                enemy.SetLevel(currentLevel);
                enemy.m_health = initialHealth;
                enemy.m_speed = initialSpeed;

                enemyList.Add(enemy);
            }

            //Clear so the next round mobs can be spawned in instead
            //roundMobId.Clear();
        }

        public static void KillZombies()
        {
            List<Character> characters = Character.GetAllCharacters();
            foreach (Character i in characters)
            {
                if (i.IsPlayer())
                    continue;

                HitData hit = new HitData();
                hit.m_damage.m_damage = 9999f;
                i.Damage(hit);
            }
            MessageBox.Show("Killed All");
            zombieSpawnCount = 0;
        }

        private static void PrintGoodLuckMessage()
        {
            if (round == 1)
            {
                string message = "Good luck";
                GameFunctions.GetLocalPlayer().Message(MessageHud.MessageType.Center, message);
            }
        }

        public static void GameOver(Player localPlayer)
        {
            // check for if player is dead in some other function then call this function to potentially end the game for that player 
            // Player player = GameFunctions.GetLocalPlayer();
            // player.IsDead();

            int death = playerDeaths[localPlayer];
            death++;
            if (death == 3)
            {
                string message = "Game Over";
                GameFunctions.GetLocalPlayer().Message(MessageHud.MessageType.Center, message);
                Menu menu = new Menu();
                menu.Logout();
            }
            playerDeaths[localPlayer] = death;
        }
    }
}