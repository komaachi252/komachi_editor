using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewFileButton : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject m_file_manager;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        Create_File();
    }

    void Create_File()
    {
        m_file_manager.GetComponent<FileManager>().Load_Map_Data(Application.dataPath + "/Resources/Map001.csv", false);

    }
    void Create_File_Name()
    {

    }
}
