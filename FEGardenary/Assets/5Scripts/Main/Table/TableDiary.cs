using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

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
        //url
        treeDiary = new TreeInfo();
        treeDiary.status = "OK";
        treeDiary.message = "success";

        GetTreeAll treeInfo1 = new GetTreeAll();
        treeInfo1.content = "���� ������ �λ�� ��¥���";
        //treeInfo1.diaryDate = DateTimeOffset.Now.LocalDateTime;

        GetTreeAll treeInfo2 = new GetTreeAll();
        treeInfo2.content = "Ŀ�Ǵ� �� ū Ŀ��";
        //treeInfo2.diaryDate = DateTimeOffset.Now.LocalDateTime;

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
                    //�ۼ��� ���� ���̾ ������ ���� ǥ��
                    //�ƹ� �͵� �ۼ����� �ʾ��� ��
                    if(treeDiary.responseDto.Count == 0)
                    {
                        //�ۼ����� �ʾҴٴ� UI�� �����ش�
                    }
                    //�� �� �ۼ��� �ϱⰡ ���� ��
                    else
                    {
                        Debug.Log(treeDiary.responseDto.Count);
                        //������ŭ UI�� ���� �����ش�
                        for (int i = 0; i < treeDiary.responseDto.Count; i++)
                        {
                            Debug.Log(i);
                            Debug.Log(treeDiary.responseDto[i].content);
                            //object�� �ϳ� ������ش�
                            GameObject treeDiaryContent = new GameObject("TreeContent" + i);
                            //layer�� UI(5)�� ����
                            treeDiaryContent.layer = 5;
                            //�θ� ������Ʈ ����
                            treeDiaryContent.transform.SetParent(GameObject.Find("AllTreeUI").transform.Find("AllTreeBackground"));

                            //�ʿ��� ������Ʈ �߰�
                            treeDiaryContent.AddComponent<CanvasRenderer>();
                            treeDiaryContent.AddComponent<RectTransform>();
                            treeDiaryContent.AddComponent<Image>();
                            //������Ʈ�� ��ġ ����
                            treeDiaryContent.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -600 * i);
                            //������Ʈ�� ũ�� ����
                            treeDiaryContent.GetComponent<RectTransform>().sizeDelta = new Vector2(1200, 400);

                            //�׽�Ʈ�� ���� �ӽ÷� �� ����
                            treeDiaryContent.GetComponent<Image>().color = Color.red;

                            //�ؽ�Ʈ �߰�
                            GameObject treeText = new GameObject("treeText" + i);
                            treeText.layer = 5;
                            treeText.transform.SetParent(GameObject.Find("AllTreeBackground").transform.Find("TreeContent" + i));

                            treeText.AddComponent<CanvasRenderer>();
                            treeText.AddComponent<RectTransform>();
                            treeText.AddComponent<TextMeshProUGUI>();

                            //Destroy(treeText.GetComponent<MeshRenderer>());
                            //�۾� ũ��� ��Ʈ ����
                            treeText.GetComponent<TextMeshProUGUI>().fontSize = 60;
                            treeText.GetComponent<TextMeshProUGUI>().font
                                = GameObject.Find("AllTreeHeaderText").GetComponent<TextMeshProUGUI>().font;

                            //���� ����
                            treeText.GetComponent<TextMeshProUGUI>().text = treeDiary.responseDto[i].content;

                            //Debug.Log(GameObject.Find("Test").GetComponent<TextMeshProUGUI>().font);
                            //TMP_FontAsset a = new TMP_FontAsset("DalseoDarling SDF");
                            //treeText.GetComponent<TextMeshProUGUI>().TM = DalseoDarling SDF
                            //������Ʈ�� ��ġ ����
                            //Debug.Log(treeText.GetComponentInChildren<TextMeshPro>().text);
                            //treeText.GetComponentInChildren<TextMeshPro>().SetText("abcdergef");

                            //treeText.GetComponentInChildren<TextMeshProUGUI>().fontSize = 60;
                            //treeText.GetComponentInChildren<TextMeshProUGUI>().text = "�㸮 ����";
                            treeText.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
                            //treeText.GetComponent<TextMeshPro>().font = "DalseoDarling SDF";
                                //treeText.GetComponent<TextMeshPro>().UpdateFontAsset("DalseoDarling SDF");
                        }
                    }
                }
            }
        }
    }
}
