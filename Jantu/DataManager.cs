using System;
using System.Runtime.Serialization;

namespace Jantu
{
    /// <summary>
    /// Manages all data resources in the game.
    /// </summary>
    [Serializable()]
    class DataManager : ISerializable
    {
        FoodKindManager _foodKinds;
        SpeciesManager _species;

        /// <summary>
        /// Gets the food kinds.
        /// </summary>
        /// <value>
        /// The food kinds.
        /// </value>
        public FoodKindManager FoodKinds
        {
            get { return _foodKinds; }
        }

        /// <summary>
        /// Gets the species.
        /// </summary>
        /// <value>
        /// The species.
        /// </value>
        public SpeciesManager Species
        {
            get { return _species; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Jantu.DataManager"/> class.
        /// </summary>
        public DataManager()
        {
            _foodKinds = new FoodKindManager();
            _species = new SpeciesManager();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Jantu.DataManager"/> class
        /// from serialized data.
        /// </summary>
        /// <param name='info'>
        /// Info.
        /// </param>
        /// <param name='ctx'>
        /// Context.
        /// </param>
        public DataManager(SerializationInfo info, StreamingContext ctx)
        {
            _foodKinds = (FoodKindManager)info.GetValue("FoodKinds", typeof(FoodKindManager));
            _species = (SpeciesManager)info.GetValue("Species", typeof(SpeciesManager));
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
            info.AddValue("FoodKinds", FoodKinds);
            info.AddValue("Species", Species);
        }
    }
}

