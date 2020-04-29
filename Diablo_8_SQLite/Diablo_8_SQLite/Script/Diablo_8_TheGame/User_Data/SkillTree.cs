using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diablo_8_SQLite
{
    public class SkillTree
    {
        List<SkillTreeSlot> skillTreeSlots = new List<SkillTreeSlot>();

        public List<SkillTreeSlot> SkillTreeSlots { get => skillTreeSlots; set => skillTreeSlots = value; }
    }
}
