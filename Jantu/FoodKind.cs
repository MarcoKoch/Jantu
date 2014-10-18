using System;
using System.Runtime.Serialization;

namespace Jantu
{
    [Serializable()]
    class FoodKind : ISerializable
    {
        public string Name;
        public char Symbol;

        public FoodKind(string name, char symbol)
        {
            Name = name;
            Symbol = symbol;
        }

        public FoodKind(SerializationInfo info, StreamingContext ctx)
        {
            Name = (string)info.GetValue("Name", typeof(string));
            Symbol = info.GetChar("Symbol");
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctx)
        {
            info.AddValue("Name", Name);
            info.AddValue("Symbol", Symbol);
        }
    }
}
