using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using BetterRCompany.Patches;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using RealCompany.Patches;

namespace BetterRCompany
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class MainPlugin : BaseUnityPlugin 
    {
        private const string modGUID = "BetterRCompany.Teku";
        private const string modName = "BetterRCompany";
        private const string modVersion = "1.0.0";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static MainPlugin Instance;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);

                mls.LogInfo("================================");
                mls.LogInfo("=      MOD ONLINE STARTED      =");
                mls.LogInfo("================================");

            harmony.PatchAll(typeof(MainPlugin));
            harmony.PatchAll(typeof(MoonEventsPatch));
            harmony.PatchAll(typeof(GeneratingNumbers));
            harmony.PatchAll(typeof(PlayerPatches));
            harmony.PatchAll(typeof(EnemyPatches));
        }

        
        public static ManualLogSource mls;

        public static Dictionary<string, Dictionary<(float, float), string>> MapEvents = new Dictionary<string, Dictionary<(float, float), string>>()
        {
            {
                "41 Experimentation", new Dictionary<(float, float), string>
                {
                    {
                        (0.00f, 0.15f), "LandmineEvent"
                    },
                    {
                        (0.15f, 0.23f), "BrackenEvent"
                    },
                    {
                        (0.23f, 0.38f), "TimeTravelEvent"
                    },
                    {
                        (0.38f, 0.48f), "CockroachPartyEvent"
                    },
                    {
                        (0.48f, 0.56f), "ClownFiestaEvent"
                    },
                    {
                        (0.56f, 0.6f), "FakeFreeRoamEvent"
                    },
                    {
                        (0.6f, 0.64f), "RealFreeRoamEvent"
                    },
                    {
                        (0.64f, 0.79f), "ArachnophobiaEvent"
                    },
                    {
                        (0.79f, 0.83f), "BankRollEvent"
                    },
                    {
                        (0.83f, 0.87f), "TaxEvent"
                    },
                    {
                        (0.87f, 1f), "RandomTPEvent"
                    },
                }
            },
            {
                "220 Assurance", new Dictionary<(float, float), string>
                {
                    {
                        (0.00f, 0.15f), "LandmineEvent"
                    },
                    {
                        (0.15f, 0.23f), "BrackenEvent"
                    },
                    {
                        (0.23f, 0.38f), "TimeTravelEvent"
                    },
                    {
                        (0.38f, 0.48f), "CockroachPartyEvent"
                    },
                    {
                        (0.48f, 0.56f), "ClownFiestaEvent"
                    },
                    {
                        (0.56f, 0.6f), "FakeFreeRoamEvent"
                    },
                    {
                        (0.6f, 0.64f), "RealFreeRoamEvent"
                    },
                    {
                        (0.64f, 0.79f), "ArachnophobiaEvent"
                    },
                    {
                        (0.79f, 0.83f), "BankRollEvent"
                    },
                    {
                        (0.83f, 0.87f), "TaxEvent"
                    },
                    {
                        (0.87f, 1f), "RandomTPEvent"
                    },
                }
            },
            {
                "56 Vow", new Dictionary<(float, float), string>
                {
                    {
                        (0.00f, 0.15f), "LandmineEvent"
                    },
                    {
                        (0.15f, 0.23f), "BrackenEvent"
                    },
                    {
                        (0.23f, 0.38f), "TimeTravelEvent"
                    },
                    {
                        (0.38f, 0.48f), "CockroachPartyEvent"
                    },
                    {
                        (0.48f, 0.56f), "ClownFiestaEvent"
                    },
                    {
                        (0.56f, 0.6f), "FakeFreeRoamEvent"
                    },
                    {
                        (0.6f, 0.64f), "RealFreeRoamEvent"
                    },
                    {
                        (0.64f, 0.79f), "ArachnophobiaEvent"
                    },
                    {
                        (0.79f, 0.83f), "BankRollEvent"
                    },
                    {
                        (0.83f, 0.87f), "TaxEvent"
                    },
                    {
                        (0.87f, 1f), "RandomTPEvent"
                    },
                }
            },
            {
                "21 Offense", new Dictionary<(float, float), string>
                {
                    {
                        (0.00f, 0.15f), "LandmineEvent"
                    },
                    {
                        (0.15f, 0.23f), "BrackenEvent"
                    },
                    {
                        (0.23f, 0.38f), "TimeTravelEvent"
                    },
                    {
                        (0.38f, 0.48f), "CockroachPartyEvent"
                    },
                    {
                        (0.48f, 0.56f), "ClownFiestaEvent"
                    },
                    {
                        (0.56f, 0.6f), "FakeFreeRoamEvent"
                    },
                    {
                        (0.6f, 0.64f), "RealFreeRoamEvent"
                    },
                    {
                        (0.64f, 0.79f), "ArachnophobiaEvent"
                    },
                    {
                        (0.79f, 0.83f), "BankRollEvent"
                    },
                    {
                        (0.83f, 0.87f), "TaxEvent"
                    },
                    {
                        (0.87f, 1f), "RandomTPEvent"
                    },
                }
            },
            {
                "61 March", new Dictionary<(float, float), string>
                {
                    {
                        (0.00f, 0.15f), "LandmineEvent"
                    },
                    {
                        (0.15f, 0.23f), "BrackenEvent"
                    },
                    {
                        (0.23f, 0.38f), "TimeTravelEvent"
                    },
                    {
                        (0.38f, 0.48f), "CockroachPartyEvent"
                    },
                    {
                        (0.48f, 0.56f), "ClownFiestaEvent"
                    },
                    {
                        (0.56f, 0.6f), "FakeFreeRoamEvent"
                    },
                    {
                        (0.6f, 0.64f), "RealFreeRoamEvent"
                    },
                    {
                        (0.64f, 0.79f), "ArachnophobiaEvent"
                    },
                    {
                        (0.79f, 0.83f), "BankRollEvent"
                    },
                    {
                        (0.83f, 0.87f), "TaxEvent"
                    },
                    {
                        (0.87f, 1f), "RandomTPEvent"
                    },
                }
            },
            {
                "85 Rend", new Dictionary<(float, float), string>
                {
                    {
                        (0.00f, 0.07f), "LandmineEvent"
                    },
                    {
                        (0.07f, 0.12f), "BrackenEvent"
                    },
                    {
                        (0.12f, 0.19f), "TimeTravelEvent"
                    },
                    {
                        (0.19f, 0.25f), "CockroachPartyEvent"
                    },
                    {
                        (0.25f, 0.32f), "ClownFiestaEvent"
                    },
                    {
                        (0.32f, 0.34f), "FakeFreeRoamEvent"
                    },
                    {
                        (0.34f, 0.36f), "RealFreeRoamEvent"
                    },
                    {
                        (0.36f, 0.43f), "ArachnophobiaEvent"
                    },
                    {
                        (0.43f, 0.91f), "NutBlasterEvent"
                    },
                    {
                        (0.91f, 0.93f), "BankRollEvent"
                    },
                    {
                        (0.93f, 0.95f), "TaxEvent"
                    },
                    {
                        (0.95f, 1f), "RandomTPEvent"
                    },
                }
            },
            {
                "7 Dine", new Dictionary<(float, float), string>
                {
                    {
                        (0.00f, 0.07f), "LandmineEvent"
                    },
                    {
                        (0.07f, 0.12f), "BrackenEvent"
                    },
                    {
                        (0.12f, 0.19f), "TimeTravelEvent"
                    },
                    {
                        (0.19f, 0.25f), "CockroachPartyEvent"
                    },
                    {
                        (0.25f, 0.32f), "ClownFiestaEvent"
                    },
                    {
                        (0.32f, 0.34f), "FakeFreeRoamEvent"
                    },
                    {
                        (0.34f, 0.36f), "RealFreeRoamEvent"
                    },
                    {
                        (0.36f, 0.43f), "ArachnophobiaEvent"
                    },
                    {
                        (0.43f, 0.91f), "NutBlasterEvent"
                    },
                    {
                        (0.91f, 0.93f), "BankRollEvent"
                    },
                    {
                        (0.93f, 0.95f), "TaxEvent"
                    },
                    {
                        (0.95f, 1f), "RandomTPEvent"
                    },
                }
            },
            {
                "8 Titan", new Dictionary<(float, float), string>
                {
                    {
                        (0.00f, 0.15f), "LandmineEvent"
                    },
                    {
                        (0.15f, 0.23f), "BrackenEvent"
                    },
                    {
                        (0.23f, 0.38f), "TimeTravelEvent"
                    },
                    {
                        (0.38f, 0.48f), "CockroachPartyEvent"
                    },
                    {
                        (0.48f, 0.56f), "ClownFiestaEvent"
                    },
                    {
                        (0.56f, 0.6f), "FakeFreeRoamEvent"
                    },
                    {
                        (0.6f, 0.64f), "RealFreeRoamEvent"
                    },
                    {
                        (0.64f, 0.79f), "ArachnophobiaEvent"
                    },
                    {
                        (0.79f, 0.83f), "BankRollEvent"
                    },
                    {
                        (0.83f, 0.87f), "TaxEvent"
                    },
                    {
                        (0.87f, 1f), "RandomTPEvent"
                    },
                }
            },
        };

        public static Terminal terminal = FindObjectOfType<Terminal>();
        public static Item ShotgunAmmo;
        public static Item MyShotgun;
        public static bool EventActive = false;
        public static string currentPlanetName;
        public static string currentEventName;
        public static int BunkerSpiderIndex;
        public static int BrackenIndex;
        public static EnemyVent[] EnemyVents;
        public static Timer timer;
        public static int HoardingBugIndex;
        public static AnimationCurve DefaultLandmineSpawnRate = new AnimationCurve(new Keyframe[]
        {
            new Keyframe(0f, 2.5f),
        });
        public static bool ModifiedLootPool = false;
        public static List<SpawnableItemWithRarity> OriginalLootPool = new List<SpawnableItemWithRarity>();
        public static double EventIDRolled;
        public static double currentChance = 0.7;
        public static List<string> ClownItems = new List<string>()
        {
            "Clown horn",
            "Large axle",
            "Toy robot",
            "Airhorn",
            "Clownhorn",
            "Dentures",
            "Cash register"
        };

        public static List<string> LandmineMessages = new List<string>()
        { "Footstep Frenzy",
          "Watch Your Step",
          "Explosive trails",
          "Minefield Madness",
          "Boom Tango",
          "Explosive Ballet",
          "Toe Tapper Trap",
          "Stompocalypse",
          "Minesweeper's Nightmare",
          "Explosion Elegance",
          "Mambo No. Mines"
        };
        public static List<string> BrackenMessages = new List<string>()
        {
            "Phantom Prowlers",
            "Nightmare Stalkers",
            "White Eyes of Despair",
            "Full-Moon Eyes",
            "Wraith Gaze",
            "They Are Watching",
            "Terror Stare",
            "Terrorising Eyes"
        };
        public static List<string> TimeTravelMessages = new List<string>
        {
            "Paradox Playtime",
            "Quantum Gambit",
            "Temporal Turbulence",
            "Temporal Dillema",
            "Time Roulette",

        };
        public static List<string> CockroachPartyMessages = new List<string>()
        {
            "Insect Insurgence",
            "Roach Rampage",
            "Bug Bash Bash",
            "Cockroach Party",
            "Pest Party Parade",
            "Critter Convention",
            "Roach Rave"
        };
        public static List<string> ClownFiestaMessages = new List<string>()
        {
            "Havoc Honk",
            "Circus Attendees",
            "Clown Fiesta",
            "The Jokes On You"
        };
        public static List<string> ArachnophobiaMessages = new List<string>()
        {
            "Big Ass Spiders"
        };
        public static List<string> NutBlasterMessages = new List<string>()
        {
            "Blast-Away",
            "Nutblaster"
        };
        public static List<string> BankRollMessages = new List<string>()
        {
            "Big money",
            "Bankroll",
        };
        public static List<string> TaxMessages = new List<string>()
        {
            "Get Taxed",
            "Poland income tax",
            "Romanian income tax"
        };
        public static List<string> RandomTPMessages = new List<string>()
        {
            "Get Inverse TP'd"
        };
    }
}
