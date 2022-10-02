using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var measureItems = new string[]
        {
            "C",
            "K",
            "F",
            "R",
        };
            cmbFirstType.DataSource = new List<string>(measureItems);
            cmbSecondType.DataSource = new List<string>(measureItems);
            cmbResultType.DataSource = new List<string>(measureItems);
        }
        private MeasureType GetMeasureType(ComboBox comboBox)
        {
            MeasureType measureType;
            switch (comboBox.Text)
            {
                case "C":
                    measureType = MeasureType.C;
                    break;
                case "F":
                    measureType = MeasureType.F;
                    break;
                case "K":
                    measureType = MeasureType.K;
                    break;
                case "R":
                    measureType = MeasureType.R;
                    break;
                default:
                    measureType = MeasureType.C;
                    break;
            }
            return measureType;
        }
        private void Calculate()
        {
            try
            {
                var firstValue = double.Parse(txtFirst.Text);
                var secondValue = double.Parse(txtSecond.Text);

                MeasureType firstType = GetMeasureType(cmbFirstType);
                MeasureType secondType = GetMeasureType(cmbSecondType);
                MeasureType resultType = GetMeasureType(cmbResultType);

                var firstLength = new Temperature(firstValue, firstType);
                var secondLength = new Temperature(secondValue, secondType);

                Temperature sumTemparaure;

                switch (cmbOperation.Text)
                {
                    case "+":
                        sumTemparaure = firstLength + secondLength;
                        break;
                    case "-":
                        sumTemparaure = firstLength - secondLength;
                        break;
                    default:
                        sumTemparaure = new Temperature(0, MeasureType.C);
                        break;
                }

                txtResult.Text = sumTemparaure.To(resultType).Verbose();
            }
            catch (FormatException)
            {

            }

        }
        private void cmbOperation_SelectedIndexChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void txtFirst_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void txtSecond_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void txtResult_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void cmbFirstType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void cmbSecondType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void cmbResultType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Calculate();
        }
    }
}
