using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class TableDiary : MonoBehaviour
{
    private CameraMovement cameraMovement;
    private GameObject targetObject;

    //å�� ������ �� �����ΰ�?
    private bool zoomFlag;

    public TreeInfo treeDiary;
    // Start is called before the first frame update
    void Start()
    {
        treeDiary = new TreeInfo();
        treeDiary.status = "OK";
        treeDiary.message = "success";

        GetTreeAll treeInfo1 = new GetTreeAll();
        treeInfo1.content = "���� ������ �λ�� ��¥���";
        treeInfo1.diaryDate = DateTimeOffset.Now.LocalDateTime;

        GetTreeAll treeInfo2 = new GetTreeAll();
        treeInfo2.content = "Ŀ�Ǵ� �� ū Ŀ��";
        treeInfo2.diaryDate = DateTimeOffset.Now.LocalDateTime;

        List<GetTreeAll> test = new List<GetTreeAll>();
        test.Add(treeInfo1);
        test.Add(treeInfo2);

        treeDiary.responseDto = test;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //CameraMovement ��ũ��Ʈ�� �����´�
            cameraMovement = GameObject.Find("Main Camera").GetComponent<CameraMovement>();
            //������ ������Ʈ�� ���������� ���� �Լ�
            targetObject = cameraMovement.GetClickedObject();
            //å�� ���� �Ǿ��� ���� ���� �˱� ���� ������ �����´�
            zoomFlag = cameraMovement.zoomFlag;

            //å�� ������ �Ǿ��� ����
            if (zoomFlag == true)
            {
                //Ŭ���� ���̾�� �� ���̾�� ���
                if (targetObject.name == "Flower Diary")
                {
                    Debug.Log("�� ���̾");
                    //�� ���̾ ��ü ����� �����ش�
                    GameObject.Find("TableUI").transform.Find("AllFlowerUI").gameObject.SetActive(true);
                                        
                }
                //Ŭ���� ���̾�� ���� ���̾�� ���
                else if (targetObject.name == "Tree Diary")
                {
                    //���� ���̾�� ���� �ٱ� UI(Canvas)�� Ȱ��ȭ
                    GameObject.Find("TableUI").transform.Find("AllTreeUI").gameObject.SetActive(true);
                    Debug.Log(treeDiary.responseDto.Count);
                    //�ۼ��� ���� ���̾ ������ ���� ǥ��
                    //�ƹ� �͵� �ۼ����� �ʾ��� ��
                    if(treeDiary.responseDto.Count == 0)
                    {
                        //�ۼ����� �ʾҴٴ� UI�� �����ش�
                    }
                    //�� �� �ۼ��� �ϱⰡ ���� ��
                    else
                    {
                        //������ŭ UI�� ���� �����ش�
                        for (int i = 0; i < treeDiary.responseDto.Count; i++)
                        {
                            Debug.Log(i);
                            //object�� �ϳ� ������ش�
                            GameObject test = new GameObject();
                            //������ �̸��� �������ְ� �ش� object�� Layer�� UI�� �������ش�
                            test.name = "TreeContent" + i;
                            test.layer = 5;
                            //�� object�� �θ� �������ش�
                            test.transform.SetParent(GameObject.Find("AllTreeUI").transform.Find("AllTreeBackground"));
                            test.AddComponent<Image>();
                        }
                    }
                }
            }
        }
    }
}
