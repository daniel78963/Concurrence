using System.Security.Cryptography;

namespace Concurrence.WebAPI.Helpers
{
    public class RandomGen
    {
        private static RNGCryptoServiceProvider _global = new RNGCryptoServiceProvider();

        //ThreadStatic me permite tener una copia particular por hilo de una variable
        [ThreadStatic]
        private static Random _randomLocal;

        public static double NextDouble()
        {
            Random inst = _randomLocal;
            if (inst == null)
            {
                byte[] buffer = new byte[4];
                _global.GetBytes(buffer);
                _randomLocal = inst = new Random(BitConverter.ToInt32(buffer, 0));
            }
            return inst.NextDouble();
        }
    }
}
