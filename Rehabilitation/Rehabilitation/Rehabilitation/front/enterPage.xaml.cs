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
    public partial class enterPage : TabbedPage
    {
        public class PatientFotList
        {
            public string Name { get; set; }
        }

        public List<PatientFotList> Patients { get; set; }

        public class CourseFotList
        {
            public string Name { get; set; }
        }

        public List<CourseFotList> Courses { get; set; }

        public enterPage(int id)
        {
            InitializeComponent();
            string[] arr1 = GetCourses(id);
            PatientIdAndFullName[] arr2 = GetPatients(id);
            int sqlCount1 = 1;//Количество курсов у врача
            int sqlCount2 = 1;//Количество пациентов у врача
            Patients = new List<PatientFotList>
            {
                new PatientFotList {Name="Test"}
            };

            Courses = new List<CourseFotList>
            {
                new CourseFotList {Name="Test"}
            };
            for (int i = 0; i < sqlCount1; i++)
            {
                Courses.Add(new CourseFotList {Name = arr1[i]});
            }
            for (int i = 0; i < sqlCount2; i++)
            {
                Patients.Add(new PatientFotList { Name = arr2[i].fullName });
            }
            
            this.BindingContext = this;
        }

        //Метод получения массива структур типа Имя пациента, ИД пациента, для
        // реализации списка пациентов вошедшего в систему врача
        PatientIdAndFullName[] GetPatients(int id)
        {
            int sqlCount = 5;//sql Селект на количество пациентов у врача
            PatientIdAndFullName[] arr = new PatientIdAndFullName[sqlCount];
            int sqlId = 2;
            string sqlFullName = "Test";
            for (int i = 0; i < sqlCount; i++)
            {
                arr[i].id = sqlId;
                arr[i].fullName = sqlFullName;
            }
            return arr;
        }

        string[] GetCourses(int id)
        {
            int sqlCount = 5;//sql Селект на количество пациентов у врача
            string[] arr = new string[sqlCount];//Вытягиваем все курсы оформленные на текущего врача
            string nameCourse = "Test";
            for (int i = 0; i < sqlCount; i++)
            {
                arr[i] = nameCourse;
            }
            return arr;
        }


        public async void ToolbarItem1_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new addPatient());
        }

        public async void ToolbarItem2_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new addCourse());
        }

        public async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            PatientFotList selectedPatient = e.Item as PatientFotList;
            if (selectedPatient != null)
                await Navigation.PushAsync(new patientInfo());
        }

        public async void OnItemTapped2(object sender, ItemTappedEventArgs e)
        {
           
            CourseFotList selectedCourse = e.Item as CourseFotList;
            if (selectedCourse != null)
                await Navigation.PushAsync(new courseInfo(selectedCourse.Name));
        }

    }



}

