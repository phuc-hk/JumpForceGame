using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundReset : MonoBehaviour
{
    Vector3 startPos;
    float backgroundWidth;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        backgroundWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startPos.x - backgroundWidth)
        {
            transform.position = startPos;
        }
    }
}
