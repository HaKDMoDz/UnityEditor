﻿using UnityEngine;
using UnityEngine.UI;

using Common;
using UI.Popups;
using UI.Toasts;
using UI.Tooltips;
using UI.Windows.MainWindow;



namespace UI
{
	/// <summary>
	/// Master script.
	/// </summary>
	public class MasterScript : MonoBehaviour
	{
		/// <summary>
		/// Script starting callback.
		/// </summary>
		void Start()
		{
			CreateUI();
		}
		
		/// <summary>
		/// Creates user interface.
		/// </summary>
		private void CreateUI()
		{
			//***************************************************************************
			// Windows GameObject
			//***************************************************************************
			#region Windows GameObject
			GameObject windows = new GameObject("Windows");
			Utils.InitUIObject(windows, transform);
			
			//===========================================================================
			// RectTransform Component
			//===========================================================================
			#region RectTransform Component
			RectTransform windowsTransform = windows.AddComponent<RectTransform>();
			Utils.AlignRectTransformStretchStretch(windowsTransform);
			
			Global.windowsTransform = windowsTransform;
			#endregion
			#endregion


			
			//***************************************************************************
			// PopupMenuArea GameObject
			//***************************************************************************
			#region PopupMenuArea GameObject
			GameObject popupMenuArea = new GameObject("PopupMenuArea");
			Utils.InitUIObject(popupMenuArea, transform);
			
			//===========================================================================
			// RectTransform Component
			//===========================================================================
			#region RectTransform Component
			RectTransform popupMenuAreaTransform = popupMenuArea.AddComponent<RectTransform>();
			Utils.AlignRectTransformStretchStretch(popupMenuAreaTransform);

			Global.popupMenuAreaTransform = popupMenuAreaTransform;
			#endregion
			
			//===========================================================================
			// PopupMenuAreaScript Component
			//===========================================================================
			#region PopupMenuAreaScript Component
			Global.popupMenuAreaScript = popupMenuArea.AddComponent<PopupMenuAreaScript>();
			#endregion
			#endregion



			//***************************************************************************
			// TooltipArea GameObject
			//***************************************************************************
			#region TooltipArea GameObject
			GameObject tooltipArea = new GameObject("TooltipArea");
			Utils.InitUIObject(tooltipArea, transform);
			
			//===========================================================================
			// RectTransform Component
			//===========================================================================
			#region RectTransform Component
			RectTransform tooltipAreaTransform = tooltipArea.AddComponent<RectTransform>();
			Utils.AlignRectTransformStretchStretch(tooltipAreaTransform);
			#endregion
			
			//===========================================================================
			// TooltipAreaScript Component
			//===========================================================================
			#region TooltipAreaScript Component
			Global.tooltipAreaScript = tooltipArea.AddComponent<TooltipAreaScript>();
			#endregion
			#endregion



			//***************************************************************************
			// ToastArea GameObject
			//***************************************************************************
			#region ToastArea GameObject
			GameObject toastArea = new GameObject("ToastArea");
			Utils.InitUIObject(toastArea, transform);
			
			//===========================================================================
			// RectTransform Component
			//===========================================================================
			#region RectTransform Component
			RectTransform toastAreaTransform = toastArea.AddComponent<RectTransform>();
			Utils.AlignRectTransformStretchStretch(toastAreaTransform);
			#endregion
			
			//===========================================================================
			// ToastAreaScript Component
			//===========================================================================
			#region ToastAreaScript Component
			Global.toastAreaScript = toastArea.AddComponent<ToastAreaScript>();
			#endregion
			#endregion
		


			MainWindowScript.Create().Show();
		}
	}
}
