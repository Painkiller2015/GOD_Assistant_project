namespace GameData.Replay.Data.Replay.Entitys
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class JsonFilterAttribute : Attribute
    {
        public readonly JsonFilterFlags Area;

        public JsonFilterAttribute(JsonFilterFlags area)
        {
        }
    }
    [Flags]
    public enum JsonFilterFlags
    {
        Meta = 2,
        Arena = 4,
        Client = 8,
        All = 0xE
    }
}
