﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
   public interface IBrowsing
    {
        public string URL { get;  }
        public string Browse();
    }
}
