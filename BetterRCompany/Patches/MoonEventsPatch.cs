using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameNetcodeStuff;
using HarmonyLib;
using UnityEngine;
using System.Threading;

namespace BetterRCompany.Patches
{
    internal class MoonEventsPatch : MainPlugin
    {
        static void AnnounceEvent()
        {
            try
            {
                Terminal terminal = FindObjectOfType<Terminal>();
                switch (currentEventName)
                {
                    case "LandmineEvent":
                        HUDManager.Instance.AddTextToChatOnServer($"<color=yellow>[The Company]:</color> {LandmineMessages[GeneratingNumbers.GenRandomNumber.Next(0, LandmineMessages.Count())]}.");
                        LandmineSpawnRate(RoundManager.Instance.currentLevel);
                        break;
                    case "BrackenEvent":
                        HUDManager.Instance.AddTextToChatOnServer($"<color=yellow>[The Company]:</color> {BrackenMessages[GeneratingNumbers.GenRandomNumber.Next(0, BrackenMessages.Count())]}.");
                        break;
                    case "TimeTravelEvent":
                        HUDManager.Instance.AddTextToChatOnServer($"<color=yellow>[The Company]:</color> {TimeTravelMessages[GeneratingNumbers.GenRandomNumber.Next(0, TimeTravelMessages.Count())]}.");
                        timer = new Timer(MoonTimeTimer, null, 0, 10000);
                        break;
                    case "CockroachPartyEvent":
                        HUDManager.Instance.AddTextToChatOnServer($"<color=yellow>[The Company]:</color> {CockroachPartyMessages[GeneratingNumbers.GenRandomNumber.Next(0, CockroachPartyMessages.Count())]}.");
                        break;
                    case "ClownFiestaEvent":
                        HUDManager.Instance.AddTextToChatOnServer($"<color=yellow>[The Company]:</color> {ClownFiestaMessages[GeneratingNumbers.GenRandomNumber.Next(0, ClownFiestaMessages.Count())]}.");
                        break;
                    case "FakeFreeRoamEvent":
                        HUDManager.Instance.AddTextToChatOnServer($"<color=yellow>[The Company]:</color> Enjoy your hard-earned free day.");
                        break;
                    case "RealFreeRoamEvent":
                        HUDManager.Instance.AddTextToChatOnServer($"<color=yellow>[The Company]:</color> Enjoy your hard-earned free day.");
                        break;
                    case "ArachnophobiaEvent":
                        HUDManager.Instance.AddTextToChatOnServer($"<color=yellow>[The Company]:</color> {ArachnophobiaMessages[GeneratingNumbers.GenRandomNumber.Next(0, ArachnophobiaMessages.Count())]}");
                        break;
                    case "NutBlasterEvent":
                        HUDManager.Instance.AddTextToChatOnServer($"<color=yellow>[The Company]:</color> {NutBlasterMessages[GeneratingNumbers.GenRandomNumber.Next(0, NutBlasterMessages.Count())]}");
                        ShotgunDeliver();
                        break;
                    case "BankRollEvent":
                        HUDManager.Instance.AddTextToChatOnServer($"<color=yellow>[The Company]:</color> {BankRollMessages[GeneratingNumbers.GenRandomNumber.Next(0, BankRollMessages.Count())]}");
                        if (currentPlanetName == "85 Rend" || currentPlanetName == "7 Dine" || currentPlanetName == "8 Titan")
                            terminal.groupCredits += GeneratingNumbers.GenRandomNumber.Next(220, 341);
                        else
                            terminal.groupCredits += GeneratingNumbers.GenRandomNumber.Next(80, 221);
                        terminal.SyncGroupCreditsServerRpc(terminal.groupCredits, terminal.numberOfItemsInDropship);
                        HUDManager.Instance.AddTextToChatOnServer($"Romanian government gave you a small bonus for your Romanian Vlone. Your new balance is: {terminal.groupCredits}");
                        break;
                    case "TaxEvent":
                        HUDManager.Instance.AddTextToChatOnServer($"<color=yellow>[The Company]:</color> {TaxMessages[GeneratingNumbers.GenRandomNumber.Next(0, TaxMessages.Count())]}");
                        terminal.groupCredits = terminal.groupCredits - (terminal.groupCredits * 20) / 100;
                        terminal.SyncGroupCreditsServerRpc(terminal.groupCredits, terminal.numberOfItemsInDropship);
                        HUDManager.Instance.AddTextToChatOnServer($"Tax paid to the Polish Government. Your new balance is: {terminal.groupCredits}");
                        break;
                    case "RandomTPEvent":
                        HUDManager.Instance.AddTextToChatOnServer($"<color=yellow>[The Company]:</color> {RandomTPMessages[GeneratingNumbers.GenRandomNumber.Next(0, RandomTPMessages.Count())]}");
                        break;
                }
            }catch(Exception e)
            {
                mls.LogError(e);
            }
        }

        public static Item GetItem(string myItem)
        {
            foreach (Item item in Resources.FindObjectsOfTypeAll<Item>())
            {
                if (item.name == myItem)
                {
                    return item;
                }
            }
            return null;
        }

        static void ShotgunDeliver()
        {
            try
            {
                Terminal terminal = FindObjectOfType<Terminal>();
                List<Item> list = terminal.buyableItemsList.ToList<Item>();
                MyShotgun = Instantiate<Item>(GetItem("Shotgun"));
                ShotgunAmmo = Instantiate<Item>(GetItem("GunAmmo"));
                list.Add(MyShotgun);
                list.Add(ShotgunAmmo);
                terminal.buyableItemsList = list.ToArray();
                //Delivering Shotgun Ammo
                terminal.orderedItemsFromTerminal.Add(terminal.buyableItemsList.Count() - 1);
                terminal.orderedItemsFromTerminal.Add(terminal.buyableItemsList.Count() - 1);
                terminal.orderedItemsFromTerminal.Add(terminal.buyableItemsList.Count() - 1);
                
                terminal.orderedItemsFromTerminal.Add(terminal.buyableItemsList.Count() - 1);
                terminal.orderedItemsFromTerminal.Add(terminal.buyableItemsList.Count() - 1);
                terminal.orderedItemsFromTerminal.Add(terminal.buyableItemsList.Count() - 1);
                //Delivering Shotguns
                terminal.orderedItemsFromTerminal.Add(terminal.buyableItemsList.Count() - 2);
                terminal.orderedItemsFromTerminal.Add(terminal.buyableItemsList.Count() - 2);
            }
            catch (Exception e)
            {
                mls.LogError(e);
            }
        }

        static void MoonTimeTimer(object state)
        {
            try
            {
                if (EventActive == true && currentEventName == "TimeTravelEvent" && StartOfRound.Instance.shipHasLanded)
                {
                    if (GeneratingNumbers.GenRandomNumber.Next(0, 2) == 0)
                        TimeOfDay.Instance.globalTimeSpeedMultiplier = 4.5f;
                    else
                        TimeOfDay.Instance.globalTimeSpeedMultiplier = -2.2f;
                }
            }catch(Exception e)
            {
                mls.LogError(e);
            }
        }

        static void LandmineSpawnRate(SelectableLevel currentPlayingLevel)
        {
            try
            {
                if (EventActive == true && currentEventName == "LandmineEvent")
                {
                    AnimationCurve LandmineNumberToSpawn = new AnimationCurve(new Keyframe[]
                    {
                        new Keyframe(0f, 150f),
                        new Keyframe(1f, 50f)
                    });
                    foreach (SpawnableMapObject spawnableObject in currentPlayingLevel.spawnableMapObjects)
                    {
                        Landmine LandmineComponent = spawnableObject.prefabToSpawn.GetComponentInChildren<Landmine>();
                        if (LandmineComponent != null && (LandmineComponent.name == spawnableObject.prefabToSpawn.name))
                        {
                            spawnableObject.numberToSpawn = LandmineNumberToSpawn;
                        }
                    }
                }
            }catch(Exception e)
            {
                mls.LogError(e);
            }
        }

        static async void RandomlyTPPlayers()
        {
            try
            {
                if (EventActive && currentEventName == "RandomTPEvent")
                {
                    var MyEnemyVents = FindObjectsOfType<EnemyVent>();
                    foreach (PlayerControllerB player in StartOfRound.Instance.allPlayerScripts)
                    {
                        if (player.isPlayerControlled)
                        {
                            player.beamUpParticle.Play();
                            await Task.Delay(1700);
                            player.isInsideFactory = true;
                            player.DropAllHeldItems();
                            player.transform.position = new Vector3(MyEnemyVents[GeneratingNumbers.GenRandomNumber.Next(0, MyEnemyVents.Count())].floorNode.position.x,
                                                                    MyEnemyVents[GeneratingNumbers.GenRandomNumber.Next(0, MyEnemyVents.Count())].floorNode.position.y,
                                                                    MyEnemyVents[GeneratingNumbers.GenRandomNumber.Next(0, MyEnemyVents.Count())].floorNode.position.z);
                            player.beamOutBuildupParticle.Play();
                            player.beamOutParticle.Play();
                        }
                    }
                }
            }catch(Exception e)
            {
                mls.LogError(e);
            }
        }

        [HarmonyPatch(typeof(ItemDropship), "ShipLeave")]
        [HarmonyPostfix]
        static void ItemDropShipLeave()
        {
            try
            {
                if(EventActive && currentEventName == "NutBlasterEvent")
                {
                    Terminal terminal = FindObjectOfType<Terminal>();
                    List<Item> list = terminal.buyableItemsList.ToList<Item>();
                    list.Remove(MyShotgun);
                    list.Remove(ShotgunAmmo);
                    terminal.buyableItemsList = list.ToArray();
                }
            }catch (Exception e)
            {
                mls.LogError(e);
            }
        }

        [HarmonyPatch(typeof(EnemyAI), "KillEnemyServerRpc")]
        [HarmonyPostfix]
        static void EnemyBounty(EnemyAI __instance)
        {
            try
            {
                if (EventActive && __instance.enemyType.isOutsideEnemy == false)
                {
                    Terminal terminal = FindObjectOfType<Terminal>();
                    terminal.groupCredits += 30;
                    terminal.SyncGroupCreditsServerRpc(terminal.groupCredits, terminal.numberOfItemsInDropship);
                }
            }catch(Exception e)
            {
                mls.LogError(e);
            }
        }

        [HarmonyPatch(typeof(StartOfRound), "ShipHasLeft")]
        [HarmonyPostfix]
        static void ResetValues(StartOfRound __instance)
        {
            try
            {
                TimeOfDay.Instance.globalTimeSpeedMultiplier = 1f;
                foreach (SpawnableMapObject SpawnableObject in RoundManager.Instance.currentLevel.spawnableMapObjects)
                {
                    Landmine _LandmineComponent = SpawnableObject.prefabToSpawn.GetComponentInChildren<Landmine>();
                    if (_LandmineComponent != null && (_LandmineComponent.name == SpawnableObject.prefabToSpawn.name))
                    {
                        SpawnableObject.numberToSpawn = DefaultLandmineSpawnRate;
                    }
                }
                EventActive = false;
                if (ModifiedLootPool == true)
                {
                    RoundManager.Instance.currentLevel.spawnableScrap.Clear();
                    foreach (SpawnableItemWithRarity MyItem in OriginalLootPool)
                        RoundManager.Instance.currentLevel.spawnableScrap.Add(MyItem);
                    ModifiedLootPool = false;
                }
            }catch(Exception ex)
            {
                mls.LogError(ex.Message);
            }
        }

        [HarmonyPatch(typeof(StartOfRound), "OnShipLandedMiscEvents")]
        [HarmonyPostfix]
        static void OpenDoors(StartOfRound __instance)
        {
            try
            {
                RandomlyTPPlayers();
            }catch(Exception e)
            {
                mls.LogInfo(e);
            }
        }

        [HarmonyPatch(typeof(RoundManager), "SpawnScrapInLevel")]
        [HarmonyPrefix]
        static void SpawnCustomScrapPool(RoundManager __instance)
        {
            try
            {
                if(ModifiedLootPool == false)
                {
                    foreach(SpawnableItemWithRarity myItem in __instance.currentLevel.spawnableScrap)
                        OriginalLootPool.Add(myItem);
                }

                if(EventActive && currentEventName == "ClownFiestaEvent")
                {
                    __instance.currentLevel.spawnableScrap.RemoveAll((SpawnableItemWithRarity item) => !ClownItems.Contains(item.spawnableItem.itemName));
                    ModifiedLootPool = true;
                    foreach (SpawnableItemWithRarity spawnableItemWithRarity in from item in __instance.currentLevel.spawnableScrap
                                                                                where (ClownItems.Contains(item.spawnableItem.itemName))
                                                                                select item)
                        spawnableItemWithRarity.rarity = 100;
                }
            }catch(Exception e) 
            {
                mls.LogError(e.Message);
            }
        }


        [HarmonyPatch(typeof(RoundManager), "LoadNewLevel")]
        [HarmonyPostfix]
        static void EventGen(RoundManager __instance)
        {
            try
            {
                currentPlanetName = __instance.currentLevel.PlanetName;
                if (currentPlanetName == "71 Gordion")
                    return;
                AnimationCurve _EnemyChances = new AnimationCurve(new Keyframe[]
                {
                        new Keyframe(0f, 100f),
                });
                __instance.currentLevel.enemySpawnChanceThroughoutDay = _EnemyChances;
                currentEventName = "";
                double eventRoll = GeneratingNumbers.EventChanceRoll();
                if (eventRoll <= currentChance)
                {
                    EventActive = true;
                    EventIDRolled = GeneratingNumbers.EventChanceRoll();
                    foreach (var myEvent in MapEvents[currentPlanetName])
                    {
                        if(EventIDRolled >= myEvent.Key.Item1 && EventIDRolled <= myEvent.Key.Item2)
                        {
                            currentEventName = myEvent.Value;
                        }
                    }
                    if(currentEventName == "BrackenEvent" || currentEventName == "CockroachPartyEvent" || currentEventName == "FakeFreeRoamEvent")
                    {
                        AnimationCurve EnemyChances = new AnimationCurve(new Keyframe[]
                        {
                        new Keyframe(0f, 0f),
                        });
                        __instance.currentLevel.enemySpawnChanceThroughoutDay = EnemyChances;
                    }
                    else
                    {
                        AnimationCurve EnemyChances = new AnimationCurve(new Keyframe[]
                        {
                        new Keyframe(0f, 100f),
                        });
                        __instance.currentLevel.enemySpawnChanceThroughoutDay = EnemyChances;
                    }
                    AnnounceEvent();
                }
            }
            catch (Exception ex)
            {
                mls.LogError(ex.Message);
            }
        }

        [HarmonyPatch(typeof(RoundManager), "SpawnEnemyOnServer")]
        [HarmonyPrefix]
        static void StopEnemySpawnOnEvent(RoundManager __instance)
        {
            try
            {
                if (EventActive && (currentEventName == "BrackenEvent" || currentEventName == "CockroachPartyEvent" || currentEventName == "FakeFreeRoamEvent"))
                    return;
            }catch(Exception e)
            {
                mls.LogError(e);
            }
        }

        [HarmonyPatch(typeof(RoundManager), "RefreshEnemyVents")]
        [HarmonyPostfix]
        static void SpawnEventEnemies(RoundManager __instance)
        {
            try
            {
                EnemyVents = FindObjectsOfType<EnemyVent>();
                if(EventActive)
                {
                    for(int j = 0; j < __instance.currentLevel.Enemies.Count; j++)
                    {
                        if (__instance.currentLevel.Enemies[j].enemyType.enemyName == "Flowerman")
                            BrackenIndex = j;
                        if (__instance.currentLevel.Enemies[j].enemyType.enemyName == "Hoarding bug")
                            HoardingBugIndex = j;
                        if (__instance.currentLevel.Enemies[j].enemyType.enemyName == "Bunker Spider")
                            BunkerSpiderIndex = j;
                    }
                    foreach(EnemyVent ExistingVent in EnemyVents)
                    {
                        if(currentEventName == "BrackenEvent")
                        {
                            __instance.SpawnEnemyGameObject(ExistingVent.floorNode.position, ExistingVent.floorNode.eulerAngles.y, BrackenIndex);
                        }
                        if(currentEventName == "CockroachPartyEvent")
                        {
                            for(int i = 0; i < 2; i++)
                                __instance.SpawnEnemyGameObject(ExistingVent.floorNode.position, ExistingVent.floorNode.eulerAngles.y, HoardingBugIndex);
                        }
                        if(currentEventName == "ArachnophobiaEvent")
                        {
                            __instance.SpawnEnemyGameObject(ExistingVent.floorNode.position, ExistingVent.floorNode.eulerAngles.y, BunkerSpiderIndex);
                        }
                        if(currentEventName == "FakeFreeRoamEvent")
                        {
                            __instance.SpawnEnemyGameObject(ExistingVent.floorNode.position, ExistingVent.floorNode.eulerAngles.y, BrackenIndex);
                            break;
                        }
                    }
                }
            }catch(Exception e)
            {
                mls.LogError(e);
            }
        }
    }
}
