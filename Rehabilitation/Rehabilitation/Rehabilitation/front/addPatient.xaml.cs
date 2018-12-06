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
	public partial class addPatient : ContentPage
	{
		public addPatient ()
		{
			InitializeComponent ();
		}

        private void btAddPatient(object sender, EventArgs e)
        {
            AddPatient(Convert.ToInt32(idPatient.Text));
            Navigation.PopAsync();
        }

        void AddPatient(int id)
        {
            //sql Делаем инсерт в пациента по переданному id(вставляем id самого врача)
            //sql if id != (select id from patients) then throw ex
        }
    }
}