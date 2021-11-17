using CurrencyConverterProjectBL.Entities;
using CurrencyConverterProjectBL.Enums;
using CurrencyConverterProjectBL.Services;
using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using CurrencyConverterProjectDAL;

namespace CurrencyConverterProjectBL.Managers
{
    public class ChartsMng
    {
        private ChartSvc chartService;

        // ctor 
        // accessKey is a unique key for accessing the API
        public ChartsMng(string accessKey) 
        {
            chartService = new ChartSvc(accessKey);
        }

        public void getChartByBaseAndSymbols()
        {
            List<string> charts = new List<string>();
            string jsonString;

            Chart getEURUSD = GetChart(chartService.Get(Symbol.EUR.ToString(), Symbol.USD.ToString()));
            // Write info to log file
            if (getEURUSD != null)
            {                
                jsonString = new JavaScriptSerializer().Serialize(getEURUSD);
                charts.Add(jsonString);
            }

            Chart getEURJPY = GetChart(chartService.Get(Symbol.EUR.ToString(), Symbol.JPY.ToString()));
            // Write info to log file
            if  (getEURJPY != null)
            {
                jsonString = new JavaScriptSerializer().Serialize(getEURJPY);
                charts.Add(jsonString);
            }

            Chart getGBPEUR = GetChart(chartService.Get(Symbol.EUR.ToString(), Symbol.GBP.ToString()));
            // Write info to log file
            if (getGBPEUR != null)
            {
                jsonString = new JavaScriptSerializer().Serialize(getGBPEUR);
                charts.Add(jsonString);
            }

            // There is a problem to get USD/ILS from this api..

            //Chart getUSDILS = GetChart(chartService.Get(Symbol.USD.ToString(), Symbol.ILS.ToString()));
            //// Write info to log file
            //if (getUSDILS != null)
            //{
            //jsonString = new JavaScriptSerializer().Serialize(getUSDILS);
            //    charts.Add(getUSDILS.ToString());
            //}

            WriteMng.WriteToFile(charts);
        }

        private Chart GetChart(string response)
        {
            if (response == null)
            {
                // Write info to log file

                return null;
            }

            JSChart jsChart = new JavaScriptSerializer().Deserialize<JSChart>(response);

            // For Backup
            //JSChartBU jsChart = new JavaScriptSerializer().Deserialize<JSChartBU>(response);

            if (jsChart == null) { return null; }
            Chart chart = new Chart();

            // For Backup
            //chart.Name = jsChart.source;

            chart.Name = jsChart.@base;            
            chart.LastUpdate = convertTimeStampToDataTime(jsChart.timestamp).ToString("dd/MM/yyyy HH:mm:ss");

            foreach (string key in jsChart.rates.Keys)
            {
                chart.Rate = jsChart.rates[key].ToString();
                chart.Name += '/' + key;
            }

            // For Backup
            //foreach (string key in jsChart.quotes.Keys)
            //{
            //    chart.Rate = jsChart.quotes[key].ToString();
            //    chart.Name += '/' + key;
            //}

            return chart;
        }

        private DateTime convertTimeStampToDataTime(long timestamp)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(timestamp).ToLocalTime();

            return dateTime;
        }
    }
}
