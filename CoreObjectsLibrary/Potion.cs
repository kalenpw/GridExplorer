// CS/INFO 1182
// Jon Holmes
// Description - A potion is something that can heal a hero
using System;

namespace BaseObjects {
    [Serializable]
    public class Potion : Item, IRepeatable<Potion> {
        private Colors _Color;
        #region "Constructors"
        /// <summary>
        /// Overloaded constructor
        /// </summary>
        /// <param name="newName">Potion's Name</param>
        /// <param name="value">Value or Potency of the Potion</param>
        /// <param name="clr">Color of the Potion</param>
        public Potion(String newName, int value, Colors clr)
            : base(newName, value) {
            _Color = clr;
        }
        #endregion
        /// <summary>
        /// Get and Set the Potion's Color
        /// </summary>
        public Colors Color {
            get {
                return _Color;
            }

            set {
                _Color = value;
            }
        }
        /// <summary>
        /// Create a deep copy of this potion.
        /// </summary>
        /// <returns></returns>
        public Potion CreateCopy() {
            return new Potion(this._Name, this._AffectValue, this._Color);
        }
    }

    public enum Colors {
        Green,
        Blue,
        Red,
        Purple
    }
}
