using PolistirolbetonDomCalc.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
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

namespace PolistirolbetonDomCalc
{

    public partial class MainWindow : Window
    {
        // Передаем Id услуги
        const int KOMPLEKT_ID = 1;
        const int PROEKT_ID = 2;
        const int GEOLOGI_ID = 3;
        const int GEODEZ_ID = 4;
        const int MONTAJDOM_ID = 5;
        const int ARMO_ID = 6;
        const int SHVI_ID = 7;
        const int DOSTAVKA_ID = 8;
        const int FUNDAMENT_ID = 9;
        const int KROVLYA_ID = 10;
        const int OKNA_ID = 11;
        const int DVER_ID = 12;

        public MainWindow()
        {
            InitializeComponent();
        }

        public async Task<int> GetPriceByIdAsync(int id)
        {
            int resault = 0;
            using (AppContext appContext = new AppContext())
            {
                var komplektObject = await appContext.Prices.SingleOrDefaultAsync(el => el.Id == id);
                if (komplektObject == null)
                {
                    throw new InvalidOperationException("Price is not found");
                }
                else
                {
                    resault = komplektObject.Value;
                }
            }
            return resault;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        // Устанавливаем локаль для России
        CultureInfo russianCulture = new CultureInfo("ru-RU");

        // ПЕРЕМЕННЫЕ ПОЛЕЙ
        int ploshad_value,
            km_value,
            plOkon_value,
            pole1Res,
            pole2Res,
            pole3Res,
            pole4Res,
            pole5Res,
            pole6Res,
            pole7Res,
            pole8Res,
            pole9Res,
            pole10Res,
            pole11Res,
            pole12Res;

        // ****************************************************

        // МЕТОДЫ:

        // Вызов метода при вводе площади дома
        public void enterploshad_TextChanged(object sender, TextChangedEventArgs e)
        {
            // ОЧИСТКА ПОЛЕЙ
            ploshad_value = 0;
            pole1Res = 0;
            pole2Res = 0;
            pole3Res = 0;
            pole4Res = 0;
            pole5Res = 0;
            pole6Res = 0;
            pole7Res = 0;
            pole8Res = 0;
            pole9Res = 0;
            pole10Res = 0;
            pole11Res = 0;
            pole12Res = 0;

            itogstoimost.Text = 0.ToString("C", russianCulture);

            checkBox_proekt.IsChecked = false;
            checkBox_geolog.IsChecked = false;
            checkBox_geodez.IsChecked = false;
            checkBox_steni.IsChecked = false;
            checkBox_motntaj.IsChecked = false;
            checkBox_dostavka.IsChecked = false;
            checkBox_shvi.IsChecked = false;
            checkBox_armo.IsChecked = false;
            checkBox_fundament.IsChecked = false;
            checkBox_krovlya.IsChecked = false;
            checkBox_okna.IsChecked = false;
            checkBox_dver.IsChecked = false;

            steni_stoimost.Text = 0.ToString("C", russianCulture);
            proekt_stoimost.Text = 0.ToString("C", russianCulture);
            geologiya_stoimost.Text = 0.ToString("C", russianCulture);
            geodeziya_stoimost.Text = 0.ToString("C", russianCulture);
            montaj_stoimost.Text = 0.ToString("C", russianCulture);
            dostavka_stoimost.Text = 0.ToString("C", russianCulture);
            shvi_stoimost.Text = 0.ToString("C", russianCulture);
            armopoyas_stoimost.Text = 0.ToString("C", russianCulture);
            fundament_stoimost.Text = 0.ToString("C", russianCulture);
            krovlya_stoimost.Text = 0.ToString("C", russianCulture);
            okna_stoimost.Text = 0.ToString("C", russianCulture);
            dver_stoimost.Text = 0.ToString("C", russianCulture);

            TextBox textBox = (TextBox)sender;
            ploshad_value = textBox.Text == "" ? 0 : Convert.ToInt32(textBox.Text);
        }

        // Производство стенового комплекта с перегородсками - руб / м2
        public async void checkBox_steni_Click(object sender, RoutedEventArgs e)
        {
            int KOMPLEKT = await GetPriceByIdAsync(KOMPLEKT_ID);
            int pole = ploshad_value;
            CheckBox checkBox = (CheckBox)sender;
            bool check = checkBox.IsChecked.Value;

            pole1Res = check == true ? (pole *= KOMPLEKT) : (pole *= 0);

            steni_stoimost.Text = pole1Res.ToString("C", russianCulture);
            itogmetod();
        }

        // Проектирование дома с 3D моделью - руб/м2
        public async void checkBox_proekt_Click(object sender, RoutedEventArgs e)
        {
            int PROEKT = await GetPriceByIdAsync(PROEKT_ID);
            int pole = ploshad_value;
            CheckBox checkBox = (CheckBox)sender;
            bool check = checkBox.IsChecked.Value;

            pole2Res = check == true ? (pole *= PROEKT) : (pole *= 0);
            proekt_stoimost.Text = pole2Res.ToString("C", russianCulture);
            itogmetod();
        }

        // Геология - руб
        public async void checkBox_geolog_Click(object sender, RoutedEventArgs e)
        {
            int GEOLOGI = await GetPriceByIdAsync(GEOLOGI_ID);
            int pole = 0;
            CheckBox checkBox = (CheckBox)sender;
            bool check = checkBox.IsChecked.Value;

            pole3Res = check == true ? (pole += GEOLOGI) : (pole *= 0);
            geologiya_stoimost.Text = pole3Res.ToString("C", russianCulture);
            itogmetod();
        }

        // Геодезия - руб
        public async void checkBox_geodez_Click(object sender, RoutedEventArgs e)
        {
            int GEODEZ = await GetPriceByIdAsync(GEODEZ_ID);
            int pole = 0;
            CheckBox checkBox = (CheckBox)sender;
            bool check = checkBox.IsChecked.Value;

            pole4Res = check == true ? (pole += GEODEZ) : (pole *= 0);
            geodeziya_stoimost.Text = pole4Res.ToString("C", russianCulture);
            itogmetod();
        }

        // Монтаж домокомплекта - руб/м2
        public async void checkBox_montaj_Click(object sender, RoutedEventArgs e)
        {
            int MONTAJDOM = await GetPriceByIdAsync(MONTAJDOM_ID);
            int pole = ploshad_value;
            CheckBox checkBox = (CheckBox)sender;
            bool check = checkBox.IsChecked.Value;

            pole5Res = check == true ? (pole *= MONTAJDOM) : (pole *= 0);
            montaj_stoimost.Text = pole5Res.ToString("C", russianCulture);
            itogmetod();
        }

        // Армопояс - руб/м2
        public async void checkBox_armo_Click(object sender, RoutedEventArgs e)
        {
            int ARMO = await GetPriceByIdAsync(ARMO_ID);
            int pole = ploshad_value;
            CheckBox checkBox = (CheckBox)sender;
            bool check = checkBox.IsChecked.Value;

            pole8Res = check == true ? (pole *= ARMO) : (pole *= 0);
            armopoyas_stoimost.Text = pole8Res.ToString("C", russianCulture);
            itogmetod();
        }

        // Обработка внешних и внетренних швов - руб/м2
        public async void checkBox_shvi_Click(object sender, RoutedEventArgs e)
        {
            int SHVI = await GetPriceByIdAsync(SHVI_ID);
            int pole = ploshad_value;
            CheckBox checkBox = (CheckBox)sender;
            bool check = checkBox.IsChecked.Value;

            pole7Res = check == true ? (pole *= SHVI) : (pole *= 0);
            shvi_stoimost.Text = pole7Res.ToString("C", russianCulture);
            itogmetod();
        }

        // Доставка домокомплекта - руб/1 км
        public async void checkBox_dostavka_Click(object sender, RoutedEventArgs e)
        {
            int DOSTAVKA = await GetPriceByIdAsync(DOSTAVKA_ID);
            int pole = 0;
            CheckBox checkBox = (CheckBox)sender;
            bool check = checkBox.IsChecked.Value;

            pole6Res = check == true ? (pole += km_value * DOSTAVKA) : (pole *= 0);
            dostavka_stoimost.Text = pole6Res.ToString("C", russianCulture);
            itogmetod();
        }

        // Фундамент - руб/м2
        public async void checkBox_fundament_Click(object sender, RoutedEventArgs e)
        {
            int FUNDAMENT = await GetPriceByIdAsync(FUNDAMENT_ID);
            int pole = ploshad_value;
            CheckBox checkBox = (CheckBox)sender;
            bool check = checkBox.IsChecked.Value;

            pole9Res = check == true ? (pole *= FUNDAMENT) : (pole *= 0);
            fundament_stoimost.Text = pole9Res.ToString("C", russianCulture);
            itogmetod();
        }

        // Кровля - руб/м2
        public async void checkBox_krovlya_Click(object sender, RoutedEventArgs e)
        {
            int KROVLYA = await GetPriceByIdAsync(KROVLYA_ID);
            int pole = ploshad_value;
            CheckBox checkBox = (CheckBox)sender;
            bool check = checkBox.IsChecked.Value;

            pole10Res = check == true ? (pole *= KROVLYA) : (pole *= 0);
            krovlya_stoimost.Text = pole10Res.ToString("C", russianCulture);
            itogmetod();
        }

        // Окна - руб/м2
        public async void checkBox_okna_Click(object sender, RoutedEventArgs e)
        {
            int OKNA = await GetPriceByIdAsync(OKNA_ID);
            int pole = 0;
            CheckBox checkBox = (CheckBox)sender;
            bool check = checkBox.IsChecked.Value;

            pole11Res = check == true ? (pole += OKNA * plOkon_value) : (pole *= 0);
            okna_stoimost.Text = pole11Res.ToString("C", russianCulture);
            itogmetod();
        }

        // Дверь входная - от руб.
        public async void checkBox_dver_Click(object sender, RoutedEventArgs e)
        {
            int DVER = await GetPriceByIdAsync(DVER_ID);
            int pole = 0;
            CheckBox checkBox = (CheckBox)sender;
            bool check = checkBox.IsChecked.Value;

            pole12Res = check == true ? (pole += DVER) : (pole *= 0);
            dver_stoimost.Text = pole12Res.ToString("C", russianCulture);
        }

        // Расстояние КМ до объекта
        private void km_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            km_value = textBox.Text == "" ? 0 : Convert.ToInt32(textBox.Text);
        }

        // Поле м2 окон
        private void plOkon_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            plOkon_value = textBox.Text == "" ? 0 : Convert.ToInt32(textBox.Text);
        }

        // Итого стоимость
        public void itogmetod()
        {
            int allsumm = pole1Res + pole2Res + pole3Res + pole4Res + pole5Res + pole6Res + pole7Res + pole8Res + pole9Res + pole10Res + pole11Res + pole12Res;
            itogstoimost.Text = allsumm.ToString("C", russianCulture);
        }

        // Кнопка свернуть
        private void btnMiniMizi_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        // Кнопка закрыть
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


    }
}