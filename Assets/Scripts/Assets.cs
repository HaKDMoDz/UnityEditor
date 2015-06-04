using UnityEngine;



/// <summary>
/// Class for loading assets of UnityEditor project.
/// </summary>
public static class Assets
{
	/// <summary>
	/// Loads an asset stored at path in a Resources folder.
	/// </summary>
	/// <returns>The asset at path if it can be found otherwise returns null.</returns>
	/// <param name="path">Pathname of the target folder.</param>
	/// <typeparam name="T">Type of resource.</typeparam>
	public static T LoadResource<T>(string path) where T : UnityEngine.Object
	{
		T res = Resources.Load<T>(path);
		
		if (res == null)
		{
			Debug.LogError("Resource \"" + path + "\" is not found");
		}
		
		return res;
	}

	#region Common assets
	/// <summary>
	/// Common assets.
	/// </summary>
	public static class Common
	{
		/// <summary>
		/// Common fonts.
		/// </summary>
        public static class Fonts
        {
			public static Font microsoftSansSerif = LoadResource<Font>("Fonts/micross");
        }
	}
	#endregion

	#region Assets for Cursors
	/// <summary>
	/// Assets for Cursors.
	/// </summary>
	public static class Cursors
	{
		public static Texture2D eastWest           = LoadResource<Texture2D>("Cursors/EastWest");
		public static Texture2D northEastSouthWest = LoadResource<Texture2D>("Cursors/NorthEastSouthWest");
		public static Texture2D northSouth         = LoadResource<Texture2D>("Cursors/NorthSouth");
		public static Texture2D northWestSouthEast = LoadResource<Texture2D>("Cursors/NorthWestSouthEast");
	}
	#endregion

	#region Assets for Windows
	/// <summary>
	/// Assets for Windows.
	/// </summary>
	public static class Windows
	{
		#region Common assets for windows
		/// <summary>
		/// Common assets for windows.
		/// </summary>
		public static class Common
		{
			/// <summary>
			/// Common texture assets for windows.
			/// </summary>
			public static class Textures
			{
				public static Sprite window                     = LoadResource<Sprite>("Textures/UI/Windows/Common/Window");
				public static Sprite subWindow                  = LoadResource<Sprite>("Textures/UI/Windows/Common/SubWindow");
				public static Sprite drawer                     = LoadResource<Sprite>("Textures/UI/Windows/Common/Drawer");
				public static Sprite minimizeButton             = LoadResource<Sprite>("Textures/UI/Windows/Common/MinimizeButton");
				public static Sprite minimizeButtonHighlighted  = LoadResource<Sprite>("Textures/UI/Windows/Common/MinimizeButtonHighlighted");
				public static Sprite minimizeButtonPressed      = LoadResource<Sprite>("Textures/UI/Windows/Common/MinimizeButtonPressed");
				public static Sprite maximizeButton             = LoadResource<Sprite>("Textures/UI/Windows/Common/MaximizeButton");
				public static Sprite maximizeButtonHighlighted  = LoadResource<Sprite>("Textures/UI/Windows/Common/MaximizeButtonHighlighted");
				public static Sprite maximizeButtonPressed      = LoadResource<Sprite>("Textures/UI/Windows/Common/MaximizeButtonPressed");
				public static Sprite normalizeButton            = LoadResource<Sprite>("Textures/UI/Windows/Common/NormalizeButton");
				public static Sprite normalizeButtonHighlighted = LoadResource<Sprite>("Textures/UI/Windows/Common/NormalizeButtonHighlighted");
				public static Sprite normalizeButtonPressed     = LoadResource<Sprite>("Textures/UI/Windows/Common/NormalizeButtonPressed");
				public static Sprite closeButton                = LoadResource<Sprite>("Textures/UI/Windows/Common/CloseButton");
				public static Sprite closeButtonHighlighted     = LoadResource<Sprite>("Textures/UI/Windows/Common/CloseButtonHighlighted");
				public static Sprite closeButtonPressed         = LoadResource<Sprite>("Textures/UI/Windows/Common/CloseButtonPressed");
				public static Sprite toolCloseButton            = LoadResource<Sprite>("Textures/UI/Windows/Common/ToolCloseButton");
				public static Sprite toolCloseButtonHighlighted = LoadResource<Sprite>("Textures/UI/Windows/Common/ToolCloseButtonHighlighted");
				public static Sprite toolCloseButtonPressed     = LoadResource<Sprite>("Textures/UI/Windows/Common/ToolCloseButtonPressed");
			}
		}
		#endregion

		#region Assets for MainWindow
		/// <summary>
		/// Assets for MainWindow.
		/// </summary>
		public static class MainWindow
		{
			#region Assets for MainMenu
			/// <summary>
			/// Assets for MainMenu.
			/// </summary>
			public static class MainMenu
			{
				/// <summary>
				/// Texture assets for MainMenu.
				/// </summary>
				public static class Textures
				{
					public static Sprite background        = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/MainMenu/Background");
					public static Sprite button            = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/MainMenu/Button");
					public static Sprite buttonHighlighted = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/MainMenu/ButtonHighlighted");
					public static Sprite buttonPressed     = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/MainMenu/ButtonPressed");
				}
			}
			#endregion
			
			#region Assets for Toolbar
			/// <summary>
			/// Assets for Toolbar.
			/// </summary>
			public static class Toolbar
			{
				/// <summary>
				/// Texture assets for Toolbar.
				/// </summary>
				public static class Textures
				{
					public static Sprite background                    = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/Background");
					public static Sprite toolLeftButton                = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolLeftButton");
					public static Sprite toolLeftButtonPressed         = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolLeftButtonPressed");
					public static Sprite toolLeftButtonActive          = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolLeftButtonActive");
					public static Sprite toolLeftButtonActivePressed   = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolLeftButtonActivePressed");
					public static Sprite toolMiddleButton              = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolMiddleButton");
					public static Sprite toolMiddleButtonPressed       = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolMiddleButtonPressed");
					public static Sprite toolMiddleButtonActive        = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolMiddleButtonActive");
					public static Sprite toolMiddleButtonActivePressed = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolMiddleButtonActivePressed");
					public static Sprite toolRightButton               = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolRightButton");
					public static Sprite toolRightButtonPressed        = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolRightButtonPressed");
					public static Sprite toolRightButtonActive         = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolRightButtonActive");
					public static Sprite toolRightButtonActivePressed  = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolRightButtonActivePressed");
					public static Sprite toolHand                      = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolHand");
					public static Sprite toolHandActive                = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolHandActive");
					public static Sprite toolMove                      = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolMove");
					public static Sprite toolMoveActive                = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolMoveActive");
					public static Sprite toolRotate                    = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolRotate");
					public static Sprite toolRotateActive              = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolRotateActive");
					public static Sprite toolScale                     = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolScale");
					public static Sprite toolScaleActive               = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolScaleActive");
					public static Sprite toolRectTransform             = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolRectTransform");
					public static Sprite toolRectTransformActive       = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolRectTransformActive");
					public static Sprite center                        = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/Center");
					public static Sprite pivot                         = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/Pivot");
					public static Sprite local                         = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/Local");
					public static Sprite global                        = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/Global");
					public static Sprite play                          = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/Play");
					public static Sprite playActive                    = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/PlayActive");
					public static Sprite pause                         = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/Pause");
					public static Sprite pauseActive                   = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/PauseActive");
					public static Sprite step                          = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/Step");
					public static Sprite stepActive                    = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/StepActive");
					public static Sprite popupButton                   = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/PopupButton");
				}
			}
			#endregion

			#region Assets for DockWidgets
			/// <summary>
			/// Assets for DockWidgets.
			/// </summary>
			public static class DockWidgets
			{
				#region Assets for DockingArea
				/// <summary>
				/// Assets for DockingArea.
				/// </summary>
				public static class DockingArea
				{
					/// <summary>
					/// Texture assets for DockingArea.
					/// </summary>
					public static class Textures
					{
						public static Sprite background = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/DockWidgets/DockingArea/Background");
					}
				}
				#endregion
			}
			#endregion
		}
		#endregion
	}
	#endregion

	#region Assets for Popups
	/// <summary>
	/// Assets for Popups.
	/// </summary>
	public static class Popups
	{		
		/// <summary>
		/// Texture assets for Popups.
		/// </summary>
		public static class Textures
		{
			public static Sprite popupBackground   = LoadResource<Sprite>("Textures/UI/Popups/PopupBackground");
			public static Sprite background        = LoadResource<Sprite>("Textures/UI/Popups/Background");
			public static Sprite separator         = LoadResource<Sprite>("Textures/UI/Popups/Separator");
			public static Sprite button            = LoadResource<Sprite>("Textures/UI/Popups/Button");
			public static Sprite buttonDisabled    = LoadResource<Sprite>("Textures/UI/Popups/ButtonDisabled");
			public static Sprite buttonHighlighted = LoadResource<Sprite>("Textures/UI/Popups/ButtonHighlighted");
			public static Sprite arrow             = LoadResource<Sprite>("Textures/UI/Popups/Arrow");
			public static Sprite checkbox          = LoadResource<Sprite>("Textures/UI/Popups/Checkbox");
		}
	}
	#endregion

	#region Assets for Tooltips
	/// <summary>
	/// Assets for Tooltips.
	/// </summary>
	public static class Tooltips
	{
		/// <summary>
		/// Texture assets for Tooltips.
		/// </summary>
		public static class Textures
		{
			public static Sprite tooltipBackground = LoadResource<Sprite>("Textures/UI/Tooltips/TooltipBackground");
        }
    }
	#endregion

	#region Assets for Toasts
	/// <summary>
	/// Assets for Toasts.
	/// </summary>
	public static class Toasts
	{		
		/// <summary>
		/// Texture assets for Toasts.
		/// </summary>
		public static class Textures
		{
			public static Sprite toastBackground = LoadResource<Sprite>("Textures/UI/Toasts/ToastBackground");
        }
    }
    #endregion
}