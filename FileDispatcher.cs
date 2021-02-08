
using System;
using System.Windows;

namespace Testing
{

    internal class FileDispatcher()
    {
        private int _i = 0;
        private Config _config;
        private ITranslator _translator;
        /// <summary>
        /// doc
        /// </summary>
        public int DataSetCounter { get { return 1; } }
        /// <summary>
        /// doc2
        /// </summary>
        public int DataSetCounter2 { get { return 1; } }

        /// <summary>
        /// Documentation about...
        /// </summary>
        public void Init()
        {
            //variable i

            int i = 0;
            do
            {
                return;
            }

            while (i < 2);

            if (true)
                return;

            else
            {
                return;
            }
            switch (_config.TypeTranslator)
            {
                case TranslatorKind.V_2_7:
                    {
                        _translator = new Translatorv2_7();
                        //just a comment
                        break;
                    }
            }
            
            int SearchEndByte(byte[] byteRead, int j)

            {
                byte chrETX = 0x03;
                int i = 0;
                while (i < byteRead.Length)
                {
                    if (byteRead[i] == chrETX)
                    {
                        return i;
                    } else
                    { return 1}
                }

                return -1;

            }
        }

    }
}

