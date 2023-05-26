using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soom_Client
{
    public interface IMainScreenComponents
    {
        bool IsFinished { get; }
        event FinishedEvent Event;
        string Name { get; }
        void Finished();
    }
}
