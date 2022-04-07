using System.Collections;
using System.Linq;
using System.Collections.Generic;

namespace Setsuna
{
    public class Enumerators : IEnumerator
    {
        public bool MoveNext()
        {
            var moveNext = false;
            foreach (var value in Values.ToArray())
            {
                if (value.MoveNext())
                {
                    moveNext = true;
                }
                else
                {
                    Values.Remove(value);
                }
            }

            return moveNext;
        }

        public void Reset()
        {
            foreach (var value in Values)
            {
                value.Reset();
            }
        }

        public object Current => null;

        private List<IEnumerator> Values { get; }

        public Enumerators(params IEnumerator[] values)
        {
            Values = values.ToList();
        }
    }
}