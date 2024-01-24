﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolistirolbetonDomCalc.Core
{
    interface IPriceRepository
    {
        Task<int> GetPriceByIdAsync(int id);
    }
}
