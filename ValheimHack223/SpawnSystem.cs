using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace ValheimHack223
{
    internal class SpawnSystem : MonoBehaviour
    {
        public static int round = 0;
        public static int baseSpawnCount = 2;
        public static int zombieCount;

        public static bool started = false;

        public static List<Character> skeletons = new List<Character>();

        private const int SKELETON_ID = -1035090735;
        private const double spawnIncreasePercentage = 0.2;

        public static void Start()
        {
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

            SpawnSystem.zombieCount = round * players.Count();
            SpawnSkeletons();
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
    }
}
