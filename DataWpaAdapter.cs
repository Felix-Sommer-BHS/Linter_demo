using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;

//using VisiWin.ApplicationFramework;
//using VisiWin.Controls;
namespace Testing
{
    public class DataWpaAdapter : INotifyPropertyChanged //: AdapterBase//ist VisiWin ? Was stattdessen??
    {
        private ConveyData _source;
        private int[] _array1 = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public event PropertyChangedEventHandler PropertyChanged;

        public int DataSetCounter
        {
            get { return (_source != null) ? _source.DataSetCounter : 0; }
        }

        public string CostumerID
        {
            get { return (_source != null) ? _source.CostumerID : string.Empty; }
        }

        public int StackerNr
        {
            get { return (_source != null) ? _source.StackerNr : 0; }
        }

        public int DataSetID
        {
            get { return (_source != null) ? _source.DataSetID : 0; }
        }

        public int MultiStacking
        {
            get { return (_source != null) ? _source.MultiStacking : 0; }
        }

        public int MultiStackPartial
        {
            get { return (_source != null) ? _source.MultiStackPartial : 0; }
        }

        public int MultiStackNrPartial
        {
            get { return (_source != null) ? _source.MultiStackNrPartial : 0; }
        }

        public string OrderNumber
        {
            get { return (_source != null) ? _source.OrderNumber : string.Empty; }
        }

        public int PartNr
        {
            get { return (_source != null) ? _source.PartNr : 0; }
        }

        public string CostumerName
        {
            get { return (_source != null) ? _source.CostumerName : string.Empty; }
        }

        public string ProcessingMachine
        {
            get { return (_source != null) ? _source.ProcessingMachine : string.Empty; }
        }

        public int LengthIndPartStack
        {
            get { return (_source != null) ? _source.LengthIndPartStack : 0; }
        }

        public int OutWidthIndPartStack
        {
            get { return (_source != null) ? _source.OutWidthIndPartStack : 0; }
        }

        public int NrSheetsPartStack
        {
            get { return (_source != null) ? _source.NrSheetsPartStack : 0; }
        }

        public int OverallNrStacks
        {
            get { return (_source != null) ? _source.OverallNrStacks : 0; }
        }

        public int OverallWidthStackPackage
        {
            get { return (_source != null) ? _source.OverallWidthStackPackage : 0; }
        }

        public int OveralllengthStackPackage
        {
            get { return (_source != null) ? _source.OveralllengthStackPackage : 0; }
        }

        public int OverallheightStackPackage
        {
            get { return (_source != null) ? _source.OverallheightStackPackage : 0; }
        }

        public int NrStackswidthwise
        {
            get { return (_source != null) ? _source.NrStackswidthwise : 0; }
        }

        public int NrStackslengthwise
        {
            get { return (_source != null) ? _source.NrStackslengthwise : 0; }
        }

        public int NrStacksabove
        {
            get { return (_source != null) ? _source.NrStacksabove : 0; }
        }

        public int StackConfNominal
        {
            get { return (_source != null) ? _source.StackConfNominal : 0; }
        }

        public int IntermLayerForPackages
        {
            get { return (_source != null) ? _source.IntermLayerForPackages : 0; }
        }

        public int LastStack
        {
            get { return (_source != null) ? _source.LastStack : 0; }
        }

        public int LastRunCostumer
        {
            get { return (_source != null) ? _source.LastRunCostumer : 0; }
        }

        public int DischargeDirection
        {
            get { return (_source != null) ? _source.DischargeDirection : 0; }
        }

        public int ExpNrStackPackPartialOrder
        {
            get { return (_source != null) ? _source.ExpNrStackPackPartialOrder : 0; }
        }

        public int ExpNrStackPackOverallOrder
        {
            get { return (_source != null) ? _source.ExpNrStackPackOverallOrder : 0; }
        }

        public string SetupIdentification
        {
            get { return (_source != null) ? _source.SetupIdentification : string.Empty; }
        }

        public int NrOuts
        {
            get { return (_source != null) ? _source.NrOuts : 0; }
        }

        public int[] ScoringKnifePos
        {
            get { return (_source != null) ? _source.ScoringKnifePos : _array1; }
        }

        public int TotalCutsActualOrder
        {
            get { return (_source != null) ? _source.TotalCutsActualOrder : 0; }
        }

        public int LastStackModified
        {
            get { return (_source != null) ? _source.LastStackModified : 0; }
        }

        public int WidthStackGroup
        {
            get { return (_source != null) ? _source.WidthStackGroup : 0; }
        }

        public int NrOutsForStackGroup
        {
            get { return (_source != null) ? _source.NrOutsForStackGroup : 0; }
        }

        public int LastStackStore
        {
            get { return (_source != null) ? _source.LastStackStore : 0; }
        }

        public string Reserved
        {
            get { return (_source != null) ? _source.Reserved : string.Empty; }
        }

        public int Port
        {
            get { return (_source != null) ? _source.Port : 0; }
        }

        public string Ip
        {
            get { return (_source != null) ? _source.Ip : string.Empty; }
        }

        public ConnectionKind ConnectionTyp
        {
            get { return (_source != null) ? _source.ConnectionTyp : ConnectionKind.Invalid; }
        }

        public TranslatorKind TranslatorTyp
        {
            get { return (_source != null) ? _source.TranslatorTyp : TranslatorKind.Invalid; }
        }

        public DeviceKind DeviceKind
        {
            get { return (_source != null) ? _source.DeviceKind : DeviceKind.Invalid; }
        }

        public string FilePath
        {
            get { return (_source != null) ? _source.FilePath : string.Empty; }
        }

        public void UpdateData(object sender, ConveyData dataWpa)
        {
            _source = dataWpa;
            OnPropertyChanged(string.Empty);
            Thread.Sleep(100);
        }

        //#region INotifyPropertyChanged
        protected void OnPropertyChanged([CallerMemberName] String info = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        //#endregion
    }
}