using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Interface
{
   public interface IEngineer
    {
        List<KeyValuePair<string, int>> Repairs { get; }
    }
}
