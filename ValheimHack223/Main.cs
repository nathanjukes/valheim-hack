using System;
using UnityEngine;
using System.Runtime.InteropServices;

namespace ValheimHack223
{
    public class Main : MonoBehaviour
    {
        [DllImport("kernel32")]
        static extern bool AllocConsole();

        public Rect MenuWindow = new Rect(20f, 20f, 180f, 290f);

        private void Start()
        {
            AllocConsole();
            Debug.Log("E2oie");

            Form1 r = new Form1();
            r.Show();
        }

        public void Update()
        {
            Player[] players = UnityEngine.Object.FindObjectsOfType(typeof(Player)) as Player[];
/*            foreach (var p in players)
                        {
                            p.SetHealth(50f);
                            p.SetMaxStamina(100f, true);
                            p.Heal(50f, true);
                        }
                        foreach (var p in Player.GetAllPlayers())
                        {
                            p.SetHealth(50f);
                            p.SetMaxStamina(100f, true);
                            p.Heal(50f, true);
                            p.SetLevel(p.GetLevel() + 1);
                        }
                        foreach (var p in Player.GetAllCharacters())
                        {
                            p.SetHealth(50f);
                            p.AddStamina(10f);
                        }*/
        }

        private void OnGUI()
        {
            //FPS Counter
            GUI.color = Color.green;
            GUI.Label(new Rect(300f, 0f, 600f, 40f), "FPSCOUNT");
        }

    }
}
