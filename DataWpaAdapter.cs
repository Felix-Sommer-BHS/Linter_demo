using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
//using VisiWin.ApplicationFramework;
//using VisiWin.Controls;
using System.Windows;

namespace Testing
{

    public class DataWpaAdapter : INotifyPropertyChanged //: AdapterBase//ist VisiWin ? Was stattdessen??
    {
        private ConveyData _source;
        int[] _array1 = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public event PropertyChangedEventHandler PropertyChanged;

        public int dataSetCounter
        {
            get { return (_source != null) ? _source.DataSetCounter : 0; }
        }

        public string costumerID
        {
            get { return (_source != null) ? _source.CostumerID : string.Empty; }
        }
        public int stackerNr
        {
            get { return (_source != null) ? _source.StackerNr : 0; }
        }
        public int dataSetID
        {
            get { return (_source != null) ? _source.DataSetID : 0; }
        }
        public int multiStacking
        {
            get { return (_source != null) ? _source.MultiStacking : 0; }
        }
        public int multiStackPartial
        {
            get { return (_source != null) ? _source.MultiStackPartial : 0; }
        }
        public int multiStackNrPartial
        {
            get { return (_source != null) ? _source.MultiStackNrPartial : 0; }
        }
        public string orderNumber
        {
            get { return (_source != null) ? _source.OrderNumber : string.Empty; }
        }

        public int PartNr
        {
            get { return (_source != null) ? _source.PartNr : 0; }
        }
        public string costumerName
        {
            get { return (_source != null) ? _source.CostumerName : string.Empty; }
        }
        public string processingMachine
        {
            get { return (_source != null) ? _source.ProcessingMachine : string.Empty; }
        }
        public int lengthIndPartStack
        {
            get { return (_source != null) ? _source.LengthIndPartStack : 0; }
        }
        public int outWidthIndPartStack
        {
            get { return (_source != null) ? _source.OutWidthIndPartStack : 0; }
        }
        public int nrSheetsPartStack
        {
            get { return (_source != null) ? _source.NrSheetsPartStack : 0; }
        }

        public int overallNrStacks
        {
            get { return (_source != null) ? _source.OverallNrStacks : 0; }
        }
        public int overallWidthStackPackage
        {
            get { return (_source != null) ? _source.OverallWidthStackPackage : 0; }
        }
        public int overalllengthStackPackage
        {
            get { return (_source != null) ? _source.OveralllengthStackPackage : 0; }
        }
        public int overallheightStackPackage
        {
            get { return (_source != null) ? _source.OverallheightStackPackage : 0; }
        }
        public int nrStackswidthwise
        {
            get { return (_source != null) ? _source.NrStackswidthwise : 0; }
        }
        public int nrStackslengthwise
        {
            get { return (_source != null) ? _source.NrStackslengthwise : 0; }
        }
        public int nrStacksabove
        {
            get { return (_source != null) ? _source.NrStacksabove : 0; }
        }
        public int stackConfNominal
        {
            get { return (_source != null) ? _source.StackConfNominal : 0; }
        }
        public int intermLayerForPackages
        {
            get { return (_source != null) ? _source.IntermLayerForPackages : 0; }
        }
        public int lastStack
        {
            get { return (_source != null) ? _source.LastStack : 0; }
        }
        public int lastRunCostumer
        {
            get { return (_source != null) ? _source.LastRunCostumer : 0; }
        }
        public int dischargeDirection
        {
            get { return (_source != null) ? _source.DischargeDirection : 0; }
        }
        public int expNrStackPackPartialOrder
        {
            get { return (_source != null) ? _source.ExpNrStackPackPartialOrder : 0; }
        }
        public int expNrStackPackOverallOrder
        {
            get { return (_source != null) ? _source.ExpNrStackPackOverallOrder : 0; }
        }
        public string setupIdentification
        {
            get { return (_source != null) ? _source.SetupIdentification : string.Empty; }
        }
        public int nrOuts
        {
            get { return (_source != null) ? _source.NrOuts : 0; }
        }


        public int[] scoringKnifePos
        {

            get { return (_source != null) ? _source.ScoringKnifePos : _array1; }
        }

        public int totalCutsActualOrder
        {
            get { return (_source != null) ? _source.TotalCutsActualOrder : 0; }
        }
        public int lastStackModified
        {
            get { return (_source != null) ? _source.LastStackModified : 0; }
        }
        public int widthStackGroup
        {
            get { return (_source != null) ? _source.WidthStackGroup : 0; }
        }
        public int nrOutsForStackGroup
        {
            get { return (_source != null) ? _source.NrOutsForStackGroup : 0; }
        }
        public int lastStackStore
        {
            get { return (_source != null) ? _source.LastStackStore : 0; }
        }
        public string reserved
        {
            get { return (_source != null) ? _source.Reserved : string.Empty; }
        }



        public int port
        {
            get { return (_source != null) ? _source.Port : 0; }
        }
        public string ip
        {
            get { return (_source != null) ? _source.Ip : string.Empty; }
        }

        public ConnectionKind connectionTyp
        {
            get { return (_source != null) ? _source.ConnectionTyp : ConnectionKind.Invalid; }
        }

        public TranslatorKind translatorTyp
        {
            get { return (_source != null) ? _source.TranslatorTyp : TranslatorKind.Invalid; }
        }
        public DeviceKind deviceKind
        {
            get { return (_source != null) ? _source.DeviceKind : DeviceKind.Invalid; }
        }
        public string filePath
        {
            get { return (_source != null) ? _source.FilePath : string.Empty; }
        }

        public void updateData(object sender, ConveyData dataWpa)
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
