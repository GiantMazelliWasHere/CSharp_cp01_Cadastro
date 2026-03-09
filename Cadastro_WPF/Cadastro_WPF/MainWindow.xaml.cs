using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cadastro_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Cadastro<string> cadastro = new Cadastro<string>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(EntradaID.Text, out int id) && !string.IsNullOrEmpty(EntradaNome.Text))
            {
                cadastro.Adicionar(id, EntradaNome.Text);
                AtualizarGrid();
                MessageBox.Show("Adicionado com sucesso!");
            }
            EntradaID.Clear();
            EntradaNome.Clear();
        }

        private void BtnList_Click(object sender, RoutedEventArgs e)
        {
            if (cadastro.ObterTodos().Count == 0)
            {
                MessageBox.Show("A lista está vazia.");
            }
            else
            {
                AtualizarGrid();
            }

        }

        private void BtnBuscarS_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(EntradaID.Text, out int id))
            {
                var resultado = cadastro.ObterPorId(id);
                if (resultado != null)
                {
                    EntradaNome.Text = resultado;
                    MessageBox.Show($"Item encontrado: {resultado}", "Busca");
                }
                else
                {
                    MessageBox.Show("ID não encontrado.", "Erro");
                }
            }
        }

        private void BtnRemover_Click(object sender, RoutedEventArgs e)
        {
            cadastro.Remover(int.Parse(EntradaID.Text));
            AtualizarGrid();
        }


        private void BtnBuscaI_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(EntradaBusca.Text, out int id))
            {
                var resultado = cadastro.ObterPorId(id);
                if (resultado != null)
                {
                    EntradaNome.Text = resultado;
                    MessageBox.Show($"Item encontrado: {resultado}", "Busca");
                }
                else
                {
                    MessageBox.Show("ID não encontrado.", "Erro");
                }
            }
        }

        private void BtnLimpar_Click(object sender, RoutedEventArgs e)
        {
            EntradaID.Clear();
            EntradaNome.Clear();
            EntradaBusca.Clear();
            DataGrid.ItemsSource = null;
        }

        private void EntradaID_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox != null)
            {
                string input = textBox.Text;
            }
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AtualizarGrid()
        {
            DataGrid.ItemsSource = cadastro.ObterTodos().ToList();
            DataGrid.Items.Refresh();
        }
    }
}