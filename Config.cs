using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using System.Xml;
using testing;
using testMfile_move;

namespace testing
{
    class Config
    {
        public DeviceKind TypeInterface;
        public string pathFileTransfer;
        public string tempPathFileTransfer;
        public string waitingTimeFileTransfer;
        public string tempFileTransfer;
        public TranslatorKind typeTranslator;
        public ConnectionKind connectionTyp;
        public int portServer;
        public string ipServer;
        public int portClient;
        public string ipClient;


        public void ReadConfig(string pathXml)
        {
            if (File.Exists(pathXml))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(pathXml);
                string typeInterface = doc.ChildNodes[0].ChildNodes[0].InnerText;
                Enum.TryParse<DeviceKind>(typeInterface, out this.TypeInterface);

                this.pathFileTransfer = doc.ChildNodes[0].ChildNodes[1].ChildNodes[0].InnerText;
                this.tempPathFileTransfer = doc.ChildNodes[0].ChildNodes[1].ChildNodes[1].InnerText;
                this.waitingTimeFileTransfer = doc.ChildNodes[0].ChildNodes[1].ChildNodes[2].InnerText;
                this.tempFileTransfer = doc.ChildNodes[0].ChildNodes[1].ChildNodes[3].InnerText;

                string con = doc.ChildNodes[0].ChildNodes[2].ChildNodes[0].InnerText;

                Enum.TryParse<ConnectionKind>(con, out this.connectionTyp);
                this.portServer = int.Parse(doc.ChildNodes[0].ChildNodes[2].ChildNodes[1].InnerText);
                this.ipServer = doc.ChildNodes[0].ChildNodes[2].ChildNodes[2].InnerText;
                this.portClient = int.Parse(doc.ChildNodes[0].ChildNodes[2].ChildNodes[3].InnerText);
                this.ipClient = doc.ChildNodes[0].ChildNodes[2].ChildNodes[4].InnerText;

                string typTrans = doc.ChildNodes[0].ChildNodes[3].InnerText;
                Enum.TryParse<TranslatorKind>(typTrans, out this.typeTranslator);


                if (TypeInterface == DeviceKind.Invalid)
                {
                    throw new Exception("Interface/Device typ does not exist");
                }

                if (pathFileTransfer == string.Empty)
                {
                    throw new Exception("File path does not exist");
                }
                if (tempPathFileTransfer == string.Empty)
                {
                    throw new Exception("Temp path does not exist");
                }
                if (waitingTimeFileTransfer == string.Empty)
                {
                    throw new Exception("Waiting time does not exist");
                }
                if (tempFileTransfer == string.Empty)
                {
                    throw new Exception("temp Verzeichnis does not exist");
                }

                if (typeTranslator == TranslatorKind.Invalid)
                {
                    throw new Exception("Translator typ does not exist");
                }

                if (connectionTyp == ConnectionKind.Invalid)
                {
                    throw new Exception("Connection(Server/Client) Kind does not exist");
                }
                if (portServer == null)
                {
                    throw new Exception("port number for Server does not exist");
                }
                if (portClient == null)
                {
                    throw new Exception("port number for client does not exist");
                }
                if (ipServer == string.Empty)
                {
                    throw new Exception("IP for Server doe not exist");
                }
                if (ipClient == string.Empty)
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
