using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using GameNetcodeStuff;
using UnityEngine;
using LethalLib;

namespace RealCompany.Patches
{
    internal class PlayerPatches : Plugin
    {

        [HarmonyPatch(typeof(PlayerControllerB), "Awake")]
        [HarmonyPostfix]
        static void increasePlayerSlots(PlayerControllerB __instance)
        {
            List<GrabbableObject> list = new List<GrabbableObject>(__instance.ItemSlots);
            __instance.ItemSlots = new GrabbableObject[5];
            for (int i = 0; i < list.Count; i++)
            {
                __instance.ItemSlots[i] = list[i];
            }
        }

        [HarmonyPatch(typeof(HUDManager), "Awake")]
        [HarmonyPostfix]
        public static void DrawItemUI()
        {
            GameObject gameObject = GameObject.Find("Systems/UI/Canvas/IngamePlayerHUD/Inventory");
            List<string> list = new List<string>
            {
                "Slot0",
                "Slot1",
                "Slot2",
                "Slot3"
            };
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                Transform child = gameObject.transform.GetChild(i);
                if (!list.Contains(child.gameObject.name))
                {
                    Destroy(child.gameObject);
                }
            }
            UnityEngine.UI.Image[] array = new UnityEngine.UI.Image[5];
            array[0] = HUDManager.Instance.itemSlotIconFrames[0];
            array[1] = HUDManager.Instance.itemSlotIconFrames[1];
            array[2] = HUDManager.Instance.itemSlotIconFrames[2];
            array[3] = HUDManager.Instance.itemSlotIconFrames[3];
            UnityEngine.UI.Image[] array2 = new UnityEngine.UI.Image[5];
            array2[0] = HUDManager.Instance.itemSlotIcons[0];
            array2[1] = HUDManager.Instance.itemSlotIcons[1];
            array2[2] = HUDManager.Instance.itemSlotIcons[2];
            array2[3] = HUDManager.Instance.itemSlotIcons[3];

            GameObject gameObject2 = GameObject.Find("Systems/UI/Canvas/IngamePlayerHUD/Inventory/Slot3");
            GameObject gameObject3 = gameObject2;
            for (int j = 0; j < 1; j++)
            {
                GameObject gameObject4 = UnityEngine.Object.Instantiate<GameObject>(gameObject2);
                gameObject4.name = string.Format("Slot{0}", 3 + (j + 1));
                gameObject4.transform.parent = gameObject.transform;
                Vector3 localPosition = gameObject3.transform.localPosition;
                gameObject4.transform.SetLocalPositionAndRotation(new Vector3(localPosition.x + 50f, localPosition.y, localPosition.z), gameObject3.transform.localRotation);
                gameObject3 = gameObject4;
                array[3 + (j + 1)] = gameObject4.GetComponent<UnityEngine.UI.Image>();
                array2[3 + (j + 1)] = gameObject4.transform.GetChild(0).GetComponent<UnityEngine.UI.Image>();
            }
            HUDManager.Instance.itemSlotIconFrames = array;
            HUDManager.Instance.itemSlotIcons = array2;
        }
    }
}
