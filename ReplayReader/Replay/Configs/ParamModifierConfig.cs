using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplayReader.Replay.Data.Replay.Configs
{
    public class ParamModifierConfig
    {
        public readonly Dictionary<string, float> additive;

        public readonly Dictionary<string, float> multiply;

        public readonly Dictionary<string, JToken> curves;

        public readonly Dictionary<string, float> reference;

        public readonly Dictionary<string, float> ui;

        public void ApplyModifiers(ParamModifierConfig other, bool considerSealed = false)
        {
        }

        public JToken GetCurveToken(string key)
        {
            return null;
        }

        public float GetValue(string key, float defaultAdd = 0f)
        {
            return 0f;
        }

        public float GetUIValue(string key)
        {
            return 0f;
        }

        public bool GetBool(string key, bool defaultValue = false)
        {
            return false;
        }

        public bool IsHasMultiply(string key)
        {
            return false;
        }

        public ParamModifierConfig GetParamsFiltered(string filter = "")
        {
            return null;
        }

        public Dictionary<string, ParamModifierConfig> GetParamsFilteredInBuckets(string filter = "")
        {
            return null;
        }

        private static bool TryAddOfFindBucket(Dictionary<string, ParamModifierConfig> buckets, string key, string filterString, out string bucketKey, out string modifierKey)
        {
            bucketKey = null;
            modifierKey = null;
            return false;
        }

        public List<string> UIModifiersKeys(bool includeMinMax = false)
        {
            return null;
        }

        public void AddAdditiveModifier(string modName, float modVal)
        {
        }

        public void AddMultModifier(string modName, float modVal)
        {
        }

        public void AddAdditiveModifiers(Dictionary<string, float> mods)
        {
        }

        public void AddMultModifiers(Dictionary<string, float> mods)
        {
        }

        public void AddUiModifiers(Dictionary<string, float> mods)
        {
        }

        private static void AddModifier(Dictionary<string, float> mods, string modName, float modVal, bool considerSealed = false)
        {
        }

        private static void AddModifiers(Dictionary<string, float> modsTo, Dictionary<string, float> modsFrom, bool considerSealed = false)
        {
        }

        private static void AddModifierCurves(Dictionary<string, JToken> curvesTo, Dictionary<string, JToken> curvesFrom)
        {
        }

        private static void AddModifierCurve(Dictionary<string, JToken> curves, string modName, JToken curveToken)
        {
        }


    }
}
