# old-pg3d-mods
here i'll show all of my code, you need basic c# and dnSpy experience

First, if you get errors related to unicode characters (example: \u055F) try deobfuscating using de4dot

Every file will have the changed code for a specific class, all the changes that need to be done, i'll not publish the source itself, but the changes that you need to do to the game to get a mod like mine.

As always, analyze code to adjust for obfuscation,
PhotonNetwork.PhotonServerSettings.AppID = "appidhere"; 
isn't the same as
PhotonNetwork.photonServerSettings_0.AppID = "appidhere";

Enjoy!
