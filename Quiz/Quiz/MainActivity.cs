using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using System.Timers;

namespace Quiz
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button btnExit, BtnStart;
        Timer timer;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            BtnStart = FindViewById<Button>(Resource.Id.button1);
            btnExit = FindViewById<Button>(Resource.Id.button2);

            btnExit.Click += delegate
            {
                Finish();
                //Process.KillProcess(Process.MyPid());
            };

            BtnStart.Click += delegate
            {
                Intent intent = new Intent(this, typeof(QuizActivity));

                StartActivity(intent);
            };


            timer = new Timer();
            timer.Interval = 1000;
            timer.Enabled = true;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
            Cancel();

           
        }

            private void Cancel()
            {
                timer.Dispose();
                timer = null;
            }

            private void Timer_Elapsed(object sender, ElapsedEventArgs e)
            {
                DateTime dt = DateTime.Now;
                RunOnUiThread(() =>
                {
                    btnExit.Text = dt.ToString();
                });
            }

        protected override void OnResume()
        {
            base.OnResume();




        }


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}