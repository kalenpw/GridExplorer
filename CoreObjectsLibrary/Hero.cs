/*
CS/INFO 1182 
Jon Holmes modified for deliverable 6 by Kalen Williams
2/1/2016
Description - Items in the game that can heal or damage actors.
*/

using BaseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreObjectsLibrary;

namespace BaseObjects {
    [Serializable]
    public class Hero : Actor {

        //Fields
        protected bool _IsRunningAway;
        protected DoorKey _HasDoorKey;
        protected Weapon _Weapon;
        /// <summary>
        /// Overloaded Constructor for a hero
        /// </summary>
        /// <param name="newName">Hero's Name</param>
        /// <param name="newTitle">Hero's Title</param>
        /// <param name="atkSpeed">Hero's AttackSpeed</param>
        /// <param name="hitPoints">Hero's Starting HP</param>
        /// <param name="startingPositionX">Hero's Starting X Position</param>
        /// <param name="startingPositionY">Hero's Starting Y Position</param>
        public Hero(String newName, String newTitle, double atkSpeed, int hitPoints, int startingPositionX, int startingPositionY)
            : base(newName, newTitle, atkSpeed, hitPoints, startingPositionX, startingPositionY) {
            Weapon = null;
        }

        /// <summary>
        /// Get Hero's attack speed
        /// </summary>
        public override double AttackSpeed {
            get {
                if (HasWeapon) {
                    return base.AttackSpeed + Weapon.SpeedModifier;
                }
                else {
                    return base.AttackSpeed;
                }
            }
        }
        /// <summary>
        /// Get and set the Hero's weapon
        /// </summary>
        public Weapon Weapon {
            get {
                return _Weapon;
            }

            set {
                _Weapon = value;
            }
        }

        /// <summary>
        /// Get and set the hero's doorkey
        /// </summary>
        public DoorKey DoorKey {
            get {
                return _HasDoorKey;
            }
        }

        /// <summary>
        /// Check status of hero running away
        /// </summary>
        public bool RunningAway {
            get {
                return _IsRunningAway;
            }
            set {
                _IsRunningAway = value;
            }
        }

        /// <summary>
        /// Check to see if the hero has a weapon equipped.
        /// </summary>
        public bool HasWeapon {
            get {
                return _Weapon != null;
            }
        }

        /// <summary>
        /// Move the hero.
        /// </summary>
        /// <param name="dirToMove">Direction the hero will move.</param>
        public override void Move(Actor.Direction dirToMove) {
            base.Move(dirToMove);
        }

        /// <summary>
        /// Get and set hero attack value
        /// </summary>
        /// <returns></returns>
        public int AttackValue() {
            if (_Weapon != null) {
                return _Weapon.AffectValue;
            }
            else {
                return 1;
            }
        }

        /// <summary>
        /// Applies item to hero
        /// </summary>
        /// <param name="newItemApplied"></param>
        /// <returns>The new weapon or item applied</returns>
        //Citation: https://msdn.microsoft.com/en-us/library/scekt9xw.aspx
        //Citation: https://msdn.microsoft.com/en-us/library/ms173105.aspx
        public Item ApplyItem(Item newItemApplied) {


            if (newItemApplied is Potion) {
                _CurrentHitPoints = _CurrentHitPoints + newItemApplied.AffectValue;
                if(_CurrentHitPoints > _MaximumHitPoints) {
                    _CurrentHitPoints = _MaximumHitPoints;
                }
                return null;
            }
            else if (newItemApplied is Weapon) {
                Item tempWeapon = newItemApplied;
                if (_Weapon != null) {
                    _Weapon = (Weapon)newItemApplied;
                    return tempWeapon;
                }
                else {
                    _Weapon = (Weapon)newItemApplied;
                    return null;
                }
            }
            else if (newItemApplied is DoorKey) {
                Item tempDoorKey = newItemApplied;
                _HasDoorKey = (DoorKey)newItemApplied;
                return tempDoorKey;
            }
            else {
                return newItemApplied;
            }
        }


        /// <summary>
        /// Operator for adding a hero to a monster.
        /// </summary>
        /// <param name="h">Hero to add</param>
        /// <param name="m">Monster to add</param>
        /// <returns>true if the hero is still alive</returns>
        // From Jon's Deliverable 5 solution
        public static bool operator +(Hero h, Monster m) {
            if (!h.RunningAway) {
                if (h.AttackSpeed > m.AttackSpeed) {
                    m.damageMe(h.AttackValue());
                    if (m.isAlive()) {
                        h.damageMe(m.AttackValue);
                    }
                }
                else if (h.AttackSpeed < m.AttackSpeed) {
                    h.damageMe(m.AttackValue);
                    if (h.isAlive()) {
                        m.damageMe(h.AttackValue());
                    }
                }
                else { // Attack Speeds are the same.
                    
                    m.damageMe(h.AttackValue());
                    h.damageMe(m.AttackValue);
                }
            }
            else {
                if (h.AttackSpeed <= m.AttackSpeed)
                    h.damageMe(m.AttackValue);
            }
            h.RunningAway = false;
            return h.isAlive();
        }
        /// <summary>
        /// Operator for adding a hero to a monster.
        /// </summary>
        /// <param name="h">Hero to add</param>
        /// <param name="m">Monster to add</param>
        /// <returns>true if the hero is still alive</returns>
        public static bool operator +(Monster m, Hero h) {
            // call the other operator overload.
            return h + m;
        }
    }
}
