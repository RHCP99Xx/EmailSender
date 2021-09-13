using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EmailSender
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EmailSenderSMTP emailSender = new EmailSenderSMTP();
            TextBoxValidators tbValidator = new TextBoxValidators();

            string email = this.tbEmail.Text;
            string subject = this.tbSubject.Text;
            string message = this.tbMessage.Text;

            if (tbValidator.EmailStructureValidator(email))
            {
                
                if (tbValidator.CompleteTextbox(message, subject))
                {
                    emailSender.SendEmail(message, email, subject);
                    MessageBox.Show("El correo se ha enviado correctamente", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Algunos campos se encuentran vacíos", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    this.tbMessage.BorderBrush = Brushes.Red;
                    this.tbSubject.BorderBrush = Brushes.Red;
                    this.tbEmail.BorderBrush = Brushes.Red;
                }

            }
            else
            {
                MessageBox.Show("El correo electrónico es inválido", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                this.tbEmail.BorderBrush = Brushes.Red;
                this.tbMessage.BorderBrush = Brushes.Black;
                this.tbSubject.BorderBrush = Brushes.Black;
            }
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            this.tbEmail.Text = "";
            this.tbMessage.Text = "";
            this.tbSubject.Text = "";
        }

        private void textBox_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Copy ||
                e.Command == ApplicationCommands.Cut ||
                e.Command == ApplicationCommands.Paste)
            {
                e.Handled = true;
            }
        }
    }
}
