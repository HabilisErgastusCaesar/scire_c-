using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace scire
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        [DllImport("kernel32.dll")] static extern bool AllocConsole();
        public MainWindow()
        {
            AllocConsole();
            InitializeComponent();
            StartUp();
        }
        private void AddQuestion_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("doe je kanker werk");

        }

        private void findQuestion(object sender, RoutedEventArgs e)
        {
            var element = sender as FrameworkElement;
            if (element != null)
            {
                var parent = element.Parent as Panel;
                if (parent != null && parent.Children.Count > 0)
                {
                    var firstChild = parent.Children[0] as TextBlock;
                    if (firstChild != null)
                    {
                        firstChild.Text = "kanker";
                    }
                }
            }
        }

        private void findAnswer(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(sender);
        }

        private void StartUp()
        {
            string[] question = { 
                "lol1", 
                "lol2", 
                "lol3", 
                "lol4" 
            };

            string[] answer = {
                "lol1",
                "lol2",
                "lol3",
                "lol4"
            };

            var index = 1;
            foreach (var item in question)
            {
                var newStackPanel = new StackPanel()
                {
                    Name = $"newQuestion{index}",
                };
                var newItem = new TextBlock() {
                    Text = $"{index}: {item}",
                    Width = 260,
                    Margin = new Thickness(0, 0, 0, 5),
                };
                var newButton = new Button()
                {
                    Content = "Edit",
                    Width = 260,
                    Margin = new Thickness(0, 0, 0, 5),
                };
                newButton.Click += findQuestion;
                newStackPanel.Children.Add(newItem);
                newStackPanel.Children.Add(newButton);
                QuestionsResult.Children.Add(newStackPanel);
            };
            
            foreach (var item in answer)
            {
                var newStackPanel = new StackPanel()
                {
                    Name = $"newAnswer{index}",
                };
                var newItem = new TextBlock()
                {
                    Text = $"{index}: {item}",
                    Width = 260,
                    Margin = new Thickness(0, 0, 0, 5)
                };
                var newButton = new Button()
                {
                    Content = "Edit",
                    Width = 260,
                    Margin = new Thickness(0, 0, 0, 5)
                };
                newButton.Click += findAnswer;
                index += 1;
                newStackPanel.Children.Add(newItem);
                newStackPanel.Children.Add(newButton);
                AnswersResult.Children.Add(newStackPanel);
            };
        }
    }
}
