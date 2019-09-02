using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl.Interface
{
    public interface IPerson
    {
        string Name { get; }

        string Age { get; }

        string Id { get; }

        string Birthday { get; }
    }
}
