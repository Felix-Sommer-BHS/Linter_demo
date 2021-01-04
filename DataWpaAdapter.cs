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

namespace testing
{

    public class DataWpaAdapter : INotifyPropertyChanged //: AdapterBase//ist VisiWin ? Was stattdessen??
    {
        private ConveyData _source;
        int[] _array1 = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public event PropertyChangedEventHandler PropertyChanged;

        public int DataSetCounter
        {
            get { return (_source != null) ? _source.DataSetCounter : 0; }
        }

        public string CostumerID
        {
            get { return (_source != null) ? _source.costumerID : string.Empty; }
        }
        public int StackerNr
        {
            get { return (_source != null) ? _source.stackerNr : 0; }
        }
        public int DataSetID
        {
            get { return (_source != null) ? _source.dataSetID : 0; }
        }
        public int MultiStacking
        {
            get { return (_source != null) ? _source.multiStacking : 0; }
        }
        public int MultiStackPartial
        {
            get { return (_source != null) ? _source.multiStackPartial : 0; }
        }
        public int MultiStackNrPartial
        {
            get { return (_source != null) ? _source.multiStackNrPartial : 0; }
        }
        public string OrderNumber
        {
            get { return (_source != null) ? _source.orderNumber : string.Empty; }
        }

        public int PartNr
        {
            get { return (_source != null) ? _source.PartNr : 0; }
        }
        public string CostumerName
        {
            get { return (_source != null) ? _source.costumerName : string.Empty; }
        }
        public string ProcessingMachine
        {
            get { return (_source != null) ? _source.processingMachine : string.Empty; }
        }
        public int LengthIndPartStack
        {
            get { return (_source != null) ? _source.lengthIndPartStack : 0; }
        }
        public int OutWidthIndPartStack
        {
            get { return (_source != null) ? _source.outWidthIndPartStack : 0; }
        }
        public int NrSheetsPartStack
        {
            get { return (_source != null) ? _source.nrSheetsPartStack : 0; }
        }

        public int OverallNrStacks
        {
            get { return (_source != null) ? _source.overallNrStacks : 0; }
        }
        public int OverallWidthStackPackage
        {
            get { return (_source != null) ? _source.overallWidthStackPackage : 0; }
        }
        public int OveralllengthStackPackage
        {
            get { return (_source != null) ? _source.overalllengthStackPackage : 0; }
        }
        public int OverallheightStackPackage
        {
            get { return (_source != null) ? _source.overallheightStackPackage : 0; }
        }
        public int NrStackswidthwise
        {
            get { return (_source != null) ? _source.nrStackswidthwise : 0; }
        }
        public int NrStackslengthwise
        {
            get { return (_source != null) ? _source.nrStackslengthwise : 0; }
        }
        public int NrStacksabove
        {
            get { return (_source != null) ? _source.nrStacksabove : 0; }
        }
        public int StackConfNominal
        {
            get { return (_source != null) ? _source.stackConfNominal : 0; }
        }
        public int IntermLayerForPackages
        {
            get { return (_source != null) ? _source.intermLayerForPackages : 0; }
        }
        public int LastStack
        {
            get { return (_source != null) ? _source.lastStack : 0; }
        }
        public int LastRunCostumer
        {
            get { return (_source != null) ? _source.lastRunCostumer : 0; }
        }
        public int DischargeDirection
        {
            get { return (_source != null) ? _source.dischargeDirection : 0; }
        }
        public int ExpNrStackPackPartialOrder
        {
            get { return (_source != null) ? _source.expNrStackPackPartialOrder : 0; }
        }
        public int ExpNrStackPackOverallOrder
        {
            get { return (_source != null) ? _source.expNrStackPackOverallOrder : 0; }
        }
        public string SetupIdentification
        {
            get { return (_source != null) ? _source.setupIdentification : string.Empty; }
        }
        public int NrOuts
        {
            get { return (_source != null) ? _source.nrOuts : 0; }
        }


        public int[] ScoringKnifePos
        {

            get { return (_source != null) ? _source.scoringKnifePos : _array1; }
        }

        public int TotalCutsActualOrder
        {
            get { return (_source != null) ? _source.totalCutsActualOrder : 0; }
        }
        public int LastStackModified
        {
            get { return (_source != null) ? _source.lastStackModified : 0; }
        }
        public int WidthStackGroup
        {
            get { return (_source != null) ? _source.widthStackGroup : 0; }
        }
        public int NrOutsForStackGroup
        {
            get { return (_source != null) ? _source.nrOutsForStackGroup : 0; }
        }
        public int LastStackStore
        {
            get { return (_source != null) ? _source.lastStackStore : 0; }
        }
        public string Reserved
        {
            get { return (_source != null) ? _source.reserved : string.Empty; }
        }



        public int Port
        {
            get { return (_source != null) ? _source.port : 0; }
        }
        public string Ip
        {
            get { return (_source != null) ? _source.ip : string.Empty; }
        }

        public ConnectionKind ConnectionTyp
        {
            get { return (_source != null) ? _source.connectionTyp : ConnectionKind.Invalid; }
        }

        public TranslatorKind TranslatorTyp
        {
            get { return (_source != null) ? _source.translatorTyp : TranslatorKind.Invalid; }
        }
        public DeviceKind DeviceKind
        {
            get { return (_source != null) ? _source.deviceKind : DeviceKind.Invalid; }
        }
        public string FilePath
        {
            get { return (_source != null) ? _source.filePath : string.Empty; }
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
