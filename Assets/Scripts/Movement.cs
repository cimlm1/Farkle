using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OwenSuperScripts
{
    [RequireComponent(typeof(Rigidbody2D))]

    public class Movement : MonoBehaviour
    {
        Rigidbody2D rb; 
        Vector3 direction;
        [Tooltip("How fast the player should move")]
        public float movementSpeed;
        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            if(movementSpeed == 0)
            {
                Debug.LogWarning("movementSpeed is zero, you fool, you absolute buffoon",gameObject);
            }else if(movementSpeed < 0)
            {
                Debug.LogWarning("What is WRONG with you!?!? THe movement speed is negative!? THis will have CONSEQUENCES.",gameObject);
            }
        }
        void FixedUpdate()
        {
            rb.MovePosition(transform.position + direction);
        }
        //Takes a direction in worldspace to move the player in 
        public void Move(Vector3 inputDirection)
        {
            direction = inputDirection * movementSpeed;
        }
    }
}
