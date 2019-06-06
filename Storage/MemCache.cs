using System;
using System.Collections.Generic;
using System.Linq;
using Lr1WebApi.Models;
using Lr1WebApi.Storage;

namespace Lr1WebApi.Storage
{
    public class MemCache : IStorage<PersonModel>
    {
        private object _sync = new object();
        private List<PersonModel> _memCache = new List<PersonModel>();
        public PersonModel this[Guid id] 
        { 
            get
            {
                lock (_sync)
                {
                    if (!Has(id)) throw new IncorrectPersonModelException($"No PersonModel with id {id}");

                    return _memCache.Single(x => x.Id == id);
                }
            }
            set
            {
                if (id == Guid.Empty) throw new IncorrectPersonModelException("Cannot request PersonModel with an empty id");

                lock (_sync)
                {
                    if (Has(id))
                    {
                        RemoveAt(id);
                    }

                    value.Id = id;
                    _memCache.Add(value);
                }
            }
        }

        public System.Collections.Generic.List<PersonModel> All => _memCache.Select(x => x).ToList();

        public void Add(PersonModel value)
        {
            if (value.Id != Guid.Empty) throw new IncorrectPersonModelException($"Cannot add value with predefined id {value.Id}");

            value.Id = Guid.NewGuid();
            this[value.Id] = value;
        }

        public bool Has(Guid id)
        {
            return _memCache.Any(x => x.Id == id);
        }

        public void RemoveAt(Guid id)
        {
            lock (_sync)
            {
                _memCache.RemoveAll(x => x.Id == id);
            }
        }
    }
}