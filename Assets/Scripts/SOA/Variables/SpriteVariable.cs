using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[CreateAssetMenu(
	    fileName = "SpriteVariable.asset",
	    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "Sprite",
	    order = 120)]
	public class SpriteVariable : BaseVariable<Sprite>
	{
	}
}