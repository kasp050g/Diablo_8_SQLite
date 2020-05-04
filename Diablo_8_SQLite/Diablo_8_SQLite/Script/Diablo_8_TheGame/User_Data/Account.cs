using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diablo_8_SQLite
{
    public class Account
    {
        private int id;
        private string name;
        private string email;
        private List<Heroes> heroes = new List<Heroes>();

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Email { get => email; set => email = value; }
        public List<Heroes> Heroes { get => heroes; set => heroes = value; }
    }
}
