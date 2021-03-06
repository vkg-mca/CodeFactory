using Microsoft.SqlServer.Server;
//------------------------------------------------------------------------------
// <copyright file="CSSqlClassFile.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Security.Cryptography;
using System.Text;

namespace CodeFactoryDb
{
    public class Cryptography
    {
        [SqlFunction]
        public static SqlBytes Encrypt(SqlString password)
        {
            // Create a strong vector 
            byte[] vector = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            RandomNumberGenerator.Create().GetNonZeroBytes(vector);

            // Get the password bytes  
            byte[] pwdBytes = password.GetNonUnicodeBytes();

            // Add the vector bytes to the password bytes and hash them both at the same time 
            SHA256Managed sha256 = new System.Security.Cryptography.SHA256Managed();
            byte[] outputBytes = sha256.ComputeHash(AddBytes(pwdBytes, vector));

            // Return the resulting hash, and append the vector again to it so it can extracted later 
            return new SqlBytes(AddBytes(outputBytes, vector));
        }
        [SqlFunction]
        public static SqlBoolean Verify(SqlString password, SqlBytes hash)
        {
            byte[] vector = new byte[16];
            byte[] pwdAndHash = new byte[32];

            // Split the hash and vector into separate variables 
            Array.Copy(hash.Value, 32, vector, 0, 16);
            Array.Copy(hash.Value, 0, pwdAndHash, 0, 32);

            // Get the password bytes that will be tested against the hash 
            byte[] pwdBytes = password.GetNonUnicodeBytes();

            // Compute a hash using the password provided, and the vector extracted from the hash 
            SHA256Managed sha256 = new System.Security.Cryptography.SHA256Managed();
            byte[] testHash = sha256.ComputeHash(AddBytes(pwdBytes, vector));

            // Compare hash values to determine if the password provided matches 
            return new SqlBoolean(BitConverter.ToString(pwdAndHash) == BitConverter.ToString(testHash));
        }

        private static byte[] AddBytes(byte[] array1, byte[] array2)
        {
            // Add two byte arrays 
            byte[] array3 = new byte[array1.Length + array2.Length];
            Array.Copy(array1, array3, array1.Length);
            Array.Copy(array2, 0, array3, array1.Length, array2.Length);
            return array3;
        } 


    }
}
