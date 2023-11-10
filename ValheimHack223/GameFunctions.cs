using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using System.Windows.Forms;
using Random = System.Random;

namespace ValheimHack223
{
    internal class GameFunctions
    {
        public static Transform arenaCentre;
        public static void SpawnMob()
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
            int amount = 1;

            try
            {
                Player localPlayer = GetLocalPlayer();
                //round 1 consists of simple mobs and the later rounds are more difficult ones
                //[[golin, troll], [Drauger, Wraith, Valkyrie, Skeleton, Greydwarf, Dragon, StoneGolem]]
                //GameObject[] prefabMobsR1 = { -137741679, 425751481 };
                //GameObject[] prefabMobsR2 = { 505464631, 68955605, 1321415847, -1035090735, 1126707611, -408509179, 1814827443 };
                GameObject prefab = ZNetScene.instance.GetPrefab(-1670867714);
                
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


        //  -1993569970 birch2
        //  735284842	Oak1
        //  -1183306829	shipwreck_karve_stern
        //  13326225	stake_wall
        //  -2111136205	shipwreck_karve_bow
        public static void SpawnArena()
        {
            Player localPlayer = GetLocalPlayer();
            Vector3 position;
            int[] prefabs = { -1993569970, 735284842, -1183306829, 13326225, -2111136205 };
            Random rnd = new Random();
            int index;

            try
            {
                //set arena centre
                arenaCentre = localPlayer.transform;

                //skip to morning
                UnityEngine.Object.FindObjectOfType<EnvMan>().SkipToMorning();

                DestroyAllTrees();

                DestroyAllMobs();

                SpawnWall();

                //Generate trees
                for (int i = 0; i < 20; i++)
                {
                    index = rnd.Next(0, 1);
                    position = GetRandPosition();
                    UnityEngine.Object.Instantiate<GameObject>(ZNetScene.instance.GetPrefab(prefabs[index]), position, Quaternion.identity);
                }

                //Generate structures
                for (int i = 0; i < 20; i++)
                {
                    index = rnd.Next(2, 4);
                    position = GetRandPosition();
                    position.y += 0.2f;
                    UnityEngine.Object.Instantiate<GameObject>(ZNetScene.instance.GetPrefab(prefabs[index]), position, Quaternion.identity);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void DestroyAllTrees()
        {
            //Find and destroy all trees
            TreeBase[] trees = Game.FindObjectsOfType(typeof(TreeBase)) as TreeBase[];
            int amount = trees.Length;

            foreach (var s in trees)
            {
                GameObject.DestroyImmediate(s.gameObject);
            }

            //Inform the player of the number of trees destroyed
            //String message = $"x{amount} trees destroyed";
            //MessageBox.Show(message);
        }

        public static void DestroyAllMobs()
        {
            //Find and destroy all mobs
            List<Character> characters = Character.GetAllCharacters();
            int amount = 0;

            foreach (Character i in characters)
            {
                if (!i.IsPlayer())
                {
                    HitData hit = new HitData();
                    hit.m_damage.m_damage = 9999.0f;
                    i.Damage(hit);
                    ++amount;
                }
            }

            //Inform the player of the number of mobs destroyed
            //String message = $"x{amount} mobs destroyed";
            //MessageBox.Show(message);
        }

        public static void SpawnWall()
        {
            //GameObject prefab = ZNetScene.instance.GetPrefab(-1245442852);
            GameObject prefab = ZNetScene.instance.GetPrefab(1524190963);
            Player localPlayer = GetLocalPlayer();
            int objectCount = 110;
            Vector3 spawnPosition;
            var spawnPositions = new List<Vector3>();
            float angle;

            for (int i = 0; i < objectCount; i++)
            {
                // Calculate the angle between objects
                angle = i * 360.0f / objectCount;

                //calculate the position to spawn the prefab
                spawnPosition = localPlayer.transform.position + Quaternion.Euler(0, angle, 0) * localPlayer.transform.forward * 100.0f + Quaternion.Euler(0, angle, 0) * localPlayer.transform.up * 25.0f;

                float y;
                ZoneSystem.instance.GetSolidHeight(spawnPosition, out y, 1000);
                spawnPosition.y = y;

                spawnPositions.Add(spawnPosition);
            }

            for (int i = 0; i < objectCount; i++)
            {
                // Instantiate the prefab at the calculated position
                UnityEngine.Object.Instantiate<GameObject>(prefab, spawnPositions[i], Quaternion.identity);
            }
        }

        public static Vector3 GetRandPosition()
        {
            Vector3 position;
            Random rnd = new Random();
            float angle = rnd.Next(1, 360);
            int distance = rnd.Next(10, 85);

            position = arenaCentre.position + Quaternion.Euler(0, angle, 0) * arenaCentre.forward * distance + Quaternion.Euler(0, angle, 0) * arenaCentre.up * 20.0f;

            position = new Vector3(position.x, position.y, position.z);

            float y;
            ZoneSystem.instance.GetSolidHeight(position, out y, 1000);
            position.y = y;

            return position;
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
