To build:

- Add following references in Solution Explorer of project solution:
	- Assembly-CSharp.dll
	- assembly_valheim.dll
	- UnityEngine.dll
	- UnityEngine.CoreModule.dll
	- UnityEngine.IMGUIModule.dll

- Build Solution in VS in x64

To run:

./smi inject -p Valheim -a ValheimHack223.dll -n ValheimHack223 -c Loader -m Load

where ./smi is SharpMonoInjector.exe

How to use Zombies hack:
1. Build the solution using Visual Studio (VS) (If new changes have been made. For first use of the hack, skip to Step 2.)
2. Open Valheim into the Start Menu.
3. Run the ./smi command above to inject the DLL
4. Press "Load Map" to generate a Zombies Map.
5. Wait for the worlds section in Valheim to refresh until you see a world called Zombies Map appear.
6. Click on the world and select "Start Server" to make the game multiplayer.
7. Start the world and wait for Valheim to load.
8. Wait all of the other players are also load into the server (if using multiplayer).
9. Press "Start Game".
10. Each player on the server will recieve an axe, shield and some armour.
11. Play each round and eliminate all zombies to go to the next round.
12. Aim to achieve enough points to end the game. 


Resources:

https://www.unknowncheats.me/forum/unity/285864-beginners-guide-hacking-unity-games.html
https://github.com/KillStr3aK/Duranda/blob/main/Duranda.cs
https://github.com/Valheim-Modding/Wiki/wiki
https://github.com/RandyKnapp/ValheimMods
https://github.com/valheimPlus/ValheimPlus
