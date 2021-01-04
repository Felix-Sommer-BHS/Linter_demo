namespace Testing
{
    public class ConveyData
    {
        public int DataSetCounter;
        public string CostumerID;
        public int StackerNr;
        public int DataSetID;
        public int MultiStacking;
        public int MultiStackPartial;
        public int MultiStackNrPartial;
        public string OrderNumber;
        public int PartNr;
        public string CostumerName;
        public string ProcessingMachine;
        public int DestLine;
        public int LengthIndPartStack;
        public int OutWidthIndPartStack;
        public int NrSheetsPartStack;
        public int OverallNrStacks;
        public int OverallWidthStackPackage;
        public int OveralllengthStackPackage;
        public int OverallheightStackPackage;
        public int NrStackswidthwise;
        public int NrStackslengthwise;
        public int NrStacksabove;
        public int StackConfNominal;
        public int IntermLayerForPackages;
        public int LastStack;
        public int LastRunCostumer;
        public int DischargeDirection;
        public int ExpNrStackPackPartialOrder;
        public int ExpNrStackPackOverallOrder;
        public string SetupIdentification;
        public int NrOuts;
        public int[] ScoringKnifePos = new int[24];
        public int TotalCutsActualOrder;
        public int LastStackModified;
        public int WidthStackGroup;
        public int NrOutsForStackGroup;
        public int LastStackStore;
        public string Reserved;

        public string FilePath;

        public int Port;
        public string Ip;
        public ConnectionKind ConnectionTyp;
        public TranslatorKind TranslatorTyp;
        public DeviceKind DeviceKind;
    }
}