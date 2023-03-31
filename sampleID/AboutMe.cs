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
    [Activity(Label = "AboutMe")]
    public class AboutMe : Activity
    {
        Button back;
        Button next;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set "aboutMe" view from the layout resource
            SetContentView(Resource.Layout.aboutMe);

            // Get btnAboutMeBack Button control from aboutMe.xml layout
            back = FindViewById<Button>(Resource.Id.btnAboutMeBack);
            back.Click += Back_Click; ; //back click event

            // Get btnAboutMeNext Button control from aboutMe.xml layout
            next = FindViewById<Button>(Resource.Id.btnAboutMeNext);
            next.Click += Next_Click; //next click event

        }

        private void Next_Click(object sender, EventArgs e)
        {
            AlertDialog.Builder alert1 = new AlertDialog.Builder(this);
            alert1.SetTitle("Confirmation");
            alert1.SetMessage("Do you really want to continue?");
            alert1.SetIcon(Resource.Drawable.ctuLogo);

            alert1.SetPositiveButton("Yes", delegate
            {
                Intent i = new Intent(this, typeof(Hobbies));  //AboutMe is the next page
                StartActivity(i); //shows the UI of the next page
            });

            alert1.SetNegativeButton("Cancel", delegate
            {
                Toast.MakeText(this, "You have cancelled the action!", ToastLength.Long).Show();
            });

            Dialog diag = alert1.Create();
            diag.Show();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(MainActivity)); 
            StartActivity(i); //shows the UI of the next page
        }
    }
}