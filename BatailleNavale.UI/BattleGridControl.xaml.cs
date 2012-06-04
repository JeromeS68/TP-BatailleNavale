using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using BatailleNavale.Domain;

namespace BatailleNavale.UI
{
    /// <summary>
    /// Logique d'interaction pour BattleGridControl.xaml
    /// </summary>
    public partial class BattleGridControl : UserControl
    {
        public BattleGridControl()
        {
            InitializeComponent();
            int i;
            for (i = 0; i < BattleGrid.ROWS; i++)
            {
                layout.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(20) });
            }
            for (i = 0; i < BattleGrid.COLS; i++)
            {
                layout.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(20) });
            }
            for (i = 0; i < BattleGrid.ROWS; i++)
            {
                for (int j = 0; j < BattleGrid.COLS; j++)
                {
                    Rectangle r = new Rectangle() { HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch, VerticalAlignment = System.Windows.VerticalAlignment.Stretch, Stroke = Brushes.White, StrokeThickness = 1, Fill = Brushes.Blue };
                    layout.Children.Add(r);
                    Grid.SetRow(r, i);
                    Grid.SetColumn(r, j);
                }
            }

            BattleGrid g = new BattleGrid();

            // Ajout de bateaux
            g.NewGrid();

            // Tirs
            for (i = 0; i < 10; i++)
            {
                g.Shoot(2, i);
                g.Shoot(3, i);
            }

            g.Shoot(6, 2);
            g.Shoot(1, 1);
            g.Shoot(4, 1);
            g.Shoot(1, 4);

            // Draw
            this.Draw(g);
            
        }

        public void Draw(BattleGrid grid)
        {
            for (int i = 0; i < BattleGrid.ROWS; i++)
            {
                for (int j = 0; j < BattleGrid.COLS; j++)
                {
                    /* alors c'est pas très beau de faire un nouveau rectangle, mais j'ai pas trop réussi à récupérer les infos du rectangle précédent... */
                    if(grid.States[i,j] == GridStates.Ship)
                    {
                        Rectangle r = new Rectangle() { HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch, VerticalAlignment = System.Windows.VerticalAlignment.Stretch, Stroke = Brushes.White, StrokeThickness = 1, Fill = Brushes.Black };
                        layout.Children.Add(r);
                        Grid.SetRow(r, i);
                        Grid.SetColumn(r, j);
                    }
                    else if (grid.States[i, j] == GridStates.Hit)
                    {
                        Rectangle r = new Rectangle() { HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch, VerticalAlignment = System.Windows.VerticalAlignment.Stretch, Stroke = Brushes.White, StrokeThickness = 1, Fill = Brushes.Red };
                        layout.Children.Add(r);
                        Grid.SetRow(r, i);
                        Grid.SetColumn(r, j);
                    }
                    else if (grid.States[i, j] == GridStates.Missed)
                    {
                        Rectangle r = new Rectangle() { HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch, VerticalAlignment = System.Windows.VerticalAlignment.Stretch, Stroke = Brushes.White, StrokeThickness = 1, Fill = Brushes.LightBlue };
                        layout.Children.Add(r);
                        Grid.SetRow(r, i);
                        Grid.SetColumn(r, j);
                    }

                }
            }
        }
    }
}
