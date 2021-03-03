using System;
using System.Windows;

namespace Testing
{
    /// <summary>
    /// here we do.
    /// </summary>
    internal class FileDispatcher
    {
        #region My class
        private Config _config;
        private IDevice _device;
        private ITranslator _translator;
        #endregion

        public FileDispatcher(Config config)
        {
            #region ddd
            _config = config;
            #endregion
        }

        public event EventHandler<ConveyData> DecodeCompleted;

        public void Init()
        {
            switch (_config.TypeTranslator)
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
                c1.DeviceKind = _config.TypeInterface;
                c1.TranslatorTyp = _config.TypeTranslator;
                c1.ConnectionTyp = _config.ConnectionTyp;
                switch (_config.TypeInterface)
                {
                    case DeviceKind.FileTransfer:
                        c1.FilePath = _config.PathFileTransfer;
                        c1.Port = 0;
                        c1.Ip = "nur für WinSocket";

                        break;

                    case DeviceKind.WinSocket:
                        c1.FilePath = "Nur für FileTransfer";
                        switch (_config.ConnectionTyp)
                        {
                            case ConnectionKind.Server:
                                c1.Port = _config.PortServer;
                                c1.Ip = _config.IpServer;
                                break;

                            case ConnectionKind.Client:
                                c1.Port = _config.PortClient;
                                c1.Ip = _config.IpClient;
                                break;
                        }

                        break;
                }

                switch (this._config.ConnectionTyp)
                {
                    case ConnectionKind.Server:
                        c1.Port = _config.PortServer;
                        c1.Ip = _config.IpServer;
                        break;

                    case ConnectionKind.Client:
                        c1.Port = _config.PortClient;
                        c1.Ip = _config.IpClient;
                        break;
                }

                DecodeCompleted(this, c1);
            }
        }
    }
}