using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FileNameButton : MonoBehaviour
{
    public GameObject m_name_field;
    public Text text;
    public Text input_text;
    public GameObject m_file_manager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick()
    {
        m_name_field.SetActive(true);
    }

    public void Set_File_Name()
    {
        //  csvを付与
        string file_name = System.IO.Path.ChangeExtension(input_text.GetComponent<Text>().text, "csv");
        Debug.Log(file_name);
        m_file_manager.GetComponent<FileManager>().Set_File_Name(file_name);
        text.GetComponent<Text>().text = file_name;
        m_name_field.SetActive(false);
    }
}
