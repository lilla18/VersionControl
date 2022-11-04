﻿using het7.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace het7.Entities
{
    class CarFactory : Abstractions.IToyFactory
    {
        public Toy CreateNew()
        {
            return new Entities.Car();
        }

    }
}
