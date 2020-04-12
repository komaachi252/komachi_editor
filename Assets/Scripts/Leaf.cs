using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Transform>().Rotate(0, 90, -30);
        this.gameObject.GetComponent<Transform>().transform.Translate(0, -0.2f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
