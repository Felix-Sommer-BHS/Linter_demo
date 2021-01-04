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

        public int dataSetCounter
        {
            get { return (_source != null) ? _source.DataSetCounter : 0; }
        }

        public string costumerID
        {
            get { return (_source != null) ? _source.costumerID : string.Empty; }
        }
        public int stackerNr
        {
            get { return (_source != null) ? _source.stackerNr : 0; }
        }
        public int dataSetID
        {
            get { return (_source != null) ? _source.dataSetID : 0; }
        }
        public int multiStacking
        {
            get { return (_source != null) ? _source.multiStacking : 0; }
        }
        public int multiStackPartial
        {
            get { return (_source != null) ? _source.multiStackPartial : 0; }
        }
        public int multiStackNrPartial
        {
            get { return (_source != null) ? _source.multiStackNrPartial : 0; }
        }
        public string orderNumber
        {
            get { return (_source != null) ? _source.orderNumber : string.Empty; }
        }

        public int PartNr
        {
            get { return (_source != null) ? _source.PartNr : 0; }
        }
        public string costumerName
        {
            get { return (_source != null) ? _source.costumerName : string.Empty; }
        }
        public string processingMachine
        {
            get { return (_source != null) ? _source.processingMachine : string.Empty; }
        }
        public int lengthIndPartStack
        {
            get { return (_source != null) ? _source.lengthIndPartStack : 0; }
        }
        public int outWidthIndPartStack
        {
            get { return (_source != null) ? _source.outWidthIndPartStack : 0; }
        }
        public int nrSheetsPartStack
        {
            get { return (_source != null) ? _source.nrSheetsPartStack : 0; }
        }

        public int overallNrStacks
        {
            get { return (_source != null) ? _source.overallNrStacks : 0; }
        }
        public int overallWidthStackPackage
        {
            get { return (_source != null) ? _source.overallWidthStackPackage : 0; }
        }
        public int overalllengthStackPackage
        {
            get { return (_source != null) ? _source.overalllengthStackPackage : 0; }
        }
        public int overallheightStackPackage
        {
            get { return (_source != null) ? _source.overallheightStackPackage : 0; }
        }
        public int nrStackswidthwise
        {
            get { return (_source != null) ? _source.nrStackswidthwise : 0; }
        }
        public int nrStackslengthwise
        {
            get { return (_source != null) ? _source.nrStackslengthwise : 0; }
        }
        public int nrStacksabove
        {
            get { return (_source != null) ? _source.nrStacksabove : 0; }
        }
        public int stackConfNominal
        {
            get { return (_source != null) ? _source.stackConfNominal : 0; }
        }
        public int intermLayerForPackages
        {
            get { return (_source != null) ? _source.intermLayerForPackages : 0; }
        }
        public int lastStack
        {
            get { return (_source != null) ? _source.lastStack : 0; }
        }
        public int lastRunCostumer
        {
            get { return (_source != null) ? _source.lastRunCostumer : 0; }
        }
        public int dischargeDirection
        {
            get { return (_source != null) ? _source.dischargeDirection : 0; }
        }
        public int expNrStackPackPartialOrder
        {
            get { return (_source != null) ? _source.expNrStackPackPartialOrder : 0; }
        }
        public int expNrStackPackOverallOrder
        {
            get { return (_source != null) ? _source.expNrStackPackOverallOrder : 0; }
        }
        public string setupIdentification
        {
            get { return (_source != null) ? _source.setupIdentification : string.Empty; }
        }
        public int nrOuts
        {
            get { return (_source != null) ? _source.nrOuts : 0; }
        }


        public int[] scoringKnifePos
        {

            get { return (_source != null) ? _source.scoringKnifePos : _array1; }
        }

        public int totalCutsActualOrder
        {
            get { return (_source != null) ? _source.totalCutsActualOrder : 0; }
        }
        public int lastStackModified
        {
            get { return (_source != null) ? _source.lastStackModified : 0; }
        }
        public int widthStackGroup
        {
            get { return (_source != null) ? _source.widthStackGroup : 0; }
        }
        public int nrOutsForStackGroup
        {
            get { return (_source != null) ? _source.nrOutsForStackGroup : 0; }
        }
        public int lastStackStore
        {
            get { return (_source != null) ? _source.lastStackStore : 0; }
        }
        public string reserved
        {
            get { return (_source != null) ? _source.reserved : string.Empty; }
        }



        public int port
        {
            get { return (_source != null) ? _source.port : 0; }
        }
        public string ip
        {
            get { return (_source != null) ? _source.ip : string.Empty; }
        }

        public ConnectionKind connectionTyp
        {
            get { return (_source != null) ? _source.connectionTyp : ConnectionKind.Invalid; }
        }

        public TranslatorKind translatorTyp
        {
            get { return (_source != null) ? _source.translatorTyp : TranslatorKind.Invalid; }
        }
        public DeviceKind deviceKind
        {
            get { return (_source != null) ? _source.deviceKind : DeviceKind.Invalid; }
        }
        public string filePath
        {
            get { return (_source != null) ? _source.filePath : string.Empty; }
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
