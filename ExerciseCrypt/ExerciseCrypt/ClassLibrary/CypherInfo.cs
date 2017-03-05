using System.Security.Cryptography;

namespace ExerciseCrypt
{
    public class CypherInfo
    {
        // какой алгоритм использовался. public - это поле должно быть доступно для изменения
        public HashAlgorithm Hash;
        // описание этого алгоритма. public - это поле должно быть доступно для изменения
        public string Description;
    }
}