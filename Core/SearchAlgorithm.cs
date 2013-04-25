using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core
{
    public static class SearchAlgorithm
    {
        public static bool HasIsolate(Func<int, bool> notEmpty, int checkPoint)
        {
            return ReportIsolate(notEmpty, checkPoint).Any();
        }

        public static IEnumerable<int> ReportIsolate(Func<int, bool> notEmpty, int checkPoint)
        {
            var isolateWorkMask = new[] { false, false, true, false, false };

            var cells = new bool[isolateWorkMask.Length];

            var lastElementIndex = isolateWorkMask.Length - 1;

            var stop = checkPoint + lastElementIndex;

            while (checkPoint != stop)
            {
                var start = checkPoint - lastElementIndex;
                var end = checkPoint;

                var negCorrection = -start;
                for (int i = start; i < end; i++)
                    cells[i + negCorrection] = notEmpty(i);

                if (!cells.Where((t, i) => t != isolateWorkMask[i]).Any())
                    yield return start + 2;//results.Add(start+2); //2 is center position
               
                checkPoint++;
            }
        }
    }
}
