using UnityEngine;

using Common;
using Common.UI.DockWidgets;



namespace UI.Windows.MainWindow.DockWidgets.Profiler
{
	/// <summary>
	/// Script that realize profiler dock widget behaviour.
	/// </summary>
	public class ProfilerDockWidgetScript : DockWidgetScript
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="UI.Windows.MainWindow.DockWidgets.Profiler.ProfilerDockWidgetScript"/> class.
		/// </summary>
		private ProfilerDockWidgetScript()
			: base()
		{
			image   = Assets.Windows.MainWindow.DockWidgets.Profiler.Textures.icon;
			tokenId = UnityTranslation.R.sections.DockWidgets.strings.profiler;
		}
		
		/// <summary>
		/// Initializes a new instance of the <see cref="UI.Windows.MainWindow.DockWidgets.Profiler.ProfilerDockWidgetScript"/> class.
		/// </summary>
		public static ProfilerDockWidgetScript Create()
		{
			if (Global.profilerDockWidgetScript == null)
			{
				//***************************************************************************
				// Profiler GameObject
				//***************************************************************************
				#region Profiler GameObject
				GameObject profiler = new GameObject("Profiler");
				Utils.InitUIObject(profiler, Global.dockingAreaScript.transform);
				
				//===========================================================================
				// ProfilerDockWidgetScript Component
				//===========================================================================
				#region ProfilerDockWidgetScript Component
				Global.profilerDockWidgetScript = profiler.AddComponent<ProfilerDockWidgetScript>();
				#endregion
				#endregion
			}
			
			return Global.profilerDockWidgetScript;
		}
		
		/// <summary>
		/// Creates the content.
		/// </summary>
		/// <param name="contentTransform">Content transform.</param>
		protected override void CreateContent(Transform contentTransform)
		{
			// TODO: Implement
			backgroundColor = new Color(1f, 0f, 0f);
		}
		
		/// <summary>
		/// Handler for destroy event.
		/// </summary>
		void OnDestroy()
		{						
			if (Global.profilerDockWidgetScript == this)
			{
				Global.profilerDockWidgetScript = null;
			}
			else
			{
				Debug.LogError("Unexpected behaviour in ProfilerDockWidgetScript.OnDestroy");
			}
		}
	}
}