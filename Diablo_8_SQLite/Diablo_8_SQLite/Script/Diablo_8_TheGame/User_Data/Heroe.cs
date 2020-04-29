using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diablo_8_SQLite
{
    public class Heroe
    {
        private int id;
        private string name;
        private string className;
        private int xp;
        private int level;
        private int gold;
        private int strength;
        private int dexterity;
        private int vitality;
        private int energy;
        private int statsPoint;
        private int skillPoint;
        private List<Skill> skills = new List<Skill>();
        private List<SkillTree> skillTrees = new List<SkillTree>();

        private Dictionary<string, dynamic> heroTableVariables = new Dictionary<string, dynamic>();
        private Dictionary<string, dynamic> heroesSaveTableVariables = new Dictionary<string, dynamic>();
        private Dictionary<string, dynamic> statTableVariables = new Dictionary<string, dynamic>();

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

        public Heroe(Dictionary<string, dynamic> heroVariables, Dictionary<string, dynamic> heroSaveVariables, Dictionary<string, dynamic> statVariables)
        {
            heroTableVariables = heroVariables;
            heroesSaveTableVariables = heroSaveVariables;
            statTableVariables = statVariables;

            SetupVariables();
        }

        private void SetupVariables()
        {
            id = heroesSaveTableVariables["Id"]; // Skal ikke skrives sådan, skal være id = x(rowElement).Id;
            className = heroTableVariables["Name"];
            xp = heroesSaveTableVariables["XP"];
            level = heroesSaveTableVariables["Level"];
            gold = heroesSaveTableVariables["Gold"];
            strength = statTableVariables["Strength"];
            dexterity = statTableVariables["Dexterity"];
            vitality = statTableVariables["Vitality"];
            energy = statTableVariables["Energy"];
        }
    }
}
