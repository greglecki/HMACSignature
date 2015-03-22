using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
using Windows.Storage.Streams;

namespace HMACSignature.WPClient.BL.Cryptographic
{
    public static class CryptographicHelpers
    {
        public static string HmacSha256(string secretKey, string value)
        {
            // Move strings to buffers.
            var key = CryptographicBuffer.ConvertStringToBinary(secretKey, BinaryStringEncoding.Utf8);
            var msg = CryptographicBuffer.ConvertStringToBinary(value, BinaryStringEncoding.Utf8);

            // Create HMAC.
            var objMacProv = MacAlgorithmProvider.OpenAlgorithm(MacAlgorithmNames.HmacSha256);
            var hash = objMacProv.CreateHash(key);
            hash.Append(msg);

            return CryptographicBuffer.EncodeToBase64String(hash.GetValueAndReset());
        }

        public static string MD5Hash(string message)
        {
            IBuffer buffer = CryptographicBuffer.ConvertStringToBinary(message, BinaryStringEncoding.Utf8);
            HashAlgorithmProvider hashAlgorithm = HashAlgorithmProvider.OpenAlgorithm(HashAlgorithmNames.Md5);
            IBuffer hashBuffer = hashAlgorithm.HashData(buffer);

            var strHashBase64 = CryptographicBuffer.EncodeToBase64String(hashBuffer);
            return strHashBase64;
        }
    }
}
