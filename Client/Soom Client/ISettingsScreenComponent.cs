using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soom_Client
{
    public interface ISettingsScreenComponent
    {
        void IsChanged();
        event ValuesChangedEvent ChangedEvent;
        List<string> Convert2Str();
        bool CheckIfChanged();
        void OrgenizeData(string data);

    }
    public class ValuesChangedEventArgs : EventArgs
    {
        public bool IsChanged;
        public ValuesChangedEventArgs(bool isChanged)
        {
            IsChanged = isChanged;
        }
    }
    public delegate void ValuesChangedEvent(ValuesChangedEventArgs e);
}
