using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diablo_8_SQLite
{
    public class Skill
    {
        int id;
        string name;
        int manaCost;
        int damage;
        int level;
        int range;
        bool isMelee;
        int damageScalingParameter;
        int manaCostScalingParameter;
        Texture2D icon;
        Texture2D displayImage;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int ManaCost { get => manaCost; set => manaCost = value; }
        public int Damage { get => damage; set => damage = value; }
        public int Level { get => level; set => level = value; }
        public int Range { get => range; set => range = value; }
        public bool IsMelee { get => isMelee; set => isMelee = value; }
        public int DamageScalingParameter { get => damageScalingParameter; set => damageScalingParameter = value; }
        public int ManaCostScalingParameter { get => manaCostScalingParameter; set => manaCostScalingParameter = value; }
        public Texture2D Icon { get => icon; set => icon = value; }
        public Texture2D DisplayImage { get => displayImage; set => displayImage = value; }
    }
}
