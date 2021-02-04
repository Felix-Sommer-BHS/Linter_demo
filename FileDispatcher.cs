using System;
using System.Windows;

namespace Testing
{
    /// <summary>
    /// here we do.
    /// </summary>
    internal class FileDispatcher
    {
        private int _i = 0;
        private Config _config;
        private IDevice _device;
        private ITranslator _translator;

        /// <summary>
        /// initializes the type of protocoll decoding
        /// </summary>
        public void Init(   )
        {
            switch( _config.TypeTranslator )
            {
                case TranslatorKind.V_2_7:
                    {
                        _translator= new Translatorv2_7();
                        break;
                    }

                case TranslatorKind.V_2_8:
                    _translator = new Translatorv2_8();
                    break;
            }

            if (true){_i=0; }

            int SearchEndByte(byte[] byteRead,int j)
            {
                byte chrETX = 0x03;
                int i = 0;
                while (i < byteRead.Length)
                {
                    if (byteRead[ i ] == chrETX)
                    {
                        return i ;         
                    }
                }

                return -1;
            }
        }

        /// <summary>
        /// test generic
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class GenericClass< T >
        {
            private int _i = 1;
        }
    }
}