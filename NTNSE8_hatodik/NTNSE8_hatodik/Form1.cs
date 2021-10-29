using NTNSE8_hatodik.Entities;
using NTNSE8_hatodik.MnbServiceReference;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;

namespace NTNSE8_hatodik
{
    public partial class Form1 : Form
    {
        BindingList<RateData> Rates = new BindingList<RateData>();
        BindingList<string> Currencies = new BindingList<string>();
        public Form1()
        {
            InitializeComponent();
            GetCurrencies();
            Refresh_data();
        }

        private void Refresh_data()
        {
            Rates.Clear();
            WebServiceHivo();
            dataGridView1.DataSource = Rates;
            XMLFeldolgozo();
            Diagramkeszito();
        }

        private string WebServiceHivo()
        {
            var mnbService = new MNBArfolyamServiceSoapClient();
            var request = new GetExchangeRatesRequestBody()
            {
                currencyNames = comboBox1.Text,
                startDate = dateTimePicker1.Value.ToString(),
                endDate = dateTimePicker2.Value.ToString()
            };
            var response = mnbService.GetExchangeRates(request);
            var result = response.GetExchangeRatesResult;
            return result;
        }
        private void XMLFeldolgozo()
        {
            var xml = new XmlDocument();
            xml.LoadXml(WebServiceHivo());

            
            foreach (XmlElement element in xml.DocumentElement)
            {
                var rate = new RateData();
                Rates.Add(rate);

                rate.Date = DateTime.Parse(element.GetAttribute("date"));

                var childElement = (XmlElement)element.ChildNodes[0];
                rate.Currency = childElement.GetAttribute("curr");

                var unit = decimal.Parse(childElement.GetAttribute("unit"));
                var value = decimal.Parse(childElement.InnerText);
                if (unit != 0)
                    rate.Value = value / unit;
            }
        }
        private void Diagramkeszito()
        {
            chartRateData.DataSource = Rates;
            var series = chartRateData.Series[0];
            series.ChartType = SeriesChartType.Line;
            series.XValueMember = "Date";
            series.YValueMembers = "Value";
            series.BorderWidth = 2;

            var legend = chartRateData.Legends[0];
            legend.Enabled = false;

            var chartArea = chartRateData.ChartAreas[0];
            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisY.MajorGrid.Enabled = false;
            chartArea.AxisY.IsStartedFromZero = false;
        }
        private void GetCurrencies()
        {
            MNBArfolyamServiceSoapClient mnbservice = new MNBArfolyamServiceSoapClient();
            GetCurrenciesRequestBody request = new GetCurrenciesRequestBody();
            var response = mnbservice.GetCurrencies(request);
            var result = response.GetCurrenciesResult;
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(result);
            foreach (XmlElement item in xml.DocumentElement.ChildNodes[0])
            {
                string elem = item.InnerText;
                Currencies.Add(elem);
            }
            comboBox1.DataSource = Currencies;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            Refresh_data();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            Refresh_data();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Refresh_data();
        }
    }
}
