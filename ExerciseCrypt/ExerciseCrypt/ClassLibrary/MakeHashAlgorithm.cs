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
                Description = "MD5 - 128 ������ �������� ��� ��������� HASH",
                Hash = MD5.Create()
            });
            list.Add(new CypherInfo
            {
                Description = "SHA256 - 256 ������ �������� ��� ��������� HASH",
                Hash = SHA256.Create()
            });
            list.Add(new CypherInfo
            {
                Description = "SHA384 - 384 ������ �������� ��� ��������� HASH",
                Hash = SHA384.Create()
            });
            list.Add(new CypherInfo
            {
                Description = "SHA512 - 512 ������ �������� ��� ��������� HASH",
                Hash = SHA512.Create()
            });

            return list;
        }
        public static string GetHash(HashAlgorithm currentHash, string source)
        { 
            // ��������� HASH MD5 � ���� ������������������ ���� �� �������� ������ � ��������� ��������� UTF8.
            byte[] data = currentHash.ComputeHash(Encoding.UTF8.GetBytes(source));
            // ��������� ������������ ����� � ������ � ����������
            return BitConverter.ToString(data).Replace("-","");
        }
       
    }
}