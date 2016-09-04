using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindMyCourtObjectLibrary.Objects
{
    // This class will implement the required methods to ensure an objects state is kept correctly.
    // This will allow us to know whether an object is new, or whether or not it has changes,
    // and subsequently, know whether to save it or not
    public abstract class SaveableObject : INotifyPropertyChanged
    {
        [JsonIgnore]
        public bool IsNew { get; set; }
        [JsonIgnore]
        public bool IsDirty { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            IsDirty = true;
        }

        public void Save()
        {
            if (IsNew)
                Insert();
            else if (IsDirty)
                Update();
        }

        protected abstract void Insert();
        protected abstract void Update();
    }
}
