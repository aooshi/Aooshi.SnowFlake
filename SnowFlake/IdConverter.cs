using System;

namespace Aooshi.SnowFlake
{
    public static class IdConverter
    {
        /// <summary>
        /// ie AAC3UcJAMAA -> 201561779220480
        /// </summary>
        public static ulong ToLong(string id)
        {
            var bytes = Convert.FromBase64String(id);
            Array.Reverse(bytes);
            return BitConverter.ToUInt64(bytes, 0);
        }

        /// <summary>
        /// ie 201561779220480 -> AAC3UcJAMAA
        /// </summary>
        public static string ToString(ulong id)
        {
            var bytes = BitConverter.GetBytes(id);
            Array.Reverse(bytes);
            return Convert.ToBase64String(bytes);
        }

        /// <summary>
        /// ie AACxF-bAEAA -> 194716213710848
        /// </summary>
        public static ulong ToUrlSafeLong(string id)
        {
            id = UrlSafeDecode(id);
            //
            var bytes = Convert.FromBase64String(id);
            Array.Reverse(bytes);
            return BitConverter.ToUInt64(bytes, 0);
        }

        /// <summary>
        /// ie 194716213710848 -> AACxF-bAEAA
        /// </summary>
        public static string ToUrlSafeString(ulong id)
        {
            var bytes = BitConverter.GetBytes(id);
            Array.Reverse(bytes);
            var base64 = Convert.ToBase64String(bytes);
            //
            base64 = UrlSafeEncode(base64);
            return base64;
        }

        /// <summary>
        /// 将Base64编码为可用的URL字符串
        /// </summary>
        /// <param name="base64"></param>
        public static string UrlSafeEncode(string base64)
        {
            if (string.IsNullOrEmpty(base64))
            {
                return base64;
            }

            // "+" 换成 "-"
            // "/" 换成 "_"
            // 去掉 "="

            base64 = base64.Replace('+', '-');
            base64 = base64.Replace('/', '_');
            base64 = base64.Replace("=", string.Empty);

            return base64;
        }

        /// <summary>
        /// 将安全Base64编码转换为源base64
        /// </summary>
        /// <param name="urlString"></param>
        public static string UrlSafeDecode(string urlString)
        {
            if (string.IsNullOrEmpty(urlString))
            {
                return urlString;
            }

            // "-" 换成 "+"
            // "_" 换成 "/"
            urlString = urlString.Replace('-', '+');
            urlString = urlString.Replace('_', '/');

            // 添加"="
            int mod = urlString.Length % 4;
            if (mod != 0)
            {
                urlString += new string('=', 4 - mod);
            }
            return urlString;
        }
    }
}

