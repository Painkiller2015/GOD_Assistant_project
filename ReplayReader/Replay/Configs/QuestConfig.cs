using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Converters;
using ReplayReader.Replay.Data.Replay.Utils;
using System.Runtime.CompilerServices;
using ReplayReader.Replay.Data.Replay.Data;
using ReplayReader.Replay.Data.Replay.Entitys;

namespace ReplayReader.Replay.Data.Replay.Configs
{
    public interface IRotatableQuest
    {
    }
    public enum QuestRotationPeriod
    {
        Daily = 0,
        Weekly = 1
    }
    public class QuestConfig : ConfigDictionary<QuestConfig>, IRotatableQuest
    {
        private static readonly Dictionary<QuestRotationPeriod, int> PeriodDurationInHours;

        public static readonly Dictionary<QuestGroup, Dictionary<string, QuestConfig>> ConfigByGroup;

        public static readonly List<QuestTrigger> IgnoredInMatchTriggers;

        public static List<QuestConfig> DependentQuests;

        public List<QuestTarget> targets;

        public Reward reward;

        public bool enabled;

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool AndCondition;

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, ItemConverterType = typeof(ConfigRefConverter<QuestConfig>))]
        public List<QuestConfig> RequiredQuests;

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool AutoClaimAfterCompletion;

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool IsSingular;

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string SteamAchievementId;

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string SteamStatId;

        [JsonIgnore]
        public HashSet<QuestGroup> groups;

        [JsonIgnore]
        public bool Orderable;

        [JsonIgnore]
        public ShopEntryConfig ShopEntry;

        [JsonIgnore]
        public OnboardingScreenConfig LinkedOnboardingScreen;

        [JsonIgnore]
        public List<QuestConfig> RelativeQuests;

        [JsonIgnore]
        public List<OnboardingRewardConfig> RelativeOnboardingRewards;

        [JsonIgnore]
        public bool IsBatch => false;

        [JsonIgnore]
        public QuestTarget target => null;

        [JsonIgnore]
        public string visual => null;

        [JsonIgnore]
        public bool IsOnboardingReward => false;

        [JsonIgnore]
        public bool IsInMatch => false;

        [JsonIgnore]
        public bool IsPrologue => false;

        [JsonIgnore]
        public bool IsCommon => false;

        [JsonIgnore]
        public bool IsHard => false;

        [JsonIgnore]
        public bool IsInfinite => false;

        [JsonIgnore]
        public bool IsWinMatch => false;

        public class OnboardingRewardConfig : ConfigDictionary<OnboardingRewardConfig>
        {
            public int SelectedRewardIndex;

            public List<OnboardingRewardSlot> Slots;

            [JsonConverter(typeof(ConfigRefConverter<QuestConfig>))]
            public QuestConfig LinkedQuest;

            [JsonIgnore]
            public bool Starter => false;

            public static void Initialize()
            {
            }

            //public OnboardingRewardConfig()
            //{
            //    ((ConfigDictionary<>)(object)this)._002Ector();
            //}
            public class OnboardingRewardSlot
            {
                public Reward Reward;

                public Reward AlternateReward;
            }
        }

        public class OnboardingScreenConfig : ConfigDictionary<OnboardingScreenConfig>, IConfigDisablable
        {
            public bool isHidden;

            public string visual;

            public bool skipActivationDelay;

            public bool popupInMeta;

            public Reward reward;

            public HashSet<ShopEntryConfig> optionalRewards;

            public UnlockConditions conditions;

            [JsonProperty(ItemConverterType = typeof(ConfigRefConverter<QuestConfig>))]
            public List<QuestConfig> LinkedQuests;

            [JsonProperty(ItemConverterType = typeof(ConfigRefConverter<ComplexQuestConfig>))]
            public List<ComplexQuestConfig> LinkedComplexQuests;

            [JsonProperty("enabledInGame")]
            public bool EnabledInGame
            {
                [CompilerGenerated]
                get
                {
                    return false;
                }
                [CompilerGenerated]
                set
                {
                }
            }

            public static void Initialize()
            {
            }

            //public OnboardingScreenConfig()
            //{
            //    ((ConfigDictionary<>)(object)this)._002Ector();
            //}
        }
        public struct UnlockConditions
        {
            public int ActivationLevel;

            public int DeactivationLevel;

            public List<TriggerName> Triggers;
        }
        public class QuestTarget
        {
            public string visual;

            
            public QuestTrigger Trigger;

            public float Count;

            public float DoTimes;

            public QuestConditions Conditions;
        }
        public enum TriggerName
        {
            FirstLogin = 0,
            FinishPolygon = 1,
            LeavePolygon = 2,
            AnimReceived = 3,
            PremReceived = 4,
            UserbarReceived = 5,
            SkinReceived = 6,
            OperReceived = 7,
            CurrencyReceived = 8,
            ConsumableReceived = 9,
            EnterMatchmake = 10
        }
        [Flags]
        [GenerateJs]
        public enum QuestTrigger : long
        {
            None = 0L,
            BotExtermination = 1L,
            PlayerKO = 2L,
            ExecutePlayer = 4L,
            Kill = 8L,
            DoDamage = 0x10L,
            ApplyBuff = 0x20L,
            Reanimation = 0x40L,
            HealedAmount = 0x80L,
            EarnRibbon = 0x100L,
            FinishRound = 0x200L,
            UseEmotion = 0x400L,
            UseBonus = 0x800L,
            DestroyVehicle = 0x1000L,
            DestroyDropItem = 0x2000L,
            ExecuteAny = 0x4000L,
            MakeDamageOfAllTypes = 0x8000L,
            Plays = 0x10000L,
            GainXP = 0x20000L,
            WinMatch = 0x40000L,
            HasShopEntry = 0x80000L,
            UnlockUpgradeOfLevel = 0x100000L,
            AssignTechnologyOfTier = 0x200000L,
            TakeRankedSeasonRank = 0x400000L,
            InSession = 0x800000L,
            HasCardOfRole = 0x1000000L,
            HasCardWithPrestigeLevel = 0x2000000L,
            HasCardFromCollection = 0x4000000L,
            TakeAccountLevel = 0x8000000L,
            CompleteAllDailyQuests = 0x10000000L,
            CompleteWeeklyQuest = 0x20000000L,
            HasCardsFromNumberOfCollections = 0x40000000L,
            HasCardsOfEveryRole = -2147483648L,
            MetaQuests = -524288L
        }
        public enum RibbonType
        {
            None = 0,
            Assist = 1,
            FirstBlood = 2,
            BullsEye = 3,
            CloseCall = 4,
            LastBulletKill = 5,
            FromTheGrave = 6,
            JustScratch = 7,
            CleanKill = 8,
            SidearmKill = 9,
            ExplosiveKill = 10,
            BotKill = 11,
            BotDoubleKill = 12,
            BotTripleKill = 13,
            BotCaptainExtermination = 14,
            BotBossExtermination = 15,
            JuggernautKill = 16,
            PlayerIncapacitation = 17,
            PlayerDoubleIncapacitation = 18,
            PlayerTripleIncapacitation = 19,
            TeamElimination = 20,
            PlayerExecution = 21,
            Heal = 22,
            StaminaHeal = 23,
            Reanimation = 24,
            CombatReanimation = 25,
            FastReanimation = 26,
            KillTheExecutor = 27,
            KillTheShooter = 28,
            DenyExecutor = 29,
            Revenge = 30,
            Payback = 31,
            EnemySpotted = 32,
            EnemyDetected = 33,
            EnemySuppressed = 34,
            EnemyStunned = 35,
            EnemyInterrupted = 36,
            EnemyBleeding = 37,
            EnemyPoisoned = 38,
            EnemyBurning = 39,
            EnemySlowed = 40,
            ShieldAlly = 41,
            SpeedUpAlly = 42,
            ReinforceAlly = 43,
            CleanseAlly = 44,
            DamageBlocked = 45,
            BuffAssist = 46,
            DebuffAssist = 47,
            DemolitionLight = 48,
            DemolitionHeavy = 49,
            BlownAway = 50,
            SmokeDeployed = 51,
            BaseCapture = 52,
            BaseCaptureAssist = 53,
            SilentBaseCapture = 54,
            Defender = 55,
            CapturePointEndgame = 56,
            TopKill = 57,
            TopRevive = 58,
            TopHeal = 59,
            TopDamage = 60,
            TopAssist = 61,
            HacktoolPlanted = 62,
            HacktoolSuccess = 63,
            HacktoolDefused = 64,
            KillHacktoolDefuser = 65,
            KillHacktoolCarrier = 66,
            CollectIntelFront = 67,
            SideIntelFront = 68,
            MainIntelFront = 69,
            TeamIntelFront = 70,
            KillCarrierFront = 71,
            CapturePointFront = 72,
            CapturePointAssistFront = 73,
            WinPVE = 74,
            WinPVP = 75,
            WinHardPVE = 76,
            WinHacking = 77,
            WinPVPVE = 78,
            WinRankedPVP = 79,
            WinR1Onslaught = 80,
            WinR2Onslaught = 81,
            WinR3Onslaught = 82,
            WinIntercept = 83,
            WinPVPDestruction = 84,
            WaveCompleteR1Onslaught = 85,
            WaveCompleteR2Onslaught = 86,
            WaveCompleteR3Onslaught = 87,
            EvacuationR1Onslaught = 88,
            EvacuationR2Onslaught = 89,
            EvacuationR3Onslaught = 90,
            EvacuationReviveOnslaught = 91
        }
        public class QuestConditions
        {
            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
            public int IntValue;

            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
            public string StringValue;

            [JsonProperty(ItemConverterType = typeof(ConfigRefConverter<CollectionConfig>))]
            public HashSet<CollectionConfig> PlayerCollection;

            [JsonProperty(ItemConverterType = typeof(StringEnumConverter))]
            public HashSet<PlayerRole> PlayerRole;

            [JsonProperty(ItemConverterType = typeof(StringEnumConverter))]
            public HashSet<PlayerRole> TargetPlayerRole;

            [JsonProperty(ItemConverterType = typeof(StringEnumConverter))]
            public HashSet<PlayerRole> BotType;

            [JsonProperty(ItemConverterType = typeof(StringEnumConverter))]
            public HashSet<BotArchetype> BotArchetype;

            [JsonProperty(ItemConverterType = typeof(StringEnumConverter))]
            public HashSet<CondItemType> ItemType;

            [JsonProperty(ItemConverterType = typeof(StringEnumConverter))]
            public HashSet<DropItemType> DropItemType;

            [JsonProperty(ItemConverterType = typeof(StringEnumConverter))]
            public HashSet<HumanWeaponSlot> WeaponSlot;

            [JsonProperty(ItemConverterType = typeof(StringEnumConverter))]
            public HashSet<CondMatchType> MatchType;

            [JsonProperty(ItemConverterType = typeof(StringEnumConverter))]
            public HashSet<CondAdditional> Additional;

            [JsonProperty(ItemConverterType = typeof(StringEnumConverter))]
            public HashSet<BuffName> InflictorHasBuff;

            [JsonProperty(ItemConverterType = typeof(StringEnumConverter))]
            public HashSet<BuffName> ApplyBuffType;

            [JsonProperty(ItemConverterType = typeof(StringEnumConverter))]
            public HashSet<BuffName> TargetActiveBuffType;

            [JsonProperty(ItemConverterType = typeof(StringEnumConverter))]
            public HashSet<CondTargetTeam> TargetTeam;

            [JsonProperty(ItemConverterType = typeof(StringEnumConverter))]
            public HashSet<CondTargetDistance> TargetDistance;

            [JsonProperty(ItemConverterType = typeof(StringEnumConverter))]
            public HashSet<RibbonType> RibbonType;

            [JsonProperty(ItemConverterType = typeof(ConfigRefConverter<CustomAnimationConfig>))]
            public HashSet<CustomAnimationConfig> AnimationType;

            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
            public TimeSpan LastPlayerKillTime;
        }
        
        public enum BotArchetype
        {
            None = 0,
            Fighter = 1,
            Leader = 2,
            HeavyFighter = 3,
            Sniper = 4,
            Assault = 5,
            Commander = 6,
            AggressiveCommander = 7,
            Dummy = 8,
            Hostage = 9,
            AggressiveSniper = 10,
            AggressiveMedic = 11,
            AllyFighter = 12,
            Sergeant = 13,
            FighterWW2 = 14
        }
        [GenerateJs]
        public enum CondTargetDistance
        {
            CloserTenMeters = 0,
            MoreThirtyMeters = 1,
            MoreSixtyMeters = 2
        }
        [GenerateJs]
        public enum CondItemType
        {
            Common = 0,
            Pistol = 1,
            AssaultRifle = 2,
            SniperRifle = 3,
            Shotgun = 4,
            LMG = 5,
            SMG = 6,
            Explosive = 7,
            Total = 8
        }
        public enum DropItemType
        {
            None = 0,
            Distributing = 1,
            Drone = 2,
            Explosive = 3,
            Airstrike = 4,
            Smoke = 5,
            HumanLure = 6,
            Turret = 7,
            Aura = 8,
            FlyingDrone = 9,
            ScanDrone = 10,
            PickupAxe = 11,
            AssaultBot = 12,
            SupportBot = 13,
            ExplosiveDrone = 14,
            Total = 15
        }
        public enum HumanWeaponSlot
        {
            None = 0,
            Primary = 1,
            Secondary = 2,
            Heavy = 3,
            ConsumableOne = 4,
            ConsumableTwo = 5,
            Total = 6
        }
        [GenerateJs]
        public enum CondAdditional
        {
            Headshot = 0,
            Explosion = 1,
            FirstBlood = 2,
            HealthBelowTwenty = 3,
            NotKilled = 4,
            NearToTeammate = 5,
            TargetHasDebuff = 6,
            TargetIsFiring = 7,
            SteamSession = 8,
            LastBullet = 9,
            NonLethalHeavyWeapon = 10
        }
        [GenerateJs]
        public enum CondTargetTeam
        {
            Friend = 0,
            Enemy = 1,
            Me = 2
        }
        public enum BuffName
        {
            None = 0,
            NoSprint = 1,
            Concentration = 2,
            Mark = 3,
            Heal = 4,
            StaminaBlow = 5,
            Shield = 6,
            Silence = 7,
            Slow = 8,
            Dot = 9,
            Suppress = 10,
            SpeedUp = 11,
            StaminaHeal = 12,
            SelfHeal = 13,
            SelfSlow = 14,
            Stun = 15,
            Poison = 16,
            InSmoke = 17,
            SmokeScan = 18,
            BleedImmunity = 19,
            PoisonImmunity = 20,
            SlowImmunity = 21,
            SuppressImmunity = 22,
            StunImmunity = 23,
            Despell = 24,
            Bipod = 25,
            BuffBullet = 26,
            AmmoRefill = 27,
            DestructibleDamage = 28,
            Heat = 29,
            IncomingDamageMod = 30,
            Adrenalin = 31,
            SelfRevive = 32,
            PersonalMark = 33,
            AdditionalArmor = 34,
            FireDot = 35,
            BollyBulletShootTarget = 36,
            BollyBulletShootEmitter = 37,
            BollyBulletReflect = 38,
            Ward = 39,
            Invisible = 40,
            InWater = 41,
            Immortal = 42,
            Dbno = 43,
            Harbinger = 44,
            AxePickup = 45,
            PassiveSpeedUp = 46,
            PassiveBuffBullet = 47,
            PassiveIncomingDamageMod = 48,
            PassiveStaminaHeal = 49,
            Retaliation = 50,
            Prudence = 51,
            FireAmmo = 52,
            Biostim = 53,
            UssrTier1 = 54,
            UssrTier2 = 55,
            UssrTier3 = 56,
            TriggerFast = 57,
            TriggerFireResist = 58,
            TriggerBulletResist = 59,
            TriggerExplosiveResist = 60,
            TriggerImmortal = 61,
            TriggerGasDOT = 62,
            TriggerSlow = 63,
            TriggerNoSprint = 64,
            TriggerFire = 65,
            WeaponEnhancement = 66,
            Medkit = 67,
            MedkitRevive = 68,
            ShortCircuitMark = 69,
            ShortCircuitStun = 70,
            SurvivalKit = 71,
            DemoralizationDamage = 72,
            DemoralizationSpread = 73,
            SecondBreathHaste = 74,
            SecondBreathRegen = 75,
            SecondBreathShield = 76,
            BombardmentSlow = 77,
            BombardmentNoSprint = 78,
            HeavyPack = 79,
            AutoAim = 80,
            Revive = 81,
            ResistDamage = 82,
            InfinityAmmoAndRateOfFire = 83,
            RespawnTimeBoost = 84,
            Flyague = 85,
            BombPlantingEnhancement = 86,
            Freezing = 87,
            Freezing0 = 88,
            Freezing1 = 89,
            Freezing2 = 90,
            Freezing3 = 91,
            Freezing4 = 92,
            Total = 93
        }
    }
    //public QuestConfig()
    //{
    //    ((ConfigDictionary<>)(object)this)._002Ector();
    //}

}
