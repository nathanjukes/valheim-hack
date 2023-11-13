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
        public static int zombieCount;

        public static int difficultyMultiplier;

        public static bool started = false;

        public static List<Character> skeletons = new List<Character>();

        private const int SKELETON_ID = -1035090735;
        private const double spawnIncreasePercentage = 0.2;


        private static int currentLevel = 1;
        private static float initialSpeed = 5f;
        private static float initialHealth = 1f;

        //[boar, gray dwarf, gd elite, gd shaman, stoneGolem, troll]
        private static int[] prefabMobsForest = { -1670867714, -137741679, -1374218359, 762782418, 1814827443, 425751481 };

        // [skelton, ghost, wraith, drauger, Draugr Elite]
        private static int[] prefabMobsUndead = { -1035090735, -696918929, 68955605, 505464631, 437915453 };

        // [goblin, goblin shaman, goblin brute, deathsquito, lox]
        private static int[] prefabMobsPlains = { -137741679, -315180887, -939999423, -1609638819, 1502599715 };

        // [Eikthyr, ElderBark, Bonemass, dragon, wraith]
        private static int[] prefabBosses = { -938588874, 938726216, -146537656, -408509179, 68955605 };

        private static int[][] roundMobs = { prefabMobsForest, prefabMobsPlains, prefabMobsUndead, prefabBosses };

        public static List<Character> enemyList = new List<Character>();

        public static Dictionary<Player, int> playerDeaths = new Dictionary<Player, int>(); 

        public static void Start(int difficulty)
        {
            difficultyMultiplier = difficulty;

            string message = $"Difficulty multiplier set to: {difficulty}";
            GameFunctions.GetLocalPlayer().Message(MessageHud.MessageType.Center, message);

            StartSpawning();

            PrintGoodLuckMessage();

            started = true;
        }

        public static void CheckForSkeletonsAlive()
        {
            for (int i = 0; i < skeletons.Count; i++)
            {
                Character skeleton = skeletons[i];
                if (skeleton.IsDead())
                {
                    zombieCount--;
                    skeletons.RemoveAt(i);
                }
            }
        }

        public static void StartSpawning()
        {
            round++;
            List<Player> players = Player.GetAllPlayers();

            for (int i = 0;i < players.Count; i++)
            {
                playerDeaths.Add(players[i], 0);
            }

            SpawnSystem.zombieCount = round * players.Count() * difficultyMultiplier;
            SpawnMob();
        }

        private static void SpawnSkeletons()
        {
            Player localPlayer = GameFunctions.GetLocalPlayer();
            GameObject prefab = ZNetScene.instance.GetPrefab(SKELETON_ID);

            for (int i = 0; i < SpawnSystem.zombieCount; i++)
            {
                Character enemy = UnityEngine.Object.Instantiate<GameObject>(prefab, GameFunctions.GetRandPosition(), Quaternion.identity).GetComponent<Character>();
                enemy.SetHealth(1f);
                skeletons.Add(enemy);
            }
        }

        public static void SpawnMob()
        {
            Player localPlayer = GameFunctions.GetLocalPlayer();
            List<int[]> roundMobId = new List<int[]>();

            // decide which enemy to spawn
            int spawner = round % 4;
            roundMobId.Add(roundMobs[spawner]);
            int limit = (round / 4) % 21;

            //increase stats based on round
            initialHealth = initialHealth + spawner;
            initialSpeed = initialSpeed + spawner;
            currentLevel = currentLevel + spawner;

            for (int i = 0; i < baseSpawnCount; i++)
            {
                GameObject prefab = ZNetScene.instance.GetPrefab(roundMobId[0][limit]);
                Character enemy = UnityEngine.Object.Instantiate<GameObject>(prefab, localPlayer.transform.position + localPlayer.transform.forward * 10.0f + Vector3.forward + (UnityEngine.Random.insideUnitSphere * 0.5f), Quaternion.identity).GetComponent<Character>();
                //update enemy stats
                enemy.SetLevel(currentLevel);
                enemy.m_health = initialHealth;
                enemy.m_speed = initialSpeed;

                enemyList.Add(enemy);
            }
            //clear so the next round mobs can be spawned in instead
            roundMobId.Clear();
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
            zombieCount = 0;
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
