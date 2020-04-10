using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveFileButton : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject m_file_manager;
    public GameObject m_saved_message;
    public GameObject m_canvas;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        GameObject obj = Instantiate(m_saved_message, this.gameObject.transform.position, Quaternion.identity);
        obj.transform.SetParent(m_canvas.transform);
        //obj.gameObject.GetComponent<RectTransform>().transform.parent = m_canvas.gameObject.GetComponent<RectTransform>().transform;
        m_file_manager.gameObject.GetComponent<FileManager>().Save_Map();
    }
}
