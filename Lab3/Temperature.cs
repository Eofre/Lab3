using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public enum MeasureType { C, F , R, K };
    public class Temperature
    {
        private double value;
        private MeasureType type;

        public Temperature(double value, MeasureType type)
        {
            this.value = value;
            this.type = type;
        }

        public static Temperature operator +(Temperature instance, double number)
        {
            var newValue = instance.value + number;
            var length = new Temperature(newValue, instance.type);         
            return length;
        }

        public static Temperature operator +(double number, Temperature instance)
        {
            return instance + number;
        }

        public static Temperature operator -(Temperature instance, double number)
        {
            var newValue = instance.value - number;
            var length = new Temperature(newValue, instance.type);
            return length;
        }

        public static Temperature operator -(double number, Temperature instance)
        {
            return instance - number;
        }

        public static Temperature operator *(Temperature instance, double number)
        {
            var newValue = instance.value * number;
            var length = new Temperature(newValue, instance.type);
            return length;
        }

        public static Temperature operator *(double number, Temperature instance)
        {
            return instance * number;
        }

        public static Temperature operator /(Temperature instance, double number)
        {
            var newValue = instance.value / number;
            var length = new Temperature(newValue, instance.type);
            return length;
        }

        public static Temperature operator /(double number, Temperature instance)
        {
            return instance / number;
        }

        public Temperature To(MeasureType newType)
        {
            // по умолчанию новое значение совпадает со старым
            var newValue = this.value;
            // если текущий тип -- это метр
            if (this.type == MeasureType.C)
            {
                // а теперь рассматриваем все другие ситуации
                switch (newType)
                {
                    // если конвертим в метр, то значение не меняем
                    case MeasureType.C:
                        newValue = this.value;
                        break;
                    // если в км.
                    case MeasureType.F:
                        newValue = (this.value * 1.8) + 32;
                        break;
                    // если в  а.е.
                    case MeasureType.R:
                        newValue = (this.value + 273.15) * (9 / 5);
                        break;
                    // если в парсек
                    case MeasureType.K:
                        newValue = this.value + 273.15;
                        break;
                }
            }
            else if (newType == MeasureType.C) // если новый тип: метр
            {
                switch (this.type) // а тут уже старый тип проверяем
                {
                    case MeasureType.C:
                        newValue = this.value;
                        break;
                    case MeasureType.K:
                        newValue = this.value - 273.15; // кстати это то же код что и выше, только / заменили на *
                        break;
                    case MeasureType.F:
                        newValue = (this.value - 32) / 1.8; // и тут / на *
                        break;
                    case MeasureType.R:
                        newValue = (this.value - 491.67) * (0.55); // и даже тут, просто / на *
                        break;
                }
            }
            else 
            {
                newValue = this.To(MeasureType.C).To(newType).value;
            }
            return new Temperature(newValue, newType);
        }

        public static Temperature operator +(Temperature instance1, Temperature instance2)
        {
            // то есть у текущей длине добавляем число 
            // полученное преобразованием значения второй длины в тип первой длины
            // так как у нас определен operator+(Length instance, double number)
            // то это сработает как ожидается
            return instance1 + instance2.To(instance1.type).value;
        }

        // вычитание двух длин
        public static Temperature operator -(Temperature instance1, Temperature instance2)
        {
            // тут все тоже, только с минусом
            return instance1 - instance2.To(instance1.type).value;
        }

        public string Verbose ()
        {
            string typeVerbose = "";
            switch (this.type)
            {
                case MeasureType.C:
                    typeVerbose = "C";
                    break;
                case MeasureType.F:
                    typeVerbose = "F";
                    break;
                case MeasureType.R:
                    typeVerbose = "R";
                    break;
                case MeasureType.K:
                    typeVerbose = "K";
                    break;
            }
            return String.Format("{0} {1}", this.value, this.type);
        }
    }
}
