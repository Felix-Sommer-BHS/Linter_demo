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
            _config = config;
            _thread = new Thread(new ThreadStart(DoWork));
            _thread.Priority = ThreadPriority.Lowest;
        }

        public event EventHandler<string> ProcessCompleted;

        public void DoWork()
        {
            do
            {
                _currentState.Action();
            }
            while (_threadWork);
        }

        public void Init()
        {
            _initState = new WinSocketInitState(this);
            _connectState = new WinSocketConnectState(this);
            _readState = new WinSocketReadState(this);
            _closeState = new WinSocketCloseState(this);

            SetState(_initState);
            Start();
        }

        public void Stop()
        {
            _threadWork = false;
        }

        internal void SetState(IWinSocketState state)
        {
            _currentState = state;
        }

        private void Start()
        {
            _threadWork = true;
            _thread.Start();
        }
    }
}