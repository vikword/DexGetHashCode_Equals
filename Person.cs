using System;

//Реализовать свой класс Person(ФИО, Дата рождения, Место рождения, Номер паспорта),
//переопределить в нём методы. GetHashCode и Equals

namespace DexGetHashCode_Equals
{
    class Person
    {
        public string Name { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string BirthPlace { get; private set; }
        public int PassportNumber { get; private set; }

        public Person(string name, string birthDate, string birthPlace, int passportNumber)
        {
            Name = name;
            if (DateTime.TryParse(birthDate, out _))
            {
                BirthDate = DateTime.Parse(birthDate);
            }
            BirthPlace = birthPlace;
            PassportNumber = passportNumber;
        }

        public override string ToString()
        {
            return $"{Name}, {BirthDate.ToShortDateString()}, {BirthPlace}, {PassportNumber}";
        }

        public override bool Equals(object obj)
        {
            return ToString() == obj.ToString();
        }

        public bool Equals(Person obj)
        {
            if (obj is Person person)
            {
                if (GetHashCode() == person.GetHashCode())
                {
                    if (this != person)
                    {
                        return Name == person.Name
                            && BirthDate == person.BirthDate
                            && BirthPlace == person.BirthPlace
                            && PassportNumber == person.PassportNumber;
                    }
                    else
                    {
                        return false;
                    }
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
