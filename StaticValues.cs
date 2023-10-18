using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOD_Assistant
{
    internal class StaticValues  //singleton object 
    {
        static StaticValues _staticValues;

        public System.Timers.Timer aTimer = new System.Timers.Timer(1000);
        public MessageQueue mQueue = new MessageQueue();

        public bool startFlag;

        internal static StaticValues Instance()
        {
            if (_staticValues == null)
                _staticValues = new StaticValues();
            return _staticValues;
        }

    }
       
}
