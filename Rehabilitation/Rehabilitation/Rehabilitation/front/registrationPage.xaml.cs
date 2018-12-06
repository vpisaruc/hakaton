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
    public partial class registrationPage : ContentPage
    {
        public registrationPage()
        {
            InitializeComponent();
        }

        private async void btnReg_Clicked(object sender, EventArgs e)
        {
            User user;
            user = Registration(enLogin.Text, enPass.Text, enReentryPass.Text, enFIO.Text, pickUser.Items[pickUser.SelectedIndex]);
            if (user == null)
                return;
            await Navigation.PopAsync();
        }

        //Метод для регистрации в приложении
        User Registration(string login, string password, string confirmationPassword,
            string fullName, string type)
        {
            //Не совпадение паролей
            if (password != confirmationPassword)
            {
                PassError.IsVisible = true;
                return null;
            }

            string sqlLogin = "test";//sql

            //Логин уже существует
            if (sqlLogin == login)
            {
                LoginError.IsVisible = true;
                return null;
            }

            User user = new User(login, password, fullName);

            if (type == TypeUser.Doctor.ToString())
            {
                Doctor doc = new Doctor(login, password, TypeUser.Doctor);
            }
            else
            {
                Patient patient = new Patient(login, password, TypeUser.Patient);
            }


            //sql Если все ифы прошли заносим данные в бд, предположительно занос данных
            //идет по созданию конструктора


      

            return user;
        }

    }
}