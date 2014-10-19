using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Jantu
{
    /// <summary>
    /// Manages all food kinds in the game.
    /// </summary>
    [Serializable()]
    class FoodKindManager : ISerializable
    {
        Dictionary<string, FoodKind> _kinds;

        /// <summary>
        /// Initializes a new instance of the <see cref="Jantu.FoodKindManager"/> class.
        /// </summary>
        public FoodKindManager()
        {
            _kinds = new Dictionary<string, FoodKind>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Jantu.FoodKindManager"/> class
        /// from serialized data.
        /// </summary>
        /// <param name='info'>
        /// Info.
        /// </param>
        /// <param name='ctx'>
        /// Context.
        /// </param>
        public FoodKindManager(SerializationInfo info, StreamingContext ctx)
        {
            List<FoodKind> kinds = (List<FoodKind>)info.GetValue(
                "FoodKindData", typeof(List<FoodKind>));
            _kinds = Enumerable.ToDictionary(kinds, k => k.Name);
        }

        /// <summary>
        /// Serializes the object.
        /// </summary>
        /// <param name='info'>
        /// Info.
        /// </param>
        /// <param name='ctx'>
        /// Context.
        /// </param>
        public void GetObjectData(SerializationInfo info, StreamingContext ctx)
        {
            info.AddValue("FoodKindData", Enumerable.ToList(_kinds.Values));
        }

        /// <summary>
        /// Add the specified food kind.
        /// </summary>
        /// <param name='kind'>
        /// Kind.
        /// </param>
        public void Add(FoodKind kind)
        {
            _kinds.Add(kind.Name, kind);
        }

        /// <summary>
        /// Gets a food kind by its name.
        /// </summary>
        /// <returns>
        /// Food kind with the specified name, if any. <c>null</c>
        /// if no such food kind exists.
        /// </returns>
        /// <param name='name'>
        /// Name of the food kind.
        /// </param>
        public FoodKind GetByName(string name)
        {
            return _kinds.ContainsKey(name) ? _kinds[name] : null;
        }
    }
}

