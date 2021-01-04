using System;
using System.Net.Sockets;
using System.Threading;

namespace Testing
{
    internal partial class WinSocketDevice : IDevice
    {
        /// <summary>
        /// ndclnsdlcnl.
        /// </summary>
        protected Socket _workSocket;

        private readonly Thread _thread;
        private IWinSocketState _closeState;
        private Config _config;
        private IWinSocketState _connectState;
        private IWinSocketState _currentState;
        private IWinSocketState _initState;
        private IWinSocketState _readState;
        private bool _threadWork;

        public WinSocketDevice(Config config)
        {
            this._config = config;
            this._thread = new Thread(new ThreadStart(this.DoWork));
            this._thread.Priority = ThreadPriority.Lowest;
        }

        public event EventHandler<string> ProcessCompleted;

        public void DoWork()
        {
            do
            {
                this._currentState.Action();
            }
            while (this._threadWork);
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

        public void Stop()
        {
            this._threadWork = false;
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