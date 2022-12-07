using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatEnvironment : MonoBehaviour
{
    private Vector3 startPos;

    private float repeatWidth;
    
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        repeatWidth = GetComponent<SpriteRenderer>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}