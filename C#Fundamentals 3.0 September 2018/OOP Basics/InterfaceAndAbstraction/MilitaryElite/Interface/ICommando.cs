using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Interface
{
   public interface ICommando
    {
       List<KeyValuePair<string, string>> Missions { get; }
        
    }
}
