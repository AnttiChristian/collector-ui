using System.Collections;
using System.Collections.Generic;

namespace Collector.Data
{
    public class Collection<TEntity> : IEnumerable<TEntity>
    {
        private readonly List<TEntity> _items;

        public Collection(List<TEntity>? items = null)
        {
            _items = items ?? new List<TEntity>();
        }

        public List<TEntity> Items
        {
            get => _items;
        }

        public IEnumerator<TEntity> GetEnumerator()
        {
            return (_items as IEnumerable<TEntity>).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() => _items.GetEnumerator();

        public void Add(TEntity item) => _items.Add(item);

        public void Remove(TEntity item) => _items.Remove(item);
    }
}
