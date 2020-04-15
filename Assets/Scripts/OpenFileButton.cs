using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Input Field用に使う
using System.Windows.Forms; //OpenFileDialog用に使う

public class OpenFileButton : MonoBehaviour
{
    public GameObject m_file_manager;
    public GameObject m_cursor_manager;
    string m_current_file_path;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        Open_File();
    }
    
    public bool Open_File()
    {
        OpenFileDialog open_file_dialog = new OpenFileDialog();

        //InputFieldの初期値を代入しておく(こうするとダイアログがその場所から開く)
        //open_file_dialog.FileName = input_field_path_.text;

        if (m_current_file_path != null){
            open_file_dialog.InitialDirectory = m_current_file_path;
        }
        //csvファイルを開くことを指定する
        open_file_dialog.Filter = "csvファイル|*.csv";

        //ファイルが実在しない場合は警告を出す(true)、警告を出さない(false)
        open_file_dialog.CheckFileExists = false;

        //ダイアログを開く
        if(open_file_dialog.ShowDialog() != DialogResult.OK){
            Debug.Log("指定したファイルがありません");
            return false;
        }

        //取得したファイル名をInputFieldに代入する
        //string file_path = open_file_dialog.FileName;

        Debug.Log(open_file_dialog.FileName);

        //  マップ情報読み込み
        Load_Map(open_file_dialog.FileName);

        //  現在のディレクトリ情報を保存
        m_current_file_path = open_file_dialog.FileName;

        //  カーソルのオフセット値をリセット
        m_file_manager.GetComponent<CursorManager>().Offset_Reset();

        return true;
    }

    public void Load_Map(string file_path)
    {
        m_file_manager.GetComponent<FileManager>().Load_Map_Data(file_path);
    }

    public string Get_File_Path()
    {
        return m_current_file_path;
    }
}
