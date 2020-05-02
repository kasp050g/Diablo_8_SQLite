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
                      ItemTypeTable, ItemsTable, InventorySlotTable, StatsSaveTable;

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

            StatsSaveTable = new Table("StatsSave_TABLE", provider, mapper,
                            "HeroesSaveID".AsType(typeof(int)),
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
                                    "DamageScalingParameter".AsType(typeof(int)),
                                    "ManaCostScalingParameter".AsType(typeof(int)),
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
            // Classes
            IRowElement Sorceress = ClassTable.InsertRow(false, "Sorceress");

            if (Sorceress != null)
            {
                IRowElement Barbarian = ClassTable.InsertRow(false, "Barbarian");
                IRowElement Necromancer = ClassTable.InsertRow(false, "Necromancer");

                // Start stats
                StartStatsTable.InsertRow(false, Sorceress.Id, 5, 10, 5, 30);
                StartStatsTable.InsertRow(false, Barbarian.Id, 15, 5, 25, 5);
                StartStatsTable.InsertRow(false, Necromancer.Id, 10, 15, 10, 15);

                // - - - Skills
                // Sorceress
                IRowElement SkillsTable_S1 = SkillsTable.InsertRow(false, "spell1", 5, 5, 0, 20, 0, 2, 2, "Pixel", "Pixel", Sorceress.Id);
                IRowElement SkillsTable_S2 = SkillsTable.InsertRow(false, "spell2", 10, 10, 0, 25, 0, 2, 2, "Pixel", "Pixel", Sorceress.Id);
                IRowElement SkillsTable_S3 = SkillsTable.InsertRow(false, "spell3", 20, 20, 0, 10, 0, 2, 2, "Pixel", "Pixel", Sorceress.Id);
                // Barbarian
                IRowElement SkillsTable_B1 = SkillsTable.InsertRow(false, "attack1", 5, 1, 0, 2, 1, 2, 2, "Pixel", "Pixel", Barbarian.Id);
                IRowElement SkillsTable_B2 = SkillsTable.InsertRow(false, "attack2", 10, 2, 0, 4, 1, 2, 2, "Pixel", "Pixel", Barbarian.Id);
                IRowElement SkillsTable_B3 = SkillsTable.InsertRow(false, "attack3", 20, 3, 0, 5, 1, 2, 2, "Pixel", "Pixel", Barbarian.Id);
                // Necromancer
                IRowElement SkillsTable_N1 = SkillsTable.InsertRow(false, "summon1", 5, 5, 0, 20, 0, 2, 2, "Pixel", "Pixel", Necromancer.Id);
                IRowElement SkillsTable_N2 = SkillsTable.InsertRow(false, "summon2", 10, 10, 0, 25, 0, 2, 2, "Pixel", "Pixel", Necromancer.Id);
                IRowElement SkillsTable_N3 = SkillsTable.InsertRow(false, "summon3", 20, 20, 0, 10, 0, 2, 2, "Pixel", "Pixel", Necromancer.Id);

                // - - - SkillTree
                IRowElement SkillTreesTable_S1 = SkillTreesTable.InsertRow(false, Sorceress.Id, "Fires");
                IRowElement SkillTreesTable_B1 = SkillTreesTable.InsertRow(false, Barbarian.Id, "Melee");
                IRowElement SkillTreesTable_N1 = SkillTreesTable.InsertRow(false, Necromancer.Id, "Summon");

                // - - - SkillTreesTable
                // Sorceress 
                IRowElement SkillTreeSlotsTable_S1 = SkillTreeSlotsTable.InsertRow(false, SkillsTable_S1.Id, SkillTreesTable_S1.Id, 1, 1);
                IRowElement SkillTreeSlotsTable_S2 = SkillTreeSlotsTable.InsertRow(false, SkillsTable_S2.Id, SkillTreesTable_S1.Id, 1, 2);
                IRowElement SkillTreeSlotsTable_S3 = SkillTreeSlotsTable.InsertRow(false, SkillsTable_S3.Id, SkillTreesTable_S1.Id, 2, 1);
                // Barbarian 
                IRowElement SkillTreeSlotsTable_B1 = SkillTreeSlotsTable.InsertRow(false, SkillsTable_B1.Id, SkillTreesTable_B1.Id, 1, 1);
                IRowElement SkillTreeSlotsTable_B2 = SkillTreeSlotsTable.InsertRow(false, SkillsTable_B2.Id, SkillTreesTable_B1.Id, 2, 1);
                IRowElement SkillTreeSlotsTable_B3 = SkillTreeSlotsTable.InsertRow(false, SkillsTable_B3.Id, SkillTreesTable_B1.Id, 2, 2);
                // Necromancer 
                IRowElement SkillTreeSlotsTable_N1 = SkillTreeSlotsTable.InsertRow(false, SkillsTable_N1.Id, SkillTreesTable_N1.Id, 1, 1);
                IRowElement SkillTreeSlotsTable_N2 = SkillTreeSlotsTable.InsertRow(false, SkillsTable_N2.Id, SkillTreesTable_N1.Id, 3, 1);
                IRowElement SkillTreeSlotsTable_N3 = SkillTreeSlotsTable.InsertRow(false, SkillsTable_N3.Id, SkillTreesTable_N1.Id, 3, 2);

                // - - - SkillRequired
                // Sorceress
                SkillRequiredTable.InsertRow(false, SkillsTable_S1.Id, SkillTreeSlotsTable_S3.Id, 3);
                // Barbarian
                SkillRequiredTable.InsertRow(false, SkillsTable_B2.Id, SkillTreeSlotsTable_B3.Id, 3);
                // Necromancer
                SkillRequiredTable.InsertRow(false, SkillsTable_N2.Id, SkillTreeSlotsTable_N3.Id, 3);

                // - - - ItemType
                IRowElement itemType_Sword = ItemTypeTable.InsertRow(false, "Sword");
                IRowElement itemType_Axe = ItemTypeTable.InsertRow(false, "Axe");
                IRowElement itemType_Wand = ItemTypeTable.InsertRow(false, "Wand");
                IRowElement itemType_Chest = ItemTypeTable.InsertRow(false, "Chest");
                IRowElement itemType_Helmet = ItemTypeTable.InsertRow(false, "Helmet");
                IRowElement itemType_Boots = ItemTypeTable.InsertRow(false, "Boots");
                IRowElement itemType_Gloves = ItemTypeTable.InsertRow(false, "Gloves");

                // - - - Items
                #region items
                IRowElement item_Sword01 = ItemsTable.InsertRow(false,
                    // ItemTypeID
                    itemType_Sword.Id,
                    // Level
                    1,
                    // Defense
                    0,
                    // MinDamage
                    2,
                    // MaxDamage
                    4,
                    // Strength
                    2,
                    // Dexterity
                    0,
                    // Virality
                    0,
                    // Energy
                    0,
                    // Health
                    0,
                    // Mana
                    0,
                    // Icon ID
                    "Pixel",
                    // Display ID
                    "Pixel",
                    // Description
                    "this is Sword",
                    // Gold
                    5
                );

                IRowElement item_Axe01 = ItemsTable.InsertRow(false,
                    // ItemTypeID
                    itemType_Axe.Id,
                    // Level
                    2,
                    // Defense
                    0,
                    // MinDamage
                    5,
                    // MaxDamage
                    10,
                    // Strength
                    2,
                    // Dexterity
                    0,
                    // Virality
                    0,
                    // Energy
                    0,
                    // Health
                    50,
                    // Mana
                    0,
                    // Icon ID
                    "Pixel",
                    // Display ID
                    "Pixel",
                    // Description
                    "this is Axe",
                    // Gold
                    5
                );

                IRowElement item_Wand01 = ItemsTable.InsertRow(false,
                    // ItemTypeID
                    itemType_Wand.Id,
                    // Level
                    1,
                    // Defense
                    0,
                    // MinDamage
                    1,
                    // MaxDamage
                    8,
                    // Strength
                    2,
                    // Dexterity
                    0,
                    // Virality
                    0,
                    // Energy
                    4,
                    // Health
                    0,
                    // Mana
                    0,
                    // Icon ID
                    "Pixel",
                    // Display ID
                    "Pixel",
                    // Description
                    "this is Wand",
                    // Gold
                    5
                );
                #endregion


                // - - - Test Zone
                IRowElement userTest = UsersTable.InsertRow(false, "1", "1", "1", "1", 1);

                IRowElement heroTest01 = HeroesTable.InsertRow(false, userTest.Id, Sorceress.Id, "Test Hero S");
                IRowElement herosaveTest01 = HeroesSaveTable.InsertRow(false, heroTest01.Id, 1, 1, 1, 0, 0);
                IRowElement savestats01 = StatsSaveTable.InsertRow(false, herosaveTest01.Id, 0, 0, 0, 0);

                IRowElement heroTest02 = HeroesTable.InsertRow(false, userTest.Id, Barbarian.Id, "Test Hero B");
                IRowElement herosaveTest02 = HeroesSaveTable.InsertRow(false, heroTest02.Id, 1, 1, 1, 0, 0);
                IRowElement savestats02 = StatsSaveTable.InsertRow(false, herosaveTest02.Id, 0, 0, 0, 0);
            }

          //  SkillsTable.InsertRow("Mortal Strike", 25, 10, 1, 100, true, 1.1, 1.2, );
        }
    }
}
