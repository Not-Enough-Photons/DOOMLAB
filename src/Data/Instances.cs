using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Threading.Tasks;

namespace NEP.DOOMLAB.Data
{
    public class Instances<T>
    {
        public List<T> Cache { get; private set; } = new List<T>();
        public Dictionary<int, T> CacheLookup { get; private set; } = new Dictionary<int, T>();

        public void AddInstance(int id, T instance)
        {
            Cache.Add(instance);
            if(!CacheLookup.ContainsKey(id))
            {
                CacheLookup.Add(id, instance);
            }
        }

        public void RemoveInstance(int id)
        {
            var value = CacheLookup[id];
            Cache.Remove(value);
            CacheLookup.Remove(id);
        }
    }
}