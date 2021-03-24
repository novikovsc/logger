using System;
using System.IO;

namespace logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger logger = new Logger();
            logger.Debug("место для вашей рекламы");
            logger.Error("line1");
            logger.ErrorUnique("line2", new Exception("line2"));
            logger.ErrorUnique("line1", new Exception("line1"));
        }
    }
}