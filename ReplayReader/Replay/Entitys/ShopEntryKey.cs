﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ReplayReader.Replay.Configs;

namespace ReplayReader.Replay.Entitys
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