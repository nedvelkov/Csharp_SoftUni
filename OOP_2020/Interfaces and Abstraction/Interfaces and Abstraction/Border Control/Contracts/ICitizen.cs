using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl.Contracts
{
   public interface ICitizen
    {
        public string Id { get;  }
        public string GetIdNumber();

    }
}
