using UnityEngine;

namespace ValheimHack223
{
    public class Main : MonoBehaviour
    {
        private static bool mapLoaded = false;
        public Rect MenuWindow = new Rect(20f, 20f, 180f, 290f);

        public static int points = 0;
        public static bool alive = true;

        private void Start()
        {
            GameFunctions.generateDict();
            Form1 r = new Form1();
            r.Show();
            points += 100;
        }

        public void Update()
        {
            Player localPlayer = Player.m_localPlayer;
            
            if (GameFunctions.glowStickMode == true)
                GameFunctions.ChangeSkinColour();

            //Add points for a player attacking a zombie
            if (localPlayer.InAttack() && localPlayer.GetTimeSinceLastAttack() > 0.3)
            {
                GameFunctions.AddPointsIfNeeded(localPlayer);
            }

            if (SpawnSystem.started)
            {
                if (SpawnSystem.zombieSpawnCount == 0 && SpawnSystem.round != 0 && SpawnSystem.finished != true)
                {
                    GameFunctions.GetLocalPlayer().Message(MessageHud.MessageType.Center, "Next round");
                    SpawnSystem.StartSpawning();
                }

                SpawnSystem.CheckForSkeletonsAlive();
            }

            //When the map first loads - Create arena and start zombies spawning
            if (localPlayer.gameObject.activeSelf && !mapLoaded)
            {
                mapLoaded = true;
            }

            //Checking if a game over is required
            if (localPlayer.IsDead() && alive)
            {
                SpawnSystem.GameOver(localPlayer);
                alive = false;
            }

            if (localPlayer.IsDead() == false)
            {
                alive = true;
            }
        }

        //Settings for GUI
        private void OnGUI()
        {
            GUI.color = Color.yellow;
            GUI.Label(new Rect(300f, 0f, 600f, 40f), "Score: " + points + " Zombies: " + SpawnSystem.zombieSpawnCount + " Round: " + SpawnSystem.round + " Difficulty Multiplier: " + SpawnSystem.difficultyMultiplier); // This re-renders when points changes btw
        }
    }
}