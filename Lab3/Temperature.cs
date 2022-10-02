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
            
            var newValue = this.value;
           
            if (this.type == MeasureType.C)
            {
                
                switch (newType)
                {
                    
                    case MeasureType.C:
                        newValue = this.value;
                        break;
                    
                    case MeasureType.F:
                        newValue = (this.value * 1.8) + 32;
                        break;
                    
                    case MeasureType.R:
                        newValue = (this.value + 273.15) * (9 / 5);
                        break;
                   
                    case MeasureType.K:
                        newValue = this.value + 273.15;
                        break;
                }
            }
            else if (newType == MeasureType.C) 
            {
                switch (this.type) 
                {
                    case MeasureType.C:
                        newValue = this.value;
                        break;
                    case MeasureType.K:
                        newValue = this.value - 273.15; 
                        break;
                    case MeasureType.F:
                        newValue = (this.value - 32) / 1.8; 
                        break;
                    case MeasureType.R:
                        newValue = (this.value - 491.67) * (0.55); 
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
            return instance1 + instance2.To(instance1.type).value;
        }

      
        public static Temperature operator -(Temperature instance1, Temperature instance2)
        {
            return instance1 - instance2.To(instance1.type).value;
        }
        public static Temperature operator *(Temperature instance1, Temperature instance2)
        {
            return instance1 * instance2.To(instance1.type).value;
        }
        public static Temperature operator /(Temperature instance1, Temperature instance2)
        {
           
            return instance1 / instance2.To(instance1.type).value;
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
