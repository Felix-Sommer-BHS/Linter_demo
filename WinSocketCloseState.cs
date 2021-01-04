using System;
using System.Net.Sockets;

namespace Testing
{
    internal partial class WinSocketDevice
    {
        private class WinSocketCloseState : IWinSocketState
        {
            private WinSocketDevice _parent;

            internal WinSocketCloseState(WinSocketDevice parent)
            {
                this._parent = parent;
            }

            public void Action()
            {
                switch (_parent._config.ConnectionTyp)
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