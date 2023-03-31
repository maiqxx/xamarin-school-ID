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
    [Activity(Label = "Welcome")]
    public class Welcome : Activity
    {
        Button btnProceed;
        Button btnBack;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //set content view
            SetContentView(Resource.Layout.welcome);

            btnProceed = FindViewById<Button>(Resource.Id.btnProceed);
            btnProceed.Click += BtnProceed_Click;

            btnBack = FindViewById<Button>(Resource.Id.btnBack);
            btnBack.Click += BtnBack_Click;

            string name = Intent.GetStringExtra("Name");
            string ID = Intent.GetStringExtra("ID");

            TextView hello = FindViewById<TextView>(Resource.Id.txtName);
            hello.Text = "Name: " + name;

            TextView id = FindViewById<TextView>(Resource.Id.txtIdNumber);
            id.Text = "ID Number: " + ID;
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(Inputs));
            StartActivity(i);
        }

        private void BtnProceed_Click(object sender, EventArgs e)
        {
            string name = Intent.GetStringExtra("Name");

            AlertDialog.Builder alert1 = new AlertDialog.Builder(this);
            alert1.SetTitle("Welcome");
            alert1.SetMessage("Do you want to know more about me?");
            alert1.SetIcon(Resource.Drawable.ctuLogo);

            alert1.SetPositiveButton("Yes", delegate
            {
                Intent i = new Intent(this, typeof(AboutMe));  //AboutMe is the next page
                //i.PutExtra("Name", name.Text.ToString());
                StartActivity(i); //shows the UI of the next page
            });

            alert1.SetNegativeButton("Cancel", delegate
            {
                Toast.MakeText(this, "You have cancelled the action!", ToastLength.Long).Show();
            });

            Dialog diag = alert1.Create();
            diag.Show();
        }
    }
}