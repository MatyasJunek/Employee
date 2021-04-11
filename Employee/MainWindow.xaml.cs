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
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace Employee
{
    //Zaměstnanci se ukládají do Listu
    public class Person
    {

        public string Name { get; set; }

        public string Surname { get; set; }

        public int Year { get; set; }

        public Person(string name, string surname, int year)
        {
            Name = name;
            Surname = surname;
            Year = year;
        }
    }

    public class EmployeeClass : Person
    {
       
        public string Education { get; set; }

        public string Job{ get; set; }

        public int GrossSalary { get; set; }

        public EmployeeClass(string name, string surname, int year, string education, string job, int grossSalary) : base(name, surname, year)
        {
            Education = education;
            Job = job;
            GrossSalary = grossSalary;
        }

    }

    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        EmployeeClass s;
        private static Regex regex = new Regex("[^0-9.-]+");
        List<EmployeeClass> Employees = new List<EmployeeClass>();
        public bool pass = true;

        public MainWindow()
        {

            InitializeComponent();
            s = new EmployeeClass("Beze jména", "Bez příjmení", 2000, "Základní škola", "Žádná", 14600);
            this.DataContext = s;
            NameError.DataContext = this;
            SurnameError.DataContext = this;
            YearError.DataContext = this;
            JobError.DataContext = this;
            SalaryError.DataContext = this;
            
    }
        
        private bool IsNameOK()
        {
            if (s.Name.Length > 0)
            {
                pass = true;
                NameErrorVisible = Visibility.Hidden;
                return true;
            }
            else
            {
                pass = false;
                NameErrorVisible = Visibility.Visible;
                return false;
            }
        }
        private Visibility _NameErrorVisible;
        public Visibility NameErrorVisible
        {
            get { return _NameErrorVisible; }
            set
            {
                _NameErrorVisible = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("NameErrorVisible"));
            }
        }
        private string _NameError = "Jméno je povinná položka";
       public string NameErrorText { get { return _NameError; } }

        private bool IsSurnameOK()
        {
            if ((s.Surname.Length > 2 && s.Surname.Length < 20))
            {
                pass = true;
                SurnameErrorVisible = Visibility.Hidden;
                return true;
            }
            else
            {
                pass = false;
                SurnameErrorVisible = Visibility.Visible;
                SurnameErrorText = "Cokoliv";
                return false;
            }
        }
        private Visibility _SurnameErrorVisible;
        public Visibility SurnameErrorVisible
        {
            get { return _SurnameErrorVisible; }
            set
            {
                _SurnameErrorVisible = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SurnameErrorVisible"));
            }
        }
        private string _SurnameError;

        public string SurnameErrorText
        {
            get { return _SurnameError; }
            set
            {
                if (s.Surname.Length < 3)
                {
                    _SurnameError = "Příjmení je příliž krátké";
                }
                else if (s.Surname.Length > 20)
                {
                    _SurnameError = "Příjmení je příliž dlouhé";
                }
                else
                    _SurnameError = "";
                PropertyChanged(this, new PropertyChangedEventArgs("SurnameErrorText"));

            }
        }
       


        private bool IsYearOK()
        {
            if (regex.IsMatch(Convert.ToString(s.Year))&&(Convert.ToString(s.Year).Length > 2))
            {
                pass = true;
                YearErrorVisible = Visibility.Hidden;
                return true;
            }
            else
            {
                pass = false;
                YearErrorVisible = Visibility.Visible;
                YearErrorText = "Cokoliv";
                return false;
            }
        }
        private Visibility _YearErrorVisible;
        public Visibility YearErrorVisible
        {
            get { return _YearErrorVisible; }
            set
            {
                _YearErrorVisible = value;
                PropertyChanged(this, new PropertyChangedEventArgs("YearErrorVisible"));
            }
        }
        private string _YearError;

        public string YearErrorText
        {
            get { return _YearError; }
            set
            {
                if ((s.Year < 1800) || (s.Year > 2021) || (Convert.ToString(s.Year).Length < 2))
                {
                    _YearError = "Neplatný rok";
                }
                else
                    _YearError = "";
                PropertyChanged(this, new PropertyChangedEventArgs("YearErrorText"));

            }
        }

        private bool IsJobOK()
        {
            if (s.Job.Length > 0)
            {
                pass = true;
                JobErrorVisible = Visibility.Hidden;
                return true;
            }
            else
            {
                pass = false;
                JobErrorVisible = Visibility.Visible;
                return false;
            }
        }
        private Visibility _JobErrorVisible;
        public Visibility JobErrorVisible
        {
            get { return _JobErrorVisible; }
            set
            {
                _JobErrorVisible = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("JobErrorVisible"));
            }
        }
        private string _JobError = "Pozice je povinná položka";
        public string JobErrorText { get { return _JobError; } }

        private bool IsSalaryOK()
        {
            if (regex.IsMatch(Convert.ToString(s.GrossSalary)) && (Convert.ToString(s.GrossSalary).Length > 2))
            {
                pass = true;
                SalaryErrorVisible = Visibility.Hidden;
                return true;
            }
            else
            {
                pass = false;
                SalaryErrorVisible = Visibility.Visible;
                SalaryErrorText = "Cokoliv";
                return false;
            }
        }
        private Visibility _SalaryErrorVisible;
        public Visibility SalaryErrorVisible
        {
            get { return _SalaryErrorVisible; }
            set
            {
                _SalaryErrorVisible = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SalaryErrorVisible"));
            }
        }
        private string _SalaryError;

        public string SalaryErrorText
        {
            get { return _SalaryError; }
            set
            {
                if (s.GrossSalary < 14600)
                {
                    _SalaryError = "Plat je příliž nízký";
                }
                else if (Convert.ToString(s.GrossSalary).Length < 2)
                {
                    _SalaryError = "Neplatný plat";
                }

                else
                    _SalaryError = "";
                PropertyChanged(this, new PropertyChangedEventArgs("SalaryErrorText"));

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (pass)
            {
                Success.Foreground = Brushes.Green;
                Employees.Add(new EmployeeClass(Name.Text, Surname.Text, Convert.ToInt32(Year.Text), Education.Text, Job.Text, Convert.ToInt32(Salary.Text)));
                Success.Content = "Přidání zaměstnance proběhlo úspěšně" + " ("+ Employees.Count + ")";
            }
            else
            {
                Success.Foreground = Brushes.Red;
                Success.Content = "Přidání zaměstnance proběhlo neúspěšně";
            }


        }



        private void Name_LostFocus(object sender, RoutedEventArgs e)
        {
            //pass = true;
            //NameError.Content = String.Empty;
            //if ((sender as TextBox).Text.Length < 1)
            //{
            //    pass = false;
            //    NameError.Content = "Jméno je povinná položka";
            //    return;
            //}
            //if ((sender as TextBox).Text.Length > 20)
            //{
            //    pass = false;
            //    NameError.Content = "Jméno může mít nejvýše 20 znaků";
            //    return;
            //}
        }

        private void Surname_LostFocus(object sender, RoutedEventArgs e)
        {
            //pass = true;
            //SurnameError.Content = String.Empty;
            //if ((sender as TextBox).Text.Length < 1)
            //{
            //    pass = false;
            //    SurnameError.Content = "Příjmení je povinná položka";
            //    return;
            //}
            //if ((sender as TextBox).Text.Length > 20)
            //{
            //    pass = false;
            //    SurnameError.Content = "Příjmení může mít nejvýše 20 znaků";
            //    return;
            //}
        }

        private void Year_LostFocus(object sender, RoutedEventArgs e)
        {
            //pass = true;
            //YearError.Content = String.Empty;
            //if (IsTextAllowed((sender as TextBox).Text))
            //{
            //    pass = false;
            //    YearError.Content = "Rok obsahuje neplatné znaky";
            //}
            //if ((sender as TextBox).Text.Length < 4)
            //{
            //    pass = false;
            //    YearError.Content = "Neplatný rok";
            //    return;
            //}
        }

        private void Job_LostFocus(object sender, RoutedEventArgs e)
        {
            //JobError.Content = String.Empty;
            //pass = true;
            //if ((sender as TextBox).Text.Length < 1)
            //{
            //    pass = false;
            //    JobError.Content = "Pozice je povinná položka";
            //    return;
            //}

        }

        private void Salary_LostFocus(object sender, RoutedEventArgs e)
        {
            //pass = true;
            //SalaryError.Content = String.Empty;
            //if (IsTextAllowed((sender as TextBox).Text))
            //{
            //    pass = false;
            //    SalaryError.Content = "Plat obsahuje neplatné znaky";
            //}
            //if ((sender as TextBox).Text.Length < 5)
            //{
            //    pass = false;
            //    SalaryError.Content = "Neplatný plat";
            //    return;
            //}

        }

        private void Education_LostFocus(object sender, RoutedEventArgs e)
        {
            //pass = true;
            //EducationError.Content = String.Empty;
            //if ((sender as ComboBox).Text.Length < 1)
            //{
            //    pass = false;
            //    EducationError.Content = "Vzdělání je povinná položka";
            //    return;
            //}
        }

        private void Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            IsNameOK();
        }

        private void Surname_TextChanged(object sender, TextChangedEventArgs e)
        {
            IsSurnameOK();
        }

        private void Year_TextChanged(object sender, TextChangedEventArgs e)
        {
            IsYearOK();
        }

        private void Job_TextChanged(object sender, TextChangedEventArgs e)
        {
            IsJobOK();
        }

        private void Salary_TextChanged(object sender, TextChangedEventArgs e)
        {
            IsSalaryOK();
        }
    }
}
