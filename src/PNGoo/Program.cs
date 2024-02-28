using System;
using System.Windows.Forms;


namespace PNGoo
{

    static class Program
    {
        private static MainView mainView;

        /// <summary>
        /// The main entry point for the application.
        /// parameter example:
        /// 
        /// -p="C:/root_folder/sub_folder"
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            mainView = new MainView(args);

            Application.Run(mainView);
        }
    }
}