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
using System.Windows.Media.Imaging;
using System.Security.Cryptography;

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
            this.SizeToContent = SizeToContent.WidthAndHeight;
        }

        bool adminSigned = false;
        List<Pet> pets = new List<Pet>();
        List<Dog> dogs = new List<Dog>();
        List<Cat> cats = new List<Cat>();
        
        List<OtherPets> otherpets = new List<OtherPets>();
        string portNumber = ConfigurationManager.AppSettings["DefaultLocalHostPort"];
        private async void adminLoginBT_Click(object sender, RoutedEventArgs e)
        {
            using MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["PetsDB"].ConnectionString);
            string checkUser = connection.ConnectionString.ToString().Split(';')[3].Split('=')[1];
            string checkPassword = connection.ConnectionString.ToString().Split(';')[4].Split('=')[1];

            if ((checkUser == usernameTB.Text) && (checkPassword == passwordPB.Password))
            {
                adminSigned = true;

                await connection.OpenAsync();
                string temp = connection.State.ToString();
                if (connection.State == ConnectionState.Open && temp == "Open")
                {
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


                        if (sender is Button)
                        {
                            adminSigned = false;
                            adminLoginBT.Content = "Bejelentkezés";
                            loginMessage.Content = "Jelentkezzen be!";
                            DogTabItem.Visibility = Visibility.Hidden;
                            CatTabItem.Visibility = Visibility.Hidden;
                            OtherTabItem.Visibility = Visibility.Hidden;
                            loginMessage.Foreground = Brushes.Red;
                        }

                    }

                    MySqlCommand command = new MySqlCommand("SELECT * FROM `pets`;", connection);
                    DbDataReader reader = await command.ExecuteReaderAsync();
                    DateTime currentDate;
                    DateTime currentUpdated;
                    int petBreadID = 0;
                    pets.Clear();
                    dogs.Clear();
                    cats.Clear();
                    PetDogSortCB.Items.Clear();
                    PetCatSortCB.Items.Clear();
                    PetDogSortCB.SelectedIndex = Convert.ToInt32(petDogIDTB.Text == "" ? 0 : petDogIDTB.Text);
                    PetCatSortCB.SelectedIndex = Convert.ToInt32(petDogIDTB.Text == "" ? 0 : petDogIDTB.Text);
                    while (await reader.ReadAsync())
                    {
                        if (reader.GetValue(9).ToString() == string.Empty)
                        {
                            petBreadID = -1;


                        }
                        else
                        {

                            petBreadID = Convert.ToInt32(reader.GetValue(9));


                        }
                        if (reader.GetValue(10).ToString() == string.Empty || reader.GetValue(10) == null)
                        {
                            currentDate = DateTime.Now;
                            currentUpdated = DateTime.Now;
                        }
                        else
                        {

                            currentDate = Convert.ToDateTime(reader.GetValue(10));
                            currentUpdated = Convert.ToDateTime(reader.GetValue(11));



                        }
                        pets.Add(new Pet(iD: Convert.ToInt32(reader.GetValue(0)), petName: reader.GetValue(1).ToString(), age: Convert.ToInt32(reader.GetValue(2)),
                            breed: reader.GetValue(3).ToString(),
                            gender: reader.GetValue(4).ToString(), castrated: Convert.ToBoolean(reader.GetValue(5)), imgUserDefine: reader.GetValue(6).ToString(),
                            description: reader.GetValue(7).ToString(), contactInfo: reader.GetValue(8).ToString(), petbreedid: petBreadID,
                            createdAt: currentDate,
                            updatedAt: currentUpdated));
                    }

                    await reader.CloseAsync();

                    foreach (Pet pet in pets)
                    {
                        switch (pet.Breed)
                        {
                            case "kutya": dogs.Add(new Dog(pet.ID, pet.PetName, pet.Age, pet.Breed, pet.Gender, pet.Castrated, pet.ImgUserDefine, pet.Description, pet.ContactInfo, pet.PetBreedId, pet.CreatedAt, pet.UpdatedAt)); break;
                            case "macska": cats.Add(new Cat(pet.ID, pet.PetName, pet.Age, pet.Breed, pet.Gender, pet.Castrated, pet.ImgUserDefine, pet.Description, pet.ContactInfo, pet.PetBreedId, pet.CreatedAt, pet.UpdatedAt)); break;
                            case "egyeb": otherpets.Add(new OtherPets(pet.ID, pet.PetName, pet.Age, pet.Breed, pet.Gender, pet.Castrated, pet.ImgUserDefine, pet.Description, pet.ContactInfo, pet.PetBreedId, pet.CreatedAt, pet.UpdatedAt)); break;
                        }
                    }

                    foreach (Dog dog in dogs)
                    {
                        PetDogSortCB.Items.Add(dog.PetName);
                    }

                    foreach (Cat cat in cats)
                    {
                        PetCatSortCB.Items.Add(cat.PetName);
                    }

                    command = new MySqlCommand("SELECT `dogbreed` FROM `doglist`;", connection);
                    reader = await command.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        petBreedDogCB.Items.Add(reader.GetValue(0));
                    }
                    await reader.CloseAsync();

                    command = new MySqlCommand("SELECT `catbreed` FROM `catlist`;", connection);
                    reader = await command.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        petBreedCatCB.Items.Add(reader.GetValue(0));
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
                if (dogs.Count == 0)
                {
                    foreach (TextBox tb in FindVisualChildren<TextBox>(this))
                    {
                        tb.Text = "";
                    }
                    MessageBox.Show("Nincs kutya az adatbázisban");
                    return;
                }
                try
                {
                    petDogIDTB.Text = dogs[petDogCounter].ID.ToString();
                    petDogAgeTB.Text = (2023 - dogs[petDogCounter].Age).ToString();
                    petDogNameTB.Text = dogs[petDogCounter].PetName;
                    petDogGenderTB.Text = dogs[petDogCounter].Gender;
                    petDogCastratedTB.Text = dogs[petDogCounter].Castrated.ToString();
                    if (dogs[petDogCounter].ImgUserDefine.ToString() == "")
                    {
                        petDogImgUserDefineTB.Text = "NULL";
                    }
                    else
                    {
                        petDogImgUserDefineTB.Text = dogs[petDogCounter].ImgUserDefine;
                    }
                    petDogDescriptionTB.Text = dogs[petDogCounter].Description;
                    PetBreedDogTB.Text = dogs[petDogCounter].Breed;
                    petDogContactInfoTB.Text = dogs[petDogCounter].ContactInfo;
                    petBreedDogCB.SelectedIndex = dogs[petDogCounter].PetBreedId;
                    PetDogSortCB.SelectedValue = petDogNameTB.Text;
                    BitmapImage bmp = new BitmapImage();
                    bmp.BeginInit();
                    bmp.UriSource = new Uri("http://localhost:" + portNumber + "/pet_imgs/" + petDogImgUserDefineTB.Text, UriKind.Absolute);
                    bmp.EndInit();
                    //showDogImg.Width = 200;
                    showDogImg.Source = bmp;
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
            if (adminSigned)
            {
                if (petCatCounter == cats.Count)
                {
                    petCatCounter = 0;
                }
                if (cats.Count == 0)
                {
                    foreach (TextBox tb in FindVisualChildren<TextBox>(this))
                    {
                        tb.Text = "";
                    }
                    MessageBox.Show("Nincs macska az adatbázisban");
                    return;
                }
                try
                {
                    petCatIDTB.Text = cats[petCatCounter].ID.ToString();
                    petCatNameTB.Text = cats[petCatCounter].PetName;

                    petCatGenderTB.Text = cats[petCatCounter].Gender;
                    petCatCastratedTB.Text = cats[petCatCounter].Castrated.ToString();
                    if (cats[petCatCounter].ImgUserDefine.ToString() == "")
                    {
                        petCatImgUserDefineTB.Text = "NULL";
                    }
                    else
                    {
                        petCatImgUserDefineTB.Text = cats[petCatCounter].ImgUserDefine;

                    }

                    petCatDescriptionTB.Text = cats[petCatCounter].Description;
                    PetBreedCatTB.Text = cats[petCatCounter].Breed;
                    petCatContactInfoTB.Text = cats[petCatCounter].ContactInfo;
                    petBreedCatCB.SelectedIndex = cats[petCatCounter].PetBreedId;

                    BitmapImage bmp = new BitmapImage();
                    bmp.BeginInit();
                    bmp.UriSource = new Uri("http://localhost:" + portNumber + "/pet_imgs/" + petCatImgUserDefineTB.Text, UriKind.Absolute);
                    bmp.EndInit();
                  //  showCatImg.Width = 200;
                    showCatImg.Source = bmp;

                }
                catch (PetException ex)

                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    petCatCounter++;
                }
            }
            else
            {
                MessageBox.Show("Jelentkezzen be!");
            }
        }
        bool InputCheck(string input)
        {
            string pattern = @"^[a-zA-Zéáöőóúüűí,;'\\s]|[a-zA-Zéáöőóúüűí]+$";
            bool intBool = false;
            if (!string.IsNullOrEmpty(input))
            {
                if (bool.TryParse(input, out intBool))
                {
                    return true;
                }
                Regex regex = new Regex(pattern);
                if (regex.IsMatch(input))
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Csak betűket tartalmazhat");
                    return false;
                }
            }
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
            List<string> arrayOfcolumns = new List<string>();

            foreach (TextBox tb in FindVisualChildren<TextBox>(this))
            {
                if (tb.Text == "")
                {
                    MessageBox.Show("Üres mezőt nem lehet menteni!");
                    return;
                }
            }
            if (adminSigned)
            {
                using MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["PetsDB"].ConnectionString);

                string temp = petDogNameTB.Text;
                await connection.OpenAsync();

                MySqlCommand command_first = new MySqlCommand("SHOW COLUMNS FROM pets;", connection);
                DbDataReader reader_first = await command_first.ExecuteReaderAsync();

                while (await reader_first.ReadAsync())
                {
                    arrayOfcolumns.Add(reader_first.GetString(0));
                }

                await connection.CloseAsync();

                int columnIndex = 0;

                await connection.OpenAsync();
                foreach (TextBox tb in FindVisualChildren<TextBox>(this))
                {
                    temp = tb.Text;
                    if (columnIndex == 2)
                    {
                        temp = (Convert.ToInt32(temp)+2023).ToString();
                    }
                    MySqlCommand command = new MySqlCommand($"UPDATE pets SET {arrayOfcolumns.ElementAt(columnIndex)} =  '{temp}' where id = {dogs[petDogCounter - 1].ID};", connection);
                    DbDataReader reader = await command.ExecuteReaderAsync();

                    reader.Close();
                    columnIndex++;
                }
                temp = petBreedDogCB.SelectedIndex.ToString();

                MySqlCommand command_cb = new MySqlCommand($"UPDATE pets SET `petbreed_id` =  '{Convert.ToInt32(temp)}' where id = {dogs[petDogCounter].ID - 1};", connection);
                DbDataReader reader_cb = await command_cb.ExecuteReaderAsync();

                reader_cb.Close();
                await connection.CloseAsync();

                MessageBox.Show("Minden adat sikeresen megváltoztatva!");
                adminLoginBT_Click(this, e);
            }
            else
            {
                MessageBox.Show("Jelentkezzen be!");
            }
        }
        private async void saveAllCat_Click(object sender, RoutedEventArgs e)
        {
            List<string> arrayOfcolumns = new List<string>();

            if (adminSigned)
            {
                using MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["PetsDB"].ConnectionString);

                string temp = petCatNameTB.Text;
                await connection.OpenAsync();

                MySqlCommand command_first = new MySqlCommand("SHOW COLUMNS FROM pets;", connection);
                DbDataReader reader_first = await command_first.ExecuteReaderAsync();


                while (await reader_first.ReadAsync())
                {
                    arrayOfcolumns.Add(reader_first.GetString(0));
                }
                await connection.CloseAsync();
                int columnIndex = 0;
                await connection.OpenAsync();
                foreach (TextBox tb in FindVisualChildren<TextBox>(this))
                {
                    temp = tb.Text;
                    MySqlCommand command = new MySqlCommand($"UPDATE pets SET {arrayOfcolumns.ElementAt(columnIndex)} =  '{temp}' where id = {cats[petCatCounter].ID - 1};", connection);
                    DbDataReader reader = await command.ExecuteReaderAsync();

                    reader.Close();
                    columnIndex++;
                }
                await connection.CloseAsync();
                MessageBox.Show("Minden adat sikeresen megváltoztatva!");
                adminLoginBT_Click(this, e);
            }
            else
            {
                MessageBox.Show("Jelentkezzen be!");
            }
        }
        private async void saveAllOther_Click(object sender, RoutedEventArgs e)
        {
            List<string> arrayOfcolumns = new List<string>();
            if (adminSigned)
            {
                using MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["PetsDB"].ConnectionString);
                string temp = petCatNameTB.Text;
                await connection.OpenAsync();

                MySqlCommand command_first = new MySqlCommand("SHOW COLUMNS FROM pets;", connection);
                DbDataReader reader_first = await command_first.ExecuteReaderAsync();

                while (await reader_first.ReadAsync())
                {
                    arrayOfcolumns.Add(reader_first.GetString(0));
                }

                await connection.CloseAsync();
                int columnIndex = 0;
                await connection.OpenAsync();

                foreach (TextBox tb in FindVisualChildren<TextBox>(this))
                {
                    temp = tb.Text;
                    if (InputCheck(temp))
                    {
                        MySqlCommand command = new MySqlCommand($"UPDATE pets SET {arrayOfcolumns.ElementAt(columnIndex)} =  '{temp}' where id = {otherpets[petOtherCounter - 1].ID};", connection);
                        DbDataReader reader = await command.ExecuteReaderAsync();
                        reader.Close();
                    }
                    columnIndex++;
                }
                await connection.CloseAsync();

                MessageBox.Show("Minden adat sikeresen megváltoztatva!");
                adminLoginBT_Click(this, e);
            }
            else
            {
                MessageBox.Show("Jelentkezzen be!");
            }
        }

        int petOtherCounter = 0;
        private void nextOtherPetBT_Click(object sender, RoutedEventArgs e)
        {
            if (adminSigned)
            {
                if (petOtherCounter == otherpets.Count)
                {
                    petOtherCounter = 0;
                }
                if (cats.Count == 0)
                {
                    foreach (TextBox tb in FindVisualChildren<TextBox>(this))
                    {
                        tb.Text = "";
                    }
                    MessageBox.Show("Nincs egyéb állat az adatbázisban");
                    return;
                }
                try
                {
                    petOtherNameTB.Text = otherpets[petOtherCounter].PetName;
                    petOtherGenderTB.Text = otherpets[petOtherCounter].Gender;
                    petOtherCastratedTB.Text = otherpets[petOtherCounter].Castrated.ToString();
                    if (otherpets[petOtherCounter].ImgUserDefine.ToString() == "")
                    {
                        petOtherImgUserDefineTB.Text = "NULL";
                    }
                    petOtherDescriptionTB.Text = otherpets[petOtherCounter].Description;
                    PetBreedOtherTB.Text = otherpets[petOtherCounter].Breed;
                    petOtherContactInfoTB.Text = otherpets[petOtherCounter].ContactInfo;
                    petBreedOtherCB.SelectedIndex = otherpets[petOtherCounter].PetBreedId;
                }
                catch (PetException ex)
                {
                    MessageBox.Show(ex.Message);
                }

                finally
                {
                    petOtherCounter++;
                }
            }
            else
            {
                MessageBox.Show("Jelentkezzen be!");
            }
        }
        private async void addDogBT_Click(object sender, RoutedEventArgs e)
        {
            List<string> arrayOfcolumns = new List<string>();

            foreach (TextBox tb in FindVisualChildren<TextBox>(this))
            {
                if (tb.Text == "")
                {
                    MessageBox.Show("Üres mezőt nem lehet menteni!");
                    return;
                }
            }

            if (adminSigned)
            {
                using MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["PetsDB"].ConnectionString);
                await connection.OpenAsync();

                MySqlCommand command_first = new MySqlCommand("SHOW COLUMNS FROM pets;", connection);
                DbDataReader reader_first = await command_first.ExecuteReaderAsync();

                while (await reader_first.ReadAsync())
                {
                    arrayOfcolumns.Add(reader_first.GetString(0));
                }
                await connection.CloseAsync();
                List<string> tempList = new List<string>();
                int temp;
                await connection.OpenAsync();
                foreach (TextBox tb in FindVisualChildren<TextBox>(this))
                {
                    tempList.Add(tb.Text);
                }
                tempList.Add(petBreedDogCB.SelectedIndex.ToString());
                if (tempList[4] == "True")
                {
                    temp = 1;
                }
                else
                {
                    temp = 0;
                }
                MySqlCommand command = new MySqlCommand($"INSERT INTO pets VALUES (NULL,'{tempList[1]}','{tempList[2]}','{tempList[3]}',{temp},'{tempList[5]}','{tempList[6]}','{tempList[7]}','{tempList[8].ToString()}','{DateTime.Now.ToString("yy-MM-dd")}','{DateTime.Now.ToString("yy-MM-dd")}');", connection);
                DbDataReader reader = await command.ExecuteReaderAsync();
                reader.Close();

                await connection.CloseAsync();

                MessageBox.Show("Minden adat sikeresen feltöltve!");

                nextDogPetBT_Click(this, e);
                adminLoginBT_Click(this, e);
            }
            else
            {
                MessageBox.Show("Jelentkezzen be!");
            }
        }
        private async void addCatBT_Click(object sender, RoutedEventArgs e)
        {
            List<string> arrayOfcolumns = new List<string>();
            foreach (TextBox tb in FindVisualChildren<TextBox>(this))
            {
                if (tb.Text == "")
                {
                    MessageBox.Show("Üres mezőt nem lehet menteni!");
                    return;
                }
            }

            if (adminSigned)
            {
                using MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["PetsDB"].ConnectionString);

                await connection.OpenAsync();

                MySqlCommand command_first = new MySqlCommand("SHOW COLUMNS FROM pets;", connection);
                DbDataReader reader_first = await command_first.ExecuteReaderAsync();

                while (await reader_first.ReadAsync())
                {
                    arrayOfcolumns.Add(reader_first.GetString(0));
                }
                await connection.CloseAsync();
                List<string> tempList = new List<string>();
                int temp;
                await connection.OpenAsync();
                foreach (TextBox tb in FindVisualChildren<TextBox>(this))
                {
                    tempList.Add(tb.Text);
                }

                tempList.Add(petBreedCatCB.SelectedIndex.ToString());
                if (tempList[4] == "True")
                {
                    temp = 1;
                }
                else
                {
                    temp = 0;
                }
                MySqlCommand command = new MySqlCommand($"INSERT INTO pets VALUES (NULL,'{tempList[1]}','{tempList[2]}','{tempList[3]}',{temp},'{tempList[5]}','{tempList[6]}','{tempList[7]}','{tempList[8].ToString()}','{DateTime.Now.ToString("yy-MM-dd")}','{DateTime.Now.ToString("yy-MM-dd")}');", connection);
                DbDataReader reader = await command.ExecuteReaderAsync();

                reader.Close();
                await connection.CloseAsync();
                MessageBox.Show("Minden adat sikeresen feltöltve!");
                nextCatPetBT_Click(this, e);
                adminLoginBT_Click(this, e);
            }
            else
            {
                MessageBox.Show("Jelentkezzen be!");
            }
        }
        private async void addOtherBT_Click(object sender, RoutedEventArgs e)
        {
            List<string> arrayOfcolumns = new List<string>();
            foreach (TextBox tb in FindVisualChildren<TextBox>(this))
            {
                if (tb.Text == "")
                {
                    MessageBox.Show("Üres mezőt nem lehet menteni!");
                    return;
                }
            }

            if (adminSigned)
            {
                using MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["PetsDB"].ConnectionString);

                await connection.OpenAsync();

                MySqlCommand command_first = new MySqlCommand("SHOW COLUMNS FROM pets;", connection);
                DbDataReader reader_first = await command_first.ExecuteReaderAsync();

                while (await reader_first.ReadAsync())
                {
                    arrayOfcolumns.Add(reader_first.GetString(0));
                }
                await connection.CloseAsync();
                List<string> tempList = new List<string>();
                int temp;
                await connection.OpenAsync();
                foreach (TextBox tb in FindVisualChildren<TextBox>(this))
                {
                    tempList.Add(tb.Text);
                }

                tempList.Add(petBreedOtherCB.SelectedIndex.ToString());
                if (tempList[4] == "True")
                {
                    temp = 1;
                }
                else
                {
                    temp = 0;
                }
                MySqlCommand command = new MySqlCommand($"INSERT INTO pets VALUES (NULL,'{tempList[1]}','{tempList[2]}','{tempList[3]}',{temp},'{tempList[5]}','{tempList[6]}','{tempList[7]}','{tempList[8].ToString()}','{DateTime.Now.ToString("yy-MM-dd")}','{DateTime.Now.ToString("yy-MM-dd")}');", connection);
                DbDataReader reader = await command.ExecuteReaderAsync();

                reader.Close();
                await connection.CloseAsync();
                MessageBox.Show("Minden adat sikeresen feltöltve!");
                nextOtherPetBT_Click(this, e);
                adminLoginBT_Click(this, e);
            }
            else
            {
                MessageBox.Show("Jelentkezzen be!");
            }
        }

        private void newDogBT_Click(object sender, RoutedEventArgs e)
        {
            foreach (TextBox tb in FindVisualChildren<TextBox>(this))
            {
                if (tb.Text != "root")
                    tb.Text = "";
            }
            PetBreedDogTB.Text = "kutya";
            petBreedDogCB.SelectedIndex = 0;
            petDogIDTB.Text = "zárolt";
            PetDogSortCB.SelectedIndex = 0;
        }
        private void newCatBT_Click(object sender, RoutedEventArgs e)
        {
            foreach (TextBox tb in FindVisualChildren<TextBox>(this))
            {
                if (tb.Text != "root")
                    tb.Text = "";
            }
            PetBreedCatTB.Text = "macska";
            petBreedCatCB.SelectedIndex = 0;
            petCatIDTB.Text = "zárolt";
            PetCatSortCB.SelectedIndex = 0;
        }
        private void newOtherBT_Click(object sender, RoutedEventArgs e)
        {
            foreach (TextBox tb in FindVisualChildren<TextBox>(this))
            {
                if (tb.Text != "root")
                    tb.Text = "";
            }
            PetBreedOtherTB.Text = "egyéb";
            petBreedOtherCB.SelectedIndex = 0;
            petOtherIDTB.Text = "zárolt";
            PetOtherSortCB.SelectedIndex = 0;
        }
        private void previousDogPetBT_Click(object sender, RoutedEventArgs e)
        {
            if (adminSigned)
            {
                petDogCounter--;
                if (petDogCounter < 0)
                {
                    petDogCounter = dogs.Count - 1;
                }
                if (dogs.Count == 0)
                {
                    foreach (TextBox tb in FindVisualChildren<TextBox>(this))
                    {
                        tb.Text = "";
                    }
                    MessageBox.Show("Nincs kutya az adatbázisban");
                    return;
                }
                try
                {
                    petDogIDTB.Text = dogs[petDogCounter].ID.ToString();
                    petDogNameTB.Text = dogs[petDogCounter].PetName;

                    petDogGenderTB.Text = dogs[petDogCounter].Gender;
                    petDogCastratedTB.Text = dogs[petDogCounter].Castrated.ToString();
                    if (dogs[petDogCounter].ImgUserDefine.ToString() == "")
                    {
                        petDogImgUserDefineTB.Text = "NULL";
                    }
                    else
                    {
                        petDogImgUserDefineTB.Text = dogs[petDogCounter].ImgUserDefine;

                    }
                    petDogDescriptionTB.Text = dogs[petDogCounter].Description;
                    PetBreedDogTB.Text = dogs[petDogCounter].Breed;
                    petDogContactInfoTB.Text = dogs[petDogCounter].ContactInfo;
                    petBreedDogCB.SelectedIndex = dogs[petDogCounter].PetBreedId;
                    BitmapImage bmp = new BitmapImage();
                    bmp.BeginInit();
                    bmp.UriSource = new Uri("http://localhost:" + portNumber + "/pet_imgs/" + petDogImgUserDefineTB.Text, UriKind.Absolute);
                    bmp.EndInit();
                 //   showDogImg.Width = Width / 3;
                    showDogImg.Source = bmp;
                }
                catch (PetException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Jelentkezzen be!");
            }
        }
        private void previousCatPetBT_Click(object sender, RoutedEventArgs e)
        {
            if (adminSigned)
            {
                petCatCounter--;

                if (petCatCounter < 0)
                {
                    petCatCounter = cats.Count - 1;
                }

                if (cats.Count == 0)
                {
                    foreach (TextBox tb in FindVisualChildren<TextBox>(this))
                    {
                        tb.Text = "";
                    }
                    MessageBox.Show("Nincs cica az adatbázisban");
                    return;
                }

                try
                {
                    petCatIDTB.Text = cats[petCatCounter].ID.ToString();
                    petCatNameTB.Text = cats[petCatCounter].PetName;

                    petCatGenderTB.Text = cats[petCatCounter].Gender;
                    petCatCastratedTB.Text = cats[petCatCounter].Castrated.ToString();
                    if (cats[petCatCounter].ImgUserDefine.ToString() == "")
                    {
                        petCatImgUserDefineTB.Text = "NULL";
                    }
                    else
                    {
                        petCatImgUserDefineTB.Text = cats[petCatCounter].ImgUserDefine;

                    }
                    petCatDescriptionTB.Text = cats[petCatCounter].Description;
                    PetBreedCatTB.Text = cats[petCatCounter].Breed;
                    petCatContactInfoTB.Text = cats[petCatCounter].ContactInfo;
                    petBreedCatCB.SelectedIndex = cats[petCatCounter].PetBreedId;

                    BitmapImage bmp = new BitmapImage();
                    bmp.BeginInit();
                    bmp.UriSource = new Uri("http://localhost:" + portNumber + "/pet_imgs/" + petCatImgUserDefineTB.Text, UriKind.Absolute);
                    bmp.EndInit();
                  //  showCatImg.Width = Width / 3;
                    showCatImg.Source = bmp;
                }
                catch (PetException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Jelentkezzen be!");
            }
        }

        private void previousOtherPetBT_Click(object sender, RoutedEventArgs e)
        {
            if (adminSigned)
            {
                petOtherCounter--;

                if (petOtherCounter < 0)
                {
                    petOtherCounter = otherpets.Count - 1;
                }

                if (otherpets.Count == 0)
                {
                    foreach (TextBox tb in FindVisualChildren<TextBox>(this))
                    {
                        tb.Text = "";
                    }
                    MessageBox.Show("Nincs egyéb az adatbázisban");
                    return;
                }

                try
                {
                    petOtherIDTB.Text = otherpets[petOtherCounter].ID.ToString();
                    petOtherNameTB.Text = otherpets[petOtherCounter].PetName;

                    petOtherGenderTB.Text = otherpets[petOtherCounter].Gender;
                    petOtherCastratedTB.Text = otherpets[petOtherCounter].Castrated.ToString();
                    if (otherpets[petOtherCounter].ImgUserDefine.ToString() == "")
                    {
                        petOtherImgUserDefineTB.Text = "NULL";
                    }
                    else
                    {
                        petOtherImgUserDefineTB.Text = otherpets[petOtherCounter].ImgUserDefine;

                    }
                    petOtherDescriptionTB.Text = otherpets[petOtherCounter].Description;
                    PetBreedOtherTB.Text = otherpets[petOtherCounter].Breed;
                    petOtherContactInfoTB.Text = otherpets[petOtherCounter].ContactInfo;
                    petBreedOtherCB.SelectedIndex = otherpets[petOtherCounter].PetBreedId;

                    BitmapImage bmp = new BitmapImage();
                    bmp.BeginInit();
                    bmp.UriSource = new Uri("http://localhost:" + portNumber + "/pet_imgs/" + petOtherImgUserDefineTB.Text, UriKind.Absolute);
                    bmp.EndInit();
                    //  showCatImg.Width = Width / 3;
                    showOtherImg.Source = bmp;
                }
                catch (PetException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Jelentkezzen be!");
            }
        }
        public string hashforimg(string input)
        {
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            MD5 md5 = MD5.Create();
            byte[] hashBytes = md5.ComputeHash(inputBytes);
            return Convert.ToHexString(hashBytes);
        }
        public async void UploadImageDog()
        {
            System.Net.WebClient Client = new System.Net.WebClient();
            Client.Headers.Add("Content-Type", "binary/octet-stream");
            byte[] result = Client.UploadFile($"http://localhost:" + portNumber + "/upload", "POST", UploadFilePath);
            using MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["PetsDB"].ConnectionString);
            await connection.OpenAsync();
            string temp = hashforimg(DialogFileName) + ".jpg";
            MySqlCommand command = new MySqlCommand($"UPDATE pets SET  img_userdefine =  '{temp}' where id = {dogs[petDogCounter - 1].ID};", connection);
            DbDataReader reader = await command.ExecuteReaderAsync();
            reader.Close();
            await connection.CloseAsync();
            MessageBox.Show("A kép sikeresen feltöltve");
            adminLoginBT_Click(sender: this, e: null);
        }

        public async void UploadImageCat()
        {
            System.Net.WebClient Client = new System.Net.WebClient();
            Client.Headers.Add("Content-Type", "binary/octet-stream");
            byte[] result = Client.UploadFile($"http://localhost:" + portNumber + "/upload", "POST", UploadFilePath);
            using MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["PetsDB"].ConnectionString);
            await connection.OpenAsync();
            string temp = hashforimg(DialogFileName) + ".jpg";
            MySqlCommand command = new MySqlCommand($"UPDATE pets SET  img_userdefine =  '{temp}' where id = {cats[petCatCounter - 1].ID};", connection);
            DbDataReader reader = await command.ExecuteReaderAsync();
            reader.Close();
            await connection.CloseAsync();
            MessageBox.Show("A kép sikeresen feltöltve");
            adminLoginBT_Click(sender: this, e: null);
        }

        public async void UploadImageOther()
        {
            System.Net.WebClient Client = new System.Net.WebClient();
            Client.Headers.Add("Content-Type", "binary/octet-stream");
            byte[] result = Client.UploadFile($"http://localhost:" + portNumber + "/upload", "POST", UploadFilePath);
            using MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["PetsDB"].ConnectionString);
            await connection.OpenAsync();
            string temp = hashforimg(DialogFileName) + ".jpg";
            MySqlCommand command = new MySqlCommand($"UPDATE pets SET  img_userdefine =  '{temp}' where id = {otherpets[petOtherCounter - 1].ID};", connection);
            DbDataReader reader = await command.ExecuteReaderAsync();
            reader.Close();
            await connection.CloseAsync();
            MessageBox.Show("A kép sikeresen feltöltve");
            adminLoginBT_Click(sender: this, e: null);
        }

        public string UploadFilePath { get; set; }
        public string DialogFileName { get; set; }
        private void browseImgForDogBT_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "dogcucc";
            dlg.DefaultExt = ".jpg";
            dlg.Filter = "JPG fájl (.jpg)|*.jpg";

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                DialogFileName = dlg.SafeFileName;
                UploadFilePath = dlg.FileName;
                pathImgTheDogLB.Content = UploadFilePath;
            }
        }
        private void browseImgForCatBT_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "catcucc";
            dlg.DefaultExt = ".jpg";
            dlg.Filter = "JPG fájl (.jpg)|*.jpg";

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                DialogFileName = dlg.SafeFileName;
                UploadFilePath = dlg.FileName;
                pathImgTheCatLB.Content = UploadFilePath;
            }
        }
        private void browseImgForOtherBT_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "othercucc";
            dlg.DefaultExt = ".jpg";
            dlg.Filter = "JPG fájl (.jpg)|*.jpg";

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                DialogFileName = dlg.SafeFileName;
                UploadFilePath = dlg.FileName;
                pathImgTheOtherLB.Content = UploadFilePath;
            }
        }

        private void doImgUploadToDogBT_Click(object sender, RoutedEventArgs e)
        {
            if (UploadFilePath != null)
            {
                UploadImageDog();
            }
        }
        private void doImgUploadToCatBT_Click(object sender, RoutedEventArgs e)
        {
            if (UploadFilePath != null)
            {
                UploadImageCat();
            }
        }
        private void doImgUploadToOtherBT_Click(object sender, RoutedEventArgs e)
        {
            if (UploadFilePath != null)
            {
                UploadImageOther();
            }
        }
        private async void removeDogBT_Click(object sender, RoutedEventArgs e)
        {
            using MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["PetsDB"].ConnectionString);
            await connection.OpenAsync();

            MySqlCommand command = new MySqlCommand($"DELETE FROM pets WHERE (id={petDogIDTB.Text} AND pet_name='{petDogNameTB.Text}');", connection);
            DbDataReader reader = await command.ExecuteReaderAsync();

            reader.Close();
            await connection.CloseAsync();

            adminLoginBT_Click(sender: this, e: e);
            petDogCounter = 0;
            nextDogPetBT_Click(sender: this, e: e);
        }
        private async void removeCatBT_Click(object sender, RoutedEventArgs e)
        {
            using MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["PetsDB"].ConnectionString);
            PetCatSortCB.SelectedIndex = 0;

            await connection.OpenAsync();

            MySqlCommand command = new MySqlCommand($"DELETE FROM pets WHERE id=({petCatIDTB.Text} AND pet_name='{petCatNameTB.Text}');", connection);
            DbDataReader reader = await command.ExecuteReaderAsync();

            reader.Close();
            await connection.CloseAsync();

            adminLoginBT_Click(sender: this, e: e);
            petCatCounter = 0;
            nextCatPetBT_Click(sender: this, e: e);
        }

        private async void removeOtherBT_Click(object sender, RoutedEventArgs e)
        {
            using MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["PetsDB"].ConnectionString);
            PetOtherSortCB.SelectedIndex = 0;

            await connection.OpenAsync();

            MySqlCommand command = new MySqlCommand($"DELETE FROM pets WHERE id=({petOtherIDTB.Text} AND pet_name='{petOtherNameTB.Text}');", connection);
            DbDataReader reader = await command.ExecuteReaderAsync();

            reader.Close();
            await connection.CloseAsync();

            adminLoginBT_Click(sender: this, e: e);
            petOtherCounter = 0;
            nextOtherPetBT_Click(sender: this, e: e);
        }
        private void PetDogSortCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (PetDogSortCB.SelectedIndex != -1)
                {
                    petDogIDTB.Text = dogs[PetDogSortCB.SelectedIndex].ID.ToString();
                    petDogNameTB.Text = dogs[PetDogSortCB.SelectedIndex].PetName;
                    petDogGenderTB.Text = dogs[PetDogSortCB.SelectedIndex].Gender;
                    petDogCastratedTB.Text = dogs[PetDogSortCB.SelectedIndex].Castrated.ToString();
                    if (dogs[PetDogSortCB.SelectedIndex].ImgUserDefine.ToString() == "")
                    {
                        petDogImgUserDefineTB.Text = "NULL";
                    }
                    else
                    {
                        petDogImgUserDefineTB.Text = dogs[PetDogSortCB.SelectedIndex].ImgUserDefine;

                    }
                    petDogDescriptionTB.Text = dogs[PetDogSortCB.SelectedIndex].Description;
                    PetBreedDogTB.Text = dogs[PetDogSortCB.SelectedIndex].Breed;
                    petDogContactInfoTB.Text = dogs[PetDogSortCB.SelectedIndex].ContactInfo;
                    petBreedDogCB.SelectedIndex = dogs[PetDogSortCB.SelectedIndex].PetBreedId;

                    BitmapImage bmp = new BitmapImage();
                    bmp.BeginInit();
                    bmp.UriSource = new Uri("http://localhost:" + portNumber + "/pet_imgs/" + petDogImgUserDefineTB.Text, UriKind.Absolute);
                    bmp.EndInit();
              //      showDogImg.Width = Width / 3;
                    showDogImg.Source = bmp;
                }
            }
            catch (PetException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void PetCatSortCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (PetCatSortCB.SelectedIndex != -1)
                {
                    petCatIDTB.Text = cats[PetCatSortCB.SelectedIndex].ID.ToString();
                    petCatNameTB.Text = cats[PetCatSortCB.SelectedIndex].PetName;
                    petCatGenderTB.Text = cats[PetCatSortCB.SelectedIndex].Gender;
                    petCatCastratedTB.Text = cats[PetCatSortCB.SelectedIndex].Castrated.ToString();
                    if (cats[PetCatSortCB.SelectedIndex].ImgUserDefine.ToString() == "")
                    {
                        petCatImgUserDefineTB.Text = "NULL";
                    }
                    else
                    {
                        petCatImgUserDefineTB.Text = cats[PetCatSortCB.SelectedIndex].ImgUserDefine;
                    }
                    petCatDescriptionTB.Text = cats[PetCatSortCB.SelectedIndex].Description;
                    PetBreedCatTB.Text = cats[PetCatSortCB.SelectedIndex].Breed;
                    petCatContactInfoTB.Text = cats[PetCatSortCB.SelectedIndex].ContactInfo;
                    petBreedCatCB.SelectedIndex = cats[PetCatSortCB.SelectedIndex].PetBreedId;


                    BitmapImage bmp = new BitmapImage();
                    bmp.BeginInit();
                    bmp.UriSource = new Uri("http://localhost:" + portNumber + "/pet_imgs/" + petCatImgUserDefineTB.Text, UriKind.Absolute);
                    bmp.EndInit();
             //       showCatImg.Width = Width / 3;
                    showCatImg.Source = bmp;

                }
            }
            catch (PetException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PetOtherSortCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (PetOtherSortCB.SelectedIndex != -1)
                {
                    petOtherIDTB.Text = otherpets[PetOtherSortCB.SelectedIndex].ID.ToString();
                    petOtherNameTB.Text = otherpets[PetOtherSortCB.SelectedIndex].PetName;
                    petOtherGenderTB.Text = otherpets[PetOtherSortCB.SelectedIndex].Gender;
                    petOtherCastratedTB.Text = otherpets[PetOtherSortCB.SelectedIndex].Castrated.ToString();
                    if (otherpets[PetOtherSortCB.SelectedIndex].ImgUserDefine.ToString() == "")
                    {
                        petOtherImgUserDefineTB.Text = "NULL";
                    }
                    else
                    {
                        petOtherImgUserDefineTB.Text = cats[PetCatSortCB.SelectedIndex].ImgUserDefine;
                    }
                    petOtherDescriptionTB.Text = otherpets[PetOtherSortCB.SelectedIndex].Description;
                    PetBreedOtherTB.Text = otherpets[PetOtherSortCB.SelectedIndex].Breed;
                    petOtherContactInfoTB.Text = otherpets[PetOtherSortCB.SelectedIndex].ContactInfo;
                    petBreedOtherCB.SelectedIndex = otherpets[PetOtherSortCB.SelectedIndex].PetBreedId;


                    BitmapImage bmp = new BitmapImage();
                    bmp.BeginInit();
                    bmp.UriSource = new Uri("http://localhost:" + portNumber + "/pet_imgs/" + petOtherImgUserDefineTB.Text, UriKind.Absolute);
                    bmp.EndInit();
                    
                    showOtherImg.Source = bmp;

                }
            }
            catch (PetException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e) => this.SizeToContent = SizeToContent.WidthAndHeight;
    }
}