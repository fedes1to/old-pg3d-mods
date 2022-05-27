// under any "At start" class (UIRoot, UICamera, AudioManager) to enable online
// also, you can get your photonappid at https://dashboard.photonengine.com/ and making a new server
PhotonNetwork.PhotonServerSettings.AppID = "photonappidhere"; // this sets the AppID of the photon server, change it to yours
PhotonNetwork.PhotonServerSettings.HostType = ServerSettings.HostingOption.PhotonCloud; // this sets the hosting option so it actually works lol
// ----------------------------------------------------------------- //
PhotonNetwork.PhotonServerSettings.UseCloud("photonappidhere", 0); // do everything that was used before but simpler
// ----------------------------------------------------------------- //
PhotonNetwork.PhotonServerSettings.PreferredRegion = CloudRegionCode.us; // use this if you want centralized servers (ping isn't that bad)


// to get max level and coins without dev console
BankController.AddCoins(10000) // replace 10000 with the number of coins desired, if you don't want to add coins, but set them, do the next command
Storager.setInt("Coins", 10000, false); // sets value for coins
Storager.setInt("GemsCurrency", 10000, false); // sets value for gems
Storager.setInt(text, 1, false); // sets desired level


// to get dev console
/*  
*   There are multiple steps to enable this, you just have to follow them in order.
*   There are 2 classes for dev console, DeveloperConsoleView and DeveloperConsoleController, the last one has the methods emptied
*   I will provide the entire DeveloperConsoleController code for 10.0.5 - 10.2.1 and a made-up (kinda broken) version for 10.3.0 - 11.1.x
*/  

// First make the button active in MainMenuController, you can find this button in MainMenuController.developerConsole
// Under MainMenuController.Start() change

// bool developerConsoleEnabled = UnityEngine.Debug.isDebugBuild; to:
bool developerConsoleEnabled = true;

// Next step is to edit DeveloperConsoleController using the files that will be available in this repository, use the correct version!
// If you're using a 8.x.x version, note that you DONT NEED TO DO THIS STEP


// To use older menus
/*
*   This one is a bit tricky to explain, but i'll try my best, basically you'll store the currently used menu in PlayerPrefs
*   We'll be using PlayerPrefs.SetString and PlayerPrefs.GetString instead of the Defs.MainMenuScene, that way it'll save between reboots
*   Also you can get the menu list using uTinyRipper and searching for Menu_ files, (Menu_Christmas, Menu_Heaven, etc)
*   To select the menus, we'll make a menu using the OnGUI method
*/

// First search for Defs.MainMenuScene and right click it, then click on the Analyze button, then go to the get method and then Used By
// Now replace every single Defs.MainMenuScene call with:
PlayerPrefs.GetString("MainMenuScene", "Menu_Heaven");

// you can replace the "Menu_Heaven with the default menu of your choosing
// now for the menu I'll make it visible when inside the DeveloperConsole scene, so under UIRoot.OnGUI() (make the method if it doesn't exist), also any "At start" class works
if (Application.loadedLevelName.Equals("DeveloperConsole"))
		{
			GUI.Box(new Rect(20f, 50f, 180f, 180f), "Select your menu!");
			if (GUI.Button(new Rect(25f, 80f, 170f, 30f), "Set Default Menu"))
			{
				PlayerPrefs.SetString(Defs.Menu, "Menu_Heaven");
				PlayerPrefs.Save();
			}
			if (GUI.Button(new Rect(25f, 115f, 170f, 30f), "Set Halloween Menu"))
			{
				PlayerPrefs.SetString(Defs.Menu, "Menu_Halloween_Heaven");
				PlayerPrefs.Save();
			}
			if (GUI.Button(new Rect(25f, 150f, 170f, 30f), "Set Knife Menu"))
			{
				PlayerPrefs.SetString(Defs.Menu, "Menu_Knife");
				PlayerPrefs.Save();
			}
			if (GUI.Button(new Rect(25f, 185f, 170f, 30f), "Set Day_D Menu"))
			{
				PlayerPrefs.SetString(Defs.Menu, "Menu_Day_D");
				PlayerPrefs.Save();
			}
        }
// this is just an example for the 8.3.3 working menus, feel free to expand it with more in newer pg3d versions


// to make chat commands! (hell yeah), go to Player_move_c.SendChat() and write the following:
if (text.Equals("command here"))
	    {
	    	// code here
	    }

// i know it's easy, so we'll add also arguments, as an example i'll add the custom level loader
if (text.StartsWith("!load "))
		{
			Application.LoadLevel(text.Substring(6)); // loads the level with the text after the command, example command: !load Menu_Christmas , command executed: Application.LoadLevel("Menu_Christmas");
		}


// to add custom weapons and skins, i'll show as an example social uzi and facebook skin
ShopNGUIController.ProvideShopItemOnStarterPackBoguht(ShopNGUIController.CategoryNames.SkinsCategory, "61", 1, false, 0, null, null, false, true, false); // adds the skin
WeaponManager.AddExclusiveWeaponToWeaponStructures(WeaponManager.SocialGunWN); // adds the weapon


// to make a run once only command, for this i just use the training completed thing, even if it might glitch while using developerConsole
if (Storager.getInt(Defs.TrainingCompleted_4_4_Sett, false) == 0)
{
    // code here
    Storager.setInt(Storager.getInt(Defs.TrainingCompleted_4_4_Sett, 1, false));
}


// to add removed weapons from the shop search for WeaponManager.InitializeRemoved150615Weapons() and just delete every weapon prefab inside that method

// at about version 5.4-6.0 connectgui became editable via dnspy. at 10.3.0 it became un-editable by this method. the way to find the method with the list of maps in each gamemode you can either search in "all of the above" for "ConnectGUI" or "ConnectNGUI" or search in "numbers/string" for a map scene name such as "day_d" or "dust"
// compare the map strings to the maps in each gamemode to find out which lists go where. to find out the strings for the scenes of the map, you can use assetripper to rip the scenes and preview them in unity.


// this code will make a button appear as long as you have a gameobject with the button code class component connected to it.
if (GUI.Button(new Rect(26f, 280f, 100f, 100f), "button" ) // the "if" statement will not only create the button but also attach a method to when you press it. the float numbers are for the position and size of the button on the screen. while the string is the text on the button. for example this button sets the amount of coins you have to 1.
    {
	    Storager.setInt("Coins", 1, false);
    } // the button code will work on almost any unity game so give it a try on some other games if you like!
    
    
    // to change the fps cap of pixel gun, place this code in an active class such as "uiroot.awake" or "appsmenu.awake"
Application.targetFrameRate = 60; // this can be as high or low as you want it.
    
