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
    private Animator animator;
    private const string lastHorizontal = "LastHorizontal";
    private const string lastVertical = "LastVertical";
    private const string walkingState = "Walking";
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    { // s= v*t
        var h = Input.GetAxisRaw(horizontal);
        var v = Input.GetAxisRaw(vertical);
        walking = false;

        if (Mathf.Abs(h) > 0.5f)
        {
            this.transform.Translate(new Vector3(h * speed * Time.deltaTime, 0, 0));
            walking = true;
            lastMovement = new Vector2(h, 0);
        }
        if (Mathf.Abs(v) > 0.5f)
        {
            this.transform.Translate(new Vector3(0, v * speed * Time.deltaTime, 0));
            walking = true;
            lastMovement = new Vector2(0, v);
        }

        animator.SetFloat(horizontal, h);
        animator.SetFloat(vertical, v);
        animator.SetBool(walkingState, walking);
        animator.SetFloat(lastHorizontal, lastMovement.x);
        animator.SetFloat(lastVertical, lastMovement.y);
    }
}
