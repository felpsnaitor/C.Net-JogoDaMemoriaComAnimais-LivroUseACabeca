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

namespace JogoDosAnimais
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetUpGame();
        }

        private void SetUpGame()
        {
            List<string> animaisEmoji = new List<string>()
           {
               "🐔", "🐔",
               "🐸", "🐸",
               "🐷", "🐷",
               "🙀", "🙀",
               "🙊", "🙊",
               "🐼", "🐼",
               "🐇", "🐇",
               "🐍", "🐍",
           };

            Random random = new Random();

            foreach (TextBlock textBlock in mainGrid.Children.OfType<TextBlock>())
            { 
                int index = random.Next(animaisEmoji.Count);
                string nextEmoji = animaisEmoji[index];
                textBlock.Text = nextEmoji;
                animaisEmoji.RemoveAt(index);
            }

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
