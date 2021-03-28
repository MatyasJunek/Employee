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
using System.Text.RegularExpressions;

namespace Employee
{
    //Zaměstnanci se ukládají do Listu
    public class Person
    {
        string _name;
        string _surname;
        int _year;

        public string Name
        {
            get { return _name; }
            set
            {
                if (value.Length < 2)
                    throw new Exception("Jméno musí mít alepoň 2 písmena");
                else
                    _name = value;


            }
        }

        public string Surname
        {
            get { return _surname; }
            set
            {
                if (value.Length < 2)
                    throw new Exception("Příjmení musí mít alepoň 2 písmena");
                else
                    _surname = value;
            }
        }

        public int Year
        {
            get { return _year; }
            set
            {
                if (value < 1900)
                    throw new Exception("Neplatný rok narození");
                else
                    _year = value;


            }
        }

        public Person(string name, string surname, int year)
        {
            Name = name;
            Surname = surname;
            Year = year;
        }
    }

    public class EmployeeClass:Person
    {
        string _education;
        string _job;
        int _grossSalary;

        public string Education
        {
            get { return _education; }
            set
            {
                if (value.Length < 2)
                    throw new Exception("Tato informace je povinná");
                else
                    _education = value;
            }
        }

        public string Job
        {
            get { return _job; }
            set
            {
                if (value.Length < 2)
                    throw new Exception("Tato informace je povinná");
                else
                    _job = value;
            }
        }

        public int GrossSalary
        {
            get { return _grossSalary; }
            set
            {
                if (value < 14600)
                    throw new Exception("Nejnižší možný plat je 14600");
                else
                    _grossSalary = value;
            }
        }

        public EmployeeClass(string name, string surname, int year, string education, string job, int grossSalary):base(name, surname, year)
        {
            Education = education;
            Job = job;
            GrossSalary = grossSalary;
        }

    }
    
    public partial class MainWindow : Window
        {
        private static Regex regex = new Regex("[^0-9.-]+");
        List<EmployeeClass> Employees = new List<EmployeeClass>();
        public static bool pass = false;
        private static bool IsTextAllowed(string text)
        {
            return regex.IsMatch(text);
        }
        public MainWindow()
            {
                InitializeComponent();
            }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (pass)
            {
                Success.Foreground = Brushes.Green;
                Employees.Add(new EmployeeClass(Name.Text, Surname.Text, Convert.ToInt32(Year.Text), Education.Text, Job.Text, Convert.ToInt32(Salary.Text)));
                Success.Content = "Přidání zaměstnance proběhlo úspěšně";
            }
            else
            {
                Success.Foreground = Brushes.Red;
                Success.Content = "Přidání zaměstnance proběhlo neúspěšně";
            }
                

        }
      
        

        private void Name_LostFocus(object sender, RoutedEventArgs e)
        {
            pass = true;
            NameError.Content = String.Empty;
            if ((sender as TextBox).Text.Length < 1)
            {
                pass = false;
                NameError.Content = "Jméno je povinná položka";
                return;
            }
            if ((sender as TextBox).Text.Length > 20)
            {
                pass = false;
                NameError.Content = "Jméno může mít nejvýše 20 znaků";
                return;
            }
        }

        private void Surname_LostFocus(object sender, RoutedEventArgs e)
        {
            pass = true;
            SurnameError.Content = String.Empty;
            if ((sender as TextBox).Text.Length < 1)
            {
                pass = false;
                SurnameError.Content = "Příjmení je povinná položka";
                return;
            }
            if ((sender as TextBox).Text.Length > 20)
            {
                pass = false;
                SurnameError.Content = "Příjmení může mít nejvýše 20 znaků";
                return;
            }
        }

        private void Year_LostFocus(object sender, RoutedEventArgs e)
        {
            pass = true;
            YearError.Content = String.Empty;
            if(IsTextAllowed((sender as TextBox).Text))
            {
                pass = false;
                YearError.Content = "Rok obsahuje neplatné znaky";
            }
            if ((sender as TextBox).Text.Length < 4)
            {
                pass = false;
                YearError.Content = "Neplatný rok";
                return;
            }


        }

        private void Job_LostFocus(object sender, RoutedEventArgs e)
        {
            JobError.Content = String.Empty;
            pass = true;
            if ((sender as TextBox).Text.Length < 1)
            {
                pass = false;
                JobError.Content = "Pozice je povinná položka";
                return;
            }
            
        }

        private void Salary_LostFocus(object sender, RoutedEventArgs e)
        {
            pass = true;
            SalaryError.Content = String.Empty;
            if (IsTextAllowed((sender as TextBox).Text))
            {
                pass = false;
                SalaryError.Content = "Plat obsahuje neplatné znaky";
            }
            if ((sender as TextBox).Text.Length < 5)
            {
                pass = false;
                SalaryError.Content = "Neplatný plat";
                return;
            }

        }

        private void Education_LostFocus(object sender, RoutedEventArgs e)
        {
            pass = true;
            EducationError.Content = String.Empty;
            if ((sender as ComboBox).Text.Length < 1)
            {
                pass = false;
               EducationError.Content = "Vzdělání je povinná položka";
                return;
            }
        }
    }
    }
