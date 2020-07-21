using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace EventExample
{
    public delegate void OneDelegate(object sender, EventArgs args);
    public delegate void WriteCons(string message);

    class Second
    {
        public event OneDelegate simpleEv;
        public string Name;

        public void callEv()
        {
            simpleEv(this, new EventArgs());
        }

        public static Second CreateInstance(string _name)
        {
            return new Second()
            {
                Name = _name
            };
        }

        public void show(string msg)
        {
            Console.WriteLine("Hello " + msg);
        }

        public void useDel()
        {
            WriteCons log = show;
            log += show;
            log("Mister");
        }
    }
}
