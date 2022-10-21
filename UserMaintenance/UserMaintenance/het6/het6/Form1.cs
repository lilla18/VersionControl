﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace het6
{
    public partial class Form1 : Form
    {

        BindingList<Entities.RateData> Rates = new BindingList<Entities.RateData>();
        public Form1()
        {
            InitializeComponent();
            Harmadik();
            dataGridView1.DataSource = Rates;
            Otodik();
        }

        private string Harmadik()
        {
            var mnbService = new MnbServiceReference.MNBArfolyamServiceSoapClient();
            var request = new MnbServiceReference.GetExchangeRatesRequestBody()
            {
                currencyNames = "EUR",
                startDate = "2020-01-01",
                endDate = "2020-06-30"
            };

            var response = mnbService.GetExchangeRates(request);
            var result = response.GetExchangeRatesResult;

            return result;
        }

        private void Otodik()
        {
            var xml = new XmlDocument();
            xml.LoadXml(Harmadik());

            foreach (XmlElement element in xml.DocumentElement)
            {
                var rate = new Entities.RateData();
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



        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
