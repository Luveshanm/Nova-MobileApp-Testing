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

       This activity is used to display the dashboard page

   ========================================================================*/
    [Activity(Label = "DashboardActivity")]
    public class DashboardActivity : AppCompatActivity
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

            // Set our view from the "dashboard" layout resource
            SetContentView(Resource.Layout.DashboardLayout);

            //Call this method to populate the dashboard with samples
            loadDashboard();

            V7Toolbar toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetDisplayShowTitleEnabled(false);
            SupportActionBar.SetHomeButtonEnabled(true);
            //SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.ic_menu);

            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawerLayout);
            navigationView = FindViewById<NavigationView>(Resource.Id.navigationView);
            setupDrawerContent(navigationView);

            /*var drawerToggle = new ActionBarDrawerToggle(this, drawerLayout, toolbar, Resource.String.drawer_open, Resource.String.drawer_close);
            drawerLayout.SetDrawerListener(drawerToggle);
            drawerToggle.SyncState();*/
        }

        void loadDashboard()
        {
            /***************************************************************************
            *
            * GET LINEAR LAYOUT FROM LAYOUT RESORUCE
            *  - This is so we can populate the linear layout with samples        
            *
            **************************************************************************/
            LinearLayout layout = FindViewById<LinearLayout>(Resource.Id.dashboardSamples);

            //TODO Call API method to get samples for the user
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
    }
}