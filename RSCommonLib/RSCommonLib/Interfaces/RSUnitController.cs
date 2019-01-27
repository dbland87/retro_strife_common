using System;
using System.Collections.Generic;
using System.Text;

namespace RSCommonLib.Interfaces
{
    interface RSUnitController
    {
        List<RSUnitModel> GetAllUnits();
        RSUnitModel FindUnitById(int id);
    }
}
