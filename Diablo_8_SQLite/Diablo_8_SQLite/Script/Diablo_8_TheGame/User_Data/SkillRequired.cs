﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diablo_8_SQLite
{
    public class SkillRequired
    {
        private int id;
        private Skill requiredSkill;
        private int requiredLevel;

        public int Id { get => id; set => id = value; }
        public Skill RequiredSkill { get => requiredSkill; set => requiredSkill = value; }
        public int RequiredLevel { get => requiredLevel; set => requiredLevel = value; }
    }
}
