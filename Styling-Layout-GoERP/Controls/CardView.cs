using Android.Views;
using Microsoft.Maui.Controls;
using static Android.Provider.CalendarContract;
using static Android.Renderscripts.ScriptGroup;
using System.Reflection.Emit;

namespace YourAppName.Controls
{
    public class CardView : ContentView
    {
        public static readonly BindableProperty TitleProperty = BindableProperty.Create(
            nameof(Title), typeof(string), typeof(CardView), default(string));

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public CardView()
        {
            var grid = new Grid
            {
                Padding = 10,
                BackgroundColor = Colors.Gray,
                RowDefinitions =
                {
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Star }
                }
            };

            var titleLabel = new Label { FontSize = 18 };
            SetBinding(TitleProperty, new Binding(nameof(Label.Text)));
            grid.Children.Add(titleLabel);

            var tableGrid = new Grid();
            tableGrid.ColumnDefinitions = new ColumnDefinitionCollection
            {
                new ColumnDefinition { Width = GridLength.Star },
                new ColumnDefinition { Width = GridLength.Star },
                new ColumnDefinition { Width = GridLength.Star },
                new ColumnDefinition { Width = GridLength.Star },
                new ColumnDefinition { Width = GridLength.Star },
                new ColumnDefinition { Width = GridLength.Star }
            };

            // Define column headers
            var headers = new[] { "ID", "Name", "Description", "Amount Inserted", "Amount Withdrawn", "Amount Total" };
            for (int i = 0; i < headers.Length; i++)
            {
                var headerLabel = new Label { Text = headers[i], HorizontalTextAlignment = TextAlignment.Center };
                tableGrid.Children.Add(headerLabel);
                Grid.SetColumn(headerLabel, i);
            }

            // Add sample data rows
            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < headers.Length; col++)
                {
                    var cell = new Label { Text = $"Row {row + 1}, Column {col + 1}" }; // Replace with actual data
                    tableGrid.Children.Add(cell);
                    Grid.SetRow(cell, row + 1); // Start rows from 1 for header row
                    Grid.SetColumn(cell, col);
                }
            }

            grid.Children.Add(tableGrid);
            Content = grid;
        }
    }
}