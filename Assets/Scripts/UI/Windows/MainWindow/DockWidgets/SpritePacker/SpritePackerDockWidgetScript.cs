using UnityEngine;

using Common;
using Common.UI.DockWidgets;



namespace UI.Windows.MainWindow.DockWidgets.SpritePacker
{
	/// <summary>
	/// Script that realize spritePacker dock widget behaviour.
	/// </summary>
	public class SpritePackerDockWidgetScript : DockWidgetScript
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="UI.Windows.MainWindow.DockWidgets.SpritePacker.SpritePackerDockWidgetScript"/> class.
		/// </summary>
		private SpritePackerDockWidgetScript()
			: base()
		{
			image   = Assets.Windows.MainWindow.DockWidgets.SpritePacker.Textures.icon;
			tokenId = UnityTranslation.R.sections.DockWidgets.strings.sprite_packer;
		}
		
		/// <summary>
		/// Initializes a new instance of the <see cref="UI.Windows.MainWindow.DockWidgets.SpritePacker.SpritePackerDockWidgetScript"/> class.
		/// </summary>
		public static SpritePackerDockWidgetScript Create()
		{
			if (Global.spritePackerDockWidgetScript == null)
			{
				//***************************************************************************
				// SpritePacker GameObject
				//***************************************************************************
				#region SpritePacker GameObject
				GameObject spritePacker = new GameObject("SpritePacker");
				Utils.InitUIObject(spritePacker, Global.dockingAreaScript.transform);
				
				//===========================================================================
				// SpritePackerDockWidgetScript Component
				//===========================================================================
				#region SpritePackerDockWidgetScript Component
				Global.spritePackerDockWidgetScript = spritePacker.AddComponent<SpritePackerDockWidgetScript>();
				#endregion
				#endregion
			}
			
			return Global.spritePackerDockWidgetScript;
		}
		
		/// <summary>
		/// Creates the content.
		/// </summary>
		/// <param name="contentTransform">Content transform.</param>
		protected override void CreateContent(Transform contentTransform)
		{
			// TODO: Implement
			backgroundColor = new Color(0f, 0.3f, 0f);
		}
		
		/// <summary>
		/// Handler for destroy event.
		/// </summary>
		void OnDestroy()
		{			
			if (Global.spritePackerDockWidgetScript == this)
			{
				Global.spritePackerDockWidgetScript = null;
			}
			else
			{
				Debug.LogError("Unexpected behaviour in SpritePackerDockWidgetScript.OnDestroy");
			}
		}
	}
}