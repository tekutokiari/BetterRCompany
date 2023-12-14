using HarmonyLib;
using LethalLib;
using System.Collections.Generic;

namespace RealCompany.Patches
{
    internal class EnemyPatches : Plugin
    {
        static int randomNumberGen()
        {
            System.Random random = new System.Random();
            int nr = random.Next(1, 11);
            rn.Add(nr);
            return rn[rn.Count - 1];
        }


        //Significantly lowering the speed of the giant, may readjust in the future
        [HarmonyPatch(typeof(ForestGiantAI), "Update")]
        [HarmonyPostfix]
        static void ForestGiantPatch(ForestGiantAI __instance)
        {
            __instance.agent.speed = 3f;
        }

        //20% chance to not explode
        [HarmonyPatch(typeof(Landmine), "PressMineServerRpc")]
        [HarmonyPostfix]
        static void LandmineTPatch(Landmine __instance)
        {
            if (randomNumberGen() < 2)
            {
                __instance.ToggleMine(false);
            }
            else
            {
                __instance.ToggleMine(true);
            }
        }

        public static List<int> rn = new List<int>();
    }
}
