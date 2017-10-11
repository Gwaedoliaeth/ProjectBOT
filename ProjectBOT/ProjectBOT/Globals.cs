using System;
using System.Collections.Generic;
using ProjectBOT.Common;
using ProjectBOT.Test;

namespace ProjectBOT
{
    public class Globals
    {
        /// <summary>
        /// Configuration data for the BOT.
        /// </summary>
        public static Configuration Configuration;

        public static Random Random;

        internal static void PrepareBot()
        {
            Random = new Random();


        }
    }
}
