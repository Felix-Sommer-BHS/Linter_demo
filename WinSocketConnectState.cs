using System;
using System.Net;
using System.Net.Sockets;

namespace Testing
{
    internal partial class WinSocketDevice
    {
        private class WinSocketConnectState : IWinSocketState
        {
            protected WinSocketDevice _parent;

            internal WinSocketConnectState(WinSocketDevice parent)
            {
                this._parent = parent;
            }

            public void Action()
            {
                switch (_parent._config.ConnectionTyp)
                {
                    case ConnectionKind.Client:

                        string ipAddress = _parent._config.IpServer;
                        IPAddress address = IPAddress.Parse(ipAddress);
                        IPEndPoint remoteEP = new IPEndPoint(address, _parent._config.PortClient);
                        try
                        {
                            //frage ob server da ist
                            // Connect to Remote EndPoint
                            _parent._workSocket.Connect(remoteEP);

                            _parent.SetState(_parent._readState);

                            //_parent._workSocket = new TcpClient(_parent._config.ipClient, _parent._config.portClient);
                            //private NetworkStream stream;
                            //stream = client.GetStream();
                            //_parent.SetState(_parent._readState);
                        }
                        catch (TimeoutException et)
                        {
                            //MessageBox.Show("Time Out Exception : {0}", et.ToString());
                            _parent.SetState(_parent._connectState);
                        }
                        catch (ArgumentNullException ane)
                        {
                            //MessageBox.Show("ArgumentNullException : {0}", ane.ToString());
                        }
                        catch (SocketException se)
                        {
                            //MessageBox.Show("SocketException, connection Client failed: {0}", se.ToString());
                        }
                        catch (Exception ex)
                        {
                            _parent.SetState(_parent._initState);

                            //MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }

                        break;

                    case ConnectionKind.Server:
                        try
                        {
                            //aktuell nicht benutzt
                            _parent.SetState(_parent._readState);
                        }
                        catch (TimeoutException e)
                        {
                            //MessageBox.Show("TimeOut by Listening" + e.Message);
                            _parent.SetState(_parent._closeState);
                        }

                        break;
                }
            }
        }
    }
}