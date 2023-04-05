namespace Sprint2
{
    class Utilities
    {

        // return x amount of dashes
        public static string Dashes(int length)
        {
            string dashes = "";
            for (int i = 0; i < length; i++)
            {
                dashes += "-";
            }

            return dashes;
        }
    }
}
