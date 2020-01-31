using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class DieReference : BaseReference<Die, DieVariable>
	{
	    public DieReference() : base() { }
	    public DieReference(Die value) : base(value) { }
	}
}