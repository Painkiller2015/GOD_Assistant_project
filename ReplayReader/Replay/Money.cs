
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplayReader.Replay
{
    public class Money
    {
        [JsonConverter(typeof(ConfigDictionaryConverter<CurrencyConfig, int>))]
        public Dictionary<CurrencyConfig, int> values;

        public static Money Zero => null;

        [JsonIgnore]
        public int Soft;

        [JsonIgnore]
        public int Hard;

        [JsonIgnore]
        public int FreeXp;

        [JsonIgnore]
        public int RefundToken;

        [JsonIgnore]
        public int CardLevelSwitchToken;

        [JsonIgnore]
        public bool HasPrice => false;

        [JsonIgnore]
        public bool HasValues => false;

        public Money()
        {
        }

        public Money(IReadOnlyDictionary<CurrencyConfig, int> currencies)
        {
        }

        public Money(CurrencyConfig currency, int value)
        {
        }

        public Money(Money other)
        {
        }

        public Money(int sc, int hc, int tokens = 0, int tickets = 0, int freeXp = 0)
        {
        }

        public bool HasCurrencyValue(CurrencyConfig currency)
        {
            return false;
        }

        public int GetCurrencyValue(CurrencyConfig type)
        {
            return 0;
        }

        public void SetCurrencyValue(CurrencyConfig type, int value)
        {
        }

        public bool IsEnoughCurrency(CurrencyConfig currency, Money cost)
        {
            return false;
        }

        public bool IsEnoughCurrency(CurrencyConfig currency, int amount)
        {
            return false;
        }

        public bool IsEnoughMoney(Money target)
        {
            return false;
        }

        public bool SpendMoney(Money price)
        {
            return false;
        }

        public bool SpendCurrency(CurrencyConfig currency, int amount)
        {
            return false;
        }

        public bool SpendCurrency(CurrencyConfig currency, Money price)
        {
            return false;
        }

        public bool AddCurrency(CurrencyConfig currency, int amount)
        {
            return false;
        }

        public bool RemoveCurrency(CurrencyConfig currency, int amount)
        {
            return false;
        }

        public void AddMoney(Money funds)
        {
        }

        public void RemoveMoney(Money funds)
        {
        }

        public void Multiply(int multiplier)
        {
        }

        public void Division(int divider)
        {
        }

        public bool MultiplyCurrency(CurrencyConfig currency, int multiplier)
        {
            return false;
        }

        public bool DivisionCurrency(CurrencyConfig currency, int divider)
        {
            return false;
        }

        public override string ToString()
        {
            return null;
        }

        public bool Equals(Money moneyObj)
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

        public static Money operator *(Money money, int multiplier)
        {
            return null;
        }

        public static Money operator /(Money money, int divider)
        {
            return null;
        }

        public static Money operator +(Money money, Money add)
        {
            return null;
        }

        public static Money operator -(Money money, Money remove)
        {
            return null;
        }
    }
}
