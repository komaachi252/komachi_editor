using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject m_file_manager;

    bool m_is_play = false;
    public bool Is_Play
    {
        set { m_is_play = value; }
        get { return m_is_play; }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick()
    {
        if (!m_is_play)
        {
            gameObject.GetComponentInChildren<Text>().text = "停止";
            gameObject.GetComponent<Image>().color = Color.gray;
            m_is_play = true;
        } else {
            gameObject.GetComponentInChildren<Text>().text = "再生";
            gameObject.GetComponent<Image>().color = Color.white;
            m_is_play = false;
            m_file_manager.GetComponent<FileManager>().Reload_Map();
        }
    }
}
