using System;
using System.Collections.ObjectModel;
using System.ServiceModel.Syndication;

namespace Podify.Extensions
{
    public static class SyndicationExtensions
    {
        public static void AddSorted(this ObservableCollection<SyndicationItem> list, SyndicationItem item)
        {
            int i = 0;
            while (i < list.Count && list[i].Compare(item) > 0)
                i++;

            list.Insert(i, item);
        }

        public static int Compare(this SyndicationItem itemA, SyndicationItem itemB)
        {
            if (itemA.PublishDate > itemB.PublishDate)
                return 1;
            else if (itemA.PublishDate < itemB.PublishDate)
                return -1;
            else
                return 0;
        }
    }
}
