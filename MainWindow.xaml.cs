using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Diagnostics;

namespace OOP_z1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //
        private Specifications character;
        private Specifications enemy;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Createbutton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                character = new Specifications(); // объекта класса Specifications
                characteristic(character); // заполнение характеристик
                enemy = new Specifications(100,4,5,0.5);
                // вывод информации о созданном объекте
                MessageBox.Show($"Создан персонаж:\nЗдоровье: {character.GetHp()}\nУрон: {character.GetDamage()}\nБроня: {character.GetArmor()}\nШанс уворота: {character.GetEvasionChance()}");
                MessageBox.Show($"Создан персонаж:\nЗдоровье: {enemy.GetHp()}\nУрон: {enemy.GetDamage()}\nБроня: {enemy.GetArmor()}\nШанс уворота: {enemy.GetEvasionChance()}");
                
            }
            catch (FormatException)
            {
                MessageBox.Show("Пожалуйста, введите корректные числовые значения.");
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Randomcreatebutton_Click(object sender, RoutedEventArgs e)
        {
            while (character.GetHp() > 0 && enemy.GetHp() > 0)
            {
                character.Attack(enemy); //атака игрока
                MessageBox.Show("HP врага: " + enemy.GetHp()); //здоровье врага после атаки
                if (enemy.GetHp() <= 0)
                {
                    break;
                }
                enemy.Attack(character); //атака врага
                MessageBox.Show("HP игрока: " + character.GetHp()); //здоровье игрока после атаки
                if (character.GetHp() <= 0)
                {
                    break;
                }
                MessageBox.Show("\n");
            }

            MessageBox.Show("\n");

            if (character.GetHp() <= 0)
            {
                MessageBox.Show("Игрок проиграл");
            }
            else if (enemy.GetHp() <= 0)
            {
                MessageBox.Show("Враг проиграл");
            }
        }
        /// заполнение характеристик
        void characteristic(Specifications hero)
        {
            double hp = double.Parse(healthTextBox.Text);
            double dmg = double.Parse(damageTextBox.Text);
            int armor = int.Parse(armorTextBox.Text);
            double eva = double.Parse(evasionTextBox.Text);
            hero.SetHp(hp); //присвоения здоровья
            hero.SetDamage(dmg); //присвоения урона;
            hero.SetArmor(armor); //присвоения брони
            hero.SetEvasionChance(eva / 100.0); //присвоения шанса уворота
        }



        private void Box_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Onlynumbers(e.Text); //ввод только чисел
        }

        private bool Onlynumbers(string text)
        {
            Regex regex = new Regex("[^0-9]+"); // только цифры
            return !regex.IsMatch(text);
        }

        ///Тесты
        void test()
        {
            Specifications a; //объект для теста 1
            Specifications b;
            a = new Specifications();
            b = new Specifications(70,10,13,0); //объект для теста 2
            a.SetHp(55); //присвоить объекту a, 55 здоровья
            a.SetDamage(5);//присвоить объекту a, 5 урона
            a.SetArmor(5);//присвоить объекту a, 5 брони
            a.SetEvasionChance(0);//присвоить объекту a, 0 процента уворота  
            Debug.Assert(55 == a.GetHp()); //проверка присвоения здоровья объекту а
            Debug.Assert(5 == a.GetDamage());//проверка присвоения урона объекту а
            Debug.Assert(5 == a.GetArmor());//проверка присвоения брони объекту а
            Debug.Assert(0 == a.GetEvasionChance());//проверка присвоения процента уворота объекту а
            a.Attack(b); //атака объекта a по объекту b
            b.Attack(a); //атака объекта b по объекту а
            Debug.Assert(47.5 == a.GetHp());//проверка уменьшения здоровья объекта а
            Debug.Assert(68.25 == b.GetHp());//проверка уменьшения здоровья объекта b

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            test();
        }
    }
}
