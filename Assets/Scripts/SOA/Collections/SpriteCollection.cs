using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[CreateAssetMenu(
	    fileName = "SpriteCollection.asset",
	    menuName = SOArchitecture_Utility.COLLECTION_SUBMENU + "Sprite",
	    order = 120)]
	public class SpriteCollection : Collection<Sprite>
	{
	}
}