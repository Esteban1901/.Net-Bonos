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
using Datos;
using BLL;

namespace Main1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        InscripcionBLL ibll = new InscripcionBLL();  
        

        public MainWindow()
        {
            InitializeComponent();
            CmbProfesion.ItemsSource = Enum.GetValues(typeof(Profesion));
            CmbProfesion.SelectedIndex= 0;
            CmbExperiencia.ItemsSource = Enum.GetValues(typeof(Experiencia));
            CmbExperiencia.SelectedIndex= 0;


            
        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
        
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Inscripcion nueva = new Inscripcion();


            nueva.Profe = (Profesion)CmbProfesion.SelectedValue;
            nueva.Exp = (Experiencia)CmbExperiencia.SelectedValue;
            nueva.FechaNacimiento = (DateTime)DpFecha.SelectedDate;
            nueva.Nombre = TxtNombre.Text.Trim();

            int fecha = nueva.FechaNacimiento.Date.Year;
            
            DateTime today = DateTime.Today;


           


            double sueldoBase;
            double bonoExperiencia;
            double bonoEdades;
            double sueldo;

            if (CmbProfesion.SelectedValue.ToString() == "Soldador")
            {
                sueldoBase = 860000;
            }
            else if ((CmbProfesion.SelectedValue.ToString() == "Ceramista") | (CmbProfesion.SelectedValue.ToString() == "Pintor") | (CmbProfesion.SelectedValue.ToString() == "Carpintero"))
            {
                sueldoBase = 680000;
            }
            else
            {
                sueldoBase = 1300000;
            }

            if (CmbExperiencia.SelectedValue.ToString() == "Junior")
            {
                bonoExperiencia = 1;
                nueva.BonoExp = "No tiene bono por experiencia";
            }
            else if (CmbExperiencia.SelectedValue.ToString() == "Maestro")
            {
                bonoExperiencia =  0.2;
                nueva.BonoExp = "Si tiene bono por experiencia";

            }
            else {
                bonoExperiencia = 0.5;
                nueva.BonoExp = "Si tiene bono por experiencia";

            }

            if (nueva.Edad < 30) {
                bonoEdades = 100000;
                nueva.BonoEdad = "Si tiene bono trabajador joven";
            }
            else if (nueva.Edad > 55){
                bonoEdades = 150000;
                nueva.BonoEdad = "Si tiene bono trayectoria";
            }
            else
            {
                bonoEdades = 0;
                nueva.BonoEdad = "No tiene bono por edad";
            }

            sueldo = sueldoBase + (sueldoBase * bonoExperiencia) + bonoEdades;
            nueva.Sueldo = sueldo;


            if (TxtNombre.Text.Trim() == "")
            {
                MessageBox.Show("El campo Nombre no puede estar vacío");
            }
            else if (nueva.FechaNacimiento > today)
            {
                MessageBox.Show("La fecha es inválida");

            }
            else
            {
                nueva.Edad = today.Year - fecha;
                ibll.Add(nueva);
            }

            LstInscripciones.ItemsSource = null;
            LstInscripciones.ItemsSource = ibll.GetAll();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
