using Script.Generics;
using SQLiteFramework.ExtensionMethods;
using SQLiteFramework.Framework;
using SQLiteFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteFramework.Framework
{
    /// <summary>
    /// Indeholder alle tables i databasen.
    /// </summary>
    public class TableContainer
    {
        private IDBProvider provider = new SQLiteDatabaseProvider("Data Source=Diablo8.db; Version=3; new=true");
        private IMapper mapper = new Mapper();

        public ITable ClassTable, StartStatsTable, HeroesSaveTable,
                      SkillsTable, SkillRequiredTable, SkillTreeSlotsTable,
                      SkillsSaveTable, SkillTreesTable, HeroesTable, UsersTable,
                      ItemTypeTable, ItemsTable, InventorySlotTable;

        public TableContainer()
        {
            InitContainer();

            AddTableContent();
        }

        private void InitContainer()
        {
            ClassTable = new Table("Class_TABLE", provider, mapper,
                                   "Name".AsType(typeof(string)));

            StartStatsTable = new Table("StartStats_TABLE", provider, mapper,
                                        "ClassID".AsType(typeof(int)),
                                        "Strength".AsType(typeof(int)),
                                        "Dexterity".AsType(typeof(int)),
                                        "Vitality".AsType(typeof(int)),
                                        "Energy".AsType(typeof(int)));

            HeroesSaveTable = new Table("HeroesSave_TABLE", provider, mapper,
                                        "HeroID".AsType(typeof(int)),
                                        "SkillPoint".AsType(typeof(int)),
                                        "StatsPoint".AsType(typeof(int)),
                                        "Level".AsType(typeof(int)),
                                        "XP".AsType(typeof(int)),
                                        "Gold".AsType(typeof(int)));

            SkillsTable = new Table("Skills_TABLE", provider, mapper,
                                    "Name".AsType(typeof(string)),
                                    "ManaCost".AsType(typeof(int)),
                                    "Damage".AsType(typeof(int)),
                                    "Level".AsType(typeof(int)),
                                    "Range".AsType(typeof(int)),
                                    "IsMelee".AsType(typeof(bool)),
                                    "DamageScalingParam".AsType(typeof(int)),
                                    "ManaCostScalingParam".AsType(typeof(int)),
                                    "IconID".AsType(typeof(string)),
                                    "DisplayID".AsType(typeof(string)),
                                    "ClassID".AsType(typeof(int)));

            SkillRequiredTable = new Table("SkillRequired_TABLE", provider, mapper,
                                           "SkillID".AsType(typeof(int)),
                                           "SkillTalent".AsType(typeof(int)),
                                           "LevelRequired".AsType(typeof(int)));

            SkillTreeSlotsTable = new Table("SkillTreeSlots_TABLE", provider, mapper,
                                            "SkillID".AsType(typeof(int)),
                                            "SkillTreeID".AsType(typeof(int)),
                                            "RowPosition".AsType(typeof(int)),
                                            "ColumnPosition".AsType(typeof(int)));

            SkillsSaveTable = new Table("SkillsSave_TABLE", provider, mapper,
                                        "SkillID".AsType(typeof(int)),
                                        "Levels".AsType(typeof(int)),
                                        "HeroesSaveID".AsType(typeof(int)));

            SkillTreesTable = new Table("SkillTrees_TABLE", provider, mapper,
                                        "ClassID".AsType(typeof(int)),
                                        "Name".AsType(typeof(string)));

            HeroesTable = new Table("Heroes_TABLE", provider, mapper,
                                    "UserID".AsType(typeof(int)),
                                    "ClassID".AsType(typeof(int)),
                                    "Name".AsType(typeof(string)));

            UsersTable = new Table("Users_TABLE", provider, mapper,
                                   "Name".AsType(typeof(string)),
                                   "Email".AsType(typeof(string)),
                                   "Salt".AsType(typeof(string)),
                                   "Password".AsType(typeof(string)),
                                   "Dato".AsType(typeof(int)));

            ItemTypeTable = new Table("ItemType_TABLE", provider, mapper,
                                      "Name".AsType(typeof(string)));

            ItemsTable = new Table("Items_TABLE", provider, mapper,
                                   "ItemTypeID".AsType(typeof(int)),
                                   "Level".AsType(typeof(int)),
                                   "Defense".AsType(typeof(int)),
                                   "MinDamage".AsType(typeof(int)),
                                   "MaxDamage".AsType(typeof(int)),
                                   "Strength".AsType(typeof(int)),
                                   "Dexterity".AsType(typeof(int)),
                                   "Vitality".AsType(typeof(int)),
                                   "Energy".AsType(typeof(int)),
                                   "Health".AsType(typeof(int)),
                                   "Mana".AsType(typeof(int)),
                                   "IconID".AsType(typeof(string)),
                                   "DisplayID".AsType(typeof(string)),
                                   "Description".AsType(typeof(string)),
                                   "GoldCost".AsType(typeof(int)));

            InventorySlotTable = new Table("InventorySlot_TABLE", provider, mapper,
                                           "UserID".AsType(typeof(int)),
                                           "Equipped".AsType(typeof(bool)),
                                           "ItemID".AsType(typeof(int)));
        }

        private void AddTableContent()
        {
            ClassTable.InsertRow(true,"Sorceress");
            ClassTable.InsertRow(false, "Barbarian");
            ClassTable.InsertRow(false, "Necromancer");

            List<IRowElement> classes = ClassTable.GetAllRows();

            foreach (IRowElement x in classes)
            {
                int h = x.Id;
                Console.WriteLine(h.ToString() + ": " + x.RowElementVariables["Name"]);
            }

                
            //for (int i = 0; i < classes.Count; i++)
            //{
            //    ClassTable.DeleteRow(classes[i].Id);
            //}
        }
    }
}
