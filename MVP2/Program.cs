using MVP2.Presenter;
using MVP2.Repository;
using MVP2.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVP2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var repository = new UserRepository(Application.StartupPath);
            var view = new View.FirstForm();
            var presenter = new UserPresenter(view, repository);
            Application.Run(view);
        }
    }
}
