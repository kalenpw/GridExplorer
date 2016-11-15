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
    public class Door : Item {
        //Fields
        protected string _DoorCode = "";

        /// <summary>
        /// Constructor for Door
        /// </summary>
        /// <param name="newDoorName">Door name</param>
        /// <param name="newAffectValue">Door affect value</param>
        /// <param name="newDoorCode">Door code</param>
        //Constructors
        public Door(string newDoorName, int newAffectValue, string newDoorCode) : base(newDoorName, newAffectValue) {
            _DoorCode = newDoorCode;
        }

        /// <summary>
        /// Get and set door's code
        /// </summary>
        //Properties
        public string DoorCode {
            get {
                return _DoorCode;
            }
            set {
                _DoorCode = value;
            }
        }

        //Methods
        /// <summary>
        /// Checks if a door and a doorkey have the same code
        /// </summary>
        /// <param name="doorKeyToCheck"></param>
        /// <returns></returns>
        public bool CodesMatch(DoorKey doorKeyToCheck) {

            if(doorKeyToCheck.KeyCode == _DoorCode) {
                return true;
            }
            else {
                return false;
            }
        }



    }
}
