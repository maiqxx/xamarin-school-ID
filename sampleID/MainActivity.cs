using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using AlertDialog = Android.App.AlertDialog;

namespace sampleID
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button btnNext;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            // Get btnNext Button control from activity_main.xml layout
            btnNext = FindViewById<Button>(Resource.Id.btnNext);

            //btnNext click event
            btnNext.Click += BtnNext_Click;
        }

        private void BtnNext_Click(object sender, System.EventArgs e)
        {
            AlertDialog.Builder alert = new AlertDialog.Builder(this);
            alert.SetTitle("Confirmation");
            alert.SetMessage("Do you really want to continue?");
            alert.SetIcon(Resource.Drawable.ctuLogo);

            alert.SetPositiveButton("OK", delegate
            {
                Intent i = new Intent(this, typeof(Inputs));  //AboutMe is the next page
                StartActivity(i); //shows the UI of the next page
            });

            alert.SetNegativeButton("Cancel", delegate
            {
                Toast.MakeText(this, "You have cancelled the action!", ToastLength.Long).Show();
            });

            Dialog diag = alert.Create();
            diag.Show();

        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}