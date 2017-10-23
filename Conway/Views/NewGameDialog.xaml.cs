using System;
using System.Windows;

namespace Conway.Views
{
    public partial class NewGameDialog
    {
        public string X => WidthAnswer.Text;
        public string Y => LengthAnswer.Text;

        public NewGameDialog()
        {
            InitializeComponent();
            WidthAnswer.Text = "";
            LengthAnswer.Text = "";
        }

        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            WidthAnswer.Focus();
        }
    }
}
