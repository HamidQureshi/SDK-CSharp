/*
 * MIT License (MIT)
 * Copyright (c) 2018
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.OpenSsl;
using System;
using System.IO;
using System.Text;

namespace ActiveLedgerLib
{
    public static class Helper
    {
        #region writing keys in file
        //writing Private key in the file in PEM format
        public static void WritekeyPairInFile(string filePath, AsymmetricCipherKeyPair keypair)
        {
            //creating file
            TextWriter textWriterPrivate = File.CreateText(filePath);
            //passing the file to PEM writer
            PemWriter pemWriterPrivate = new PemWriter(textWriterPrivate);
            //writing private/public key
            pemWriterPrivate.WriteObject(keypair.Private);
            pemWriterPrivate.WriteObject(keypair.Public);
            pemWriterPrivate.Writer.Flush();
            //closing text writer
            textWriterPrivate.Dispose();
        }
        //writing Public key in the file in PEM format
        public static void WritePublicKeyInFile(string filePath, AsymmetricCipherKeyPair keypair)
        {
            TextWriter textWriterPrivate = File.CreateText(filePath);
            PemWriter pemWriterPrivate = new PemWriter(textWriterPrivate);
            //wrting public key
            pemWriterPrivate.WriteObject(keypair.Public);
            pemWriterPrivate.Writer.Flush();
            //closing text writer
            textWriterPrivate.Dispose();
        }


        #endregion writing keys in file
        //read Keys from pem
       public static AsymmetricCipherKeyPair ReadAsymmetricKeyParameter(string keypairPathPEMFile)
        {
            var fileStream = System.IO.File.OpenText(keypairPathPEMFile);
            var pemReader = new Org.BouncyCastle.OpenSsl.PemReader(fileStream);
            var KeyParameter = (AsymmetricCipherKeyPair)pemReader.ReadObject();
            return KeyParameter;
        }

        //json to string Converter
        public static string ConvertJsonToString(JObject json)
        {
            string jsonStr = JsonConvert.SerializeObject(json);
            return jsonStr;

        }
        //Covert String to byte Array
        public static byte[] ConvertStringToByteArray(string str)
        {
            // Create a UnicodeEncoder to convert between byte array and string.
            ASCIIEncoding ByteConverter = new ASCIIEncoding();
            byte[] byteArray = ByteConverter.GetBytes(str);
            return byteArray;

        }
        //convert  byte Array to base 64 string
        public static string ConvertByteArrayToBase64String(byte[] byteArray)
        {
            string str = Convert.ToBase64String(byteArray);
            return str;

        }



    }
}
