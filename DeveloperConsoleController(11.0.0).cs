// FOR USE ONLY ON 10.3.0 UPWARDS
using System;
using System.Collections;
using Rilisoft;
using UnityEngine;

// Token: 0x02000AF2 RID: 2802
internal sealed class DeveloperConsoleController : MonoBehaviour
{
	// Token: 0x06005413 RID: 21523 RVA: 0x000028D0 File Offset: 0x00000AD0
	public DeveloperConsoleController()
	{
	}

	// Token: 0x06005414 RID: 21524 RVA: 0x000028FA File Offset: 0x00000AFA
	static DeveloperConsoleController()
	{
	}

	// Token: 0x06005415 RID: 21525 RVA: 0x000028FA File Offset: 0x00000AFA
	public void HandleInvalidateQuestConfig(UILabel label)
	{
	}

	// Token: 0x06005416 RID: 21526 RVA: 0x00032734 File Offset: 0x00030934
	public void HandleFacebookLoginReward(UIToggle toggle)
	{
		FacebookController.CheckAndGiveFacebookReward("test");
	}

	// Token: 0x06005417 RID: 21527 RVA: 0x00032740 File Offset: 0x00030940
	public void HandleBackButton()
	{
		this._backRequested = true;
	}

	// Token: 0x06005418 RID: 21528 RVA: 0x00032749 File Offset: 0x00030949
	public void HandleClearKeychainAndPlayerPrefs()
	{
		PlayerPrefs.DeleteAll();
		Application.Quit();
	}

	// Token: 0x06005419 RID: 21529 RVA: 0x001AE554 File Offset: 0x001AC754
	public void HandleLevelMinusButton()
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

	// Token: 0x0600541A RID: 21530 RVA: 0x000028FA File Offset: 0x00000AFA
	public void HandleTipsShownButton()
	{
	}

	// Token: 0x0600541B RID: 21531 RVA: 0x00032755 File Offset: 0x00030955
	public void HandleAddGemsButton()
	{
		BankController.AddGems(1000, true, AnalyticsConstants.AccrualType.Earned);
	}

	// Token: 0x0600541C RID: 21532 RVA: 0x00032763 File Offset: 0x00030963
	public void HandleAddCoinsButton()
	{
		BankController.AddCoins(1000, true, AnalyticsConstants.AccrualType.Earned);
	}

	// Token: 0x0600541D RID: 21533 RVA: 0x001AE5D0 File Offset: 0x001AC7D0
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

	// Token: 0x0600541E RID: 21534 RVA: 0x000028FA File Offset: 0x00000AFA
	public void HandleLevelChanged()
	{
	}

	// Token: 0x0600541F RID: 21535 RVA: 0x000028FA File Offset: 0x00000AFA
	public void HandleLevelSliderChanged()
	{
	}

	// Token: 0x06005420 RID: 21536 RVA: 0x001AE63C File Offset: 0x001AC83C
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

	// Token: 0x06005421 RID: 21537 RVA: 0x001AE67C File Offset: 0x001AC87C
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

	// Token: 0x06005422 RID: 21538 RVA: 0x00032771 File Offset: 0x00030971
	public void HandleEnemiesInCampaignChange()
	{
		if (this._enemiesInCampaignDirty != null)
		{
			this._enemiesInCampaignDirty = new bool?(true);
		}
	}

	// Token: 0x06005423 RID: 21539 RVA: 0x000028FA File Offset: 0x00000AFA
	public void HandleDayChange(UIInput input)
	{
	}

	// Token: 0x06005424 RID: 21540 RVA: 0x000028FA File Offset: 0x00000AFA
	public void HandleDaySubmit(UIInput input)
	{
	}

	// Token: 0x06005425 RID: 21541 RVA: 0x001AE6B8 File Offset: 0x001AC8B8
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

	// Token: 0x06005426 RID: 21542 RVA: 0x001AE6F4 File Offset: 0x001AC8F4
	public void HandleTrainingCompleteChanged(UIToggle toggle)
	{
		if (toggle == null)
		{
			return;
		}
		int num = Convert.ToInt32(toggle.value);
		Storager.setInt(Defs.TrainingCompleted_4_4_Sett, num, false);
	}

	// Token: 0x06005427 RID: 21543 RVA: 0x000028FA File Offset: 0x00000AFA
	public void HandleStrongDeviceChanged(UIToggle toggle)
	{
	}

	// Token: 0x06005428 RID: 21544 RVA: 0x0003278C File Offset: 0x0003098C
	public void HandleSet60FpsChanged(UIToggle toggle)
	{
		if (toggle == null)
		{
			return;
		}
		bool value = toggle.value;
		Application.targetFrameRate = 240;
	}

	// Token: 0x06005429 RID: 21545 RVA: 0x000327A9 File Offset: 0x000309A9
	public void HandleMouseControlChanged(UIToggle toggle)
	{
		if (toggle == null)
		{
			return;
		}
		Defs.isMouseControl = toggle.value;
	}

	// Token: 0x0600542A RID: 21546 RVA: 0x000327C0 File Offset: 0x000309C0
	public void HandleSpectatorMode(UIToggle toggle)
	{
		if (toggle == null)
		{
			return;
		}
		Defs.isRegimVidosDebug = toggle.value;
	}

	// Token: 0x0600542B RID: 21547 RVA: 0x000327D7 File Offset: 0x000309D7
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

	// Token: 0x0600542C RID: 21548 RVA: 0x001AE724 File Offset: 0x001AC924
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

	// Token: 0x0600542D RID: 21549 RVA: 0x001AE764 File Offset: 0x001AC964
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

	// Token: 0x0600542E RID: 21550 RVA: 0x0003280C File Offset: 0x00030A0C
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

	// Token: 0x0600542F RID: 21551 RVA: 0x000028FA File Offset: 0x00000AFA
	public void HandleIsPixelGunLowChanged(UIToggle toggle)
	{
	}

	// Token: 0x06005430 RID: 21552 RVA: 0x0003282C File Offset: 0x00030A2C
	public void HandleForcedEventX3Changed(UIToggle toggle)
	{
		if (toggle == null)
		{
			return;
		}
		bool initialized = this._initialized;
	}

	// Token: 0x06005431 RID: 21553 RVA: 0x0003283F File Offset: 0x00030A3F
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

	// Token: 0x06005432 RID: 21554 RVA: 0x000028FA File Offset: 0x00000AFA
	private static void SetItemsBought(bool bought, bool onlyGuns = true)
	{
	}

	// Token: 0x06005433 RID: 21555 RVA: 0x000028FA File Offset: 0x00000AFA
	public void HandleFillGunsButton()
	{
	}

	// Token: 0x06005434 RID: 21556 RVA: 0x000028FA File Offset: 0x00000AFA
	public void HandleClearPurchasesButton()
	{
	}

	// Token: 0x06005435 RID: 21557 RVA: 0x000028FA File Offset: 0x00000AFA
	public void HandleClearProgressButton()
	{
	}

	// Token: 0x06005436 RID: 21558 RVA: 0x000028FA File Offset: 0x00000AFA
	public void HandleFillProgressButton()
	{
	}

	// Token: 0x06005437 RID: 21559 RVA: 0x000028FA File Offset: 0x00000AFA
	public void HandleClearCloud()
	{
	}

	// Token: 0x06005438 RID: 21560 RVA: 0x000028FA File Offset: 0x00000AFA
	public void HandleUnbanUs(UIButton butt)
	{
	}

	// Token: 0x06005439 RID: 21561 RVA: 0x000028FA File Offset: 0x00000AFA
	public void HandleClearX3()
	{
	}

	// Token: 0x0600543A RID: 21562 RVA: 0x000028FA File Offset: 0x00000AFA
	private void RefreshRating(bool current)
	{
	}

	// Token: 0x0600543B RID: 21563 RVA: 0x000028FA File Offset: 0x00000AFA
	private void RefreshExperience()
	{
	}

	// Token: 0x0600543C RID: 21564 RVA: 0x000028FA File Offset: 0x00000AFA
	private void RefreshLevel()
	{
	}

	// Token: 0x0600543D RID: 21565 RVA: 0x000028FA File Offset: 0x00000AFA
	private void RefreshLevelSlider()
	{
	}

	// Token: 0x0600543E RID: 21566 RVA: 0x000028FA File Offset: 0x00000AFA
	public void HandleExperienceSliderChanged()
	{
	}

	// Token: 0x0600543F RID: 21567 RVA: 0x000028FA File Offset: 0x00000AFA
	public void HandleRatingSliderChanged()
	{
	}

	// Token: 0x06005440 RID: 21568 RVA: 0x000028FA File Offset: 0x00000AFA
	public void HandleSignInOuButton(UILabel socialUsernameLabel)
	{
	}

	// Token: 0x06005441 RID: 21569 RVA: 0x000028FA File Offset: 0x00000AFA
	public void SetMarathonTestMode(UIToggle toggle)
	{
	}

	// Token: 0x06005442 RID: 21570 RVA: 0x000028FA File Offset: 0x00000AFA
	public void SetMarathonCurrentDay(UIInput input)
	{
	}

	// Token: 0x06005443 RID: 21571 RVA: 0x000028FA File Offset: 0x00000AFA
	public void SetOffGameGUIMode(UIToggle toggle)
	{
	}

	// Token: 0x06005444 RID: 21572 RVA: 0x000028FA File Offset: 0x00000AFA
	public void ClearStarterPackData()
	{
	}

	// Token: 0x06005445 RID: 21573 RVA: 0x000028FA File Offset: 0x00000AFA
	private void Refresh()
	{
	}

	// Token: 0x06005446 RID: 21574 RVA: 0x00032859 File Offset: 0x00030A59
	private void Awake()
	{
		DeveloperConsoleController.instance = this;
	}

	// Token: 0x06005447 RID: 21575 RVA: 0x00032861 File Offset: 0x00030A61
	private void OnDestroy()
	{
		DeveloperConsoleController.instance = null;
	}

	// Token: 0x06005448 RID: 21576 RVA: 0x00032869 File Offset: 0x00030A69
	private IEnumerator Start()
	{
		yield break;
	}

	// Token: 0x06005449 RID: 21577 RVA: 0x000028FA File Offset: 0x00000AFA
	public void ChangePremiumAccountLiveTime(UIInput input)
	{
	}

	// Token: 0x0600544A RID: 21578 RVA: 0x000028FA File Offset: 0x00000AFA
	public void ClearAllPremiumAccounts()
	{
	}

	// Token: 0x0600544B RID: 21579 RVA: 0x000028FA File Offset: 0x00000AFA
	public void ClearCurrentPremiumAccont()
	{
	}

	// Token: 0x0600544C RID: 21580 RVA: 0x00032871 File Offset: 0x00030A71
	private void HandleGemsInputSubmit(UIInput input)
	{
		bool isActiveAndEnabled = input.isActiveAndEnabled;
	}

	// Token: 0x0600544D RID: 21581 RVA: 0x001AE7D0 File Offset: 0x001AC9D0
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

	// Token: 0x0600544E RID: 21582 RVA: 0x0003287A File Offset: 0x00030A7A
	private void OnEnable()
	{
		if (this._escapeSubscription != null)
		{
			this._escapeSubscription.Dispose();
		}
		this._escapeSubscription = BackSystem.Instance.Register(new Action(this.HandleEscape), "DevConsole");
	}

	// Token: 0x0600544F RID: 21583 RVA: 0x000328B0 File Offset: 0x00030AB0
	private void OnDisable()
	{
		if (this._escapeSubscription != null)
		{
			this._escapeSubscription.Dispose();
			this._escapeSubscription = null;
		}
	}

	// Token: 0x06005450 RID: 21584 RVA: 0x00032740 File Offset: 0x00030940
	private void HandleEscape()
	{
		this._backRequested = true;
	}

	// Token: 0x06005451 RID: 21585 RVA: 0x000028FA File Offset: 0x00000AFA
	public void OnChangeStarterPackLive(UIInput inputField)
	{
	}

	// Token: 0x06005452 RID: 21586 RVA: 0x000028FA File Offset: 0x00000AFA
	public void OnChangeStarterPackCooldown(UIInput inputField)
	{
	}

	// Token: 0x06005453 RID: 21587 RVA: 0x000028FA File Offset: 0x00000AFA
	public void UpdateStateActiveMemoryInfo()
	{
	}

	// Token: 0x06005454 RID: 21588 RVA: 0x000028FA File Offset: 0x00000AFA
	public void OnChangeStateMemoryInfo()
	{
	}

	// Token: 0x06005455 RID: 21589 RVA: 0x000028FA File Offset: 0x00000AFA
	public void OnChangeReviewActive()
	{
	}

	// Token: 0x06005456 RID: 21590 RVA: 0x000028FA File Offset: 0x00000AFA
	public void OnClickSystemBuff()
	{
	}

	// Token: 0x06005457 RID: 21591 RVA: 0x000028FA File Offset: 0x00000AFA
	public void OnClickRating()
	{
	}

	// Token: 0x06005458 RID: 21592 RVA: 0x000028FA File Offset: 0x00000AFA
	public void FillAll()
	{
	}

	// Token: 0x040043F0 RID: 17392
	public static DeveloperConsoleController instance;

	// Token: 0x040043F1 RID: 17393
	public DeveloperConsoleView view;

	// Token: 0x040043F2 RID: 17394
	public static bool isDebugGuiVisible;

	// Token: 0x040043F3 RID: 17395
	public bool isMiniConsole;

	// Token: 0x040043F4 RID: 17396
	private int sliderLevel;

	// Token: 0x040043F5 RID: 17397
	private IDisposable _escapeSubscription;

	// Token: 0x040043F6 RID: 17398
	public UIToggle buffToogle;

	// Token: 0x040043F7 RID: 17399
	public UIToggle ratingToogle;

	// Token: 0x040043F8 RID: 17400
	private bool? _enemiesInCampaignDirty;

	// Token: 0x040043F9 RID: 17401
	private bool _backRequested;

	// Token: 0x040043FA RID: 17402
	private bool _initialized;

	// Token: 0x040043FB RID: 17403
	private bool _needsRestart;
}
