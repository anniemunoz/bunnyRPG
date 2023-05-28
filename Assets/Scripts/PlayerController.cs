using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 4.0f;
    private bool walking = false;
    public Vector2 lastMovement = Vector2.zero;

    private const string horizontal = "Horizontal";
    private const string vertical = "Vertical";
    private const string lastHorizontal = "LastHorizontal";
    private const string lastVertical = "LastVertical";
    private const string walkingState = "Walking";

    private Animator animator;
    private Rigidbody2D playerRigidbody;

    private float moveHorizontal;
    private float moveVertical;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxisRaw(horizontal);
        moveVertical = Input.GetAxisRaw(vertical);
    }

    private void FixedUpdate()
    {
        walking = false;

        if (Mathf.Abs(moveHorizontal) > 0.5f ||
                Mathf.Abs(moveVertical) > 0.5)
        {
            walking = true;

            lastMovement = new Vector2(
                moveHorizontal,
                moveVertical);

            playerRigidbody.velocity = lastMovement.normalized *
                speed * Time.deltaTime;
        }

        if (!walking)
        {
            playerRigidbody.velocity = Vector2.zero;
        }


        animator.SetFloat(horizontal, moveHorizontal);
        animator.SetFloat(vertical, moveVertical);

        animator.SetBool(walkingState, walking);

        animator.SetFloat(lastHorizontal, lastMovement.x);
        animator.SetFloat(lastVertical, lastMovement.y);

    }
}