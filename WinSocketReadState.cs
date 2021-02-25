using System;
using System.Text;
using System.Windows;

namespace Testing
{
    internal partial class WinSocketDevice
    {
        private class WinSocketReadState : IWinSocketState
        {
            protected WinSocketDevice _parent;

            internal WinSocketReadState(WinSocketDevice parent)
            {
                this._parent = parent;
            }

            public void Action()
            {
                string data = null;
                byte[] bytes = null;

                int bytesRec;
                int i = 0;
                try
                {
                    bytes = new byte[1024];

                    bytesRec = _parent._workSocket.Receive(bytes);

                    int posStart = SearchStartByte(bytes);
                    int posEnd = SearchEndByte(bytes);

                    data += Encoding.ASCII.GetString(bytes, posStart + 1, (posEnd - posStart + 1));

                    MessageBox.Show(data);

                    _parent.ProcessCompleted(this, data);
                    _parent.SetState(_parent._readState);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Read failed: " + e.ToString());
                    _parent.SetState(_parent._closeState);
                }

                //a
            }

            private int SearchEndByte(byte[] byteRead)
            {
                byte chrETX = 0x03;
                int i = 0;
                while (i < byteRead.Length)
                {
                    if (byteRead[i] == chrETX)
                    {
                        return i;
                    }
                    else
                    {
                        i = i + 1;
                    }
                }

                return -1;
            }

            private int SearchStartByte(byte[] byteRead)
            {
                byte chrSTX = 0x02;
                int i = 0;
                while (i < byteRead.Length)
                {
                    if (byteRead[i] == chrSTX)
                    {
                        return i;
                    }
                    else
                    {
                        i = i + 1;
                    }
                }

                return -1;
            }

            //private byte[] cutOutMsg(byte[] bOld, int indexStart, int indexEnd)
            //{
            //    //Message starts after Startbyte
            //    indexStart = indexStart + 1;
            //    //Message ends one byte before Endbyte
            //    indexEnd = indexEnd - 1;

            //    byte[] b1 = new byte [indexEnd-indexStart+1];

            //    for(int i=indexStart; i < indexEnd + 1; i = i + 1)
            //    {
            //        b1[i - indexStart] = bOld[i];

            //    }
            //    return b1;

            //}
        }
    }
}