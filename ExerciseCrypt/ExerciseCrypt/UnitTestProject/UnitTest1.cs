using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExerciseCrypt;
/*
0 - "MD5 - 128 битный алгоритм для получения HASH"
1 - "SHA256 - 256 битный алгоритм для получения HASH"
2 - "SHA384 - 384 битный алгоритм для получения HASH"
3 - "SHA512 - 512 битный алгоритм для получения HASH"
*/

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        // Исходный текст
        const string sources = "Hello word";

        [TestMethod]
        public void CheckEncryptionMethod_MD5()
        {
            // Полученный HASH по алгоритму MD5 от исходного текста
            var validMD5 = BitConverter.ToString(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(sources))).Replace("-", "");
                       
            // Получаем данные из методов класса MakeHashAlgorithm
            // Объект для хранения информация о метоте HASH
            var currentCypher = MakeHashAlgorithm.GetCypherMethods();
            // Выбираем индекс 0, что соответствует алгоритму MD5
            var MethodResult = MakeHashAlgorithm.GetHash(currentCypher[0].Hash, sources);
            
            // Методы сравнения
            // Сравниваем результат
            Assert.AreEqual(MethodResult, validMD5);
        }
        [TestMethod]
        public void CheckEncryptionMethod_SHA256()
        {
            // Полученный HASH по алгоритму SHA256 от исходного текста
            var validMD5 = BitConverter.ToString(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(sources))).Replace("-", "");

            // Получаем данные из методов класса MakeHashAlgorithm
            // Объект для хранения информация о метоте HASH
            var currentCypher = MakeHashAlgorithm.GetCypherMethods();
            // Выбираем индекс 0, что соответствует алгоритму SHA256
            var MethodResult = MakeHashAlgorithm.GetHash(currentCypher[1].Hash, sources);

            // Методы сравнения
            // Сравниваем результат
            Assert.AreEqual(MethodResult, validMD5);
        }
        [TestMethod]
        public void CheckEncryptionMethod_SHA384()
        {
            // Полученный HASH по алгоритму SHA384 от исходного текста
            var validMD5 = BitConverter.ToString(SHA384.Create().ComputeHash(Encoding.UTF8.GetBytes(sources))).Replace("-", "");

            // Получаем данные из методов класса MakeHashAlgorithm
            // Объект для хранения информация о метоте HASH
            var currentCypher = MakeHashAlgorithm.GetCypherMethods();
            // Выбираем индекс 0, что соответствует алгоритму SHA384
            var MethodResult = MakeHashAlgorithm.GetHash(currentCypher[2].Hash, sources);

            // Методы сравнения
            // Сравниваем результат
            Assert.AreEqual(MethodResult, validMD5);
        }
        [TestMethod]
        public void CheckEncryptionMethod_SHA512()
        {
            // Полученный HASH по алгоритму SHA512 от исходного текста
            var validMD5 = BitConverter.ToString(SHA512.Create().ComputeHash(Encoding.UTF8.GetBytes(sources))).Replace("-", "");

            // Получаем данные из методов класса MakeHashAlgorithm
            // Объект для хранения информация о метоте HASH
            var currentCypher = MakeHashAlgorithm.GetCypherMethods();
            // Выбираем индекс 0, что соответствует алгоритму SHA512
            var MethodResult = MakeHashAlgorithm.GetHash(currentCypher[3].Hash, sources);

            // Методы сравнения
            // Сравниваем результат
            Assert.AreEqual(MethodResult, validMD5);
        }
    }
}