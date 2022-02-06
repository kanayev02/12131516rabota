using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _91011rabota
{
    public partial class Ученики
    {
        public string Matematika
        {
            get
            {
                return "Математика " + ОценкаМатематика.ToString();
            }
        }
        public string Russk
        {
            get
            {
                return "Русский язык " + ОценкаРусский.ToString();
            }
        }
        public string Fizika
        {
            get
            {
                return "Физика " + ОценкаФизика.ToString();
            }
        }
    }
}
