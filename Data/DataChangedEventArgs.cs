using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasky.Data
{
    public enum DataChangedMode
    {
        New,
        Update,
        Delete
    }

    public delegate void DataChangedEventHandler<T>(DataChangedEventArgs<T> e);

    public class DataChangedEventArgs<Ttype>
    {
        public Ttype ChangedEntity { get; private set; }
        public DataChangedMode Mode { get; private set; }

        public DataChangedEventArgs(Ttype changedEntity,DataChangedMode mode)
        {
            this.ChangedEntity = changedEntity;
            this.Mode = mode;
        }
    }
}
