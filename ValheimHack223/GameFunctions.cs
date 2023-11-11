﻿using System;
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
        private static Transform arenaCentre;
        private const String ZOMBIES_MAP_NAME = "Zombies Map";
        private const String ZOMBIES_MAP_SEED = "b3s3sLJU2J";
        private static Dictionary<string, PrefabDict> itemShop;

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

        public static void StartGame()
        {

            try
            {
                generateDict();
                InitialLoadout();
                SpawnSystem.Start();
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

        public static void StartMap()
        {
            // Called in homescreen, starts map and server

            DeleteMapIfExists();

            CreateMap();

            SaveWithBackups save;
            SaveSystem.TryGetSaveByName(ZOMBIES_MAP_NAME, SaveDataType.World, out save);

            MessageBox.Show("World Name to load: " + save.m_name);

            //World.LoadWorld(save);
        }

        private static void CreateMap()
        {
            World world = new World(ZOMBIES_MAP_NAME, ZOMBIES_MAP_SEED);
            world.m_fileSource = FileHelpers.FileSource.Local;
            world.SaveWorldMetaData(DateTime.Now);
        }

        public static void DeleteMapIfExists()
        {
            World.RemoveWorld(ZOMBIES_MAP_NAME, FileHelpers.FileSource.Local);
        }

        public static void InitialLoadout()
        {
            List<Player> players = Player.GetAllPlayers();
            Inventory inventory;
            GameObject tempPrefab;

            foreach (Player i in players)
            {
                ClearInventory(i);
                inventory = i.GetInventory();
                tempPrefab = ZNetScene.instance.GetPrefab(itemShop["ShieldWood"].hash);
                inventory.AddItem(tempPrefab, 1);
                tempPrefab = ZNetScene.instance.GetPrefab(itemShop["Club"].hash);
                inventory.AddItem(tempPrefab, 1);
                tempPrefab = ZNetScene.instance.GetPrefab(itemShop["ArmorRagsChest"].hash);
                inventory.AddItem(tempPrefab, 1);
                tempPrefab = ZNetScene.instance.GetPrefab(itemShop["ArmorRagsLegs"].hash);
                inventory.AddItem(tempPrefab, 1);
            }
        }

        public static void ClearInventory(Player targetPlayer)
        {
            Inventory inventory = targetPlayer.GetInventory();
            inventory.RemoveAll();

            string message = $"Cleared the inventory";
            targetPlayer.Message(MessageHud.MessageType.Center, message);

        }

        private static void generateDict()
        {
            itemShop = new Dictionary<string, PrefabDict>{
                {"ArmorBronzeChest", new PrefabDict(-524840022, 1)},
                {"ArmorBronzeLegs", new PrefabDict(-1070975544, 1)},
                {"ArmorIronChest", new PrefabDict(-77418440, 1)},
                {"ArmorIronLegs", new PrefabDict(855433562, 1)},
                {"ArmorLeatherLegs", new PrefabDict(-129361023, 1)},
                {"ArmorPaddedCuirass", new PrefabDict(-2102914493, 1)},
                {"ArmorPaddedGreaves", new PrefabDict(-1316976302, 1)},
                {"ArmorRagsChest", new PrefabDict(-1873790835, 1)},
                {"ArmorRagsLegs", new PrefabDict(-1807008579, 1)},
                {"ArmorTrollLeatherChest", new PrefabDict(-1722809642, 1)},
                {"ArmorTrollLeatherLegs", new PrefabDict(-560834156, 1)},
                {"ArmorWolfChest", new PrefabDict(-914594978, 1)},
                {"ArmorWolfLegs", new PrefabDict(-1695215220, 1)},
                {"AtgeirBlackmetal", new PrefabDict(275694258, 4) },
                {"AtgeirBronze", new PrefabDict(-971799304, 2)},
                {"AtgeirIron", new PrefabDict(-1697777810, 3)},
                {"AxeBlackMetal", new PrefabDict(1694548656, 4)},
                {"AxeBronze", new PrefabDict(-533689078, 2)},
                {"AxeFlint", new PrefabDict(-1468314591, 1)},
                {"AxeIron", new PrefabDict(1790496580, 3)},
                {"AxeStone", new PrefabDict(-1779108881, 2)},
                {"Battleaxe", new PrefabDict(1943723324, 1)},
                {"BowDraugrFang", new PrefabDict(-1470815101, 1)},
                {"BowFineWood", new PrefabDict(1304037785, 1)},
                {"BowHuntsman", new PrefabDict(1410944776, 1)},
                {"Bow", new PrefabDict(1502599522, 1)},
                {"Club", new PrefabDict(829393066, 1)},
                {"KnifeBlackMetal", new PrefabDict(1790496580, 1)},
                {"KnifeChitin", new PrefabDict(-505018634, 1)},
                {"KnifeCopper", new PrefabDict(1410911030, 1)},
                {"KnifeFlint", new PrefabDict(-1567646802, 1)},
                {"MaceBronze", new PrefabDict(1042173684, 1)},
                {"MaceIron", new PrefabDict(-2074455458, 1)},
                {"MaceNeedle", new PrefabDict(1646123621, 1)},
                {"MaceSilver", new PrefabDict(-589925683, 1)},
                {"ShieldBlackmetal", new PrefabDict(-417136115, 1)},
                {"ShieldBlackmetalTower", new PrefabDict(-1283608710, 1)},
                {"ShieldBronzeBuckler", new PrefabDict(831128417, 1)},
                {"ShieldIronSquare", new PrefabDict(-66427558, 1)},
                {"ShieldIronTower", new PrefabDict(1602392070, 1)},
                {"ShieldKnight", new PrefabDict(-1748101970, 1)},
                {"ShieldSerpentscale", new PrefabDict(-344082900, 1)},
                {"ShieldSilver", new PrefabDict(-1248409586, 1)},
                {"ShieldWood", new PrefabDict(897989326, 1)},
                {"ShieldWoodTower", new PrefabDict(1729114779, 1)},
                {"SledgeIron", new PrefabDict(-228048586, 1)},
                {"SledgeStagbreaker", new PrefabDict(-698896327, 1)},
                {"SpearBronze", new PrefabDict(-1821145625, 1)},
                {"SpearChitin", new PrefabDict(678850310, 1)},
                {"SpearElderbark", new PrefabDict(-1438354023, 1)},
                {"SpearFlint", new PrefabDict(-1352659250, 1)},
                {"SpearWolfFang", new PrefabDict(228563121, 1)},
                {"Torch", new PrefabDict(795277336, 1)}
            };
        }
    }
}
