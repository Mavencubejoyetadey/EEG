using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Montage
    {
        public string montage_ch { get; set; }
        public string montage_name { get; set; }
        public String[] channelList = { };
        public Montage(string _name, String[] list)
        {
           
            montage_name = _name;
            channelList = list;
        }
        public Montage()
        {
            montage_ch = "";
            montage_name = "";
            channelList = new string[]{ };
        }
    }
}
