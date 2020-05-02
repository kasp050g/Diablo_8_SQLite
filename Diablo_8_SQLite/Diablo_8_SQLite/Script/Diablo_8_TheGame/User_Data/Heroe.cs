using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameFramework;
using Script.Generics;
using SQLiteFramework.ExtensionMethods;
using SQLiteFramework.Framework;
using SQLiteFramework.Interfaces;
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
        private int startstrength;
        private int startdexterity;
        private int startvitality;
        private int startenergy;
        private int statsPoint;
        private int skillPoint;
        private List<Skill> skills = new List<Skill>();
        private List<SkillTree> skillTrees = new List<SkillTree>();

        private Dictionary<string, dynamic> heroTableVariables = new Dictionary<string, dynamic>();
        private Dictionary<string, dynamic> heroesSaveTableVariables = new Dictionary<string, dynamic>();
        private Dictionary<string, dynamic> statTableVariables = new Dictionary<string, dynamic>();

        private int heroSaveId;
        private int statsSaveId;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string ClassName { get => className; set => className = value; }
        public int Xp { get => xp; set => xp = value; }
        public int Level { get => level; set => level = value; }
        public int Gold { get => gold; set => gold = value; }
        public int Strength { get => strength + startstrength; set => strength = value; }
        public int Dexterity { get => dexterity + startdexterity; set => dexterity = value; }
        public int Vitality { get => vitality + startvitality; set => vitality = value; }
        public int Energy { get => energy + startenergy; set => energy = value; }
        public int StatsPoint { get => statsPoint; set => statsPoint = value; }
        public int SkillPoint { get => skillPoint; set => skillPoint = value; }
        public List<Skill> Skills { get => skills; set => skills = value; }
        public List<SkillTree> SkillTrees { get => skillTrees; set => skillTrees = value; }

        public Heroe()
        {

        }

        public Heroe(int heroID)
        {
            IRowElement hero_Table = Singletons.TableContainerSingleton.HeroesTable.FindRow(heroID);
            // Class
            IRowElement class_Table = Singletons.TableContainerSingleton.ClassTable.FindRow((int)hero_Table.RowElementVariables["ClassID"]);
            IRowElement StartStats_Table = Singletons.TableContainerSingleton.StartStatsTable.FindRow("ClassID", class_Table.Id);
            // Skill
            List<IRowElement> Skills_Table = Singletons.TableContainerSingleton.SkillsTable.FindRows("ClassID", class_Table.Id);
            List<IRowElement> SkillTrees_Table = Singletons.TableContainerSingleton.SkillTreesTable.FindRows("ClassID", class_Table.Id);
            List<IRowElement> skillTreeSlots_Table = new List<IRowElement>();
            foreach (IRowElement item in SkillTrees_Table)
            {
                skillTreeSlots_Table.AddRange(Singletons.TableContainerSingleton.SkillTreeSlotsTable.FindRows("SkillTreeID", item.Id));
            }
            List<IRowElement> skillRequired_Table = Singletons.TableContainerSingleton.SkillRequiredTable.GetAllRows();
            // TODO: Fix Error here if we got the time.
            //List<IRowElement> skillRequired_Table = new List<IRowElement>();
            //foreach (IRowElement item in skillTreeSlots_Table)
            //{
            //    skillRequired_Table.Add(Singletons.TableContainerSingleton.SkillRequiredTable.FindRow("SkillTalent", item.Id));
            //}
            // save Data
            IRowElement heroesSave_Table = Singletons.TableContainerSingleton.HeroesSaveTable.FindRow("HeroID", hero_Table.Id);
            IRowElement statsSave_Table = Singletons.TableContainerSingleton.StatsSaveTable.FindRow("HeroesSaveID", heroesSave_Table.Id);
            List<IRowElement> skillsSave_Table = Singletons.TableContainerSingleton.SkillsSaveTable.FindRows("HeroesSaveID", heroesSave_Table.Id);

            // - - - - - Set Data into Hero

            id = hero_Table.Id;
            name = hero_Table.RowElementVariables["Name"];
            className = class_Table.RowElementVariables["Name"];

            heroSaveId = heroesSave_Table.Id;
            xp = heroesSave_Table.RowElementVariables["XP"];
            level = heroesSave_Table.RowElementVariables["Level"];
            gold = heroesSave_Table.RowElementVariables["Gold"];
            // Stats
            statsSaveId = statsSave_Table.Id;
            strength =  statsSave_Table.RowElementVariables["Strength"];
            dexterity =  statsSave_Table.RowElementVariables["Dexterity"];
            vitality =  statsSave_Table.RowElementVariables["Vitality"];
            energy =  statsSave_Table.RowElementVariables["Energy"];
            startstrength = StartStats_Table.RowElementVariables["Strength"] ;
            startdexterity = StartStats_Table.RowElementVariables["Dexterity"] ;
            startvitality = StartStats_Table.RowElementVariables["Vitality"] ;
            startenergy = StartStats_Table.RowElementVariables["Energy"] ;

            statsPoint = heroesSave_Table.RowElementVariables["StatsPoint"];
            skillPoint = heroesSave_Table.RowElementVariables["SkillPoint"];

            foreach (IRowElement x in Skills_Table)
            {
                Skill newSkill = new Skill()
                {
                    Id = x.Id,
                    Name = x.RowElementVariables["Name"],
                    ManaCost = x.RowElementVariables["ManaCost"],
                    Damage = x.RowElementVariables["Damage"],
                    Level = x.RowElementVariables["Level"],
                    Range = x.RowElementVariables["Range"],
                    IsMelee = x.RowElementVariables["IsMelee"],
                    DamageScalingParameter = x.RowElementVariables["DamageScalingParameter"],
                    ManaCostScalingParameter = x.RowElementVariables["ManaCostScalingParameter"],
                    Icon = SpriteContainer.Instance.sprite[x.RowElementVariables["IconID"]],
                    DisplayImage = SpriteContainer.Instance.sprite[x.RowElementVariables["DisplayID"]]
                };
                skills.Add(newSkill);
            }

            foreach (Skill x in skills)
            {
                foreach (IRowElement y in skillsSave_Table)
                {
                    int tmp_skillsSaveID = y.RowElementVariables["SkillID"];
                    if (x.Id == tmp_skillsSaveID)
                    {
                        int tmp_skillsSaveLevel = y.RowElementVariables["Levels"];
                        x.Level += tmp_skillsSaveLevel;
                    }
                }
            }

            // full on skill tree
            // note to self, dont make it like this in the future.
            foreach (IRowElement skillTree in SkillTrees_Table)
            {
                SkillTree newSkillTree = new SkillTree()
                {
                    Id = skillTree.Id
                };

                foreach (IRowElement skillTreeSlot in skillTreeSlots_Table)
                {
                    if (skillTreeSlot.RowElementVariables["SkillTreeID"] == skillTree.Id)
                    {
                        // make skillTreeSlot
                        SkillTreeSlot newSkillTreeSlot = new SkillTreeSlot()
                        {
                            Id = skillTreeSlot.Id,
                            Position = new Vector2(skillTreeSlot.RowElementVariables["RowPosition"], skillTreeSlot.RowElementVariables["ColumnPosition"])
                        };
                        // Add the skill to skillTreeSlot.
                        foreach (Skill skill in skills)
                        {
                            if (skillTreeSlot.RowElementVariables["SkillID"] == skill.Id)
                            {
                                newSkillTreeSlot.Skill = skill;
                            }
                        }
                        // skillRequired
                        foreach (IRowElement skillRequired in skillRequired_Table)
                        {
                            if (skillRequired.RowElementVariables["SkillTalent"] == skillTreeSlot.Id)
                            {
                                SkillRequired newskillRequired = new SkillRequired()
                                {
                                    Id = skillRequired.Id,
                                    RequiredLevel = skillRequired.RowElementVariables["LevelRequired"]
                                };

                                foreach (Skill skill in skills)
                                {
                                    if (skillRequired.RowElementVariables["SkillID"] == skill.Id)
                                    {
                                        newskillRequired.RequiredSkill = skill;
                                    }
                                }
                                newSkillTreeSlot.SkillRequireds.Add(newskillRequired);
                            }
                        }
                        newSkillTree.SkillTreeSlots.Add(newSkillTreeSlot);
                    }
                }

                SkillTrees.Add(newSkillTree);
            }
        }

        public void SaveHero()
        {
            Singletons.TableContainerSingleton.HeroesSaveTable.Update(heroSaveId, "SkillPoint".Pair(skillPoint), "StatsPoint".Pair(statsPoint), "Level".Pair(level), "XP".Pair(xp),"Gold".Pair(gold));
            Singletons.TableContainerSingleton.StatsSaveTable.Update(statsSaveId, "Strength".Pair(strength), "Dexterity".Pair(dexterity), "Vitality".Pair(vitality), "Energy".Pair(energy));
            
            List<IRowElement> saveSkills = Singletons.TableContainerSingleton.SkillsSaveTable.FindRows("HeroesSaveID", heroSaveId);
            foreach (Skill _skill in skills)
            {
                if(_skill.Level > 0)
                {
                    bool didUpdate = false;
                    foreach (IRowElement _saveSkills in saveSkills)
                    {
                        if (_saveSkills.RowElementVariables["SkillID"] == _skill.Id)
                        {
                            Singletons.TableContainerSingleton.SkillsSaveTable.Update(_saveSkills.Id, "Levels".Pair(_skill.Level));
                            didUpdate = true;
                        }
                    }
                    if (didUpdate == false)
                    {
                        Singletons.TableContainerSingleton.SkillsSaveTable.InsertRow(_skill.Id, _skill.Level, heroSaveId);
                    }
                }
            }
        }
    }
}
