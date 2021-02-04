using System;
using System.Windows;

namespace Testing
{
    /// <summary>
    /// test
    /// </summary>
    public enum TestEnum
    {
        ABC, DEF,
    }

    /// <summary>
    /// here we do.
    /// </summary>
    internal class FileDispatcher
    {
        private Config _config;
        private IDevice _device;
        //
        private String _leftButtonLocalizableText = "";

        private int
                _i,
            _j;

        

        public FileDispatcher(Config config)
        {
            _config = config; ;
        }

        /// <summary>
        /// ffrfe
        /// </summary>
        public void Init(
            )
        {
            _translator.TranslateInformation(object a,
                "  ");

            switch (_config.TypeTranslator) //comment
            {
                case TranslatorKind.V_2_8:
                    _translator = new Translatorv2_8();
                    break;
            }
        }

        public void StartTranslator

            (

            object sender

            , string dataWpa
            )
        {
            if (null != DecodeCompleted)
            {
                return;
            }
        }
    }
}