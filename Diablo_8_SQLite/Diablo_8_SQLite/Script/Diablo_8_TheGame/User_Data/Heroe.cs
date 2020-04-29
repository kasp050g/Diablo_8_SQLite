using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diablo_8_SQLite
{
    public class Heroe
    {
        int id;
        string name;
        string className;
        int xp;
        int level;
        int gold;
        int strength;
        int dexterity;
        int vitality;
        int energy;
        int statsPoint;
        int skillPoint;
        List<Skill> skills = new List<Skill>();
        List<SkillTree> skillTrees = new List<SkillTree>();

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string ClassName { get => className; set => className = value; }
        public int Xp { get => xp; set => xp = value; }
        public int Level { get => level; set => level = value; }
        public int Gold { get => gold; set => gold = value; }
        public int Strength { get => strength; set => strength = value; }
        public int Dexterity { get => dexterity; set => dexterity = value; }
        public int Vitality { get => vitality; set => vitality = value; }
        public int Energy { get => energy; set => energy = value; }
        public int StatsPoint { get => statsPoint; set => statsPoint = value; }
        public int SkillPoint { get => skillPoint; set => skillPoint = value; }
        public List<Skill> Skills { get => skills; set => skills = value; }
        public List<SkillTree> SkillTrees { get => skillTrees; set => skillTrees = value; }        
    }
}
