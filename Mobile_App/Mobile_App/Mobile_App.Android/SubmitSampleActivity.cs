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
using Mobile_App.Droid;

namespace Mobile_App.Droid
{
    /*=======================================================================

       This activity is used to display the sample form and allow a 
       user to submit the form

   ========================================================================*/
    [Activity(Label = "SubmitSampleActivity")]
    public class SubmitSampleActivity : AppCompatActivity
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

            // Set our view from the "submit sample" layout resource
            SetContentView(Resource.Layout.SubmitSampleLayout);

            V7Toolbar toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetDisplayShowTitleEnabled(false);
            SupportActionBar.SetHomeButtonEnabled(true);
            //SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.ic_menu);

            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawerLayout);
            navigationView = FindViewById<NavigationView>(Resource.Id.navigationView);
            setupDrawerContent(navigationView);

            /***************************************************************************
            *
            * GET SUBMIT BUTTON FROM LAYOUT RESORUCE        
            *
            **************************************************************************/
            Button submitButton = FindViewById<Button>(Resource.Id.btnSubmitSample);

            /***************************************************************************
            *
            * SETUP EVENT HANDLERS FOR THE BUTTONS 
            *  - This will allow certain functions to be bound to certain evetns        
            *
            **************************************************************************/
            submitButton.Click += new EventHandler(onSubmitClicked);
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
         * SUBMIT BUTTON EVENT HANDLER 
         *  - When the submit button is clicked this function is called 
         *  - This function directs submits the sample and shows a success message
         *
         ***************************************************************************/
        void onSubmitClicked(object sender, EventArgs e)         {
            //TODO Error checking and sample submition
            bool formValid = true;

            /***************************************************************************
            *
            * GET SAMPLE FORM ELEMENTS FROM LAYOUT RESORUCE        
            *
            **************************************************************************/
            EditText treeSpecies = FindViewById<EditText>(Resource.Id.txtTreeSpecies);
            EditText numberOfSamples = FindViewById<EditText>(Resource.Id.txtNoSamples);
            EditText area = FindViewById<EditText>(Resource.Id.txtArea);
            EditText streetAddress = FindViewById<EditText>(Resource.Id.txtStreetAddress);
            EditText compartmentNumber = FindViewById<EditText>(Resource.Id.txtCompartmentNo);
            EditText dateCollected = FindViewById<EditText>(Resource.Id.txtDateCollected);

            //Sample Types
            CheckBox soil = FindViewById<CheckBox>(Resource.Id.cbxSoil);
            CheckBox twigs = FindViewById<CheckBox>(Resource.Id.cbxTwigs);
            CheckBox mediaPlates = FindViewById<CheckBox>(Resource.Id.cbxMediaPlates);
            CheckBox stems = FindViewById<CheckBox>(Resource.Id.cbxStems);
            CheckBox roots = FindViewById<CheckBox>(Resource.Id.cbxRoots);
            CheckBox leaves = FindViewById<CheckBox>(Resource.Id.cbxLeaves);
            CheckBox seedlings = FindViewById<CheckBox>(Resource.Id.cbxSeedings);
            CheckBox water = FindViewById<CheckBox>(Resource.Id.cbxWater);

            //Symptoms
            CheckBox wilt = FindViewById<CheckBox>(Resource.Id.cbxWilt);
            CheckBox stunting = FindViewById<CheckBox>(Resource.Id.cbxStunting);
            CheckBox leafSpot = FindViewById<CheckBox>(Resource.Id.cbxLeafSpot);
            CheckBox rootRot = FindViewById<CheckBox>(Resource.Id.cbxRootRot);
            CheckBox dieBack = FindViewById<CheckBox>(Resource.Id.cbxDieBack);
            CheckBox cankers = FindViewById<CheckBox>(Resource.Id.cbxCankers);
            CheckBox death = FindViewById<CheckBox>(Resource.Id.cbxSeedicbxDeathngs);
            CheckBox wood = FindViewById<CheckBox>(Resource.Id.cbxWood);
            EditText other = FindViewById<EditText>(Resource.Id.txtOther);

            //Distribution
            RadioButton localized = FindViewById<RadioButton>(Resource.Id.rbtnLocalized);
            RadioButton scattered = FindViewById<RadioButton>(Resource.Id.rbtnScattered);
            RadioButton general = FindViewById<RadioButton>(Resource.Id.rbtnGeneral);

            //Weather and Planting Conditions
            EditText percentagePlantsAffected = FindViewById<EditText>(Resource.Id.txtPlantsAffected);
            EditText dateProblemNoticed = FindViewById<EditText>(Resource.Id.txtProblemNoticed);
            EditText datePlanted = FindViewById<EditText>(Resource.Id.txtPlantsPlanted);
            EditText weatherDisturbances = FindViewById<EditText>(Resource.Id.txtWeatherDisturbances);
            EditText weatherPrior = FindViewById<EditText>(Resource.Id.txtWeatherConditionsPrior);
            EditText othersAffected = FindViewById<EditText>(Resource.Id.txtOthersAffected);
            EditText additionalInfo = FindViewById<EditText>(Resource.Id.txtAdditionalInfo);

            //Landowner permission
            CheckBox landownerPermission = FindViewById<CheckBox>(Resource.Id.cbxLandownerPermission);

            //TODO Validate all elements

            if (formValid)
            {
                //submit sample form
            }             else
            {
                //return and error message asking user to provide all information
            }         }
    }
}