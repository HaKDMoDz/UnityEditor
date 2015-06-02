using UnityEngine;
using UnityEngine.EventSystems;
using UnityTranslation;



namespace UI.Tooltips
{
	/// <summary>
	/// Script that realize behaviour for tooltip owner.
	/// </summary>
	public class TooltipOwnerScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
	{
		private R.sections.Tooltips.strings mTokenId = R.sections.Tooltips.strings.Count;



		/// <summary>
		/// Gets or sets token ID for translation.
		/// </summary>
		/// <value>Token ID for translation.</value>
		public R.sections.Tooltips.strings tokenId
		{
			get { return mTokenId;  }
			set { mTokenId = value; }
		}



		/// <summary>
		/// Handler for destroy event.
		/// </summary>
		void OnDestroy()
		{
			Global.tooltipAreaScript.OnTooltipOwnerDestroy(this);
		}

		/// <summary>
		/// Handler for disable event.
		/// </summary>
		void OnDisable()
		{
			Global.tooltipAreaScript.OnTooltipOwnerDisable(this);
		}

		/// <summary>
		/// Handler for pointer enter event.
		/// </summary>
		public void OnPointerEnter(PointerEventData eventData)
		{
			Global.tooltipAreaScript.OnTooltipOwnerEnter(this);
		}

		/// <summary>
		/// Handler for pointer exit event.
		/// </summary>
		public void OnPointerExit(PointerEventData eventData)
        {
			Global.tooltipAreaScript.OnTooltipOwnerExit(this);
        }
    }
}