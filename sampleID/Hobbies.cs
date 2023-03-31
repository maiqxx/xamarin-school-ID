using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sampleID
{
    [Activity(Label = "Hobbies")]
    public class Hobbies : Activity
    {
        Button back;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set "hobbies2" view from the layout resource
            SetContentView(Resource.Layout.hobbies);

            // Get btnHobbies2Back Button control from btnHobbies2Back.xml layout
            back = FindViewById<Button>(Resource.Id.btnHobbies2Back);
            back.Click += Back_Click; ; //next click event
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(AboutMe));  //Hobbies1 for the back button
            StartActivity(i); //shows the UI of the next page
        }
    }
}