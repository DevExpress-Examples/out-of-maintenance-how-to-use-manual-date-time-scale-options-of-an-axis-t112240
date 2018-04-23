using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Resources;
using System.Xml.Linq;

namespace WpfApplication19
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MyModel();
        }
    }

    public class DateTimePoint
    {
        double value;
        DateTime argument;

        public double Value
        {
            get { return value; }
        }

        public DateTime Argument
        {
            get { return argument; }
        }

        public DateTimePoint(DateTime argument, double value)
        {
            this.argument = argument;
            this.value = value;
        }
    }

    public class MyModel
    {
        List<DateTimePoint> rate = new List<DateTimePoint>();

        public List<DateTimePoint> Rate
        {
            get { return rate; }
        }


        public MyModel()
        {

            LoadPoints(rate, LoadFromFile("/GbpUsdRate.xml"));
        }

        XDocument LoadFromFile(string xmlFile)
        {
            return LoadXmlFromResources(xmlFile);
        }

        public static XDocument LoadXmlFromResources(string fileName)
        {

            try
            {
                fileName = "/WpfApplication19;component" + fileName;
                Uri uri = new Uri(fileName, UriKind.RelativeOrAbsolute);
                StreamResourceInfo info = Application.GetResourceStream(uri);
                return XDocument.Load(info.Stream);
            }
            catch
            {
                return null;
            }
        }

        void LoadPoints(List<DateTimePoint> rate, XDocument document)
        {
            if (rate != null && document != null)
            {
                foreach (XElement element in document.Descendants("CurrencyRate"))
                {
                    DateTime argument = DateTime.Parse(element.Element("DateTime").Value);
                    double value = double.Parse(element.Element("Rate").Value, CultureInfo.InvariantCulture);
                    rate.Add(new DateTimePoint(argument, value));
                }
            }
        }
    }
}
