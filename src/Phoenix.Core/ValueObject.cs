using System;
using System.Collections.Generic;
using System.Linq;

namespace Phoenix.Core
{
    /// <summary>
    /// Base class for all value objects
    /// </summary>
    public abstract class ValueObject
    {
        /// <summary>
        /// Check if the two ValueObjects are equal
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>
        /// True, if the values of all properties are equal
        /// False if the values are not equal
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
            {
                return false;
            }

            ValueObject other = (ValueObject)obj;
            IEnumerator<object> thisValues = this.GetAtomicValues().GetEnumerator();
            IEnumerator<object> otherValues = other.GetAtomicValues().GetEnumerator();
            while (thisValues.MoveNext() && otherValues.MoveNext())
            {
                if (ReferenceEquals(thisValues.Current, null) ^
                    ReferenceEquals(otherValues.Current, null))
                {
                    return false;
                }

                if (thisValues.Current != null &&
                    !thisValues.Current.Equals(otherValues.Current))
                {
                    return false;
                }
            }
            return !thisValues.MoveNext() && !otherValues.MoveNext();
        }
        /// <summary>
        /// Protected static utility method used inside operator
        /// overloading methods
        /// </summary>
        /// <param name="left">ValueObject type</param>
        /// <param name="right">ValueObject type</param>
        /// <returns></returns>
        protected static bool EqualOperator(ValueObject left, ValueObject right)
        {
            if (ReferenceEquals(left, null) ^
                ReferenceEquals(right, null))
            {
                return false;
            }
            return ReferenceEquals(left, null) || left.Equals(right);
        }

        /// <summary>
        /// Operator overloading for 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator==(ValueObject left, ValueObject right)
        {
            return EqualOperator(left, right);
        }

        public static bool operator!=(ValueObject left, ValueObject right)
        {
            return !EqualOperator(left, right);
        }

        public override int GetHashCode()
        {
            return this.GetAtomicValues()
                .Select(x => x != null ? x.GetHashCode() : 0)
                .Aggregate((x, y) => x ^ y);
        }

        protected abstract IEnumerable<object> GetAtomicValues();
    }
}