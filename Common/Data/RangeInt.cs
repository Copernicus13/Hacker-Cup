//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a T4 template.
//
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace HackerCup.Common.Data
{
    public class RangeInt
    {
        private Tuple<int, int> _Range;

        public static RangeInt Void = new RangeInt(default(int), default(int));

        public int Minimum { get { return _Range.Item1; } }

        public int Maximum { get { return _Range.Item2; } }

        public int Count { get { return Maximum - Minimum + 1; } }

        public RangeInt(int min, int max)
        {
            _Range = new Tuple<int, int>(min, max);
        }

        public bool ContainsValue(int value)
        {
			return Comparer<int>.Default.Compare(Minimum, value) <= 0 &&
                Comparer<int>.Default.Compare(value, Maximum) <= 0;
        }

        public bool IsInsideRange(RangeInt range) =>
            range.ContainsValue(Minimum) && range.ContainsValue(Maximum);

        public bool ContainsRange(RangeInt range) =>
            ContainsValue(range.Minimum) && ContainsValue(range.Maximum);

        public bool IsOverlapping(RangeInt range) =>
            ContainsValue(range.Minimum) || ContainsValue(range.Maximum) ||
            range.ContainsValue(Minimum) || range.ContainsValue(Maximum);

		public RangeInt Union(RangeInt range)
        {
            if (!IsOverlapping(range))
                return Void;
            if (IsInsideRange(range))
                return range;
            if (ContainsRange(range))
                return this;
            return new RangeInt(
                Comparer<int>.Default.Compare(Minimum, range.Minimum) < 0 ?
                    Minimum : range.Minimum,
                Comparer<int>.Default.Compare(Maximum, range.Maximum) > 0 ?
                    Maximum : range.Maximum);
        }

        public RangeInt Intersect(RangeInt range)
        {
            if (!IsOverlapping(range))
                return Void;
            if (IsInsideRange(range))
                return this;
            if (ContainsRange(range))
                return range;
            return new RangeInt(
                Comparer<int>.Default.Compare(Minimum, range.Minimum) < 0 ?
                    range.Minimum : Minimum,
                Comparer<int>.Default.Compare(Maximum, range.Maximum) > 0 ?
                    range.Maximum : Maximum);
        }
    }
}
