using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	[CreateAssetMenu(
	    fileName = "DieGameEvent.asset",
	    menuName = SOArchitecture_Utility.GAME_EVENT + "Dice",
	    order = 121)]
	public sealed class DieGameEvent : GameEventBase<Die>
	{
	}
}