using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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
        List<Dog> dogs = new List<Dog>();
        List<Cat> cats = new List<Cat>();
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
                

                    if (loginMessage.Foreground == Brushes.Red)
                    {

                        adminLoginBT.Content = "Kijelentkezés";
                        loginMessage.Foreground = Brushes.Green;
                        loginMessage.Content = "Sikeres bejelentkzés!";
                        DogTabItem.Visibility = Visibility.Visible;
                        CatTabItem.Visibility = Visibility.Visible;
                        OtherTabItem.Visibility = Visibility.Visible;
                    }
                    else
                    {

                        adminLoginBT.Content = "Bejelentkezés";
                        adminSigned = false;
                        loginMessage.Content = "Jelentkezzen be!";
                        DogTabItem.Visibility = Visibility.Hidden;
                        CatTabItem.Visibility = Visibility.Hidden;
                        OtherTabItem.Visibility = Visibility.Hidden;
                        loginMessage.Foreground = Brushes.Red;
                    }


                  



                    MySqlCommand command = new MySqlCommand("SELECT * FROM `pets`;", connection);
                    DbDataReader reader = await command.ExecuteReaderAsync();
                    DateTime currentDate;
                    DateTime currentUpdated;
                    int petBreadID = 0;
                    pets.Clear();
                    dogs.Clear();
                    cats.Clear();
                    while (await reader.ReadAsync())
                    {
                        if (reader.GetValue(8).ToString() ==string.Empty)
                        {
                            petBreadID = -1;


                        }
                        else
                        {

                            petBreadID = Convert.ToInt32(reader.GetValue(8));


                        }
                        if (reader.GetValue(9).ToString() == string.Empty || reader.GetValue(9)==null)
                        {
                            currentDate = DateTime.Now;
                            currentUpdated = DateTime.Now;
                        }
                        else
                        {

                            currentDate = Convert.ToDateTime(reader.GetValue(9));
                            currentUpdated = Convert.ToDateTime(reader.GetValue(10));



                        }

                        pets.Add(new Pet(iD: Convert.ToInt32(reader.GetValue(0)), petName: reader.GetValue(1).ToString(), breed: reader.GetValue(2).ToString(),
                            gender: reader.GetValue(3).ToString(), castrated: Convert.ToBoolean(reader.GetValue(4)), imgUserDefine: reader.GetValue(5).ToString(),
                            description: reader.GetValue(6).ToString(), contactInfo: reader.GetValue(7).ToString(), petbreadid: petBreadID, 
                            createdAt: currentDate,
                            updatedAt: currentUpdated));

                        if (reader.GetValue(2).ToString() == "kutya")
                        {
                            dogs.Add(new Dog(iD: Convert.ToInt32(reader.GetValue(0)), petName: reader.GetValue(1).ToString(), breed: reader.GetValue(2).ToString(),
                                gender: reader.GetValue(3).ToString(), castrated: Convert.ToBoolean(reader.GetValue(4)), imgUserDefine: reader.GetValue(5).ToString(),
                                description: reader.GetValue(6).ToString(), contactInfo: reader.GetValue(7).ToString(),
                                petbreedid: petBreadID , createdAt: currentDate,
                                updatedAt: currentUpdated));

                        }

                        if (reader.GetValue(2).ToString() == "macska")
                        {
                            cats.Add(new Cat(iD: Convert.ToInt32(reader.GetValue(0)), petName: reader.GetValue(1).ToString(), breed: reader.GetValue(2).ToString(),
                                gender: reader.GetValue(3).ToString(), castrated: Convert.ToBoolean(reader.GetValue(4)), imgUserDefine: reader.GetValue(5).ToString(),
                                description: reader.GetValue(6).ToString(), contactInfo: reader.GetValue(7).ToString(), 
                                petbreedid: petBreadID, createdAt: currentDate,
                                updatedAt: currentUpdated));

                        }

                    }


                    await reader.CloseAsync();

                    command = new MySqlCommand("SELECT `dogbreed` FROM `doglist`;", connection);
                    reader = await command.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {


                        petBreedDogCB.Items.Add(reader.GetValue(0));


                    }

                    await reader.CloseAsync();


                    await connection.CloseAsync();

                    




                }
                else
                {
                    MessageBox.Show("Sikertelen kapcsolódás! A kapcsolat nem jó");

                }
            }
            else
            {
                MessageBox.Show($"Kapcsolódás sikertelen! \n Rossz felhasználónév vagy jelszó!");

            }

        
          

        }


        
       
        int petDogCounter = 0;
        private void nextDogPetBT_Click(object sender, RoutedEventArgs e)
        {


            if (adminSigned)
            {



                if (petDogCounter == dogs.Count)
                {

                    petDogCounter = 0;

                }

                try
                {

                    petDogNameTB.Text = dogs[petDogCounter].PetName;

                    petDogGenderTB.Text = dogs[petDogCounter].Gender;
                    petDogCastratedTB.Text = dogs[petDogCounter].Castrated.ToString();
                    if (dogs[petDogCounter].ImgUserDefine.ToString() == "")
                    {
                        petDogImgUserDefineTB.Text = "NULL";
                    }
                    petDogDescriptionTB.Text = dogs[petDogCounter].Description;
                    PetBreedDogTB.Text = dogs[petDogCounter].Breed;
                    petDogContactInfoTB.Text = dogs[petDogCounter].ContactInfo;
                    petBreedDogCB.SelectedIndex = dogs[petDogCounter].PetBreedId;

                }
                catch (PetException ex)

                {
                    MessageBox.Show(ex.Message);




                }

                finally
                {
                    petDogCounter++;
                }
            }
            else
            {

                MessageBox.Show("Jelentkezzen be!");

            }



        }

        int petCatCounter = 0;
        private void nextCatPetBT_Click(object sender, RoutedEventArgs e)
        {

            if (cats.Count < 0)
            {

                throw new PetException("Adatbázisban nem szerepel cica, javítsa ki!");


            }


            if (petCatCounter == cats.Count)
            {

                petCatCounter = 0;

            }

            petCatNameTB.Text = cats[petCatCounter].PetName;





            petCatCounter++;
        }

        bool InputCheck(string input)
        {
            string pattern = @"^[a-zA-Zéáöőóúüűí]+$";
            string patternNum = "^[0-9]";


            if (!string.IsNullOrEmpty(input))
            {

                bool c = Char.IsUpper(input[0]);
                if (!c)
                {
                    MessageBox.Show("Nagybetűvel kell kezdődnie!");
                    return false;

                }
                else
                {


                    Regex regex = new Regex(pattern);
                    Regex regexNum = new Regex(patternNum);
                    if (regex.IsMatch(input) && !regexNum.IsMatch(input))
                    {
                        return true;

                    }
                    else
                    {
                        MessageBox.Show("Csak betűket tartalmazhat");
                        return false;

                    }
                }
            }

            return true;
        }
        bool InputCheckNum(string input) // még implementálni kell
        {
            return true;
        }

        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj == null) yield return (T)Enumerable.Empty<T>();
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                DependencyObject ithChild = VisualTreeHelper.GetChild(depObj, i);
                if (ithChild == null) continue;
                if (ithChild is T t) yield return t;
                foreach (T childOfChild in FindVisualChildren<T>(ithChild)) yield return childOfChild;
            }
        }

        private async void saveAllDog_Click(object sender, RoutedEventArgs e)
        {
        

          List <string> arrayOfcolumns = new List<string>();




            if (adminSigned)
            {


                using MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["PetsDB"].ConnectionString);

                string temp = petDogNameTB.Text;
                await connection.OpenAsync();

                MySqlCommand command_first = new MySqlCommand("SHOW COLUMNS FROM pets;", connection); //($"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME LIKE 'pets'", connection);
                DbDataReader reader_first = await command_first.ExecuteReaderAsync();


               while(await reader_first.ReadAsync())
                {
                 arrayOfcolumns.Add(reader_first.GetString(0));
                }
                

           

                await connection.CloseAsync();
                int columnIndex = 1;
                
                foreach (TextBox tb in FindVisualChildren<TextBox>(this))
                {
                    temp = tb.Text;

               //     MessageBox.Show(temp);
              
               
                        
                    await connection.OpenAsync();

                   

                    MySqlCommand command = new MySqlCommand($"UPDATE pets SET {arrayOfcolumns.ElementAt(columnIndex)} =  '{temp}' where id = {dogs[petDogCounter].ID-1};", connection);
                    DbDataReader reader = await command.ExecuteReaderAsync();
                    columnIndex++;

                        reader.Close();
                        await connection.CloseAsync();
                

                
                }
                

    

            }
                else
            {

                MessageBox.Show("Jelentkezzen be!");

            }
           
        }

     
    }
}
