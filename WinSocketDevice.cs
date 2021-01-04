using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using testMfile_move;

namespace testing
{
    partial class WinSocketDevice : IDevice
    {
        private readonly Thread _thread;

        /// <summary>
        /// ndclnsdlcnl.
        /// </summary>
        protected Socket _workSocket;
        private Config _config;
        private bool _threadWork;

        IWinSocketState _initState;
        IWinSocketState _connectState;
        IWinSocketState _readState;
        IWinSocketState _closeState;
        IWinSocketState _currentState;

        public WinSocketDevice(Config Config)
        {
            this._config = Config;
            this._thread = new Thread(new ThreadStart(this.DoWork));
            this._thread.Priority = ThreadPriority.Lowest;
        }

        public event EventHandler<string> ProcessCompleted;


        public void Stop()
        {
            this._threadWork = false;
        }



        public void Init()
        {
            this._initState = new WinSocketInitState(this);
            this._connectState = new WinSocketConnectState(this);
            this._readState = new WinSocketReadState(this);
            this._closeState = new WinSocketCloseState(this);

            SetState(_initState);
            Start();
        }

        public void DoWork()
        {
            do
            {
                this._currentState.Action();
            }
            while (this._threadWork);
        }

        internal void SetState(IWinSocketState state)
        {
            this._currentState = state;
        }

        private void Start()
        {
            this._threadWork = true;
            this._thread.Start();
        }
    }
}