using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvlTwoCharMovement : MonoBehaviour
{
    private float xInput, zInput;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(xInput, 0, zInput) * Time.deltaTime * speed);
    }
}
