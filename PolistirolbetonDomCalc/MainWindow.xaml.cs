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
        public readonly CalculatorService calculatorService = new CalculatorService();

        public MainWindow()
        {
            InitializeComponent();
        }
        // Устанавливаем локаль для России
        CultureInfo russianCulture = new CultureInfo("ru-RU");

        // Поля
        int areaHouseValueSquarMeter,
            DistanceKilometersValue,
            filedWindowArea,
            filedWallsRes,
            filedProjectsRes,
            filedGeologyRes,
            filedGeodesyRes,
            filedConstructionRes,
            filedArmoRes,
            filedSeamsRes,
            filedDeliveryRes,
            filedFundationRes,
            filedRoofRes,
            filedWindowsRes,
            filedDoorRes;

        // Методы
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        // Вызов метода при вводе площади дома (ОЧИСТКА ПОЛЕЙ)
        public void enterploshad_TextChanged(object sender, TextChangedEventArgs e)
        {
            areaHouseValueSquarMeter = 0;
            filedWallsRes = 0;
            filedProjectsRes = 0;
            filedGeologyRes = 0;
            filedGeodesyRes = 0;
            filedConstructionRes = 0;
            filedArmoRes = 0;
            filedSeamsRes = 0;
            filedDeliveryRes = 0;
            filedFundationRes = 0;
            filedRoofRes = 0;
            filedWindowsRes = 0;
            filedDoorRes = 0;

            final_cost.Text = 0.ToString("C", russianCulture);

            checkBox_project.IsChecked = false;
            checkBox_geology.IsChecked = false;
            checkBox_geodesy.IsChecked = false;
            checkBox_walls.IsChecked = false;
            checkBox_construction.IsChecked = false;
            checkBox_delivery.IsChecked = false;
            checkBox_seams.IsChecked = false;
            checkBox_armo.IsChecked = false;
            checkBox_fundation.IsChecked = false;
            checkBox_roof.IsChecked = false;
            checkBox_windows.IsChecked = false;
            checkBox_door.IsChecked = false;

            wall_cost.Text = 0.ToString("C", russianCulture);
            project_cost.Text = 0.ToString("C", russianCulture);
            geology_cost.Text = 0.ToString("C", russianCulture);
            geodesy_cost.Text = 0.ToString("C", russianCulture);
            construction_cost.Text = 0.ToString("C", russianCulture);
            delivery_cost.Text = 0.ToString("C", russianCulture);
            seams_cost.Text = 0.ToString("C", russianCulture);
            armo_cost.Text = 0.ToString("C", russianCulture);
            fundation_cost.Text = 0.ToString("C", russianCulture);
            roof_cost.Text = 0.ToString("C", russianCulture);
            windows_cost.Text = 0.ToString("C", russianCulture);
            door_cost.Text = 0.ToString("C", russianCulture);

            TextBox textBox = (TextBox)sender;
            areaHouseValueSquarMeter = textBox.Text == "" ? 0 : Convert.ToInt32(textBox.Text);
        }

        // Производство стенового комплекта с перегородсками - руб / м2
        public async void checkBox_walls_Click(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            bool check = checkBox.IsChecked.Value;
            if (check == true)
            {
                filedWallsRes = await calculatorService.GetWallsCost(areaHouseValueSquarMeter);
            }
            else
            {
                filedWallsRes = 0;
            }
            wall_cost.Text = filedWallsRes.ToString("C", russianCulture);
            GetTotalCost();
        }

        // Проектирование дома с 3D моделью - руб/м2
        public async void checkBox_project_Click(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            bool check = checkBox.IsChecked.Value;
            if (check == true)
            {
                filedProjectsRes = await calculatorService.GetProjectsCost(areaHouseValueSquarMeter);
            }
            else
            {
                filedProjectsRes = 0;
            }
            project_cost.Text = filedProjectsRes.ToString("C", russianCulture);
            GetTotalCost();
        }

        // Геология - руб
        public async void checkBox_geology_Click(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            bool check = checkBox.IsChecked.Value;
            if (check == true)
            {
                filedGeologyRes = await calculatorService.GetGeologyCost(areaHouseValueSquarMeter);
            }
            else
            {
                filedGeologyRes = 0;
            }
            geology_cost.Text = filedGeologyRes.ToString("C", russianCulture);
            GetTotalCost();
        }

        // Геодезия - руб
        public async void checkBox_geodesy_Click(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            bool check = checkBox.IsChecked.Value;
            if (check == true)
            {
                filedGeodesyRes = await calculatorService.GetGeodesyCost(areaHouseValueSquarMeter);
            }
            else
            {
                filedGeodesyRes = 0;
            }
            geodesy_cost.Text = filedGeodesyRes.ToString("C", russianCulture);
            GetTotalCost();
        }

        // Монтаж домокомплекта - руб/м2
        public async void checkBox_construction_Click(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            bool check = checkBox.IsChecked.Value;
            if (check == true)
            {
                filedConstructionRes = await calculatorService.GetConstructionCost(areaHouseValueSquarMeter);
            }
            else
            {
                filedConstructionRes = 0;
            }
            construction_cost.Text = filedConstructionRes.ToString("C", russianCulture);
            GetTotalCost();
        }

        // Армопояс - руб/м2
        public async void checkBox_armo_Click(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            bool check = checkBox.IsChecked.Value;
            if (check == true)
            {
                filedArmoRes = await calculatorService.GetArmoCost(areaHouseValueSquarMeter);
            }
            else
            {
                filedArmoRes = 0;
            }
            armo_cost.Text = filedArmoRes.ToString("C", russianCulture);
            GetTotalCost();
        }

        // Обработка внешних и внетренних швов - руб/м2
        public async void checkBox_seams_Click(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            bool check = checkBox.IsChecked.Value;
            if (check == true)
            {
                filedSeamsRes = await calculatorService.GetSeamsCost(areaHouseValueSquarMeter);
            }
            else
            {
                filedSeamsRes = 0;
            }
            seams_cost.Text = filedSeamsRes.ToString("C", russianCulture);
            GetTotalCost();
        }

        // Ввод расстояние КМ до объекта (доставка)
        private void km_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            DistanceKilometersValue = textBox.Text == "" ? 0 : Convert.ToInt32(textBox.Text);
        }
        // Доставка домокомплекта - руб/1 км
        public async void checkBox_delivery_Click(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            bool check = checkBox.IsChecked.Value;
            if (check == true)
            {
                filedDeliveryRes = await calculatorService.GetDeliveryCost(areaHouseValueSquarMeter, DistanceKilometersValue);
                if (filedDeliveryRes == 0)
                {
                    checkBox_delivery.IsChecked = false;
                }
            }
            else
            {
                filedDeliveryRes = 0;
            }
            delivery_cost.Text = filedDeliveryRes.ToString("C", russianCulture);
            GetTotalCost();
        }

        // Фундамент - руб/м2
        public async void checkBox_fundation_Click(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            bool check = checkBox.IsChecked.Value;
            if (check == true)
            {
                filedFundationRes = await calculatorService.GetFundationCost(areaHouseValueSquarMeter);
            }
            else
            {
                filedFundationRes = 0;
            }
            fundation_cost.Text = filedFundationRes.ToString("C", russianCulture);
            GetTotalCost();
        }

        // Кровля - руб/м2
        public async void checkBox_roof_Click(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            bool check = checkBox.IsChecked.Value;
            if (check == true)
            {
                filedRoofRes = await calculatorService.GetRoofCost(areaHouseValueSquarMeter);
            }
            else
            {
                filedRoofRes = 0;
            }
            roof_cost.Text = filedRoofRes.ToString("C", russianCulture);
            GetTotalCost();
        }

        // Ввод м2 окон
        private void filed_windown_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            filedWindowArea = textBox.Text == "" ? 0 : Convert.ToInt32(textBox.Text);
        }
        // Окна - руб/м2
        public async void checkBox_windows_Click(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            bool check = checkBox.IsChecked.Value;
            if (check == true)
            {
                filedWindowsRes = await calculatorService.GetWindowsCost(areaHouseValueSquarMeter, filedWindowArea);
                if (filedWindowsRes == 0)
                {
                    checkBox_windows.IsChecked = false;
                }
            }
            else
            {
                filedWindowsRes = 0;
            }
            windows_cost.Text = filedWindowsRes.ToString("C", russianCulture);
            GetTotalCost();
        }

        // Дверь входная - от руб.
        public async void checkBox_door_Click(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            bool check = checkBox.IsChecked.Value;
            if (check == true)
            {
                filedDoorRes = await calculatorService.GetDoorCost(areaHouseValueSquarMeter);
            }
            else
            {
                filedDoorRes = 0;
            }
            door_cost.Text = filedDoorRes.ToString("C", russianCulture);
            GetTotalCost();
        }

        // Итого стоимость
        public void GetTotalCost()
        {
            int allCost = filedWallsRes + filedProjectsRes + filedGeologyRes + filedGeodesyRes + filedConstructionRes + filedArmoRes + filedSeamsRes + filedDeliveryRes + filedFundationRes + filedRoofRes + filedWindowsRes + filedDoorRes;
            final_cost.Text = allCost.ToString("C", russianCulture);
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