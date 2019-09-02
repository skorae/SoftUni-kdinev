using System;
using System.Collections.Generic;
using System.Text;

namespace Google
{
    public class Children
    {
        private string name;
        private string birthday;

        public Children(string name,string birthday)
        {
            this.Name = name;
            this.Birthday = birthday;
        }
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public string Birthday
        {
            get { return this.birthday; }
            set { this.birthday = value; }
        }
        
    }
}
