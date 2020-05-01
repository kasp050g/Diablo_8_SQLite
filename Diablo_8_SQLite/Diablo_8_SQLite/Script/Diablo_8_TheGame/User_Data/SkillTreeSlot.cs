using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diablo_8_SQLite
{
    public class SkillTreeSlot
    {
        int id;
        Skill skill;
        List<SkillRequired> skillRequireds = new List<SkillRequired>();
        Vector2 position;

        public int Id { get => id; set => id = value; }
        public Skill Skill { get => skill; set => skill = value; }
        public List<SkillRequired> SkillRequireds { get => skillRequireds; set => skillRequireds = value; }
        public Vector2 Position { get => position; set => position = value; }
    }
}
