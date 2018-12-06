using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Entry = Microcharts.Entry;
using SkiaSharp;
using Microcharts;

namespace Rehabilitation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class patientInfo : ContentPage
    {
        List<Entry> entries = new List<Entry>
        {
            new Entry(200)
            {
                Color = SKColor.Parse("#ff6256"),
                Label = "Дата: 11",
                ValueLabel = "200"
            },

            new Entry(300)
            {
                Color = SKColor.Parse("#a9ff52"),
                Label = "Дата: 12",
                ValueLabel = "300"
            },
            new Entry(400)
            {
                Color = SKColor.Parse("#79b600"),
                Label = "Дата: 13",
                ValueLabel = "400"
            },
            new Entry(400)
            {
                Color = SKColor.Parse("#79b600"),
                Label = "Дата: 13",
                ValueLabel = "400"
            }

        };
        public patientInfo()
        {
            InitializeComponent();
            MyChart.Chart = new BarChart { Entries = entries };

        }
    }
}