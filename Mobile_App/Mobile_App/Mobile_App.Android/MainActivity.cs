using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content;
using Xamarin.Forms.StyleSheets;
using System.Reflection;

namespace Mobile_App.Droid
{
    /*=======================================================================

       This activity is used as the "splash" page where users can login

   ========================================================================*/
    [Activity(Label = "FABI_Mobile", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        /***************************************************************************
        *
        * DEFINE GLOBAL VARIABLES  
        *  - These will be used in other functions  
        *            
        *   loggedIn: This indicates if the user has already logged in 
        *   existingUser: This indicates if the user already exists within the system           
        *
        **************************************************************************/
        bool loggedIn = false;
        bool existingUser = false;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            //TabLayoutResource = Resource.Layout.Tabbar;
            //ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.MainLayout);

            /***************************************************************************
            *
            * GET BUTTONS FROM LAYOUT RESORUCE
            *  - This is so we can sign up for the button's click events        
            *
            **************************************************************************/
            Button loginButton = FindViewById<Button>(Resource.Id.btnSplashLogin);

            /***************************************************************************
            *
            * SETUP EVENT HANDLERS FOR THE BUTTONS 
            *  - This will allow certain functions to be bound to certain evetns        
            *
            **************************************************************************/
            loginButton.Click += new EventHandler(onLoginClicked);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }

        /***************************************************************************
         *
         * LOGIN BUTTON EVENT HANDLER 
         *  - When the login button is clicked this function is called 
         *  - This function directs to the LoginActivity or HomeActivity
         *
         ***************************************************************************/
        void onLoginClicked(object sender, EventArgs e)         {
            //TODO Create currentlyLoggedIn function to check if the user is already logged in
            loggedIn = false; //This will change based off of a check function

            if (loggedIn)
            {
                //If already logged in
                Intent intent = new Intent(this, typeof(DashboardActivity));
                StartActivity(intent);
            }
            else
            {
                //If not already logged in
                Intent intent = new Intent(this, typeof(LoginActivity));
                StartActivity(intent);
            }         }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}