using System;

namespace RS_test_paper.Models
{
    public class Test
    {
        public int Major { get; set; }
        public int Minor { get; set; }

        public Test(int major, int minor)
        {
            // Minor should not be 0
            if (minor == 0)
            {
                throw new ArgumentException("Minor should not be 0");
            }

            Major = major;
            Minor = minor;
        }
    }
}
