﻿using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace ValheimHack
{
    /// <summary>
    /// Turn on god mode and ghost mode
    /// </summary>

     [HarmonyPatch(typeof(Player), nameof(Player.InGodMode))]
     public static class Player_InGodMode_patch
     {
        private static override bool Postfix(ref Player __instance, ref bool __result)
        {
            __result = true;
	        return true;
        }
     }

     [HarmonyPatch(typeof(Player), nameof(Player.InGhostMode))]
     public static class Player_InGhostMode_patch
     {
        private static override bool Postfix(ref Player __instance, ref bool __result)
        {
            __result = true;
	        return true;
        }
     }
}
