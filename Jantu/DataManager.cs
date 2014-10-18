using System;
using System.Runtime.Serialization;

namespace Jantu
{
    [Serializable()]
    class DataManager : ISerializable
    {
        public FoodKindManager FoodKinds { get { return _foodKinds; } }
        public SpeciesManager Species { get { return _species; } }

        public DataManager()
        {
            _foodKinds = new FoodKindManager();
            _species = new SpeciesManager();
        }

        public DataManager(SerializationInfo info, StreamingContext ctx)
        {
            _foodKinds = (FoodKindManager)info.GetValue("FoodKinds", typeof(FoodKindManager));
            _species = (SpeciesManager)info.GetValue("Species", typeof(SpeciesManager));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctx)
        {
            info.AddValue("FoodKinds", FoodKinds);
            info.AddValue("Species", Species);
        }

        FoodKindManager _foodKinds;
        SpeciesManager _species;
    }
}

