using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[AddComponentMenu(SOArchitecture_Utility.EVENT_LISTENER_SUBMENU + "Die")]
	public sealed class DieGameEventListener : BaseGameEventListener<Die, DieGameEvent, DieUnityEvent>
	{
	}
}