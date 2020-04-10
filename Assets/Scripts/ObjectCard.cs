using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCard : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject m_cursor;
    public GameObject m_selected_message;
    public int m_object_index;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_selected_message.activeInHierarchy){
            if(m_cursor.gameObject.GetComponent<CursorManager>().Get_Seleted_Object() != m_object_index){
                m_selected_message.SetActive(false);
            }
        }
    }
    public void OnClick()
    {
        if (m_selected_message.activeInHierarchy){
            m_selected_message.SetActive(false);
            //   未選択状態に設定
            m_cursor.gameObject.GetComponent<CursorManager>().Set_Selected_Object_Index(-1);
        }
        else
        {
            m_selected_message.gameObject.SetActive(true);
            m_cursor.gameObject.GetComponent<CursorManager>().Set_Selected_Object_Index(m_object_index);

        }
    }
}
