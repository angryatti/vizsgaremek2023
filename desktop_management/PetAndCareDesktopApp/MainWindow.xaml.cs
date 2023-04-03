using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Windows;

namespace PetAndCareDesktopApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        bool adminSigned = false;
        List<Pet> pets = new List<Pet>();
        private async void adminLoginBT_Click(object sender, RoutedEventArgs e)
        {
            using MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["PetsDB"].ConnectionString);

            string checkUser = connection.ConnectionString.ToString().Split(';')[3].Split('=')[1];
            string checkPassword = connection.ConnectionString.ToString().Split(';')[4].Split('=')[1];


            if ((checkUser == usernameTB.Text) && (checkPassword == passwordPB.Password))
            {





                await connection.OpenAsync();
                string temp = connection.State.ToString();
                if (connection.State == ConnectionState.Open && temp == "Open")
                {


                    adminSigned = true;


                    loginMessage.Content = "Sikeres bejelentkzés!";




                    MySqlCommand command = new MySqlCommand("SELECT * FROM `pets`;", connection);
                    DbDataReader reader = await command.ExecuteReaderAsync();
                    DateTime currentDate;
                    DateTime currentUpdated;
                    while (await reader.ReadAsync())
                    {

                        if (reader.GetValue(8).ToString() == string.Empty || reader.GetValue(8)==null)
                        {
                            currentDate = DateTime.Now;
                            currentUpdated = DateTime.Now;
                        }
                        else
                        {

                            currentDate = Convert.ToDateTime(reader.GetValue(8));
                            currentUpdated = Convert.ToDateTime(reader.GetValue(9));



                        }

                        pets.Add(new Pet(iD: Convert.ToInt32(reader.GetValue(0)), petName: reader.GetValue(1).ToString(), breed: reader.GetValue(2).ToString(),
                            gender: reader.GetValue(3).ToString(), castrated: Convert.ToBoolean(reader.GetValue(4)), imgUserDefine: reader.GetValue(5).ToString(),
                            description: reader.GetValue(6).ToString(), contactInfo: reader.GetValue(7).ToString(), createdAt: currentDate,
                            updatedAt: currentUpdated));




                    }

          


                    await connection.CloseAsync();


                    MessageBox.Show(pets[0].CreatedAt.ToString());





                }
            }
        }
    }
}
