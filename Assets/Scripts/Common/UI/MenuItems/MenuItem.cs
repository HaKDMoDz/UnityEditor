using UnityEngine;
using UnityEngine.Events;
using UnityTranslation;



namespace Common.UI.MenuItems
{
	/// <summary>
	/// Menu item.
	/// </summary>
	public class MenuItem : CustomMenuItem
	{
		/// <summary>
		/// Gets or sets the token ID for translation.
		/// </summary>
		/// <value>The token identifier.</value>
		public R.sections.MenuItems.strings tokenId
		{
			get { return mTokenId;  }
			set { mTokenId = value; }
		}
		
		/// <summary>
		/// Gets or sets the token arguments.
		/// </summary>
		/// <value>The token arguments.</value>
		public object[] tokenArguments
		{
			get { return mTokenArguments;  }
			set { mTokenArguments = value; }
		}
		
		/// <summary>
		/// Gets the menu item name.
		/// </summary>
		/// <value>The menu item name.</value>
		public string name
		{
			get
			{
				if (mText != null)
				{
					return mText;
				}
				
				if (mTokenId != R.sections.MenuItems.strings.Count)
				{
					return mTokenId.ToString();
				}
				
				Debug.LogError("MenuItem.Name returns empty string");
				return "";
			}
		}
		
		/// <summary>
		/// Gets or sets the menu item text.
		/// </summary>
		/// <value>The menu item text.</value>
		public string text
		{
			get
			{
				if (mText != null)
				{
					return mText;
				}
				
				if (mTokenId != R.sections.MenuItems.strings.Count)
				{
					if (mTokenArguments == null || mTokenArguments.Length == 0)
					{
						return Translator.getString(mTokenId);
					}
					else
					{
						return Translator.getString(mTokenId, mTokenArguments);
					}
				}
				
				Debug.LogError("MenuItem.Text returns empty string");
				return "";
			}
			
			set
			{
				if (value == null || value == "")
				{
					mText = null;
				}
				else
				{
					mText = value;
				}
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="Common.UI.MenuItems.MenuItem"/> is enabled.
		/// </summary>
		/// <value><c>true</c> if enabled; otherwise, <c>false</c>.</value>
		public bool enabled
		{
			get
			{
				return mEnabled; 
			}
			
			set
			{
				if (mEnabled != value)
				{
					mEnabled = value; 
					
					if (mShortcutHandler != null)
					{
						if (mEnabled)
						{
							mShortcutHandler.RegisterShortcut(this);
						}
						else
						{
							mShortcutHandler.DeregisterShortcut(this);
						}
					}
				}
			}
		}
		
		/// <summary>
		/// Gets the click event handler.
		/// </summary>
		/// <value>The click event handler.</value>
		public UnityAction onClick
		{
			get { return mOnClick; }
		}
		
		/// <summary>
		/// Gets the shortcut.
		/// </summary>
		/// <value>The shortcut.</value>
		public string shortcut
		{
			get
			{
				if (mShortcut != null)
				{
					return mShortcut.ToString();
				}
				
				return null; 
			}
		}
		
		/// <summary>
		/// Gets or sets menu radio group.
		/// </summary>
		/// <value>Menu radio group.</value>
		public MenuRadioGroup radioGroup
		{
			get { return mRadioGroup;  }
			set { mRadioGroup = value; }
		}



		private R.sections.MenuItems.strings mTokenId;
		private object[]                     mTokenArguments;
		private string                       mText;
		private bool                         mEnabled;
		private UnityAction                  mOnClick;
		private IShortcutHandler             mShortcutHandler;
		private KeyboardInput                mShortcut;
		private MenuRadioGroup               mRadioGroup;
		


		/// <summary>
		/// Initializes a new instance of the <see cref="Common.UI.MenuItems.MenuItem"/> class.
		/// </summary>
		/// <param name="tokenId">Token ID for translation.</param>
		/// <param name="tokenArguments">Arguments for provided token ID.</param>
		/// <param name="text">Menu item text.</param>
		/// <param name="enabled">Is this menu item enabled or not.</param>
		/// <param name="onClick">Click event handler.</param>
		/// <param name="shortcutHandler">Shortcut handler.</param>
		/// <param name="shortcut">Shortcut.</param>
		/// <param name="radioGroup">Menu radio group.</param>
		private MenuItem(
						   R.sections.MenuItems.strings tokenId         = R.sections.MenuItems.strings.Count
						 , object[]                     tokenArguments  = null
						 , string                       text            = null
						 , bool                         enabled         = false
						 , UnityAction                  onClick         = null
						 , IShortcutHandler             shortcutHandler = null
						 , KeyboardInput                shortcut        = null
						 , MenuRadioGroup               radioGroup      = null
						)
			: base()
		{
			mTokenId         = tokenId;
			mTokenArguments  = tokenArguments;
			mText            = text;
			mEnabled         = enabled;
			mOnClick         = onClick;
			mShortcutHandler = shortcutHandler;
			mShortcut        = shortcut;
			mRadioGroup      = null;
			
			if (mShortcut == null)
			{
				mShortcutHandler = null;
			}
			
			if ((mShortcutHandler != null) && mEnabled)
			{
				mShortcutHandler.RegisterShortcut(this);
			}
			
			if (radioGroup != null)
			{
				radioGroup.Register(this);
			}
		}
		
		/// <summary>
		/// Initializes a new instance of the <see cref="Common.UI.MenuItems.MenuItem"/> class with given token ID and with
		/// assigning to specified <see cref="Common.TreeNode`1"/> instance.
		/// </summary>
		/// <param name="owner"><see cref="Common.TreeNode`1"/> instance.</param>
		/// <param name="tokenId">Token ID for translation.</param>
		/// <param name="onClick">Click event handler.</param>
		/// <param name="enabled">Is this menu item enabled or not.</param>
		/// <param name="shortcutHandler">Shortcut handler.</param>
		/// <param name="shortcut">Shortcut.</param>
		/// <param name="radioGroup">Menu radio group.</param>
		public static TreeNode<CustomMenuItem> Create(
													    TreeNode<CustomMenuItem>     owner
													  , R.sections.MenuItems.strings tokenId
													  , UnityAction                  onClick         = null
													  , bool                         enabled         = true
												      , IShortcutHandler             shortcutHandler = null
													  , string                       shortcut        = null
													  , MenuRadioGroup               radioGroup      = null
													 )
		{
			MenuItem item = new MenuItem(
										   tokenId                            // Token ID
										 , null                               // Token arguments
										 , null                               // Text
										 , enabled                            // Enabled
										 , onClick                            // Click event handler
										 , shortcutHandler    			      // Shortcut handler
									 	 , KeyboardInput.FromString(shortcut) // Shortcut
								 		 , radioGroup                         // Menu radio group
										);
			
			TreeNode<CustomMenuItem> node = owner.AddChild(item);
			
			item.mNode = node;
			
			return node;
		}
		
		/// <summary>
		/// Initializes a new instance of the <see cref="Common.UI.MenuItems.MenuItem"/> class with given text and with
		/// assigning to specified <see cref="Common.TreeNode`1"/> instance.
		/// </summary>
		/// <param name="owner"><see cref="Common.TreeNode`1"/> instance.</param>
		/// <param name="text">Menu item text.</param>
		/// <param name="onClick">Click event handler.</param>
		/// <param name="enabled">Is this menu item enabled or not.</param>
		/// <param name="shortcutHandler">Shortcut handler.</param>
		/// <param name="shortcut">Shortcut.</param>
		/// <param name="radioGroup">Menu radio group.</param>
		public static TreeNode<CustomMenuItem> Create(
													    TreeNode<CustomMenuItem> owner
													  , string 		             text
													  , UnityAction              onClick         = null
													  , bool                     enabled         = true
													  , IShortcutHandler         shortcutHandler = null
													  , string                   shortcut        = null
													  , MenuRadioGroup           radioGroup      = null
													 )
		{
			MenuItem item = new MenuItem(
										   R.sections.MenuItems.strings.Count // Token ID
										 , null    							  // Token arguments
										 , text                               // Text
										 , enabled 							  // Enabled
										 , onClick 							  // Click event handler
										 , shortcutHandler    			      // Shortcut handler
										 , KeyboardInput.FromString(shortcut) // Shortcut
										 , radioGroup                         // Menu radio group
										);
			
			TreeNode<CustomMenuItem> node = owner.AddChild(item);
			
			item.mNode = node;
			
			return node;
		}
		
		/// <summary>
		/// Verifies that shortcut was pressed and call click event handler.
		/// </summary>
		/// <returns><c>true</c>, if shortcut was handled, <c>false</c> otherwise.</returns>
		public bool HandleShortcut()
		{
			if (mShortcut.getInputDown(true) != 0)
			{
				mOnClick.Invoke();
				
				return true;
			}
			
			return false;
		}
	}
}
