using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using System.Threading;

namespace Rehabilitation
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class enterPagePatient : TabbedPage
    {

        SensorSpeed speed = SensorSpeed.UI;
        double startPitch, startRoll, startYaw;
        bool startFlag;
        double roll, pitch, yaw;

        public enterPagePatient (int id)
		{
			InitializeComponent ();
		}

        private async void butStart_Clicked(object sender, EventArgs e)
        {
            butStart.IsVisible = false;
            butStop.IsVisible = true;
            
            if (Accelerometer.IsMonitoring)
            {
                Accelerometer.ReadingChanged -= Accelerometer_ReadingChanged;
                Accelerometer.Stop();
            }
            else
            {
                startFlag = true;
                Accelerometer.Start(speed);
                Accelerometer.ReadingChanged += Accelerometer_ReadingChanged;
            }
        }

        private async void butStop_Clicked(object sender, EventArgs e)
        {
            butStart.IsVisible = true;
            butStop.IsVisible = false;
            if (Accelerometer.IsMonitoring)
            {
                Accelerometer.ReadingChanged -= Accelerometer_ReadingChanged;
                Accelerometer.Stop();
            }
            else
            {
                startFlag = true;
                Accelerometer.Start(speed);
                Accelerometer.ReadingChanged += Accelerometer_ReadingChanged;
            }
        }

        void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
        {
            var data = e.Reading;
            if (startFlag)
            {
                startFlag = false;
                startRoll = Math.Atan(data.Acceleration.Y / Math.Sqrt(Math.Pow(data.Acceleration.X, 2.0) + Math.Pow(data.Acceleration.Z, 2.0)));
                startPitch = Math.Atan(data.Acceleration.X / Math.Sqrt(Math.Pow(data.Acceleration.Y, 2.0) + Math.Pow(data.Acceleration.Z, 2.0)));
                startYaw = Math.Atan(Math.Sqrt(Math.Pow(data.Acceleration.X, 2.0) + Math.Pow(data.Acceleration.Z, 2.0)) / data.Acceleration.Z);

            }
            else
            {
                roll = Math.Atan(data.Acceleration.Y / Math.Sqrt(Math.Pow(data.Acceleration.X, 2.0) + Math.Pow(data.Acceleration.Z, 2.0)));
                pitch = Math.Atan(data.Acceleration.X / Math.Sqrt(Math.Pow(data.Acceleration.Y, 2.0) + Math.Pow(data.Acceleration.Z, 2.0)));
                yaw = Math.Atan(Math.Sqrt(Math.Pow(data.Acceleration.X, 2.0) + Math.Pow(data.Acceleration.Z, 2.0)) / data.Acceleration.Z);
                var sqlAngle = 90;
                var coef = 57.692308;
                var fault = 3;
                
                var angle1 = (pitch * coef - startPitch * coef);
                var angle2 = (roll * coef - startRoll * coef);
                var angle3 = (yaw * coef - startYaw * coef);
                var resAngle = Math.Max(angle1, Math.Max(angle2, angle3));
                lbAngle.Text = ($"Угол : {string.Format("{0:0.00}", resAngle)}");

                if (pitch * coef >= (sqlAngle + (startPitch * coef) - fault) ||
                    roll * coef >= (sqlAngle + (startRoll * coef) - fault) ||
                    yaw * coef >= (sqlAngle + (startYaw * coef) - fault))
                {
                    Vibration.Vibrate();

                    Thread.Sleep(5000);
                }

            }
        }

        //Кнопка перехода в график
        public async void butInfo_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new patientCourseGraph());
        }

    }
}