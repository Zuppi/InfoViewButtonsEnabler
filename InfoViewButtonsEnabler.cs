using System;
using ICities;
using UnityEngine;
using ColossalFramework.UI;

namespace InfoViewEnabler
{
	public class InfoViewEnaberdesc : IUserMod 
	{
		
		public string Name
		{
			get { return "Info View Buttons Enabler"; }
		}
		
		public string Description 
		{
			get { return "All info view buttons are always enabled"; }
		}
	}
	
	public class InfoViewEnablerer : LoadingExtensionBase
	{
		ColossalFramework.UI.UIButton[] infoviewButtons;

		public override void OnLevelLoaded(LoadMode mode)
		{
			if (mode.Equals(LoadMode.NewGame) || mode.Equals(LoadMode.LoadGame)){
				infoviewButtons = GameObject.Find("InfoViewsPanel").transform.FindChild("Container").gameObject.GetComponentsInChildren<ColossalFramework.UI.UIButton>();
				ColossalFramework.UI.UIButton menuButton = GameObject.Find("InfoMenu").transform.FindChild("Info").GetComponent<ColossalFramework.UI.UIButton>();
				menuButton.eventClick += ButtonClick;
			}

		}

		private void ButtonClick(UIComponent component, UIMouseEventParameter eventParam)
		{
			foreach(ColossalFramework.UI.UIButton button in infoviewButtons){
				button.isEnabled = true;
			}
		}
	}
}

