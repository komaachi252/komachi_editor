using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf : MonoBehaviour
{
    public GameObject m_controller;
    public enum Colli_Type
    {
        ICE,
        AQUA,
        CLOUD
    };

    void Start()
    {
        
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
    }

    private void OnTriggerExit(Collider col)
    {
        Debug.Log("OnTriggerExit_Leaf");
        if (col.gameObject.CompareTag("Ice") || col.gameObject.CompareTag("Aqua"))
        {
            if (!col.gameObject.GetComponent<BoxCollider>().isTrigger){
                m_controller.GetComponent<Leaf_Controller>().Return_Angle();
            }
        }
    }
}