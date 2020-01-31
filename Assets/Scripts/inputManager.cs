using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OwenSuperScripts;

[RequireComponent(typeof(Movement))]
public class inputManager : MonoBehaviour
{

    Movement movementScript;
    // Start is called before the first frame update
    void Start()
    {
        movementScript = GetComponent<Movement>();
        
    }

    // Update is called once per frame
    void Update()
    {
        movementScript.Move((Vector3.up * Input.GetAxis("Vertical") + Vector3.right * Input.GetAxis("Horizontal"))*Time.deltaTime);
    }
}
