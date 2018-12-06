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
	public partial class courseInfo : ContentPage
	{
		public courseInfo (string name)
		{
			InitializeComponent ();
            int sqlNumDays = 1;
            int sqlNumExercises = 1;
            int sqlAngle = 30;//Селет по имени name
            lbNameCourse.Text += name;
            lbAngleCourse.Text += Convert.ToInt32(sqlAngle);
            lbNumDaysCourse.Text += Convert.ToInt32(sqlNumDays);
            lbNumExercisesCourse.Text += Convert.ToInt32(sqlNumExercises);
        }
	}
}