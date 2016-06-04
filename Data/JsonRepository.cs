using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Tasky.Data
{
    public class JsonRepository<T> : JsonRepositoryBase<T>,Interfaces.IDataRepository<T> where T :Models.IModel
    {
        /*
        public event DataChangedEventHandler<T> DataChanged;
        private static string _fileName = "tasky.json";        
        private List<T> _entityList = new List<T>();
        */
        
        public event DataChangedEventHandler<T> DataChanged;

        public JsonRepository()
        {
           
            Load();
        }

        private async void Load()
        {
            var jsonString = await GetFileAsString(GetFilePath());
            var desirializedList = DesirializeJson(jsonString);
            base.SetEntityList(ref desirializedList);
            
        }

        private void WriteBack()
        {
            var serializedString = SerializeJson(base.GetEntityList());
            WriteStringToFile(GetFilePath(), serializedString);
        }

        #region Helper Methods



        

        
        #endregion


        #region Data Methods

        public void Add(T entity)
        {
            if(entity != null)
            {
                if (base.GetEntityList().Count != 0)
                {
                    entity.Id = base.GetEntityList().Max(x => x.Id) +1;
                }
                else
                {
                    entity.Id = 1;
                }
                base.GetEntityList().Add(entity);
                RaiseDataChanged(entity,DataChangedMode.New);
                WriteBack();
            }
        }

        public void Delete(T entity)
        {
            if (entity != null)
            {
                base.GetEntityList().Remove(entity);
                RaiseDataChanged(entity, DataChangedMode.Delete);
                WriteBack();
            }
        }

        public ObservableCollection<T> GetAll()
        {
            return new ObservableCollection<T>(base.GetEntityList());
        }

        public void Save(T entity)
        {
            if (entity != null)
            {
                var oldObject = base.GetEntityList().First(x => x.Id == entity.Id);
                var oldObjectIndex = base.GetEntityList().IndexOf(oldObject);
                base.GetEntityList().Remove(oldObject);
                base.GetEntityList().Insert(oldObjectIndex, entity);
                RaiseDataChanged(entity, DataChangedMode.Update);
                WriteBack();
            }
        }

        #endregion

        private void RaiseDataChanged(T entity,DataChangedMode mode)
        {
            var handler = DataChanged;
            handler?.Invoke(new DataChangedEventArgs<T>(entity,mode));
        }
    }
}

