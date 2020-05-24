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

namespace Trabalho
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {

            cadastro c = new cadastro();
            c.nome = txtNome.Text;
            c.cpf = txtCPF.Text;
            c.endereco = txtEndereço.Text;
           
                using (Cadastro_ClienteEntities bnc = new Cadastro_ClienteEntities())
                {
                    bnc.cadastro.Add(c);
                    bnc.SaveChanges();

                }   
            

        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.listarCadastro();
        }

        private void listarCadastro()
        {
            using (Cadastro_ClienteEntities bnc = new Cadastro_ClienteEntities())
            {
                var consulta = bnc.cadastro;
                dgDados.ItemsSource = consulta.ToList();

            }
        }

        
    }
}
