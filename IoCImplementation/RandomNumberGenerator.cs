using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoCImplementation
{
    internal class RandomNumberGenerator
    {
        public int RandNum { get; set; } = new Random().Next(0, 1000);
    }
}
