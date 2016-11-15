// CS/INFO 1182
// Jon Holmes
// Description - A monster is an actor that can attack and be attacked by a hero.
using BaseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreObjectsLibrary;

namespace BaseObjects {
    [Serializable]
    public class Monster:Actor {
        private int _AttackValue = 0;
        #region "Constructors"
        /// <summary>
        /// OverLoaded Constructor
        /// </summary>
        /// <param name="newName">Monster's Name</param>
        /// <param name="newTitle">Monster's Title, if any</param>
        /// <param name="myAttackSpeed">How faster the Monster can attack</param>
        /// <param name="hitPoints">Amount of life</param>
        /// <param name="startingPositionX">Starting Position x Coordinate</param>
        /// <param name="startingPositionY">Starting Position y Coordinate</param>
        /// <param name="attackDamage">How much damage the monster can do</param>
        public Monster(String newName, String newTitle, double myAttackSpeed, int hitPoints, int startingPositionX, int startingPositionY, int attackDamage) 
            :base(newName,newTitle,myAttackSpeed,hitPoints,startingPositionX,startingPositionY ){
            _AttackValue = attackDamage;
        }
        #endregion
        /// <summary>
        /// Amount of damage done by the monster
        /// </summary>
        public int AttackValue {
            get {
                return _AttackValue;
            }
        }
        /// <summary>
        /// Create a deep copy of this monster
        /// </summary>
        /// <returns>Deep copy of monster</returns>
        public Monster CreateCopy() {
            return new Monster(this._Name, this._Title, this._AttackSpeed, this._MaximumHitPoints, this._PositionX, this._PositionY, this.AttackValue);
        }
    }
}
