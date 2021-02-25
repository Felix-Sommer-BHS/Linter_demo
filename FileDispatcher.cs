using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace testing
{
    /// <summary>
    /// here we do.
    /// </summary>
    class FileDispatcher
    {
        private Config _config;
        private IDevice _device;
        private ITranslator _translator;

        public FileDispatcher(Config config)
        {
            _config = config;
        }

        public event EventHandler<ConveyData> DecodeCompleted;

        public void Init()
        {
            switch (_config.typeTranslator)
            {
                case TranslatorKind.V_2_7:
                    {
                        _translator = new Translatorv2_7();
                        break;
                    }

                case TranslatorKind.V_2_8:
                    _translator = new Translatorv2_8();
                    break;
            }

            switch (_config.TypeInterface)
            {
                case DeviceKind.FileTransfer:
                    _device = new FileDevice(_config);
                    _device.ProcessCompleted += StartTranslator;
                    _device.Init();
                    break;

                case DeviceKind.WinSocket:
                    _device = new WinSocketDevice(_config);
                    _device.ProcessCompleted += StartTranslator;
                    _device.Init();

                    break;

                default:
                    MessageBox.Show("File Device does not exist");
                    break;
            }

        }


        public void StartTranslator(object sender, string dataWpa)
        {
            if (DecodeCompleted != null)
            {
                // File Transfer daten fehlen noch!!!!!!!!
                ConveyData c1 = _translator.TranslateInformation(dataWpa);
                c1.deviceKind = _config.TypeInterface;
                c1.translatorTyp = _config.typeTranslator;
                c1.connectionTyp = _config.connectionTyp;
                switch (_config.TypeInterface)
                {
                    case DeviceKind.FileTransfer:
                        c1.filePath = _config.pathFileTransfer;
                        c1.port = 0;
                        c1.ip = "nur für WinSocket";

                        break;

                    case DeviceKind.WinSocket:
                        c1.filePath = "Nur für FileTransfer";
                        switch (_config.connectionTyp)
                        {
                            case ConnectionKind.Server:
                                c1.port = _config.portServer;
                                c1.ip = _config.ipServer;
                                break;

                            case ConnectionKind.Client:
                                c1.port = _config.portClient;
                                c1.ip = _config.ipClient;
                                break;
                        }

                        break;
                }

                switch (this._config.connectionTyp)
                {
                    case ConnectionKind.Server:
                        c1.port = _config.portServer;
                        c1.ip = _config.ipServer;
                        break;

                    case ConnectionKind.Client:
                        c1.port = _config.portClient;
                        c1.ip = _config.ipClient;
                        break;
                }

                DecodeCompleted(this, c1);
            }
        }
    }
}