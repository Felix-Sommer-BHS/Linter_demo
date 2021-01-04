using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
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


    public class Test : System.Windows.Application
    {

        [System.STAThreadAttribute()]
        public static void Main()
        {
            bool configIsValid = true;
            string filepathConfig = @"C:\Users\FSommer\source\repos\BHS-Corrugated\TesteWorklflow\config.xml";
            Config g = new Config();

            try
            {
                g.ReadConfig(filepathConfig);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                configIsValid = false;
            }

            if (configIsValid)
            {
                DataWpaAdapter myAdapter = new DataWpaAdapter();
                FileDispatcher myDispatcher = new FileDispatcher(g);

                myDispatcher.Init();
                myDispatcher.DecodeCompleted += myAdapter.updateData;


                //Console.WriteLine("test start second threat");bbbbcacbc


                testing.Test app = new testing.Test();

                View1 mainView = new View1();

                mainView.DataContext = myAdapter;
                mainView.Show();

                app.Run(mainView);
            }
        }

    }

}
