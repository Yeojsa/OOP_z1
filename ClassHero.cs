using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OOP_z1
{
    public class Specifications
    { 
        private double hp; // здоровье
        private double damage; // урон
        private int armor; // броня
        private double evasionChance; // процент уворота

        public static readonly int MinDamage = 1; // минимальное значение урона
        public static readonly int MaxDamage = 20; // максимальное значение урона

        // Конструктор по умолчанию
        public Specifications()
        {
            hp = 0; // здоровье по умолчанию
            damage = 0; // урон по умолчанию
            armor = 0; // броня по умолчанию
            evasionChance = 0; // процент уворота по умолчанию
        }

        // Конструктор класса с начальным здоровьем, уроном, броней и процентом уворота
        public Specifications(double startHp, double startDamage, int startArmor, double startEvasionChance)
        {
            hp = startHp; // начальное здоровье 
            damage = startDamage; // начальный урон
            armor = startArmor; // начальная броня
            evasionChance = startEvasionChance; // начальный процент уворота
        }

        // Получение текущего здоровья
        public double GetHp()
        {
            return hp;
        }

        // Присвоение значений здоровья
        public void SetHp(double newHp)
        {
            const int min = 50; // минимальное значение здоровья
            const int max = 100; // максимальное значение здоровья
            if (newHp >= min && newHp <= max)
            {
                hp = newHp;
            }
            else
            {
                throw new ArgumentException("Некорректное значение здоровья!");
            }
        }

        // Получение текущего урона
        public double GetDamage()
        {
            return damage;
        }

        // Присвоение значений урона
        public void SetDamage(double newDamage)
        {
            if (newDamage >= MinDamage && newDamage <= MaxDamage)
            {
                damage = newDamage;
            }
            else
            {
                throw new ArgumentException("Некорректное значение урона!");
            }
        }

        // Получение текущей брони
        public int GetArmor()
        {
            return armor;
        }

        // Присвоение значений брони
        public void SetArmor(int newArmor)
        {
            const int min = 0; // минимальное значение брони
            const int max = 20; // максимальное значение брони
            if (newArmor >= min && newArmor <= max)
            {
                armor = newArmor;
            }
            else
            {
                throw new ArgumentException("Некорректное значение брони!");
            }
        }

        // Получение текущего процента уворота
        public double GetEvasionChance()
        {
            return evasionChance;
        }

        // Присвоение значений процента уворота
        public void SetEvasionChance(double newEvasionChance)
        {
            const double min = 0; // минимальное значение процента уворота
            const double max = 0.8; // максимальное значение процента уворота
            if (newEvasionChance >= min && newEvasionChance <= max)
            {
                evasionChance = newEvasionChance;
            }
            else
            {
                throw new ArgumentException("Некорректное значение шанса уворота!");
            }
        }

        // Получение урона с учётом блока
        public void TakeDamage(double receivedDamage)
        {
            double evasionRoll = new Random().NextDouble(); // генерация от 0 до 1   
            if (evasionRoll > evasionChance) // проверка на уворот
            {
                hp -= receivedDamage; // уменьшение здоровья
            }
            else
            {
                MessageBox.Show("Игрок: увернулся.");
            }
        }

        // Атака
        public void Attack(Specifications bot)
        {
            double block = 1 - (bot.GetArmor() * 0.05); // блок урона
            double inflictedDamage = damage * block; // урон после блока
            double evasionRoll = new Random().NextDouble(); // генерация от 0 до 1
                                                            // проверка на уворот
            if (evasionRoll > bot.GetEvasionChance())
            {
                bot.TakeDamage(inflictedDamage); // вызов получения урона
            }
            else
            {
                MessageBox.Show("Враг: увернулся.");
            }
        }

       
    }
}
