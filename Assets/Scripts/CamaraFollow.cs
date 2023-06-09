using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraFollow : MonoBehaviour
{
    [SerializeField]
    private GameObject followTarget;
    [SerializeField]
    private Vector3 targetPosition;
    [SerializeField]
    private float cameraSpeed = 4.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var currentPosition = this.transform.position;

        targetPosition = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y,
                                    currentPosition.z);

        this.transform.position =  Vector3.Lerp(currentPosition, targetPosition, cameraSpeed * Time.deltaTime);
    }
}
