using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ValheimHack223
{
    internal class GameFunctions
    {
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
            int amount = 3;

            try
            {
                Player localPlayer = GetLocalPlayer();
                //round 1 consists of simple mobs and the later rounds are more difficult ones
                //[[golin, troll], [Drauger, Wraith, Valkyrie, Skeleton, Greydwarf, Dragon, StoneGolem]]
                //GameObject[] prefabMobsR1 = { -137741679, 425751481 };
                //GameObject[] prefabMobsR2 = { 505464631, 68955605, 1321415847, -1035090735, 1126707611, -408509179, 1814827443 };
                GameObject prefab = ZNetScene.instance.GetPrefab(-137741679);

                for (int i = 0; i < amount; i++)
                {
                    Character component = UnityEngine.Object.Instantiate<GameObject>(prefab, localPlayer.transform.position + localPlayer.transform.forward * 10.0f + Vector3.forward + (UnityEngine.Random.insideUnitSphere * 0.5f), Quaternion.identity).GetComponent<Character>();
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
    }
}
