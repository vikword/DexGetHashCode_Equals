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
            Dictionary<Person, string> workPlace = new Dictionary<Person, string>()
            {
                {
                    new Person() 
                    { 
                        Name = "Иванов Иван Иванович", 
                        BirthDate = new DateTime(1993,04,07), 
                        BirthPlace = "Бендеры", 
                        PassportNumber = "К 123456" 
                    }, "ООО РОГА И КОПЫТА" 
                },
                {
                    new Person() 
                    { 
                        Name = "Пертов Сергей Васильевич", 
                        BirthDate = new DateTime(1992,09,04), 
                        BirthPlace = "Тирасполь", 
                        PassportNumber = "С 654321" 
                    }, "ООО КАРАНДАШ" 
                },
                {
                    new Person() 
                    { 
                        Name = "Семенов Иван Николаевич", 
                        BirthDate = new DateTime(1995,08,05), 
                        BirthPlace = "Рыбница", 
                        PassportNumber = "В 234123" 
                    }, "ООО МЕЧТА" 
                },
                {
                    new Person()
                    {
                        Name = "d",
                        BirthDate = new DateTime(1000,10,10),
                        BirthPlace = "d",
                        PassportNumber = "d"
                    }, "OOO LG"
                },
            };
            
            bool flagInput = true;
            while (flagInput)
            {
                Console.WriteLine("Введите данные физического лица.");
                Person person = Input();
                bool flagEquals = true;
                foreach (var item in workPlace)
                {
                    if (item.Key.GetHashCode() == person.GetHashCode())
                    {
                        if (item.Key.Equals(person))
                        {
                            Console.WriteLine($"Текущее место работы: {item.Value}\n");
                            Console.Write("Если вы хотите изменить место работы нажмите (y), иначе любую другую клавишу: ");
                            var inputKey = Console.ReadKey();
                            Console.WriteLine();
                            if (inputKey.Key == ConsoleKey.Y)
                            {
                                Console.Write("Введите новое место работы: ");
                                string tmp = Console.ReadLine();
                                workPlace[person] = tmp;
                                Console.WriteLine($"Место работы изменено на: {workPlace[person]}");
                                flagEquals = false;
                                break;
                            }
                            else
                            {
                                flagEquals = false;
                                break;
                            }
                        }
                    }
                }
                if (flagEquals)
                {
                    Console.WriteLine("В справочнике нет информации о данном лице\n");
                }

                Console.Write("Завершить поиск в справочнике? (y/n): ");
                while (true)
                {
                    var inputKey = Console.ReadKey();
                    Console.WriteLine("\n");
                    if (inputKey.Key == ConsoleKey.Y)
                    {
                        flagInput = false;
                        break;
                    }
                    else if (inputKey.Key == ConsoleKey.N)
                    {
                        break;
                    }
                    else if (inputKey.Key != ConsoleKey.Y && inputKey.Key != ConsoleKey.N)
                    {
                        Console.WriteLine("\nДля выхода из программы нажмите Y, для продолжения поиска N\n");
                    }
                }
            }
        }

        public static Person Input()
        {
            Person person = new Person();
            Console.WriteLine("Введите ФИО: ");
            person.Name = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Введите место рождения: ");
            person.BirthPlace = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Введите номер паспорта: (Б 000000");
            person.PassportNumber = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Введите дату рождения (yyyy.mm.dd): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime dateBirth))
                person.BirthDate = dateBirth;
            else
                Console.WriteLine("Введена некорректная дата рождения");
            return person;
        }
    }
}
