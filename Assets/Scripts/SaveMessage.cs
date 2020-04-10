using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveMessage : MonoBehaviour
{
    // Start is called before the first frame update
    public int m_frame = 0;
    public const int DESTROY_FRAME = 120;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        m_frame++;
        if(m_frame >= DESTROY_FRAME){
            Destroy(this.gameObject);
        }
    }
}
