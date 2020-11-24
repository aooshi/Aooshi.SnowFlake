using System;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace Aooshi.SnowFlake
{
    /// <summary>
    /// SnowFlakeId
    /// </summary>
    public class SnowFlakeId
    {
        /// <summary>
        /// get this class singleton
        /// </summary>
        public readonly static SnowFlakeId Instance = new SnowFlakeId();

        private readonly Generator generator = null;

        /// <summary>
        /// initialize new instance, for 0 and 2020/1/1 1:1:1 utc
        /// </summary>
        public SnowFlakeId()
        {
            short generatorId = 0;
            DateTime time = new DateTime(2020, 1, 1, 1, 1, 1, DateTimeKind.Utc);

            //
            this.generator = new Generator(generatorId, time);
        }

        /// <summary>
        /// initialize new instance
        /// </summary>
        /// <param name="generatorId"></param>
        /// <param name="time"></param>
        public SnowFlakeId(short generatorId, DateTime time)
        {
            this.generator = new Generator(generatorId, time);
        }


        /// <summary>
        /// Can generate up to 4096 different IDs per millisecond.
        /// </summary>
        public string Next()
        {
            lock (this.generator)
            {
                return this.generator.Next();
            }
        }

        /// <summary>
        /// get a id
        /// </summary>
        /// <returns></returns>
        public ulong NextId()
        {
            lock (this.generator)
            {
                return this.generator.NextLong();
            }
        }

        /// <summary>
        /// get a id for data
        /// </summary>
        /// <returns></returns>
        public byte[] NextData()
        {
            lock (this.generator)
            {
                return this.generator.NextData();
            }
        }

        /// <summary>
        /// get a id for hex
        /// </summary>
        /// <returns></returns>
        public string NextHex()
        {
            lock (this.generator)
            {
                return this.generator.NextHex();
            }
        }

        /// <summary>
        /// get a id for hex upper
        /// </summary>
        /// <returns></returns>
        public string NextHexUpper()
        {
            lock (this.generator)
            {
                return this.generator.NextHexUpper();
            }
        }
    }
}
