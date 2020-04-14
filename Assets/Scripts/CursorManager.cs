using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 m_cursor_position;

    private Vector3 m_mouse_pos;
    // スクリーン座標をワールド座標に変換した位置座標
    private Vector3 m_screen_pos;

    public GameObject m_cursor;
    public GameObject m_camera;
    public GameObject m_file_manager;
    public GameObject m_play;

    public Transform m_objects_position;
    int m_offset_x = 0;
    //int m_offset_y = FileManager.MAP_HEIGHT_MAX - CURSOR_HEIGHT;
    int m_offset_y = 0;
    int m_object_index = 0;
    const int CURSOR_HEIGHT = 17;
    const int CURSOR_WIDTH = 17;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (m_play.GetComponent<PlayButton>().Is_Play) return;
        // Vector3でマウス位置座標を取得する
        Vector3 position = Input.mousePosition;
        // Z軸修正
        position.z = 10f;
        // マウス位置座標をスクリーン座標からワールド座標に変換する
        m_screen_pos = Camera.main.ScreenToWorldPoint(position);
        float width = Screen.width / 800.0f;
        float height = Screen.height / 450.0f;
        float size = 45 * width;

        int i = (int)(position.y / size);
        int j = (int)(position.x / size);

        m_cursor_position.x = size * j + size * 0.5f;
        m_cursor_position.y = size * i + size * 0.5f;
    
        //Debug.Log(Screen.height);
        if(m_cursor_position.y >= Screen.height - size){
            m_cursor.SetActive(false);
        }else if(!m_cursor.activeInHierarchy){
            m_cursor.SetActive(true);
        }
        //Debug.Log("i" + i);
        //Debug.Log("j" + j);

        Cursor_Move(m_cursor_position);

        //m_camera.gameObject.GetComponent<Transform>().position = new Vector3(x,4.5f,-10);
        Move_Object(size);

        if (Input.GetMouseButton(0) && m_cursor.activeInHierarchy)
        {
            Set_Cursor_Object((50 - (m_offset_y + 1) - i) , j + m_offset_x, m_object_index);
        }
    }

    void Cursor_Move(in Vector3 pos)
    {
        m_cursor.gameObject.GetComponent<RectTransform>().transform.position = pos;
        //m_cursor.gameObject.GetComponent<RectTransform>().transform.position = new Vector3(22.5f,22.5f,0);
    }
    //  選択カーソルのオブジェクトの縦　横　オブジェクトのインデックス番号
    void Set_Cursor_Object(int i, int j, int obj_index)
    {
        //Debug.Log("i" + i);
        //Debug.Log("offset" + m_offset_y);
        if(obj_index == 0){
            m_file_manager.gameObject.GetComponent<FileManager>().Erase_Object(i, j);
        }
        else{
            m_file_manager.gameObject.GetComponent<FileManager>().Add_Object(i, j, m_offset_y, m_offset_x, obj_index);
        }
    }


    void Move_Object(float size)
    {
        //  マップ情報未読込
        if (m_offset_x < 0) return;

        //　マウス入力
        if (Input.GetMouseButtonDown(2)){
            //  押された座標を保存
            m_mouse_pos = Input.mousePosition;
        }

        if (Input.GetMouseButton(2)){
            int move_x = (int)((Input.mousePosition.x - m_mouse_pos.x) / size);
            int move_y = (int)((Input.mousePosition.y - m_mouse_pos.y) / size);

            if(m_offset_x  + move_x * -1 < 0){
                move_x = m_offset_x;
            }
            if(move_y < 0 && m_offset_y + CURSOR_HEIGHT + move_y > FileManager.MAP_HEIGHT_MAX){
                move_y = 0;
            }
            if(move_x < 0 && m_offset_x + CURSOR_WIDTH + move_x * -1 > FileManager.MAP_WIDTH_MAX){
                move_x = 0;
            }
            if (m_offset_y <= 0 &&  move_y > 0){
                move_y = 0;
            }

            m_objects_position.transform.Translate(move_x, move_y, 0);

            //  移動が成功したら座標を代入する
            if (Mathf.Abs(move_x) >= 1 || Mathf.Abs(move_y) >= 1){
                m_mouse_pos = Input.mousePosition;
            }

            m_offset_x += move_x * -1;
            m_offset_y += move_y * -1;
            //Debug.Log("x" + m_offset_x);
            //Debug.Log("y" + m_offset_y);
        }
    }

    public void Reset_Offset()
    {
        m_offset_x = 0;
        //m_offset_y = FileManager.MAP_HEIGHT_MAX - CURSOR_HEIGHT;
        m_offset_y = 0;
    }
    public void Set_Selected_Object_Index(int index)
    {
        m_object_index = index;
    }
    public int Get_Seleted_Object()
    {
        return m_object_index >= 0 ? m_object_index : -1;
    }
}
