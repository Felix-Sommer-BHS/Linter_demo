using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testing
{
    public class ConveyData
    {
        public int DataSetCounter;
        public string costumerID;
        public int stackerNr;
        public int dataSetID;
        public int multiStacking;
        public int multiStackPartial;
        public int multiStackNrPartial;
        public string orderNumber;
        public int PartNr;
        public string costumerName;
        public string processingMachine;
        public int destLine;
        public int lengthIndPartStack;
        public int outWidthIndPartStack;
        public int nrSheetsPartStack;
        public int overallNrStacks;
        public int overallWidthStackPackage;
        public int overalllengthStackPackage;
        public int overallheightStackPackage;
        public int nrStackswidthwise;
        public int nrStackslengthwise;
        public int nrStacksabove;
        public int stackConfNominal;
        public int intermLayerForPackages;
        public int lastStack;
        public int lastRunCostumer;
        public int dischargeDirection;
        public int expNrStackPackPartialOrder;
        public int expNrStackPackOverallOrder;
        public string setupIdentification;
        public int nrOuts;
        public int[] scoringKnifePos = new int[24];
        public int totalCutsActualOrder;
        public int lastStackModified;
        public int widthStackGroup;
        public int nrOutsForStackGroup;
        public int lastStackStore;
        public string reserved;

        public string filePath;

        public int port;
        public string ip;
        public ConnectionKind connectionTyp;
        public TranslatorKind translatorTyp;
        public DeviceKind deviceKind;
    }
}
