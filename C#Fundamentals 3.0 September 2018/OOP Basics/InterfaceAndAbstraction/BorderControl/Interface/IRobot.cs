using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl.Interface
{
    public interface IRobot
    {
        string Model { get; }

        string Id { get; }
    }
}
