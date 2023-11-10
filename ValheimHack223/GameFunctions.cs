using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace ValheimHack223
{
    internal class GameFunctions
    {
        public static void SpawnMobs()
        {
            // -137741679  Goblin 
            // 505464631   Drauger 
            // 68955605    Wraith
            // 1321415847    Valkyrie
            // -1035090735    Skeleton
            // 1126707611    Greydwarf
            // -408509179    Dragon
            // 1814827443    StoneGolem
            // 425751481    Troll
            // -315180887    GoblinShaman
            // 1671717323    Serpent

            //amount varies by round 
            int amount = 4;

            try
            {
                Player localPlayer = GetLocalPlayer();
                //round 1 consists of simple mobs and the later rounds are more difficult ones
                //[[golin, troll], [Drauger, Wraith, Valkyrie, Skeleton, Greydwarf, Dragon, StoneGolem]]
                //GameObject[] prefabMobsR1 = { -137741679, 425751481 };
                //GameObject[] prefabMobsR2 = { 505464631, 68955605, 1321415847, -1035090735, 1126707611, -408509179, 1814827443 };
                GameObject prefab = ZNetScene.instance.GetPrefab(-1035090735);
                
                for (int i = 0; i < amount; i++)
                {
                    Character enemy = UnityEngine.Object.Instantiate<GameObject>(prefab, localPlayer.transform.position + localPlayer.transform.forward * 10.0f + Vector3.forward + (UnityEngine.Random.insideUnitSphere * 0.5f), Quaternion.identity).GetComponent<Character>();
                    enemy.SetHealth(10f);
                }

                string message = $"Spawned x{amount}";
                localPlayer.Message(MessageHud.MessageType.Center, message);

            }
            catch
            {

            }
        }

        public static Player GetLocalPlayer()
        {
            return Player.m_localPlayer;
        }

        public static void AddPointsIfNeeded(Player localPlayer)
        {
            bool updatePoints = false;

            // Find enemies taking damage, if exists
            foreach (Character c in Character.GetAllCharacters())
            {
                // check if monster and not player + in range
                if (InRange(c, localPlayer, 4f) && !c.IsPlayer()) // This range may need to change
                {
                    if (c.m_onDamaged != null)
                    {
                        updatePoints = true;
                    }

                    // Could also do a death points here but for now, damage works fine

                    if (updatePoints)
                    {
                        Main.points += 10;
                        updatePoints = false;
                        Thread.Sleep(5);
                    }
                }
            }
        }

        private static bool InRange(Character c1, Character c2, float maxDistance)
        {
            Vector3 position1 = c1.GetTransform().position;
            Vector3 position2 = c2.GetTransform().position;

            float distance = CalculateDistance(position1, position2);

            return distance <= maxDistance;
        }

        private static float CalculateDistance(Vector3 pos1, Vector3 pos2)
        {
            float distance = (float)Math.Sqrt(Math.Pow(pos1.x - pos2.x, 2) + Math.Pow(pos1.y - pos2.y, 2) + Math.Pow(pos1.z - pos2.z, 2));
            return distance;
        }
    }
}
