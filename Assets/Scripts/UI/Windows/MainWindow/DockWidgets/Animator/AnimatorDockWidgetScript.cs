using UnityEngine;

using Common;
using Common.UI.DockWidgets;



namespace UI.Windows.MainWindow.DockWidgets.Animator
{
	/// <summary>
	/// Script that realize animator dock widget behaviour.
	/// </summary>
	public class AnimatorDockWidgetScript : DockWidgetScript
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="UI.Windows.MainWindow.DockWidgets.Animator.AnimatorDockWidgetScript"/> class.
		/// </summary>
		private AnimatorDockWidgetScript()
			: base()
		{
			image   = Assets.Windows.MainWindow.DockWidgets.Animator.Textures.icon;
			tokenId = UnityTranslation.R.sections.DockWidgets.strings.animator;
		}
		
		/// <summary>
		/// Initializes a new instance of the <see cref="UI.Windows.MainWindow.DockWidgets.Animator.AnimatorDockWidgetScript"/> class.
		/// </summary>
		public static AnimatorDockWidgetScript Create()
		{
			if (Global.animatorDockWidgetScript == null)
			{
				//***************************************************************************
				// Animator GameObject
				//***************************************************************************
				#region Animator GameObject
				GameObject animator = new GameObject("Animator");
				Utils.InitUIObject(animator, Global.dockingAreaScript.transform);
				
				//===========================================================================
				// AnimatorDockWidgetScript Component
				//===========================================================================
				#region AnimatorDockWidgetScript Component
				Global.animatorDockWidgetScript = animator.AddComponent<AnimatorDockWidgetScript>();
				#endregion
				#endregion
			}
			
			return Global.animatorDockWidgetScript;
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
			if (Global.animatorDockWidgetScript == this)
			{
				Global.animatorDockWidgetScript = null;
			}
			else
			{
				Debug.LogError("Unexpected behaviour in AnimatorDockWidgetScript.OnDestroy");
			}
		}
	}
}