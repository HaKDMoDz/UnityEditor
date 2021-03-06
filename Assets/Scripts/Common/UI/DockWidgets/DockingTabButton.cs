using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

using Common.UI.DragAndDrop;



namespace Common.UI.DockWidgets
{
	/// <summary>
	/// Button component for docking group tab.
	/// </summary>
	public class DockingTabButton : Button, IBeginDragHandler, IDragHandler, IEndDragHandler
	{
		/// <summary>
		/// Gets or sets the dock widget.
		/// </summary>
		/// <value>The dock widget.</value>
		public DockWidgetScript dockWidget
		{
			get { return mDockWidget;  }
			set { mDockWidget = value; }
		}

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="Common.UI.DockWidgets.DockingTabButton"/> is active.
		/// </summary>
		/// <value><c>true</c> if active; otherwise, <c>false</c>.</value>
		public bool active
		{
			get
			{
				return mActive;  
			}

			set
			{
				if (mActive != value)
				{
					mActive = value;
				
					UpdateImage();
				}
			}
		}



		private DockWidgetScript mDockWidget;
		private bool             mActive;
		private bool             mSelected;



		/// <summary>
		/// Initializes a new instance of the <see cref="Common.UI.DockWidgets.DockingTabButton"/> class.
		/// </summary>
		public DockingTabButton()
			: base()
		{
			mDockWidget = null;
			mActive     = false;
			mSelected   = false;

			onClick.AddListener(buttonClicked);
		}

		/// <summary>
		/// Script starting callback.
		/// </summary>
		protected override void Start()
		{
			base.Start();

			UpdateImage();
		}

		/// <summary>
		/// Handler for select event.
		/// </summary>
		/// <param name="eventData">Pointer data.</param>
		public override void OnSelect(BaseEventData eventData)
		{
			base.OnSelect(eventData);

			mSelected = true;
			UpdateImage();
		}

		/// <summary>
		/// Handler for deselect event.
		/// </summary>
		/// <param name="eventData">Pointer data.</param>
		public override void OnDeselect(BaseEventData eventData)
		{
			base.OnDeselect(eventData);

			mSelected = false;
			UpdateImage();
		}

		/// <summary>
		/// Handler for begin drag event.
		/// </summary>
		/// <param name="eventData">Pointer data.</param>
		public void OnBeginDrag(PointerEventData eventData)
		{
			buttonClicked();

			DragHandler.dockWidget    = mDockWidget;
			DragHandler.handledByArea = null;
			DragHandler.mouseLocation = DragHandler.MouseLocation.Outside;
			DragHandler.minimum       = float.MaxValue;

			foreach (DockingAreaScript dockingArea in DockingAreaScript.instances)
			{
				dockingArea.CacheDragInfo();
            }

			StartCoroutine(CreateDraggingImage(eventData));
		}

		/// <summary>
		/// Handler for drag event.
		/// </summary>
		/// <param name="eventData">Pointer data.</param>
		public void OnDrag(PointerEventData eventData)
		{
			DragHandler.handledByArea = null;
			DragHandler.mouseLocation = DragHandler.MouseLocation.Outside;
			DragHandler.minimum       = float.MaxValue;

			foreach (DockingAreaScript dockingArea in DockingAreaScript.instances)
			{
				dockingArea.ProcessDockWidgetDrag(eventData);
			}

			if (DragHandler.handledByArea != null)
			{
				DragData.HideImage();
			}
			else
			{
				DummyDockWidgetScript.DestroyInstance();

				DragData.ShowImage();
				DragData.Drag(eventData);
			}
		}

		/// <summary>
		/// Handler for end drag event.
		/// </summary>
		/// <param name="eventData">Pointer data.</param>
		public void OnEndDrag(PointerEventData eventData)
		{
			DummyDockWidgetScript.DestroyInstance();

			if (DragHandler.handledByArea != null)
            {
				DragHandler.handledByArea.DropDockWidget();
			}
			else
			{
				// TODO: Put dock widget in window
			}

			DragHandler.dockWidget    = null;
			DragHandler.handledByArea = null;
			DragHandler.mouseLocation = DragHandler.MouseLocation.Outside;
			DragHandler.minimum       = float.MaxValue;

			foreach (DockingAreaScript dockingArea in DockingAreaScript.instances)
			{
				dockingArea.ClearDragInfo();
            }
            
            DragData.EndDrag(eventData);
		}

		/// <summary>
		/// Creates the dragging image.
		/// </summary>
		/// <returns>The dragging image.</returns>
		/// <param name="eventData">Pointer data.</param>
		public IEnumerator CreateDraggingImage(PointerEventData eventData)
		{
			yield return new WaitForEndOfFrame();

			Vector3[] corners = Utils.GetWindowCorners(mDockWidget.parent.transform as RectTransform);
			
			int widgetX      = (int)corners[0].x;
			int widgetY      = (int)corners[0].y;
			int widgetWidth  = (int)(corners[3].x - corners[0].x);
			int widgetHeight = (int)(corners[3].y - corners[0].y);

			float dragPosX = eventData.pressPosition.x - widgetX;
			float dragPosY = Screen.height - eventData.pressPosition.y - widgetY;
			
			DragData.BeginDrag(
								 eventData
							   , DraggingType.DockWidget
							   , gameObject
							   , Sprite.Create(
							                     Utils.TakeScreenshot(widgetX, widgetY, widgetWidth, widgetHeight)
							                   , new Rect(0, 0, widgetWidth, widgetHeight)
						                       , new Vector2(0.5f, 0.5f)
				                              )
							   , widgetWidth
							   , widgetHeight
							   , dragPosX
							   , dragPosY
			                  );
		}

		/// <summary>
		/// Button click handler.
		/// </summary>
		private void buttonClicked()
		{
			mDockWidget.Select();
		}

		/// <summary>
		/// Updates background image.
		/// </summary>
		private void UpdateImage()
		{
			if (mActive)
			{
				if (mSelected)
				{
					image.sprite = Assets.DockWidgets.Textures.tabSelected;
				}
				else
				{
					image.sprite = Assets.DockWidgets.Textures.tabActive;
				}
			}
			else
			{
				image.sprite = Assets.DockWidgets.Textures.tab;
			}
		}
	}
}

