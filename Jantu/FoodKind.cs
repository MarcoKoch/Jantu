using System;
using System.Runtime.Serialization;

namespace Jantu
{
    /// <summary>
    /// Describes a kind of animal food.
    /// </summary>
    /// <remarks>
    /// This is an abstract description only. The actual representation of a
    /// food object is represented by <see cref="Jantu.FoodEntity"/>.
    /// </remarks>
    [Serializable()]
    class FoodKind : ISerializable
    {
        string  _name;
        char    _symbol;

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get { return _name; }}

        /// <summary>
        /// Gets or sets the symbol.
        /// </summary>
        /// <value>
        /// The symbol.
        /// </value>
        public char Symbol
        {
            get { return _symbol; }
            set { _symbol = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Jantu.FoodKind"/> class.
        /// </summary>
        /// <param name='name'>
        /// Name.
        /// </param>
        /// <param name='symbol'>
        /// Symbol.
        /// </param>
        public FoodKind(string name, char symbol)
        {
            _name = name;
            _symbol = symbol;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Jantu.FoodKind"/> class
        /// from serialized data.
        /// </summary>
        /// <param name='info'>
        /// Info.
        /// </param>
        /// <param name='ctx'>
        /// Context.
        /// </param>
        public FoodKind(SerializationInfo info, StreamingContext ctx)
        {
            _name = (string)info.GetValue("Name", typeof(string));
            _symbol = info.GetChar("Symbol");
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
            info.AddValue("Name", Name);
            info.AddValue("Symbol", Symbol);
        }
    }
}
