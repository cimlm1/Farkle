using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;
public class EnabledByBoolReference : MonoBehaviour
{
    public BoolReference theBool;
    public GameObject gobj;
    // Update is called once per frame
    void Update()
    {
        gobj.SetActive(theBool.Value);
    }
}
