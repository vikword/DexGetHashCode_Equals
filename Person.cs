using System;

//Реализовать свой класс Person(ФИО, Дата рождения, Место рождения, Номер паспорта),
//переопределить в нём методы. GetHashCode и Equals

namespace DexGetHashCode_Equals
{
    class Person
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public string PassportNumber { get; set; }

        public override string ToString()
        {
            return $"{Name}, {BirthDate.ToShortDateString()}, {BirthPlace}, {PassportNumber}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Person person)
            {
                if (this != person)
                {
                    return Name == person.Name
                        && BirthDate == person.BirthDate
                        && BirthPlace == person.BirthPlace
                        && PassportNumber == person.PassportNumber;
                }
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() + BirthDate.GetHashCode() + BirthPlace.GetHashCode() + PassportNumber.GetHashCode();
        }
    }
}
