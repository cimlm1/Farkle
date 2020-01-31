using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[CreateAssetMenu(
	    fileName = "DieCollection.asset",
	    menuName = SOArchitecture_Utility.COLLECTION_SUBMENU + "Dice",
	    order = 121)]
	public class DieCollection : Collection<Die>
	{
	}
}