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
    [Activity(Label = "ContactUsActivity")]
    public class ContactUsActivity : AppCompatActivity
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

            // Set our view from the "contact us" layout resource
            SetContentView(Resource.Layout.ContactUsLayout);

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
    }
}