// FOR USE ONLY ON 10.2.1 AND DOWNWARDS
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GooglePlayGames;
using Rilisoft;
using UnityEngine;

// Token: 0x020008BF RID: 2239
internal sealed class DeveloperConsoleController : MonoBehaviour
{
	// Token: 0x060042F7 RID: 17143 RVA: 0x000026D8 File Offset: 0x000008D8
	public DeveloperConsoleController()
	{
	}

	// Token: 0x060042F8 RID: 17144 RVA: 0x000026FB File Offset: 0x000008FB
	static DeveloperConsoleController()
	{
	}

	// Token: 0x060042F9 RID: 17145 RVA: 0x000295DA File Offset: 0x000277DA
	public void HandleBackButton()
	{
		this._backRequested = true;
	}

	// Token: 0x060042FA RID: 17146 RVA: 0x000295E3 File Offset: 0x000277E3
	public void HandleClearKeychainAndPlayerPrefs()
	{
		Debug.Log("[Clear Keychain] pressed.");
		PlayerPrefs.DeleteAll();
		Application.Quit();
	}

	// Token: 0x060042FB RID: 17147 RVA: 0x00163014 File Offset: 0x00161214
	public void HandleLevelMinusButton()
	{
		if (ExperienceController.sharedController != null)
		{
			int currentLevel = ExperienceController.sharedController.currentLevel;
			if (currentLevel == 1)
			{
				return;
			}
			int num = currentLevel - 1;
			Storager.setInt("currentLevel" + currentLevel, 0, true);
			Storager.setInt("currentLevel" + num, 1, true);
			ExperienceController.sharedController.Refresh();
			this.view.LevelLabel = "Level: " + num;
			this.RefreshExperience();
		}
	}

	// Token: 0x060042FC RID: 17148 RVA: 0x0016309C File Offset: 0x0016129C
	public void HandleLevelPlusButton()
	{
		if (ExperienceController.sharedController != null)
		{
			int num = ExperienceController.sharedController.currentLevel + 1;
			Storager.setInt("currentLevel" + num, 1, true);
			ExperienceController.sharedController.Refresh();
			this.view.LevelLabel = "Level: " + num;
			this.RefreshExperience();
		}
	}

	// Token: 0x060042FD RID: 17149 RVA: 0x00163108 File Offset: 0x00161308
	public void HandleCoinsInputSubmit(UIInput input)
	{
		if (input == null || string.IsNullOrEmpty(input.value))
		{
			return;
		}
		int num;
		if (int.TryParse(input.value, out num))
		{
			Storager.setInt("Coins", num, false);
		}
	}

	// Token: 0x060042FE RID: 17150 RVA: 0x00163148 File Offset: 0x00161348
	public void HandleEnemyCountInSurvivalWaveInput(UIInput input)
	{
		if (input == null || string.IsNullOrEmpty(input.value))
		{
			return;
		}
		int num;
		if (int.TryParse(input.value, out num))
		{
			ZombieCreator.EnemyCountInSurvivalWave = num;
		}
	}

	// Token: 0x060042FF RID: 17151 RVA: 0x000295F9 File Offset: 0x000277F9
	public void HandleEnemiesInCampaignChange()
	{
		if (this._enemiesInCampaignDirty != null)
		{
			this._enemiesInCampaignDirty = new bool?(true);
		}
	}

	// Token: 0x06004300 RID: 17152 RVA: 0x00163184 File Offset: 0x00161384
	public void HandleEnemiesInCampaignInput(UIInput input)
	{
		if (input == null || string.IsNullOrEmpty(input.value))
		{
			return;
		}
		int num;
		if (int.TryParse(input.value, out num))
		{
			GlobalGameController.EnemiesToKill = num;
		}
	}

	// Token: 0x06004301 RID: 17153 RVA: 0x001631C0 File Offset: 0x001613C0
	public void HandleTrainingCompleteChanged(UIToggle toggle)
	{
		if (toggle == null)
		{
			return;
		}
		int num = Convert.ToInt32(toggle.value);
		Storager.setInt(Defs.TrainingCompleted_4_4_Sett, num, false);
		Defs.isTrainingFlag = Storager.getInt(Defs.TrainingCompleted_4_4_Sett, false) == 0;
	}

	// Token: 0x06004302 RID: 17154 RVA: 0x00029614 File Offset: 0x00027814
	public void HandleSet60FpsChanged(UIToggle toggle)
	{
		if (toggle == null)
		{
			return;
		}
		bool value = toggle.value;
		Application.targetFrameRate = 240;
	}

	// Token: 0x06004303 RID: 17155 RVA: 0x00029631 File Offset: 0x00027831
	public void HandleMouseControlChanged(UIToggle toggle)
	{
		if (toggle == null)
		{
			return;
		}
		Defs.isMouseControl = toggle.value;
	}

	// Token: 0x06004304 RID: 17156 RVA: 0x00029648 File Offset: 0x00027848
	public void HandleSpectatorMode(UIToggle toggle)
	{
		if (toggle == null)
		{
			return;
		}
		Defs.isRegimVidosDebug = toggle.value;
	}

	// Token: 0x06004305 RID: 17157 RVA: 0x0002965F File Offset: 0x0002785F
	public void HandleTempGunChanged(UIToggle toggle)
	{
		if (toggle == null)
		{
			return;
		}
		if (toggle.value)
		{
			TempItemsController.sharedController.AddTemporaryItem(WeaponTags.Impulse_Sniper_Rifle_Tag, 60);
			return;
		}
		WeaponManager.sharedManager.RemoveTemporaryItem(WeaponTags.Impulse_Sniper_Rifle_Tag);
	}

	// Token: 0x06004306 RID: 17158 RVA: 0x00163204 File Offset: 0x00161404
	public void HandleIpadMiniRetinaChanged(UIToggle toggle)
	{
		if (toggle == null)
		{
			return;
		}
		if (!this._initialized)
		{
			return;
		}
		int num = Convert.ToInt32(toggle.value);
		PlayerPrefs.SetInt("Dev.ResolutionDowngrade", num);
		this._needsRestart = true;
	}

	// Token: 0x06004307 RID: 17159 RVA: 0x00163244 File Offset: 0x00161444
	public void HandleIsPayingChanged(UIToggle toggle)
	{
		if (toggle == null)
		{
			return;
		}
		if (!this._initialized)
		{
			return;
		}
		if (toggle.value)
		{
			Storager.setString("AdvertCountDuringCurrentPeriod", "{}", false);
			StoreKitEventListener.SetLastPaymentTime();
			Storager.setInt("PayingUser", 1, true);
			return;
		}
		PlayerPrefs.DeleteKey("Last Payment Time");
		PlayerPrefs.DeleteKey("Last Payment Time (Advertisement)");
		Storager.setInt("PayingUser", 0, true);
	}

	// Token: 0x06004308 RID: 17160 RVA: 0x00029694 File Offset: 0x00027894
	public void HandleIsDebugGuiVisibleChanged(UIToggle toggle)
	{
		if (toggle == null)
		{
			return;
		}
		if (!this._initialized)
		{
			return;
		}
		DeveloperConsoleController.isDebugGuiVisible = toggle.value;
	}

	// Token: 0x06004309 RID: 17161 RVA: 0x000296B4 File Offset: 0x000278B4
	public void HandleForcedEventX3Changed(UIToggle toggle)
	{
		if (toggle == null)
		{
			return;
		}
		bool initialized = this._initialized;
	}

	// Token: 0x0600430A RID: 17162 RVA: 0x000296C7 File Offset: 0x000278C7
	public void HandleAdIdCanged(UIToggle toggle)
	{
		if (toggle == null)
		{
			return;
		}
		if (!this._initialized)
		{
			return;
		}
		MobileAdManager.RefreshBytes();
	}

	// Token: 0x0600430B RID: 17163 RVA: 0x001632B0 File Offset: 0x001614B0
	public void HandleClearPurchasesButton()
	{
		Debug.Log("[Clear Purchases] clicked.");
		this._needsRestart = true;
		Dictionary<string, string>.ValueCollection values = WeaponManager.storeIDtoDefsSNMapping.Values;
		List<string> list = new List<string>();
		foreach (KeyValuePair<ShopNGUIController.CategoryNames, List<List<string>>> keyValuePair in Wear.wear)
		{
			foreach (List<string> list2 in keyValuePair.Value)
			{
				list.AddRange(list2);
			}
		}
		IEnumerable<string> enumerable = InAppData.inAppData.Values.Select(delegate(KeyValuePair<string, string> kv)
		{
			KeyValuePair<string, string> keyValuePair2 = kv;
			return keyValuePair2.Value;
		});
		string[] array = new string[]
		{
			Defs.SkinsMakerInProfileBought,
			Defs.hungerGamesPurchasedKey,
			Defs.CaptureFlagPurchasedKey,
			Defs.smallAsAntKey,
			Defs.code010110_Key,
			Defs.UnderwaterKey
		};
		foreach (string text in from id in values.Concat(list).Concat(enumerable).Concat(array)
			where Storager.getInt(id, false) != 0
			select id)
		{
			Storager.setInt(text, 0, false);
		}
		foreach (string text2 in GearManager.Gear)
		{
			for (int j = 1; j <= GearManager.NumOfGearUpgrades; j++)
			{
				Storager.setInt(GearManager.NameForUpgrade(text2, j), 0, false);
			}
			Storager.setInt(text2, 0, false);
		}
		StarterPackController.Get.ClearAllGooglePurchases();
	}

	// Token: 0x0600430C RID: 17164 RVA: 0x00163494 File Offset: 0x00161694
	public void HandleClearProgressButton()
	{
		CampaignProgress.boxesLevelsAndStars.Clear();
		CampaignProgress.boxesLevelsAndStars.Add(LevelBox.campaignBoxes[0].name, new Dictionary<string, int>());
		CampaignProgress.SaveCampaignProgress();
		Storager.setString(Defs.WeaponsGotInCampaign, string.Empty, false);
		Storager.setString(Defs.LevelsWhereGetCoinS, string.Empty, false);
	}

	// Token: 0x0600430D RID: 17165 RVA: 0x001634F0 File Offset: 0x001616F0
	public void HandleFillProgressButton()
	{
		CampaignProgress.boxesLevelsAndStars.Clear();
		int num = LevelBox.campaignBoxes.Count - 1;
		for (int i = 0; i < num; i++)
		{
			int starCount = ((i >= num - 1) ? 1 : 3);
			LevelBox levelBox = LevelBox.campaignBoxes[i];
			Dictionary<string, int> dictionary = levelBox.levels.ToDictionary((CampaignLevel l) => l.sceneName, (CampaignLevel _) => starCount);
			CampaignProgress.boxesLevelsAndStars.Add(levelBox.name, dictionary);
		}
		CampaignProgress.SaveCampaignProgress();
	}

	// Token: 0x0600430E RID: 17166 RVA: 0x00163594 File Offset: 0x00161794
	public void HandleClearCloud()
	{
		if (BuildSettings.BuildTarget == BuildTarget.WP8Player)
		{
			PlayerPrefs.SetInt("WantToResetKeychain", 1);
			PlayerPrefs.Save();
			if (!Application.isEditor)
			{
				Application.Quit();
				return;
			}
		}
		else if (BuildSettings.BuildTarget == BuildTarget.Android)
		{
			CloudCleaner.Instance.CleanSavedGameFile("Purchases");
			CloudCleaner.Instance.CleanSavedGameFile("Progress");
		}
	}

	// Token: 0x0600430F RID: 17167 RVA: 0x001635F0 File Offset: 0x001617F0
	public void HandleUnbanUs(UIButton butt)
	{
		if (FriendsController.sharedController != null)
		{
			FriendsController.sharedController.UnbanUs(delegate
			{
				butt.GetComponent<UISprite>().spriteName = "green_btn";
				FriendsController.sharedController.Banned = 0;
			});
		}
	}

	// Token: 0x06004310 RID: 17168 RVA: 0x00163630 File Offset: 0x00161830
	public void HandleClearX3()
	{
		PlayerPrefs.SetInt(Defs.EventX3WindowShownCount, 1);
		PlayerPrefs.SetString(Defs.EventX3WindowShownLastTime, PromoActionsManager.CurrentUnixTime.ToString());
		PlayerPrefs.SetInt(Defs.AdvertWindowShownCount, 3);
		PlayerPrefs.SetString(Defs.AdvertWindowShownLastTime, PromoActionsManager.CurrentUnixTime.ToString());
	}

	// Token: 0x06004311 RID: 17169 RVA: 0x00163684 File Offset: 0x00161884
	private void RefreshExperience()
	{
		int currentLevel = ExperienceController.sharedController.currentLevel;
		int num = ExperienceController.MaxExpLevels[currentLevel];
		int num2 = Mathf.Clamp(Convert.ToInt32(this.view.ExperiencePercentage * (float)num), 0, num - 1);
		float num3 = (float)num2 / (float)num;
		this.view.ExperienceLabel = string.Concat(new object[] { "Exp: ", num2, '/', num });
		this.view.ExperiencePercentage = num3;
		Storager.setInt("currentExperience", num2, false);
		ExperienceController.sharedController.Refresh();
		if (ExpController.Instance != null)
		{
			ExpController.Instance.Refresh();
		}
	}

	// Token: 0x06004312 RID: 17170 RVA: 0x000296E1 File Offset: 0x000278E1
	public void HandleExperienceSliderChanged()
	{
		if (ExperienceController.sharedController != null)
		{
			this.RefreshExperience();
		}
	}

	// Token: 0x06004313 RID: 17171 RVA: 0x0016373C File Offset: 0x0016193C
	public void HandleSignInOuButton(UILabel socialUsernameLabel)
	{
		if (Defs.AndroidEdition == Defs.RuntimeAndroidEdition.GoogleLite || Defs.AndroidEdition == Defs.RuntimeAndroidEdition.GooglePro)
		{
			if (PlayGamesPlatform.Instance.IsAuthenticated())
			{
				Debug.Log("Signing out...");
				PlayGamesPlatform.Instance.SignOut();
				if (socialUsernameLabel != null)
				{
					socialUsernameLabel.text = string.Empty;
					return;
				}
			}
			else
			{
				Debug.Log("Signing in...");
				PlayGamesPlatform.Instance.Authenticate(delegate(bool success)
				{
					if (success)
					{
						if (socialUsernameLabel != null)
						{
							socialUsernameLabel.text = PlayGamesPlatform.Instance.localUser.userName;
							return;
						}
					}
					else
					{
						Debug.LogWarning("Failed to sign in.");
						if (socialUsernameLabel != null)
						{
							socialUsernameLabel.text = string.Empty;
						}
					}
				}, false);
			}
		}
	}

	// Token: 0x06004314 RID: 17172 RVA: 0x000296F6 File Offset: 0x000278F6
	public void SetMarathonTestMode(UIToggle toggle)
	{
		if (toggle == null)
		{
			return;
		}
		PlayerPrefs.SetInt(Defs.MarathonTestMode, (!toggle.value) ? 0 : 1);
	}

	// Token: 0x06004315 RID: 17173 RVA: 0x001637C8 File Offset: 0x001619C8
	public void SetMarathonCurrentDay(UIInput input)
	{
		if (input == null || string.IsNullOrEmpty(input.value))
		{
			return;
		}
		int num;
		if (int.TryParse(input.value, out num))
		{
			Storager.setInt(Defs.NextMarafonBonusIndex, num, false);
		}
	}

	// Token: 0x06004316 RID: 17174 RVA: 0x00029718 File Offset: 0x00027918
	public void SetOffGameGUIMode(UIToggle toggle)
	{
		if (toggle == null)
		{
			return;
		}
		PlayerPrefs.SetInt(Defs.GameGUIOffMode, (!toggle.value) ? 0 : 1);
		PlayerPrefs.Save();
	}

	// Token: 0x06004317 RID: 17175 RVA: 0x000026FB File Offset: 0x000008FB
	public void ClearStarterPackData()
	{
	}

	// Token: 0x06004318 RID: 17176 RVA: 0x00163808 File Offset: 0x00161A08
	private void Refresh()
	{
		if (this.view == null)
		{
			throw new InvalidOperationException();
		}
		if (ExperienceController.sharedController != null)
		{
			int currentLevel = ExperienceController.sharedController.currentLevel;
			int num = ExperienceController.MaxExpLevels[currentLevel];
			int currentExperience = ExperienceController.sharedController.CurrentExperience;
			this.view.LevelLabel = "Level: " + currentLevel;
			this.view.ExperienceLabel = string.Concat(new object[] { "Exp: ", currentExperience, '/', num });
			this.view.ExperiencePercentage = (float)currentExperience / (float)num;
		}
		this.view.CoinsInput = Storager.getInt("Coins", false);
		this.view.GemsInput = Storager.getInt("GemsCurrency", false);
		this.view.EnemiesInSurvivalWaveInput = ZombieCreator.EnemyCountInSurvivalWave;
		this.view.EnemiesInCampaignInput = GlobalGameController.EnemiesToKill;
		int @int = Storager.getInt(Defs.TrainingCompleted_4_4_Sett, false);
		this.view.TrainingCompleted = Convert.ToBoolean(@int);
		this.view.TempGunActive = TempItemsController.sharedController.ContainsItem(WeaponTags.Impulse_Sniper_Rifle_Tag);
		this.view.Set60FPSActive = Application.targetFrameRate == 60;
		this.view.IsPayingUser = FlurryPluginWrapper.IsPayingUser();
		this.view.isDebugGuiVisibleCheckbox.value = DeveloperConsoleController.isDebugGuiVisible;
		this.view.SetMouseControll = Defs.isMouseControl;
		this.view.SetSpectatorMode = Defs.isRegimVidosDebug;
		string @string = PlayerPrefs.GetString("RemotePushNotificationToken", string.Empty);
		if (string.IsNullOrEmpty(@string))
		{
			this.view.DevicePushTokenInput = "None";
		}
		else
		{
			this.view.DevicePushTokenInput = @string;
		}
		this.view.PlayerIdInput = ((!(FriendsController.sharedController != null)) ? "None" : FriendsController.sharedController.id);
		this.view.starterPackLive.text = StarterPackModel.MaxLiveTimeEvent.TotalMinutes.ToString();
		this.view.starterPackCooldown.text = StarterPackModel.CooldownTimeEvent.TotalMinutes.ToString();
		this.view.SocialUserName = ((!PlayGamesPlatform.Instance.IsAuthenticated()) ? string.Empty : PlayGamesPlatform.Instance.localUser.userName);
		PremiumAccountController instance = PremiumAccountController.Instance;
	}

	// Token: 0x06004319 RID: 17177 RVA: 0x00163A74 File Offset: 0x00161C74
	private void Awake()
	{
		if (this.view != null)
		{
			if (this.view.set60FpsCheckbox != null)
			{
				this.view.set60FpsCheckbox.startsActive = Application.targetFrameRate == 60;
			}
			if (this.view.tempGunCheckbox != null)
			{
				this.view.tempGunCheckbox.startsActive = TempItemsController.sharedController.ContainsItem(WeaponTags.Impulse_Sniper_Rifle_Tag);
			}
			int @int = Storager.getInt(Defs.TrainingCompleted_4_4_Sett, false);
			if (this.view.trainingCheckbox != null)
			{
				this.view.trainingCheckbox.startsActive = Convert.ToBoolean(@int);
			}
			if (this.view.downgradeResolutionCheckbox != null)
			{
				this.view.downgradeResolutionCheckbox.startsActive = Convert.ToBoolean(PlayerPrefs.GetInt("Dev.ResolutionDowngrade", 1));
			}
			if (this.view.isPayingCheckbox != null)
			{
				this.view.isPayingCheckbox.startsActive = FlurryPluginWrapper.IsPayingUser();
			}
			if (this.view.deviceInfo != null)
			{
				this.view.deviceInfo.text = string.Format("{0} {{ Memory: {1}Mb }}  W: {2}  {3}\r\n{4}", new object[]
				{
					SystemInfo.deviceModel,
					SystemInfo.systemMemorySize,
					Screen.width,
					"Q: " + QualitySettings.GetQualityLevel(),
					Device.FormatGpuModelMemoryRating()
				});
			}
			if (this.view.marathonTestMode != null)
			{
				this.view.MarathonTestMode = PlayerPrefs.GetInt(Defs.MarathonTestMode, 0) == 1;
			}
			if (this.view.marathonCurrentDay != null)
			{
				this.view.MarathonDayInput = Storager.getInt(Defs.NextMarafonBonusIndex, false);
			}
			if (this.view.gameGUIOffMode != null)
			{
				this.view.GameGUIOffMode = PlayerPrefs.GetInt(Defs.GameGUIOffMode, 0) == 1;
			}
		}
	}

	// Token: 0x0600431A RID: 17178 RVA: 0x0002973F File Offset: 0x0002793F
	private IEnumerator Start()
	{
		if (this.view != null)
		{
			this.Refresh();
		}
		this._enemiesInCampaignDirty = new bool?(false);
		yield return null;
		this._initialized = true;
		yield break;
	}

	// Token: 0x0600431B RID: 17179 RVA: 0x00163C78 File Offset: 0x00161E78
	public void ChangePremiumAccountLiveTime(UIInput input)
	{
		string name = input.name;
		if (!(name == "OneDayInput") && !(name == "ThreeDayInput") && !(name == "SevenDayInput"))
		{
			name == "MonthDayInput";
		}
		double num = 0.0;
		double.TryParse(input.value, out num);
	}

	// Token: 0x0600431C RID: 17180 RVA: 0x0002974E File Offset: 0x0002794E
	public void ClearAllPremiumAccounts()
	{
		MonoBehaviour.print("you dont");
	}

	// Token: 0x0600431D RID: 17181 RVA: 0x000026FB File Offset: 0x000008FB
	public void ClearCurrentPremiumAccont()
	{
	}

	// Token: 0x0600431E RID: 17182 RVA: 0x00163CD8 File Offset: 0x00161ED8
	private void HandleGemsInputSubmit(UIInput input)
	{
		if (input == null || string.IsNullOrEmpty(input.value))
		{
			return;
		}
		int num;
		if (int.TryParse(input.value, out num))
		{
			Storager.setInt("GemsCurrency", num, false);
		}
	}

	// Token: 0x0600431F RID: 17183 RVA: 0x00163D18 File Offset: 0x00161F18
	private void Update()
	{
		if (this._backRequested)
		{
			this._backRequested = false;
			this.HandleCoinsInputSubmit(this.view.coinsInput);
			this.HandleGemsInputSubmit(this.view.gemsInput);
			this.HandleEnemyCountInSurvivalWaveInput(this.view.enemyCountInSurvivalWave);
			if (this._enemiesInCampaignDirty != null && this._enemiesInCampaignDirty.Value)
			{
				this.HandleEnemiesInCampaignInput(this.view.enemiesInCampaignInput);
			}
			if (this._needsRestart)
			{
				Application.Quit();
				return;
			}
			Application.LoadLevel(Defs.MainMenuScene);
		}
	}

	// Token: 0x06004320 RID: 17184 RVA: 0x0002975A File Offset: 0x0002795A
	private void LateUpdate()
	{
		if (Input.GetKeyUp(KeyCode.Escape))
		{
			this._backRequested = true;
		}
	}

	// Token: 0x06004321 RID: 17185 RVA: 0x00163DAC File Offset: 0x00161FAC
	public void OnChangeStarterPackLive(UIInput inputField)
	{
		if (inputField == null || string.IsNullOrEmpty(inputField.value))
		{
			return;
		}
		float num = 0f;
		float.TryParse(inputField.value, out num);
		if (num > 0f)
		{
			StarterPackModel.MaxLiveTimeEvent = TimeSpan.FromMinutes((double)num);
		}
	}

	// Token: 0x06004322 RID: 17186 RVA: 0x00163DF8 File Offset: 0x00161FF8
	public void OnChangeStarterPackCooldown(UIInput inputField)
	{
		if (inputField == null || string.IsNullOrEmpty(inputField.value))
		{
			return;
		}
		float num = 0f;
		float.TryParse(inputField.value, out num);
		if (num > 0f)
		{
			StarterPackModel.CooldownTimeEvent = TimeSpan.FromMinutes((double)num);
		}
	}

	// Token: 0x0400351B RID: 13595
	public DeveloperConsoleView view;

	// Token: 0x0400351C RID: 13596
	public static bool isDebugGuiVisible;

	// Token: 0x0400351D RID: 13597
	private bool? _enemiesInCampaignDirty;

	// Token: 0x0400351E RID: 13598
	private bool _backRequested;

	// Token: 0x0400351F RID: 13599
	private bool _initialized;

	// Token: 0x04003520 RID: 13600
	private bool _needsRestart;
}
