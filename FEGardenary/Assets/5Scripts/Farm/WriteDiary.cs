using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WriteDiary : MonoBehaviour
{
    //���� �� ���̾�� �ۼ��ߴ� ���� ����
    private bool flowerFlag;

    // Start is called before the first frame update
    void Start()
    {
        flowerFlag = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(flowerFlag);
            if(flowerFlag == true)
            {
                Debug.Log("ȭ��� ���� �ʹ�");
                GameObject.Find("FarmUI").transform.Find("FlowerWrite").gameObject.SetActive(true);
            }
            else
            {
                GameObject.Find("FarmUI").transform.Find("AlreadyWrite").gameObject.SetActive(true);
            }
        }
    }
    public void Close()
    {
        GameObject.Find("FarmUI").transform.Find("FlowerWrite").gameObject.SetActive(false);
    }

    public void AlreadyClose()
    {
        GameObject.Find("FarmUI").transform.Find("AlreadyWrite").gameObject.SetActive(false);
    }
}
