using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject m_clear_logo;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision col)
    {
        //!  プレイヤーだった場合ゲームクリア呼び出し
        if (col.gameObject.CompareTag("Player"))
        {
            Instantiate(m_clear_logo);
        }
    }
}
