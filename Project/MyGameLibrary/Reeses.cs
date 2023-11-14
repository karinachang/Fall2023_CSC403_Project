using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#pragma warning disable 1591 // use this to disable comment warnings

namespace Fall2020_CSC403_Project.code
{
    /// <summary>
    /// This is the class for an enemy
    /// </summary>
    public class Reeses : Character
    {
        public int Health { get; private set; }
        public int MaxHealth { get; private set; }
        private float strength;

        public event Action<int> AttackEvent;

        /// <summary>
        /// THis is the image for an enemy
        /// </summary>
        public Image Img { get; set; }

        /// <summary>
        /// this is the background color for the fight form for this enemy
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="initPos">this is the initial position of the enemy</param>
        /// <param name="collider">this is the collider for the enemy</param>
        /// 
        public Reeses(Vector2 initPos, Collider collider) : base(initPos, collider)
        {
            MaxHealth = 10;
            strength = 2;
            Health = MaxHealth;
        }

        public void OnAttack(int amount)
        {
            AttackEvent((int)(amount * strength));
        }
        public void AlterHealth(int amount)
        {
            Health += amount;
        }
    }
}
