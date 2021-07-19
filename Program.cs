using System;
using System.Collections.Generic;

//Реализовать упрощенную версию справочника места работ, где ключом является
//класс Person(ФИО, Дата рождения, Место рождения, Номер паспорта), значением -
//string(текущее место работы).В качестве результата работы должно быть следующее:
//Вводим данные о физическом лице: ФИО, Дата рождения, Место рождения, Номер
//паспорта и нам выдают его текущее место работы, если такой человек существует в
//нашей базе.

namespace DexGetHashCode_Equals
{
    class Program
    {
        static void Main()
        {
            Person pers1 = new Person("Иванов Иван Иванович", "07.04.1993", "Бендеры", 123456);
            Person pers2 = new Person("Пертов Сергей Васильевич", "04.09.1992", "Тирасполь", 654321);
            Person pers3 = new Person("Семенов Иван Николаевич", "05.08.1995", "Рыбница", 234123);

            Dictionary<Person, string> workPlace = new Dictionary<Person, string>
            {
                { pers1, "ООО РОГА И КОПЫТА" },
                { pers2, "ООО КАРАНДАШ" },
                { pers3, "ООО МЕЧТА" }
            };

            //Console.WriteLine("Введите данные в формате: Фамилия Имя Отчество, дд.мм.гггг, Город, Номер паспорта");
            //string search = Console.ReadLine();
            bool flag = true;
            foreach (var item in workPlace)
            {
                if (item.Key.Equals("Семенов Иван Николаевич, 05.08.1995, Рыбница, 234123"))
                {
                    Console.WriteLine(item.Value);
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                Console.WriteLine("Объект не существует или некоректно ввели данные.");
            }
        }
    }
}
