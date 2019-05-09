using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Views;
using Android.Widget;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.V7.App;


namespace Mobile_App.Droid
{
    /*=======================================================================

       This activity is used to display the login page

   ========================================================================*/
    [Activity(Label = "LoginActivity")]
    public class LoginActivity : AppCompatActivity
    {
        /***************************************************************************
        *
        * DEFINE GLOBAL VARIABLES  
        *  - These will be used in other functions  
        *            
        *   drawerLayout: This will be used to access the burger menu
        *   navigationView: This will be used to access the burger menu          
        *
        **************************************************************************/
        DrawerLayout drawerLayout;
        NavigationView navigationView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "login" layout resource
            SetContentView(Resource.Layout.LoginLayout);

            /***************************************************************************
            *
            * GET BUTTONS FROM LAYOUT RESORUCE
            *  - This is so we can sign up for the button's click events        
            *
            **************************************************************************/
            Button loginButton = FindViewById<Button>(Resource.Id.btnLogin);

            /***************************************************************************
            *
            * SETUP EVENT HANDLERS FOR THE BUTTONS 
            *  - This will allow certain functions to be bound to certain evetns        
            *
            **************************************************************************/
            loginButton.Click += new EventHandler(onLoginSubmitClicked);

            V7Toolbar toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetDisplayShowTitleEnabled(false);
            SupportActionBar.SetHomeButtonEnabled(true);
            //SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.ic_menu);

            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawerLayout);
            navigationView = FindViewById<NavigationView>(Resource.Id.navigationView);
            setupDrawerContent(navigationView);
        }

        void setupDrawerContent(NavigationView navigationView)
        {
            navigationView.NavigationItemSelected += (sender, e) => {
                e.MenuItem.SetChecked(true);
                drawerLayout.CloseDrawers();
            };
        }

        /***************************************************************************
        *
        * SWITCH TO MENU ITEM  
        *  - This function is used to switch between the items in the menu
        *    when selected by the user
        *
        **************************************************************************/

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    drawerLayout.OpenDrawer(Android.Support.V4.View.GravityCompat.Start);
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }

        /***************************************************************************
        *
        * LOGIN BUTTON EVENT HANDLER 
        *  - When the login button is clicked this function is called 
        *  - This function directs to the DashboardActivity if successful
        *
        ***************************************************************************/
        void onLoginSubmitClicked(object sender, EventArgs e)
        {
            //TODO AuthenticationFunction
            bool authenticated = true; //This will change based off of an authentication function

            //TODO Form Validation
            bool validForm = true; //This will changed based off of a form validation function

            if (validForm)
            {
                if (authenticated)
                {
                    //If login is successful we redirect to the home activity
                    Intent intent = new Intent(this, typeof(DashboardActivity));
                    StartActivity(intent);
                }
                else
                {
                    //Display Error
                    Android.App.AlertDialog alertDialog = new Android.App.AlertDialog.Builder(this).Create();
                    alertDialog.SetTitle("Login");
                    alertDialog.SetMessage("Login was unsuccessful! Retry.");
                    alertDialog.Show();
                }
            }
            else
            {
                //TODO Contain this within the FormValidation function instead with other validation checks
                //Display Error
                Android.App.AlertDialog alertDialog = new Android.App.AlertDialog.Builder(this).Create();
                alertDialog.SetTitle("Form Validation");
                alertDialog.SetMessage("Please make sure that you provide all the necessary details.");
                alertDialog.Show();
            }
        }
    }
}