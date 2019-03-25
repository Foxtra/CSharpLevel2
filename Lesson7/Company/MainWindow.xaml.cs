/*
 * Изменить WPF-приложение для ведения списка сотрудников компании (из урока 5), 
 * используя связывание данных, DataGrid и ADO.NET.
 * 
 * Создать таблицы Employee и Department в БД MSSQL Server и заполнить списки сущностей начальными данными.
 * Для списка сотрудников и списка департаментов предусмотреть визуализацию (отображение). 
 * Это можно сделать, например, с использованием ComboBox или ListView.
 * Предусмотреть редактирование сотрудников и департаментов. Должна быть возможность изменить департамент у сотрудника. 
 * Список департаментов для выбора можно выводить в ComboBox, и все это можно выводить на дополнительной форме.
 * Предусмотреть возможность создания новых сотрудников и департаментов. 
 * Реализовать данную возможность либо на форме редактирования, либо сделать новую форму.
 * 
 * Сергей Ткачев
 */

using Company.Classes;
using Company.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Company
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal static DB dbd;
        SqlConnection connection;
        SqlDataAdapter adapter;
        DataTable dt;
        public MainWindow()
        {
            InitializeComponent();
            dbd = new DB();
            empList.ItemsSource = dbd.GetEmployees();
            cbDepList.ItemsSource = dbd.GetDeptaments();
            this.DataContext = dbd;

            var connectionStringBuilder = new SqlConnectionStringBuilder
            {
                DataSource = @"(localdb)\MSSQLLocalDB",
                InitialCatalog = "lesson7_2403"
            };

            connection = new SqlConnection(connectionStringBuilder.ConnectionString);
            adapter = new SqlDataAdapter();

            SqlCommand command =
                new SqlCommand(@"SELECT e.ID, e.Name, e.Surname," +
                             " e.Age, e.Salary, d.Name Department" +
                             "FROM Employees e" +
                             "JOIN Departments d on e.DepartmentID = d.ID",
                connection);
            adapter.SelectCommand = command;

            dt = new DataTable();

            adapter.Fill(dt);

            dgWorkers.DataContext = dt.DefaultView;

        }

        /// <summary>Обработка события выбора элемента из списка</summary>
        /// <param name="sender">Объект</param>
        /// <param name="args">Параметры</param>
        private void Selected(object sender, SelectionChangedEventArgs args)
        {
            tbInfo.Text = dbd.GetInfo(sender);
        }

        /// <summary>Обработка нажатия кнопки "редактировать департамент"</summary>
        /// <param name="sender">Объект</param>
        /// <param name="args">Параметры</param>
        private void BtnEditDep_Click(object sender, RoutedEventArgs e)
        {
            if (cbDepList.SelectedItem != null)
            {
                Department editdep = cbDepList.SelectedItem as Department;
                DepEditWindow depEditWindow = new DepEditWindow(editdep.DepartmentID, editdep.Name);
                depEditWindow.Owner = this;
                depEditWindow.Show();
            }
            else
                MessageBox.Show("Выберете отдел для редактирования!");
        }

        /// <summary>Обработка нажатия кнопки "редактировать сотрудника"</summary>
        /// <param name="sender">Объект</param>
        /// <param name="args">Параметры</param>
        private void BtnEditEmp_Click(object sender, RoutedEventArgs e)
        {
            if (empList.SelectedItem != null)
            {
                EmpEditWindow empEditWindow = new EmpEditWindow(empList.SelectedItem as Employee);
                empEditWindow.Owner = this;
                empEditWindow.DataContext = dbd;
                empEditWindow.cboxDepartment.ItemsSource = dbd.GetDeptaments();
                empEditWindow.Show();
            }
            else
                MessageBox.Show("Выберете сотрудника для редактирования!");
        }

        /// <summary>Обработка нажатия кнопки "добавить сотрудника"</summary>
        /// <param name="sender">Объект</param>
        /// <param name="args">Параметры</param>
        private void BtnCreateEmp_Click(object sender, RoutedEventArgs e)
        {
            AddEmpWindow addEmpWindow = new AddEmpWindow();
            addEmpWindow.Owner = this;
            addEmpWindow.DataContext = dbd;
            addEmpWindow.cboxDepartment.ItemsSource = dbd.GetDeptaments();
            addEmpWindow.Show();
        }

        /// <summary>Обработка нажатия кнопки "добавить департамент"</summary>
        /// <param name="sender">Объект</param>
        /// <param name="args">Параметры</param>
        private void BtnCreateDep_Click(object sender, RoutedEventArgs e)
        {
            AddDepWindow addDepWindow = new AddDepWindow();
            addDepWindow.Owner = this;
            addDepWindow.Show();
        }
    }
}
