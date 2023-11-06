using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplayReader.Replay
{
    public interface IConfigDisablable
    {
        bool EnabledInGame { get; set; }
    }
}
