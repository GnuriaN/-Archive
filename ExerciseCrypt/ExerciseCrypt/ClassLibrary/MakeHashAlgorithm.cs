using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace ExerciseCrypt
{
   public class MakeHashAlgorithm
    {
        public static List<CypherInfo> GetCypherMethods()
        {
            var list = new List<CypherInfo>();
            list.Add(new CypherInfo
            {
                Description = "MD5 - 128 битный алгоритм дл€ получени€ HASH",
                Hash = MD5.Create()
            });
            list.Add(new CypherInfo
            {
                Description = "SHA256 - 256 битный алгоритм дл€ получени€ HASH",
                Hash = SHA256.Create()
            });
            list.Add(new CypherInfo
            {
                Description = "SHA384 - 384 битный алгоритм дл€ получени€ HASH",
                Hash = SHA384.Create()
            });
            list.Add(new CypherInfo
            {
                Description = "SHA512 - 512 битный алгоритм дл€ получени€ HASH",
                Hash = SHA512.Create()
            });

            return list;
        }
        public static string GetHash(HashAlgorithm currentHash, string source)
        { 
            // ѕолучение HASH MD5 в виде последовательности байт из исходной строки с указанием кодировки UTF8.
            byte[] data = currentHash.ComputeHash(Encoding.UTF8.GetBytes(source));
            // ѕереводим получившиес€ байты в строку и возвращаем
            return BitConverter.ToString(data).Replace("-","");
        }
       
    }
}