using UnityEngine;
using UnityEngine.Events;



namespace Common.UI.Listeners
{
	/// <summary>
	/// Script that listen for screen resize events.
	/// </summary>
	public class ResizeListenerScript : MonoBehaviour
	{
		private static readonly float CHECK_INTERVAL = 200f / 1000f;



		private static ResizeListenerScript instance = null;



		private float mScreenWidth;
		private float mScreenHeight;
		private float mDelay;

		private UnityEvent mListeners;



		/// <summary>
		/// Script starting callback.
		/// </summary>
		void Start()
		{
			if (instance == null)
			{
				instance = this;
			}
			else
			{
				Debug.LogError("Two instances of ResizeListenerScript not supported");
			}

			mScreenWidth  = Screen.width;
			mScreenHeight = Screen.height;
			mDelay        = CHECK_INTERVAL;

			mListeners = new UnityEvent();
		}

		/// <summary>
		/// Handler for destroy event.
		/// </summary>
		void OnDestroy()
		{
			if (instance == this)
			{
				instance = null;
			}
		}

		/// <summary>
		/// Update is called once per frame.
		/// </summary>
		void Update()
		{
			mDelay -= Time.deltaTime;

			if (mDelay < 0f)
			{
				mDelay = CHECK_INTERVAL;

				float screenWidth  = Screen.width;
				float screenHeight = Screen.height;

				if (
					mScreenWidth  != screenWidth
					||
					mScreenHeight != screenHeight
				   )
				{
					mScreenWidth  = screenWidth;
					mScreenHeight = screenHeight;

					mListeners.Invoke();
				}
			}
		}

		/// <summary>
		/// Adds the listener.
		/// </summary>
		/// <param name="listener">Listener.</param>
		public static void AddListener(UnityAction listener)
		{
			if (instance != null)
			{
				instance.mListeners.AddListener(listener);
			}
			else
			{
				Debug.LogError("There is no ResizeListenerScript instance");
			}
		}

		/// <summary>
		/// Removes the listener.
		/// </summary>
		/// <param name="listener">Listener.</param>
		public static void RemoveListener(UnityAction listener)
		{
			if (instance != null)
			{
				instance.mListeners.RemoveListener(listener);
			}
        }
	}
}

