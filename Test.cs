using System;
using System.Windows;
using testMfile_move;

namespace Testing
{
    public class Test : System.Windows.Application
    {
        [System.STAThreadAttribute]
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
                myDispatcher.DecodeCompleted += myAdapter.UpdateData;

                Testing.Test app = new Testing.Test();

                View1 mainView = new View1();

                mainView.DataContext = myAdapter;
                mainView.Show();

                app.Run(mainView);
            }
        }
    }
}