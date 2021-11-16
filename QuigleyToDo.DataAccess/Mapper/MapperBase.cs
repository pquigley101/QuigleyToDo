using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Data;

namespace QuigleyToDo.DataAccess.Mapper
{
    public abstract class MapperBase<T>
    {
        protected abstract T Map(IDataRecord record);
        public Collection<T> MapAll(IDataReader reader)
        {
            Collection<T> collection = new Collection<T>();
            while (reader.Read())
            {
                try
                {
                    collection.Add(Map(reader));
                }
                catch
                {
                    throw;
                }
            }
            return collection;
        }
    }
}
