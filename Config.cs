using System;
using System.IO;
using System.Xml;

namespace Testing
{
    internal class Config
    {
        public DeviceKind TypeInterface;
        public string PathFileTransfer;
        public string TempPathFileTransfer;
        public string WaitingTimeFileTransfer;
        public string TempFileTransfer;
        public TranslatorKind TypeTranslator;
        public ConnectionKind ConnectionTyp;
        public int PortServer;
        public string IpServer;
        public int PortClient;
        public string IpClient;

        public void ReadConfig(string pathXml)
        {
            if (File.Exists(pathXml))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(pathXml);
                string typeInterface = doc.ChildNodes[0].ChildNodes[0].InnerText;
                Enum.TryParse<DeviceKind>(typeInterface, out this.TypeInterface);

                this.PathFileTransfer = doc.ChildNodes[0].ChildNodes[1].ChildNodes[0].InnerText;
                this.TempPathFileTransfer = doc.ChildNodes[0].ChildNodes[1].ChildNodes[1].InnerText;
                this.WaitingTimeFileTransfer = doc.ChildNodes[0].ChildNodes[1].ChildNodes[2].InnerText;
                this.TempFileTransfer = doc.ChildNodes[0].ChildNodes[1].ChildNodes[3].InnerText;

                string con = doc.ChildNodes[0].ChildNodes[2].ChildNodes[0].InnerText;

                Enum.TryParse<ConnectionKind>(con, out this.ConnectionTyp);
                this.PortServer = int.Parse(doc.ChildNodes[0].ChildNodes[2].ChildNodes[1].InnerText);
                this.IpServer = doc.ChildNodes[0].ChildNodes[2].ChildNodes[2].InnerText;
                this.PortClient = int.Parse(doc.ChildNodes[0].ChildNodes[2].ChildNodes[3].InnerText);
                this.IpClient = doc.ChildNodes[0].ChildNodes[2].ChildNodes[4].InnerText;

                string typTrans = doc.ChildNodes[0].ChildNodes[3].InnerText;
                Enum.TryParse<TranslatorKind>(typTrans, out this.TypeTranslator);

                if (TypeInterface == DeviceKind.Invalid)
                {
                    throw new Exception("Interface/Device typ does not exist");
                }

                if (PathFileTransfer == string.Empty)
                {
                    throw new Exception("File path does not exist");
                }

                if (TempPathFileTransfer == string.Empty)
                {
                    throw new Exception("Temp path does not exist");
                }

                if (WaitingTimeFileTransfer == string.Empty)
                {
                    throw new Exception("Waiting time does not exist");
                }

                if (TempFileTransfer == string.Empty)
                {
                    throw new Exception("temp Verzeichnis does not exist");
                }

                if (TypeTranslator == TranslatorKind.Invalid)
                {
                    throw new Exception("Translator typ does not exist");
                }

                if (ConnectionTyp == ConnectionKind.Invalid)
                {
                    throw new Exception("Connection(Server/Client) Kind does not exist");
                }

                if (PortServer == null)
                {
                    throw new Exception("port number for Server does not exist");
                }

                if (PortClient == null)
                {
                    throw new Exception("port number for client does not exist");
                }

                if (IpServer == string.Empty)
                {
                    throw new Exception("IP for Server doe not exist");
                }

                if (IpClient == string.Empty)
                {
                    throw new Exception("IP for Client does not exist");
                }
            }
            else
            {
                throw new FileNotFoundException(pathXml);
            }
        }
    }
}