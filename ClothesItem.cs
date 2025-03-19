using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greenday
{
    internal record ClothesItem
    {
        public int id = -1;
        public string type = "";
        public int size = -1;
        public string brand = "";
        public int condition = 0;
        public string material = "";
        public double c02Savings = 0.0d;
        public bool sold;
        public DateTime donationTime;
    }
}
