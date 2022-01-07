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
using System.Data.Entity;
using CramaDaciaModel;
using System.Data;


namespace Crama_Dacia_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    enum ActionState
    {
        New,
        Edit,
        Delete,
        Nothing
    }
    public partial class MainWindow : Window
    {
        ActionState action = ActionState.Nothing;
        CramaDaciaEntitiesModel ctx = new CramaDaciaEntitiesModel();
        CollectionViewSource clientiVSource;
        CollectionViewSource inventarVSource;
      //  CollectionViewSource comenziVSource;
      //  CollectionViewSource tipuriVSource;
        CollectionViewSource sortimenteVSource;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {


            clientiVSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("clientiViewSource")));
            clientiVSource.Source = ctx.Clientis.Local;
            ctx.Clientis.Load();

            sortimenteVSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("sortimenteViewSource")));
            sortimenteVSource.Source = ctx.Sortimentes.Local;
            ctx.Sortimentes.Load();

            inventarVSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("inventarViewSource")));
            inventarVSource.Source = ctx.Inventars.Local;
            ctx.Sortimentes.Load();

            System.Windows.Data.CollectionViewSource clientiViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("clientiViewSource")));
            System.Windows.Data.CollectionViewSource sortimenteViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("sortimenteViewSource")));
            System.Windows.Data.CollectionViewSource inventarViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("inventarViewSource")));
            
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            action = ActionState.New;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            action = ActionState.Edit;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            action = ActionState.Delete;
        }

        

        private void btnPrevious2_Click(object sender, RoutedEventArgs e)
        {
            clientiVSource.View.MoveCurrentToPrevious();

        }

        private void btnNext2_Click(object sender, RoutedEventArgs e)
        {
            clientiVSource.View.MoveCurrentToNext();
        }

        private void SaveClienti()
        {
            Clienti client = null;
            if (action == ActionState.New)
            {
                try
                {
                    //instantiem Customer entity
                    client = new Clienti()
                    {
                        //ClientId = clientIdTextBox.Text.Trim(),
                        Nume = numeTextBox.Text.Trim(),
                        Prenume = prenumeTextBox.Text.Trim()
                    };
                    //adaugam entitatea nou creata in context
                    ctx.Clientis.Add(client);
                    clientiVSource.View.Refresh();
                    //salvam modificarile
                    ctx.SaveChanges();
                }
                //using System.Data;
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
           if (action == ActionState.Edit)
            {
                try
                {
                    client = (Clienti)clientiDataGrid.SelectedItem;
                    client.Nume = nume1TextBox.Text.Trim();
                    client.Prenume = prenumeTextBox.Text.Trim();
                    //salvam modificarile
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (action == ActionState.Delete)
            {
                try
                {
                    client = (Clienti)clientiDataGrid.SelectedItem;
                    ctx.Clientis.Remove(client);
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                clientiVSource.View.Refresh();
            }

        }

        private void btnPrevious1_Click(object sender, RoutedEventArgs e)
        {
            sortimenteVSource.View.MoveCurrentToPrevious();
        }

        private void btnNext1_Click(object sender, RoutedEventArgs e)
        {
            sortimenteVSource.View.MoveCurrentToNext();
        }

        private void SaveSortimente()
        {
            Sortimente sortiment = null;
            if (action == ActionState.New)
            {
                try
                {
                    //instantiem Customer entity
                    sortiment = new Sortimente()
                    {
                        //ClientId = clientIdTextBox.Text.Trim(),
                        An_productie = int.Parse(an_productieTextBox.Text),
                        Soi = soiTextBox.Text.Trim()
                    };
                    //adaugam entitatea nou creata in context
                    ctx.Sortimentes.Add(sortiment);
                    sortimenteVSource.View.Refresh();
                    //salvam modificarile
                    ctx.SaveChanges();
                }
                //using System.Data;
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
           if (action == ActionState.Edit)
            {
                try
                {
                    sortiment = (Sortimente)sortimenteDataGrid.SelectedItem;
                    sortiment.Soi = soiTextBox.Text.Trim();
                    sortiment.An_productie = int.Parse(an_productieTextBox.Text);
                   
                    //salvam modificarile
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (action == ActionState.Delete)
            {
                try
                {
                    sortiment = (Sortimente)sortimenteDataGrid.SelectedItem;
                    ctx.Sortimentes.Remove(sortiment);
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                sortimenteVSource.View.Refresh();
            }
        }

        private void btnPrevious0_Click(object sender, RoutedEventArgs e)
        {
            inventarVSource.View.MoveCurrentToPrevious();
        }

        private void btnNext0_Click(object sender, RoutedEventArgs e)
        {
            inventarVSource.View.MoveCurrentToNext();
        }


        private void SaveInventar()
        {
            Inventar sticla = null;
            if (action == ActionState.New)
            {
                try
                {
                    //instantiem Customer entity
                    sticla = new Inventar()
                    {
                        //ClientId = clientIdTextBox.Text.Trim(),
                        Nume = numeTextBox.Text.Trim(),
                        Tip = tipTextBox.Text.Trim()
                    };
                    //adaugam entitatea nou creata in context
                    ctx.Inventars.Add(sticla);
                    inventarVSource.View.Refresh();
                    //salvam modificarile
                    ctx.SaveChanges();
                }
                //using System.Data;
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
           if (action == ActionState.Edit)
            {
                try
                {
                    sticla = (Inventar)sortimenteDataGrid.SelectedItem;
                    sticla.Nume = numeTextBox.Text.Trim();
                    sticla.Tip = tipTextBox.Text.Trim();

                    //salvam modificarile
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (action == ActionState.Delete)
            {
                try
                {
                    sticla = (Inventar)inventarDataGrid.SelectedItem;
                    ctx.Inventars.Remove(sticla);
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                inventarVSource.View.Refresh();
            }
        }

     /*   private void gbOperations_Click(object sender, RoutedEventArgs e)
        {
            Button SelectedButton = (Button)e.OriginalSource;
            Panel panel = (Panel)SelectedButton.Parent;

            foreach (Button B in panel.Children.OfType<Button>())
            {
                if (B != SelectedButton)
                    B.IsEnabled = false;
            }
            gbActions.IsEnabled = true;
        }*/
        private void ReInitialize()
        {

            Panel panel = gbOperations.Content as Panel;
            foreach (Button B in panel.Children.OfType<Button>())
            {
                B.IsEnabled = true;
            }
            gbActions.IsEnabled = false;
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            ReInitialize();
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            TabItem ti = tblCtrlCramaDacia.SelectedItem as TabItem;

            switch (ti.Header)
            {
                case "Clienti":
                    SaveClienti();
                    break;
                case "Inventar":
                    SaveInventar();
                    break;
                case "Sortimente":
                    SaveSortimente();
                    break;
            }
            ReInitialize();
        }
    }

}
