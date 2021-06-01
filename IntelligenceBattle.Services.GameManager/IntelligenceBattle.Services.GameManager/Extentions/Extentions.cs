using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelligenceBattle.Services.GameManager.Extentions
{
    public static class Extentions
    {
        public static IEnumerable<BatchPageDataModel<List<T>>> SplitList<T>(this List<T> locations, int nSize = 30)
        {
            for (int i = 0; i < locations.Count; i += nSize)
            {
                yield return new BatchPageDataModel<List<T>>
                {
                    Data = locations.GetRange(i, Math.Min(nSize, locations.Count - i)),
                    PageNumber = i / nSize,
                };
            }
        }

        public class BatchPageDataModel<T>
        {
            public T Data { get; set; }
            public int PageNumber { get; set; }
        }
    }
}
