using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[CreateAssetMenu(
	    fileName = "DieVariable.asset",
	    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "Dice",
	    order = 121)]
	public class DieVariable : BaseVariable<Die>
	{
	}
}