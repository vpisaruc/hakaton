using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Rehabilitation
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class addCourse : ContentPage
	{
		public addCourse ()
		{
			InitializeComponent ();
		}

        private void btAddCourse(object sender, EventArgs e)
        {
            AddCourse(courseName.Text, Convert.ToInt32(angle.Text), Convert.ToInt32(numDays.Text),
                Convert.ToInt32(numExercises.Text));
            Navigation.PopAsync();
        }

        void AddCourse(string name, int angle, int numDays, int numExercises)
        {
            //sql инсерт всех данных врача
        }
    }
}