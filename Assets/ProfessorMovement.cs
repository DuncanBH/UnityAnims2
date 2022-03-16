using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfessorMovement : MonoBehaviour
{

    Animator animator;
    new Transform transform;

    int direction = 0;
    
    [SerializeField]
    private float speedModif = 2;

    void Start()
    {
        animator = GetComponent<Animator>();
        transform = GetComponent<Transform>();
    }

    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        if (inputX > 0)
        {
            direction = 3;
        }
        if (inputX < 0)
        {
            direction = 1;
        }
        if (inputY > 0)
        {
            direction = 2;
        }
        if (inputY < 0)
        {
            direction = 0;
        }

        animator.SetInteger("Direction", direction);
        
        animator.speed = (inputY == 0 && inputX == 0) ? 0 : 1;

        transform.Translate(new Vector2(inputX, inputY).normalized * speedModif * Time.deltaTime);
    }
}
