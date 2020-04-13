using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System.Text;

public class FileManager : MonoBehaviour
{
    // Start is called before the first frame update
    Map_Data m_map_data;
    string m_file_name;
    string m_file_path;
    public GameObject[] m_objects;
    public GameObject m_name_field;
    public GameObject m_cursor;
    public GameObject[,] m_object_instances;
    public static int MAP_HEIGHT_MAX = 50;
    public static int MAP_WIDTH_MAX = 50;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Load_Map_Data(string file_path, bool load = true)
    {
        foreach (Transform n in this.gameObject.transform){
            Destroy(n.gameObject);
        }
        m_map_data = new Map_Data();
        m_file_name = System.IO.Path.GetFileName(file_path);
        if (load){
            MapLoader.Map_Load(file_path, ref m_map_data);
        }else{
            Create_Map_Data(ref m_map_data);
        }
        Set_File_Name(m_file_name);
        Show_Map(m_map_data);
        m_cursor.gameObject.GetComponent<CursorManager>().Reset_Offset();
        Debug.Log(m_file_name);
    }
    void Show_Map(in Map_Data map_data)
    {
        //  座標初期値
        var x = 0.5f;
        var y = (map_data.Height - 1) * 1.0f;
        m_object_instances = new GameObject[MAP_HEIGHT_MAX, MAP_WIDTH_MAX];

        for (int i = 0; i < map_data.Height; i++)
        {
            for (int j = 0; j < map_data.Width; j++)
            {
                if (map_data.Map_data[i, j] == 0)continue;
                GameObject obj = Instantiate(m_objects[map_data.Map_data[i, j]], new Vector3(x + j, y - i, 0.0f), Quaternion.identity);
                obj.transform.parent = this.gameObject.GetComponent<Transform>().transform;
                m_object_instances[i, j] = obj;
            }
        }
    }
    void Create_Map_Data(ref Map_Data map_data)
    {
        map_data.Map_data = new int[MAP_HEIGHT_MAX, MAP_WIDTH_MAX];
        map_data.Height = MAP_HEIGHT_MAX;
        map_data.Width = MAP_WIDTH_MAX;

    }
    public void Set_File_Name(string file_name)
    {
        m_file_name = m_name_field.GetComponent<Text>().text = file_name;
        m_file_path = Application.dataPath + "/Resources/" + file_name;
    }
    public void Save_Map()
    {
        StreamWriter sw = new System.IO.StreamWriter(m_file_path, false, Encoding.UTF8);

        for(int i = 0; i < m_map_data.Height; i++){
            for(int j = 0; j < m_map_data.Width; j++){
                sw.Write(m_map_data.Map_data[i, j].ToString());
                sw.Write(',');
            }
            sw.Write("\r\n");
        }
        sw.Close();
    }

    public void Add_Object(int i, int j, int offset_i, int offset_j, int object_index)
    {
        Debug.Log("offset_j" + offset_j);
        //  データ上の変更
        m_map_data.Map_data[i, j] = object_index;

        //  GUI上の変更
        Destroy(m_object_instances[i, j]);
        var x = 0.5f - offset_j;
        var y = (m_map_data.Height - 1) * 1.0f - offset_i;
        GameObject obj = Instantiate(m_objects[object_index], new Vector3(x + j, y - i, 0.0f), Quaternion.identity);
        obj.transform.parent = this.gameObject.GetComponent<Transform>().transform;
        m_object_instances[i, j] = obj;
    }
    public void Erase_Object(int i, int j)
    {
        //  データ上の削除
        m_map_data.Map_data[i, j] = 0;

        //  GUI上の削除
        Destroy(m_object_instances[i, j]);
    }
    public void Reload_Map()
    {
        foreach (Transform n in this.gameObject.transform){
            Destroy(n.gameObject);
        }
        //  座標初期値
        var x = 0.5f;
        var y = (m_map_data.Height - 1) * 1.0f;
        m_object_instances = new GameObject[MAP_HEIGHT_MAX, MAP_WIDTH_MAX];

        for (int i = 0; i < m_map_data.Height; i++){
            for (int j = 0; j < m_map_data.Width; j++){
                if (m_map_data.Map_data[i, j] == 0) continue;
                GameObject obj = Instantiate(m_objects[m_map_data.Map_data[i, j]], new Vector3(x + j, y - i, 0.0f), Quaternion.identity);
                obj.transform.parent = this.gameObject.GetComponent<Transform>().transform;
                m_object_instances[i, j] = obj;
            }
        }
    }

}
