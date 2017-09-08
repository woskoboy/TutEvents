using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_WPF
{
    class Presenter
    {
        private MainWindow mainWindow;
        private Model model;

        public Presenter(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            this.mainWindow.SomeEvent += MainWindow_SomeEvent;
            this.model = new Model();
        }

        private void MainWindow_SomeEvent(object sender, EventArgs e)
        {
            this.mainWindow.textBox.Text = model.SomeMethod(this.mainWindow.textBox.Text);
        }
    }
}
