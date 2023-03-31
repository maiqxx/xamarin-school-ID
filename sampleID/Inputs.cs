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
    [Activity(Label = "Inputs")]
    public class Inputs : Activity
    {
        Button submit;
        EditText name;
        EditText idNum;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set "inputs" or welcome view from the layout resource
            SetContentView(Resource.Layout.inputs);

            // Get btnSubmit Button control from inputs.xml layout
            submit = FindViewById<Button>(Resource.Id.btnSubmit);
            submit.Click += Submit_Click;

            // Get editTextName EditText control from inputs.xml layout
            name = FindViewById<EditText>(Resource.Id.editTextName);
            InputsClass.Name = name.Text;

            // Get editTextIDNum EditText control from inputs.xml layout
            idNum = FindViewById<EditText>(Resource.Id.editTextIDNum);
            InputsClass.IDNum = idNum.Text;
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            if (name.Text != "" && idNum.Text != "")
            {
                AlertDialog.Builder alert1 = new AlertDialog.Builder(this);
                alert1.SetTitle("Welcome");
                alert1.SetMessage("Hello, " + name.Text + "! Do you want to know more about me?");
                alert1.SetIcon(Resource.Drawable.ctuLogo);

                alert1.SetPositiveButton("Yes", delegate
                {
                    Intent i = new Intent(this, typeof(Welcome));  //AboutMe is the next page
                    i.PutExtra("Name", name.Text.ToString());
                    i.PutExtra("ID", idNum.Text.ToString());
                    StartActivity(i); //shows the UI of the next page
                });

                alert1.SetNegativeButton("Cancel", delegate
                {
                    Toast.MakeText(this, "You have cancelled the action!", ToastLength.Long).Show();
                });

                Dialog diag = alert1.Create();
                diag.Show();
            }
            else
            {
                Toast.MakeText(this, "Please provide your name.", ToastLength.Long).Show();
            }
        }
    }
}