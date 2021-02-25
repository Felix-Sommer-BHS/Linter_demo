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
    partial class WinSocketDevice
    {
        class WinSocketConnectState : IWinSocketState
        {
            protected WinSocketDevice _parent;

            internal WinSocketConnectState(WinSocketDevice Parent)
            {
                this._parent = Parent;
            }


            public void Action()
            {
                switch (_parent._config.connectionTyp)
                {
                    case ConnectionKind.Client:

                        string ipAddress = _parent._config.ipServer;
                        IPAddress address = IPAddress.Parse(ipAddress);
                        IPEndPoint remoteEP = new IPEndPoint(address, _parent._config.portClient);
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