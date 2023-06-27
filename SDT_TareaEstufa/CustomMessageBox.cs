using System.Windows.Controls;
using System.Windows;

namespace SDT_TareaEstufa
{
    public class CustomMessageBox : Window
    {
        public CustomMessageBox(string message, string title, MessageBoxButton buttons, MessageBoxImage icon)
        {
            Title = title;
            ResizeMode = ResizeMode.NoResize;
            SizeToContent = SizeToContent.WidthAndHeight;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            var textBlock = new TextBlock
            {
                Text = message,
                Margin = new Thickness(20),
                TextWrapping = TextWrapping.Wrap
            };

            var buttonPanel = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(10)
            };

            switch (buttons)
            {
                case MessageBoxButton.OK:
                    var okButton = new Button
                    {
                        Content = "Aceptar",
                        Padding = new Thickness(10),
                        Margin = new Thickness(5)
                    };
                    okButton.Click += (sender, e) => this.Close();
                    buttonPanel.Children.Add(okButton);
                    break;
                case MessageBoxButton.OKCancel:
                    var cancelButton = new Button
                    {
                        Content = "Cancelar",
                        Padding = new Thickness(10),
                        Margin = new Thickness(5)
                    };
                    cancelButton.Click += (sender, e) => Close();
                    buttonPanel.Children.Add(cancelButton);

                    var acceptButton = new Button
                    {
                        Content = "Aceptar",
                        Padding = new Thickness(10),
                        Margin = new Thickness(5)
                    };
                    acceptButton.Click += (sender, e) => Close();
                    buttonPanel.Children.Add(acceptButton);
                    break;
                case MessageBoxButton.YesNo:
                    var noButton = new Button
                    {
                        Content = "No",
                        Padding = new Thickness(10),
                        Margin = new Thickness(5)
                    };
                    noButton.Click += (sender, e) => Close();
                    buttonPanel.Children.Add(noButton);

                    var yesButton = new Button
                    {
                        Content = "Sí",
                        Padding = new Thickness(10),
                        Margin = new Thickness(5)
                    };
                    yesButton.Click += (sender, e) => Close();
                    buttonPanel.Children.Add(yesButton);
                    break;
            }

            var mainPanel = new StackPanel
            {
                Orientation = Orientation.Vertical,
                VerticalAlignment = VerticalAlignment.Center
            };
            mainPanel.Children.Add(textBlock);
            mainPanel.Children.Add(buttonPanel);

            Content = mainPanel;

            // Controla el cierre manualmente
            
        }
    }
}
