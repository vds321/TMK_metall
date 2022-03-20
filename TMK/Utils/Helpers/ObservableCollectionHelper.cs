using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TMK.Utils.Helpers
{
    public static class ObservableCollectionHelper
    {
        public static ObservableCollection<T> AddRange<T>(this ObservableCollection<T> collection, IEnumerable<T> range) where T : class
        {
            foreach (var item in range)
            {
                collection.Add(item);
            }

            return collection;
        }

    }
}
