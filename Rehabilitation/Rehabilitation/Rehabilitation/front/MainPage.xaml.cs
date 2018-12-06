using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace Rehabilitation
{
    public partial class MainPage : ContentPage
    {
        
        public MainPage()
        {
            
            InitializeComponent();
        }

        


        private async void btSingIn_Clicked(object sender, EventArgs e)
        {
            TypeUser res = TypeUser.Unknown;
            res = SignIn(enLog.Text, enPass.Text);
            int sqlId = 2;//Select по логину и паролю
            if (res == TypeUser.Unknown)
            {
                return;
            }
            else if (res == TypeUser.Doctor)
                await Navigation.PushAsync(new enterPage(sqlId));
            else
                await Navigation.PushAsync(new enterPagePatient(sqlId));
        }

        private async void btSingUp_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new registrationPage());
            
        }

        //Метод для входа в приложения
        TypeUser SignIn(string login, string password)
        {
            TypeUser res; 
            string sqlLogin = "q";//sql
            string sqlPassword = "q";
            if (sqlLogin != login || sqlPassword != password)
            {
                LoginError.IsVisible = true;
                res = TypeUser.Unknown;
                return res;
            }
            string sqlType = "Doctor";
            string sqlType2 = "Patient";
            if (sqlType2 == TypeUser.Doctor.ToString())
            {
                res = TypeUser.Doctor;
            }
            else
            {
                res = TypeUser.Patient;
            }
            return res;

        }

        
    }
}
