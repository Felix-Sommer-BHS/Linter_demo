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
        class WinSocketCloseState : IWinSocketState
        {
            private WinSocketDevice _parent;

            internal WinSocketCloseState(WinSocketDevice parent)
            {
                this._parent = parent;
            }

            public void Action()
            {
                switch (_parent._config.connectionTyp)
                {
                    case ConnectionKind.Client:
                        try
                        {
                            // Release the socket.    
                            _parent._workSocket.Shutdown(SocketShutdown.Both);
                            _parent._workSocket.Close();
                            _parent.SetState(_parent._initState);
                        }
                        catch (Exception e)
                        {
                            //Console.WriteLine(e.ToString());
                            _parent._workSocket.Close();
                            _parent.SetState(_parent._initState);
                        }
                        break;

                    case ConnectionKind.Server:
                        try
                        {
                            // Release the socket.    
                            _parent._workSocket.Shutdown(SocketShutdown.Both);
                            _parent._workSocket.Close();
                            _parent.SetState(_parent._initState);
                        }
                        catch (Exception e)
                        {
                            //MessageBox.Show(e.ToString());
                            _parent.SetState(_parent._initState);
                        }

                        break;
                }
            }
        }
    }
}