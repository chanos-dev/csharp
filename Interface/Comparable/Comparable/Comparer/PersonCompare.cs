using Comparable.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comparable.Comparer
{
    public class PersonCompare : IComparer<Person>
    {
        public int Compare(Person x, Person y) => x.CompareTo(y);
    }
}
