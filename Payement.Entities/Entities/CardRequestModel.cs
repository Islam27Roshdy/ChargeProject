﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payement.Entities.Entities
{
    public class CardRequestModel: RequestModel
    {
        public string cardToken { get; set; }
    }
}