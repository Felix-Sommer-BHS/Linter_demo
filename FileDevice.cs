using System;
using System.IO;
using System.Threading;
using System.Windows;

namespace Testing
{
    internal class FileDevice : IDevice
    {
        private readonly Thread _mainThread;
        private bool _threadWork;
        private Config _config;
        private State _state = new State();
        private string _dataWpa = string.Empty;
        private string _temppath; // = _config.tempPathFileTransfer;
        private string _temp;

        public FileDevice(Config config)
        {
            _config = config;
            _mainThread = new Thread(new ThreadStart(this.DoWork));
            _mainThread.Priority = ThreadPriority.Lowest;
            _temppath = _config.TempPathFileTransfer;
            _temp = _config.TempFileTransfer;
        }

        public event EventHandler<string> ProcessCompleted;

        public enum State
        {
            DetectFile,
            ExistTemp,

            //jdkef
            MoveToTemp,

            ReadFile,
            Delete,
        }

        public void Init()
        {
            _threadWork = true;
            _mainThread.Start();
        }

        public void Stop()
        {
            _threadWork = false;
        }

        public void DoWork()
        {
            if (ProcessCompleted != null)
            {
                _state = State.DetectFile;

                do
                {
                    FileTransfer(_state);
                }
                while (this._threadWork);
            }
        }

        public void FileTransfer(State state)
        {
            string filepath = _config.PathFileTransfer;
            int waitingTime = Convert.ToInt32(_config.WaitingTimeFileTransfer);
            string tempNew;

            switch (state)
            {
                case State.DetectFile:

                    if (File.Exists(filepath))
                    {
                        this._state = State.ExistTemp;
                        Console.WriteLine("File existiert in :" + filepath);

                        break;
                    }
                    else
                    {
                        this._state = State.DetectFile;
                        Console.WriteLine("File existiert nicht");
                        Thread.Sleep(waitingTime);

                        break;
                    }

                case State.ExistTemp:

                    if (Directory.Exists(_temp))
                    {
                        Console.WriteLine("TempVerzeichnis existiert bereits:" + _temp);
                        if (File.Exists(_temppath))
                        {
                            Console.WriteLine("Vorher schon datei in Temp Verzeichnis");
                            File.Delete(_temppath);
                        }

                        this._state = State.MoveToTemp;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("TempVerzeichnis existiert nicht");

                        tempNew = Path.GetTempPath();

                        _temppath = tempNew + "temp.txt";
                        _temp = tempNew;
                        Console.WriteLine("Neues TempVerzeichnis: " + _temppath);
                        MessageBox.Show(_temppath);
                        this._state = State.DetectFile;
                        Thread.Sleep(waitingTime);
                        break;
                    }

                case State.MoveToTemp:
                    File.Move(filepath, _temppath);

                    if (File.Exists(filepath))
                    {
                        Console.WriteLine("The original file still exists in filepath, which is unexpected");
                        this._state = State.DetectFile;
                        Thread.Sleep(10);
                    }
                    else
                    {
                        Console.WriteLine("{0} was moved to {1}.", filepath, _temppath);
                        this._state = State.ReadFile;
                    }

                    break;

                case State.ReadFile:
                    _dataWpa = File.ReadAllText(_temppath);
                    Console.WriteLine("file eingelesen");

                    this._state = State.Delete;
                    break;

                case State.Delete:
                    File.Delete(_temppath);
                    if (File.Exists(_temppath))
                    {
                        Console.WriteLine("löschen im temp-verzeichnis hat nicht funktioniert");
                        this._state = State.DetectFile;
                        Thread.Sleep(waitingTime);
                    }
                    else
                    {
                        Console.WriteLine("löschen im temop hat funktioniert");
                        this._state = State.DetectFile;
                        ProcessCompleted(this, _dataWpa);
                    }

                    break;

                default:
                    this._state = State.DetectFile;
                    break;
            }
        }
    }
}