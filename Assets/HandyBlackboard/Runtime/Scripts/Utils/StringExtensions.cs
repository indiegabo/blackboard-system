namespace IndieGabo.HandyBlackboard
{
    public static class StringExtensions
    {
        /// <summary>
        /// Computes the FNV-1a hash value for the input string.
        /// </summary>
        /// <param name="str">The input string to compute the hash for.</param>
        /// <returns>The computed FNV-1a hash value as an integer.</returns>
        public static int ComputeFNV1aHash(this string str)
        {
            // FNV-1a hash initialization
            uint hash = 2166136261;

            // Iterate over each character in the input string to calculate the hash
            for (int i = 0; i < str.Length; i++)
            {
                // Update the hash using the FNV-1a algorithm
                hash = (hash ^ str[i]) * 16777619;
            }

            // Return the computed hash value as an integer
            return unchecked((int)hash);
        }
    }
}