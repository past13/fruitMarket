using System;

namespace testApp.Service.Utility
{
    public static class ModifySequece
    {
        public static string ReverseName(string name)
        {
            char[] array = name.ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }
    }
}
