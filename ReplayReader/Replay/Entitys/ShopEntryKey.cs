using ReplayReader.Replay.Data.Replay.Configs;
using System.Runtime.CompilerServices;

namespace ReplayReader.Replay.Data.Replay.Entitys
{
    public readonly struct ShopEntryKey : IEquatable<ShopEntryKey>
    {
        public ShopItemType ItemType
        {
            [CompilerGenerated]
            get
            {
                return default;
            }
        }

        public CardConfig LinkedCardId
        {
            [CompilerGenerated]
            get
            {
                return null;
            }
        }

        public string ItemId
        {
            [CompilerGenerated]
            get
            {
                return null;
            }
        }

        public ShopEntryKey(ShopItemType itemType, string itemId, CardConfig linkedCardId)
        {
        }

        public bool Equals(ShopEntryKey other)
        {
            return false;
        }

        public override bool Equals(object obj)
        {
            return false;
        }

        public override int GetHashCode()
        {
            return 0;
        }
    }
}
