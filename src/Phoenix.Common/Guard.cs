using System;

namespace Phoenix.Common
{
    public static class Guard
    {
        public static void NotNull(object anObject)
        {
            if (anObject == null)
            {
                throw new ArgumentNullException(nameof(anObject));
            }
        }

        public static void NotNullOrEmpty(string aString)
        {
            if (string.IsNullOrEmpty(aString))
            {
                throw new ArgumentNullException(nameof(aString));
            }
        }
    }
}