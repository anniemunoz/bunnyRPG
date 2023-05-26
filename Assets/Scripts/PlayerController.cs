using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 4.0f;
    private const string horizontal = "Horizontal";
    private const string vertical = "Vertical";
    private Animator animator;
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

        if (Mathf.Abs(h) > 0.5f)
        {
            this.transform.Translate(new Vector3(h * speed * Time.deltaTime, 0, 0));
        }
        if (Mathf.Abs(v) > 0.5f)
        {
            this.transform.Translate(new Vector3(0, v * speed * Time.deltaTime, 0));
        }

        animator.SetFloat(horizontal, h);
        animator.SetFloat(vertical, v);
    }
}
