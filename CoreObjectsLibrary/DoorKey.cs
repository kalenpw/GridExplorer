// Kalen Williams
// CS 1182
// 7 April 2016
// Deliverable 5

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseObjects;

namespace CoreObjectsLibrary {
    [Serializable]
    public class DoorKey : Item {
        //Fields
        protected string _KeyCode;

        /// <summary>
        /// Constructor for door key
        /// </summary>
        /// <param name="newDoorKeyName">Key's name</param>
        /// <param name="newAffectValue">Key's affect value</param>
        /// <param name="newDoorKeyCode">Key's code</param>
        //Constructors
        public DoorKey(string newDoorKeyName, int newAffectValue, string newDoorKeyCode) : base(newDoorKeyName, newAffectValue) {
            _KeyCode = newDoorKeyCode;
        }

        /// <summary>
        /// Returns key code
        /// </summary>
        //Properties
        public string KeyCode {
            get {
                return _KeyCode;
            }
        }
    }
}
