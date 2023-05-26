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
        bool CheckIfChanged();
        List<string> GetChanges();
        void OrgenizeData(string data);
        void ResetSettingsToDefault();

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
