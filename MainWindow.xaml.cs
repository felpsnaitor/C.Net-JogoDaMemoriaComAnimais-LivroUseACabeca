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
    using System.Windows.Threading;

    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        int tenthsOfSecondsElapsed;
        int matchesFound;


        public MainWindow()
        {
            InitializeComponent();

            timer.Interval = TimeSpan.FromSeconds(0);
            timer.Tick += Timer_Tick;
            SetUpGame();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            tenthsOfSecondsElapsed++;
            timeTextBlock.Text = (tenthsOfSecondsElapsed / 10F).ToString("0,0s");
            if (matchesFound == 8)
            {
                timer.Stop();
                timeTextBlock.Text = timeTextBlock.Text + " - de novo?";
            }
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
                if (textBlock.Name != "timeTextBlock")
                {
                    int index = random.Next(animaisEmoji.Count);
                    string nextEmoji = animaisEmoji[index];
                    textBlock.Text = nextEmoji;
                    animaisEmoji.RemoveAt(index);
                }
            }

            timer.Start();
            tenthsOfSecondsElapsed = 0;
            matchesFound = 0;

        }

   
        TextBlock lastTextBlockClicked;
        bool findingMatch = false;

        private void TexBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {

            TextBlock textBlock = sender as TextBlock;
            if (findingMatch == false)
            {
                textBlock.Visibility = Visibility.Hidden;
                lastTextBlockClicked = textBlock;
                findingMatch = true;

            }
            else if (textBlock.Text == lastTextBlockClicked.Text) 
            {
                matchesFound++;
                textBlock.Visibility |= Visibility.Hidden;
                findingMatch = false;

            }
            else
            {
                lastTextBlockClicked.Visibility = Visibility.Visible;
                findingMatch = false;
             
            }
        }

        private void TimeTextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (matchesFound == 8)
            {
                SetUpGame();
            }

        }

    }
}
