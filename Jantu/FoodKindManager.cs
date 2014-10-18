using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Jantu
{
    [Serializable()]
    class FoodKindManager : ISerializable
    {
        public FoodKindManager()
        {
            _kinds = new Dictionary<string, FoodKind>();
        }

        public FoodKindManager(SerializationInfo info, StreamingContext ctx)
        {
            List<FoodKind> kinds = (List<FoodKind>)info.GetValue(
                "FoodKindData", typeof(List<FoodKind>));
            _kinds = Enumerable.ToDictionary(kinds, k => k.Name);
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctx)
        {
            info.AddValue("FoodKindData", Enumerable.ToList(_kinds.Values));
        }

        public void Add(FoodKind kind)
        {
            _kinds.Add(kind.Name, kind);
        }

        public FoodKind GetByName(string name)
        {
            return _kinds.ContainsKey(name) ? _kinds[name] : null;
        }

        Dictionary<string, FoodKind> _kinds;
    }
}

