using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diablo_8_SQLite
{
    public class Account
    {
        int id;
        string name;
        string email;
        List<Heroe> heroes = new List<Heroe>();

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Email { get => email; set => email = value; }
        public List<Heroe> Heroes { get => heroes; set => heroes = value; }
    }
}
