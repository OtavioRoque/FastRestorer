namespace FastRestorer.Helpers
{
    public static class ParseHelper
    {
        private static bool IsNull(object o) => o == null || o == DBNull.Value;

        /// <summary>
        /// Converts an object to a long integer.
        /// </summary>
        /// 
        /// <param name="o">
        /// The object to convert. Can be null, DBNull, string, or numeric types.
        /// </param>
        /// 
        /// <returns>
        /// The converted long value.
        /// Returns 0 if the object is null, DBNull, or cannot be parsed as a long.
        /// </returns>
        public static long ToLong(object o)
        {
            if (IsNull(o))
                return 0;

            _ = long.TryParse(o.ToString(), out long result);
            return result;
        }

        /// <summary>
        /// Converts an object to a DateTime value.
        /// </summary>
        /// 
        /// <param name="o">
        /// The object to convert. Can be null, DBNull, string, or DateTime.
        /// </param>
        /// 
        /// <returns>
        /// The converted DateTime value.
        /// Returns DateTime.MinValue if the object is null, DBNull, or cannot be parsed as a DateTime.
        /// </returns>
        public static DateTime ToDateTime(object o)
        {
            if (IsNull(o))
                return DateTime.MinValue;

            _ = DateTime.TryParse(o.ToString(), out DateTime result);
            return result;
        }
    }
}
