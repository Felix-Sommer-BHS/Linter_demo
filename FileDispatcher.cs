using System;
using System.Windows;

namespace Testing
{
    /// <summary>
    /// here we do.
    /// </summary>
    internal class fileDispatcher
    {
        public int data;

        private static readonly string[] house_icons = new[]
        {
            "Time",
        };

        private static int MARGIN = 7;
        private int i = 0;
        private Config _config;
        private IDevice _device;
        private ITranslator _translator;

        /// <summary>
        /// initializes the type of protocoll decoding
        /// </summary>
        public void Init()
        {
            var T = new fileDispatcher();

            int SearchEndByte(byte[] ByteRead, int J)
            {
                byte chrETX = 0x03;
                int i = 0;

                return -1;
            }
        }
    }
}