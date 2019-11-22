using System;

namespace Aooshi.SnowFlake
{
    public class GeneratorOne
    {
        public readonly static Generator generator = new Generator(1, new DateTime(2019, 1, 1, 1, 1, 1, DateTimeKind.Utc));
    }
}
