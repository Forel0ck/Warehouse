﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.BD;

namespace Warehouse.Classes
{
    internal class ClassEntities
    {
        public static AutopartEntities context { get; set; } = new AutopartEntities();
    }
}
