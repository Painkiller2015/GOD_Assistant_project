using System.Text.Json.Serialization;

namespace RR
{
    public class Replay
    {
        public Log Log { get; set; }
        [JsonPropertyName("Users")]
        public UserMatchAward[] UsersResults { get; set; }
        public bool GameModesBanEnabled { get; set; }
        public bool PlayerReportsEnabled { get; set; }
    }

    public class Log
    {
        public Data Data { get; set; }
        public int WinnerTeamId { get; set; }
        public int MaxRoundsWon { get; set; }
        public int LowerScoreToWin { get; set; }
        public int UpperScoreToWin { get; set; }
        public float MatchTimeSeconds { get; set; }
        public float MissionStartTime { get; set; }
        public string MissionFinishReason { get; set; }
        public UserMatchResult[] Users { get; set; }
        public Round[] Rounds { get; set; }
        public object Checkpoints { get; set; }
        public Hackingmodeentry[] HackingModeEntries { get; set; }
        public object PvPvEModeEntries { get; set; }
        public object PvPModeEntries { get; set; }
        public object InterceptModeEntries { get; set; }
        public object PlayerReports { get; set; }
        public object Surrenders { get; set; }
        public object OnslaughtRounds { get; set; }
        public object TeamScore { get; set; }
        public object FrontierPVOButtonStates { get; set; }
    }

    public class Data
    {
        [JsonPropertyName("0")]
        public string MathId { get; set; }
        [JsonPropertyName("1")]
        public string Map { get; set; }
        [JsonPropertyName("2")]
        public string Mission { get; set; }
        public object[] _3 { get; set; }
        [JsonPropertyName("4")]
        public string GameMode { get; set; }
        public object _5 { get; set; }
        [JsonPropertyName("6")]
        public string ServerRegion { get; set; }
        [JsonPropertyName("7")]
        public Player[] Players { get; set; }
        public object _8 { get; set; }
        public int _9 { get; set; } //mb id роли
        public int _10 { get; set; }
        [JsonPropertyName("11")]
        public string ServerIP { get; set; }
        public bool _12 { get; set; }
        public object[] _13 { get; set; }
        public object[] _14 { get; set; }
    }

    public class Player
    {
        [JsonPropertyName("0")]
        public int MainAccountId { get; set; }
        [JsonPropertyName("1")]
        public int CurrentAccountId { get; set; }
        [JsonPropertyName("2")]
        public string NickName { get; set; }
        [JsonPropertyName("3")]
        public int AccountLevel { get; set; }
        public int _4 { get; set; }
        public string _5 { get; set; }
        public bool _6 { get; set; }
        public string _7 { get; set; }
        [JsonPropertyName("8")]
        public PlayerMatchCard Operator { get; set; }
        public int[] _9 { get; set; }
        public int _10 { get; set; }
        [JsonPropertyName("11")]
        public SelfMissions[] Achivments { get; set; }
        public int _12 { get; set; }
        public int _13 { get; set; }
        [JsonPropertyName("16")]
        public RankedInfo Ranked { get; set; }
        [JsonPropertyName("17")]
        public string SelectedBattlepass { get; set; }
        public long _18 { get; set; }
        public int _19 { get; set; }
        [JsonPropertyName("20")]
        public AllPerks Perks { get; set; }
        public int _21 { get; set; }
        [JsonPropertyName("22")]
        public Missions ActiveMissions { get; set; }
        public bool _23 { get; set; }
    }

    public class PlayerMatchCard
    {
        [JsonPropertyName("0")]
        public int CardNo { get; set; }
        [JsonPropertyName("1")]
        public string OperatorName { get; set; }
        public bool _2 { get; set; }
        public bool _3 { get; set; }
        [JsonPropertyName("4")]
        public int Experience { get; set; }
        public int _5 { get; set; }
        public long _6 { get; set; }
        public long _7 { get; set; }
        public object[] _8 { get; set; }
        [JsonPropertyName("9")]
        public string[] Skins { get; set; }
        public object[] _10 { get; set; }
        [JsonPropertyName("11")]
        public string[] Emotions { get; set; }
        public object[] _12 { get; set; }
        [JsonPropertyName("13")]
        public string Fatality { get; set; }
        [JsonPropertyName("14")]
        public string[] Сonsumables { get; set; }
        [JsonPropertyName("15")]
        public string[] SelectedPerks { get; set; }
        public object _16 { get; set; }
        [JsonPropertyName("17")]
        public int OperatorPrestige { get; set; }
        [JsonPropertyName("18")]
        public int OperatorLevel { get; set; }
        [JsonPropertyName("19")]
        public int OpenPerksSlots { get; set; }
        public int _20 { get; set; }
    }

    public class RankedInfo
    {
        [JsonPropertyName("0")]
        public string SeasonName { get; set; }
        [JsonPropertyName("1")]
        public int CurrentPoints { get; set; }
        [JsonPropertyName("2")]
        public int PrevPoints { get; set; }
        [JsonPropertyName("3")]
        public int BattleCount { get; set; }
        [JsonPropertyName("4")]
        public int BattleWin { get; set; }
        [JsonPropertyName("5")]
        public DateTime LastUpdate { get; set; }
        public int[] _6 { get; set; }
        public bool IsInRanked { get; set; }
        public bool IsCalibrating { get; set; }
    }

    public class AllPerks
    {
        public int booster_pouch { get; set; }
        public int field_medicine { get; set; }
        public int advanced_training { get; set; }
        public int heavyweight_marathon { get; set; }
        public int battle_hardening { get; set; }
        public int strong_nerves { get; set; }
        public int hemoglobin_serum { get; set; }
        public int second_wind { get; set; }
        public int consumables_pouch { get; set; }
        public int fireres_materials { get; set; }
        public int subdermal_meldonium { get; set; }
        public int shrapnel_layer { get; set; }
        public int subdermal_morphine { get; set; }
        public int regenerative_materials { get; set; }
        public int adaptive_armor { get; set; }
        public int tight_fit { get; set; }
        public int forend_processing { get; set; }
        public int barrel_cutting { get; set; }
        public int quick_release_magazines { get; set; }
        public int direct_acting_shutter { get; set; }
        public int super_sensitive_trigger { get; set; }
        public int armor_piercing_rounds { get; set; }
        public int spare_syringe { get; set; }
        public int improved_formula { get; set; }
        public int cold_math { get; set; }
        public int altitude_training { get; set; }
        public int stealth_warrior { get; set; }
        public int ambush { get; set; }
        public int will_to_live { get; set; }
        public int blood_rage { get; set; }
        public int head_hunter { get; set; }
        public int prudence { get; set; }
        public int self_healing { get; set; }
        public int retaliation { get; set; }
        public int head_protection { get; set; }
        public int heavy_barrel { get; set; }
        public int robotic_calibrations { get; set; }
        public int lightweight_armor { get; set; }
        public int merciless { get; set; }
        public int counter_attack { get; set; }
        public int lightweight_equipment { get; set; }
        public int cold_blood { get; set; }
        public int well_rested { get; set; }
        public int fast_revive { get; set; }
        public int tungsten_coating { get; set; }
        public int stim_medpacks { get; set; }
        public int die_hard { get; set; }
        public int combined_armor { get; set; }
        public int expansive_bullets { get; set; }
        public int adrenaline_rush { get; set; }
        public int thermal_imager { get; set; }
        public int dead_silence { get; set; }
        public int heavy_ammunition { get; set; }
        public int sixth_sense { get; set; }
        public int healing_factor { get; set; }
        public int own_priorities { get; set; }
        public int lone_wolf { get; set; }
        public int flatness { get; set; }
        public int take_aim { get; set; }
        public int stay_frosty { get; set; }
        public int strong_stim { get; set; }
        public int fresh_forces { get; set; }
        public int enhanced_armor { get; set; }
        public int team_medpacks { get; set; }
        public int shoulder_to_shoulder { get; set; }
        public int priority_target { get; set; }
        public int in_the_crosshairs { get; set; }
        public int inner_strength { get; set; }
    }

    public class Missions
    {
        public int Weekly { get; set; }
        public int Hard { get; set; }
        public int Daily { get; set; }
        public int Orderable { get; set; }
    }

    public class SelfMissions
    {
        [JsonPropertyName("0")]
        public string Id { get; set; }
        [JsonPropertyName("1")]
        public string Name { get; set; }
        [JsonPropertyName("2")]
        public float[] CurrentValue { get; set; }
        public int _3 { get; set; }
        public int _4 { get; set; }
        public bool _5 { get; set; } //mb premium
    }
    public class UserMatchResult
    {
        public Ribbons Ribbons { get; set; }
        public Questcounters QuestCounters { get; set; }
        public Foulplay FoulPlay { get; set; }
        public Earnedcurrencies EarnedCurrencies { get; set; }
        public object Triggers { get; set; }
        public object Segments { get; set; }
        public int PlayerKills { get; set; }
        public int BotKills { get; set; }
        public Specificplayerkills SpecificPlayerKills { get; set; }
        public int FriendKills { get; set; }
        public int Assists { get; set; }
        public int Executions { get; set; }
        public int Revives { get; set; }
        public int Deaths { get; set; }
        public float DamageDealt { get; set; }
        public float DamageReceived { get; set; }
        public float FriendlyDamageDealt { get; set; }
        public bool DamageByEffects { get; set; }
        public int[] DamageBySlots { get; set; }
        public Damagedby DamagedBy { get; set; }
        public float HealProvided { get; set; }
        public float LeaveTime { get; set; }
        public bool LoadedInMatch { get; set; }
        public bool ConnectedOnMatchFinish { get; set; }
        public bool FirstWhoLeave { get; set; }
        public string KickReason { get; set; }
        public Consumablesusagecount ConsumablesUsageCount { get; set; }
        public int AbilityUsageCount { get; set; }
        public int AmmoBoxUsageCount { get; set; }
        public int CheckPointCount { get; set; }
        public int WinRoundCount { get; set; }
    }

    public class Ribbons
    {
        public Dictionary<int, string> RibbonsDictionary { get; set; }
    }

    public class Questcounters
    {
        public Dictionary<string, float[]> SelfMissionsDict { get; set; }
    }

    public class Foulplay
    {
        public int AllyLightDamaged { get; set; }
        public int AllyHeavyDamaged { get; set; }
        public int AllyKilled { get; set; }
    }

    public class Earnedcurrencies
    {
    }

    public class Specificplayerkills
    {
        public int _7 { get; set; }
        public int _4 { get; set; }
        public int _6 { get; set; }
        public int _5 { get; set; }
        public int _2 { get; set; }
        public int _3 { get; set; }
        public int _0 { get; set; }
        public int _1 { get; set; }
    }

    public class Damagedby
    {
        public Dictionary<string, string> DamagedByDict { get; set; }
    }

    public class Consumablesusagecount
    {
        public int ArmorPack { get; set; }
        public int StaminaRegenBooster { get; set; }
        public int HealthPack { get; set; }
    }

    public class Round
    {
        public int winner_team { get; set; }
        public int winner_base { get; set; }
        public int reason { get; set; }
        public int number { get; set; }
        public string entity_id { get; set; }
        public float time { get; set; }
    }

    public class Hackingmodeentry
    {
        public int ActionType { get; set; }
        public int UserId { get; set; }
        public int TeamId { get; set; }
        public string CapturePointId { get; set; }
        public int Round { get; set; }
        public string entity_id { get; set; }
        public float time { get; set; }
    }

    public class UserMatchAward
    {
        public int ScorePointCount { get; set; }
        public Battlerewards BattleRewards { get; set; }
        public Battlepassresult BattlepassResult { get; set; }
        public Currenciestaken CurrenciesTaken { get; set; }
        public Penalties Penalties { get; set; }
        public int CardXp { get; set; }
        public int FreeXp { get; set; }
        public object BoostersReleased { get; set; }
        public object Marathon { get; set; }
        public int MarathonTokensForTicketBonus { get; set; }
        public int MarathonTicketsTaken { get; set; }
        public int MarathonTicketsGiven { get; set; }
        public int MarathonTokensGiven { get; set; }
        public int MarathonPointsGiven { get; set; }
        public int MarathonBattlesWon { get; set; }
        public RankedInfo RankedSeason { get; set; }
        public int LevelBefore { get; set; }
        public int CardXpBefore { get; set; }
        public int PrestigeXpBefore { get; set; }
        public int NextLevelProgressBefore { get; set; }
        public object CommonCause { get; set; }
    }

    public class Battlerewards
    {
        public int ExperiencePenalty { get; set; }
        public Rewards Rewards { get; set; }
        public Medals Medals { get; set; }
        public Ribbons1 Ribbons { get; set; }
        public int FarmerBonusLevel { get; set; }
    }

    public class Rewards
    {
        public Ribbon Ribbon { get; set; }
        public Medal Medal { get; set; }
        public Matchreward MatchReward { get; set; }
        public Premium Premium { get; set; }
        public Premiumteammate PremiumTeammate { get; set; }
        public Premiumfullteam PremiumFullTeam { get; set; }
        public Farmcardbonus FarmCardBonus { get; set; }
    }

    public class Ribbon
    {
        public Shopentries shopEntries { get; set; }
        public int xp { get; set; }
        public object visual { get; set; }
    }

    public class Shopentries
    {
    }

    public class Medal
    {
        public Shopentries1 shopEntries { get; set; }
        public int xp { get; set; }
        public object visual { get; set; }
    }

    public class Shopentries1
    {
    }

    public class Matchreward
    {
        public Shopentries2 shopEntries { get; set; }
        public int xp { get; set; }
        public object visual { get; set; }
    }

    public class Shopentries2
    {
        public int shop_currency_soft { get; set; }
    }

    public class Premium
    {
        public Shopentries3 shopEntries { get; set; }
        public int xp { get; set; }
        public object visual { get; set; }
    }

    public class Shopentries3
    {
        public int shop_currency_soft { get; set; }
    }

    public class Premiumteammate
    {
        public Shopentries4 shopEntries { get; set; }
        public int xp { get; set; }
        public object visual { get; set; }
    }

    public class Shopentries4
    {
        public int shop_currency_soft { get; set; }
    }

    public class Premiumfullteam
    {
        public Shopentries5 shopEntries { get; set; }
        public int xp { get; set; }
        public object visual { get; set; }
    }

    public class Shopentries5
    {
        public int shop_currency_soft { get; set; }
    }

    public class Farmcardbonus
    {
        public Shopentries6 shopEntries { get; set; }
        public int xp { get; set; }
        public object visual { get; set; }
    }

    public class Shopentries6
    {
        public int shop_currency_soft { get; set; }
    }

    public class Medals
    {
        public int Assist { get; set; }
        public int CloseCall { get; set; }
        public int Payback { get; set; }
        public int SmokeDeployed { get; set; }
        public int Revenge { get; set; }
        public int Heal { get; set; }
        public int Reanimation { get; set; }
        public int PlayerIncapacitation { get; set; }
        public int EnemyDetected { get; set; }
        public int StaminaHeal { get; set; }
        public int DebuffAssist { get; set; }
        public int TopAssist { get; set; }
        public int LastBulletKill { get; set; }
        public int WinRankedPVP { get; set; }
    }

    public class Ribbons1
    {
        public int EnemySlowed { get; set; }
        public int Assist { get; set; }
        public int DebuffAssist { get; set; }
        public int EnemyPoisoned { get; set; }
        public int Revenge { get; set; }
        public int PlayerIncapacitation { get; set; }
        public int KillTheShooter { get; set; }
        public int DamageBlocked { get; set; }
        public int CloseCall { get; set; }
        public int Payback { get; set; }
        public int KillHacktoolCarrier { get; set; }
        public int CleanKill { get; set; }
        public int DemolitionLight { get; set; }
        public int SmokeDeployed { get; set; }
        public int FirstBlood { get; set; }
        public int StaminaHeal { get; set; }
        public int PlayerExecution { get; set; }
        public int SidearmKill { get; set; }
        public int BullsEye { get; set; }
        public int Heal { get; set; }
        public int LastBulletKill { get; set; }
        public int Reanimation { get; set; }
        public int SpeedUpAlly { get; set; }
        public int HacktoolPlanted { get; set; }
        public int BuffAssist { get; set; }
        public int HacktoolSuccess { get; set; }
        public int TopHeal { get; set; }
        public int EnemySuppressed { get; set; }
        public int EnemyDetected { get; set; }
        public int PlayerDoubleIncapacitation { get; set; }
        public int WinRankedPVP { get; set; }
        public int FastReanimation { get; set; }
        public int TopDamage { get; set; }
        public int TopAssist { get; set; }
        public int TopRevive { get; set; }
        public int TopKill { get; set; }
    }

    public class Battlepassresult
    {
        public int BaseExperience { get; set; }
        public int PremiumExperience { get; set; }
        public int ExperienceBefore { get; set; }
        public bool HasBattlePass { get; set; }
    }

    public class Currenciestaken
    {
        public Values values { get; set; }
    }

    public class Values
    {
    }

    public class Penalties
    {
        public int AllyLightDamaged { get; set; }
        public int AllyHeavyDamaged { get; set; }
        public int AllyKilled { get; set; }
    }


}


