﻿using Drinko.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Drinko.ViewModel
{
    public class OrderViewModel
    {
        public Order Order { get; set; }
        public ApplicationUser User { get; set; }
    }
}
