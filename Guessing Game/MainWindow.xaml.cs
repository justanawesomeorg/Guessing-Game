using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Guessing_Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int num = 0;
        int wrong = 0;
        int right = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Number_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                confirmBTN.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                e.Handled = true;
                return;
            }
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            wrongGuesses.Text = $"{wrong}";
            rightGuesses.Text = $"{right}";
            num = new Random().Next(1, 50);
        }

        private void ConfirmBTN_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(number.Text, out int n))
            {
                if (num == n)
                {
                    MessageBox.Show($"Parabens Acertaste!!!\nO numero certo era mesmo {num}.");
                    right++;
                    wrongGuesses.Text = $"{wrong}";
                    rightGuesses.Text = $"{right}";
                    num = new Random().Next(1, 50);
                }
                else
                {
                    MessageBox.Show($"Infelizmente não tiveste sorte!!!\nO numero certo era {num}.\nMelhor Sorte para a proxima jogada!");
                    wrong++;
                    wrongGuesses.Text = $"{wrong}";
                    rightGuesses.Text = $"{right}";
                    num = new Random().Next(1, 50);
                }
            }
            else
            {
                MessageBox.Show("Ocurreu um erro ao tentar ler o numero que introduziste!");
                num = new Random().Next(1, 50);
            }
        }

        private void Number_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!int.TryParse(e.Text, out _))
            {
                e.Handled = true;
                return;
            }

            if (int.Parse(number.Text + e.Text) < 1 || int.Parse(number.Text + e.Text) > 50)
            {
                e.Handled = true;
                return;
            }
        }
    }
}