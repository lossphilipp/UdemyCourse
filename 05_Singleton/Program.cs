using System;

namespace Coding.Exercise
{
    public class SingletonTester
    {
        private static int instanceId = 0;

        public static bool IsSingleton(Func<object> func)
        {
            if (instanceId != func.GetHashCode())
            {
                instanceId = func.GetHashCode();
                return true;
            }

            return false;
        }
    }
}
