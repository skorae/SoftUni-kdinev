using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Entity.Characters
{
    public interface IHealable
    {
        void Heal(Character character);
    }
}
