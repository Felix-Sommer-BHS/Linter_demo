using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace testing
{
    //a
    //b
    partial class WinSocketDevice
    {
        class WinSocketInitState : IWinSocketState
        {
            protected WinSocketDevice _parent;
            internal WinSocketInitState(WinSocketDevice Parent)
            {
                _parent = Parent;
            }

            public void Action()
            {
                switch (_parent._config.connectionTyp)
                {
                    case ConnectionKind.Client:
                        try
                        {
                            _parent._workSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP)
                            {
                                ReceiveTimeout = 3000,
                                SendTimeout = 3000,
                            };
                            _parent.SetState(_parent._connectState);
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show("Init Client schlägt fehl" + e.Message);
                            _parent.SetState(_parent._initState);
                        }
                        break;

                    case ConnectionKind.Server:
                        try
                        {
                            _parent._workSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP)
                            {
                                SendTimeout = 1000,
                                ReceiveTimeout = 1000
                            };
                            //Socket konfigurieren

                            string ipAddress = _parent._config.ipServer;
                            IPAddress address = IPAddress.Parse(ipAddress);
                            IPEndPoint myEP = new IPEndPoint(address, _parent._config.portServer);

                            this._parent._workSocket.Bind(myEP);
                            // We will listen 1 requests at a time  
                            //geht iwie immer durch!!!!!!!!!!!
                            this._parent._workSocket.Listen(1);

                            this._parent._workSocket = this._parent._workSocket.Accept();
                            //MessageBox.Show("Connection accepted");

                            _parent.SetState(_parent._readState);
                        }
                        catch (TimeoutException e)
                        {
                            // MessageBox.Show("TimeOut by Listening Server" + e.Message);
                            _parent.SetState(_parent._closeState);
                        }
                        catch (Exception ex)
                        {
                            _parent.SetState(_parent._closeState);
                            //MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        break;

                }
            }
        }
    }
}
