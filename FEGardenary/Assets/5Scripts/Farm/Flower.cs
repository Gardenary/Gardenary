using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Flower : MonoBehaviour
{
    //��, ���� �ۼ� ���� �Ⱓ ǥ�� UI
    public TextMeshProUGUI flowerPeriod, treePeriod;
    //�� ��° ��������, ���� ���� ǥ�� UI
    public TextMeshProUGUI questionUI, questionNumUI;

    //���� ���� ����ġ
    private int flowerExp;

    //��, ���� �ۼ� ���� �Ⱓ�� ����
    private int flowerNum, treeNum;

    //�� ������ ���°����
    private int questionNum;
    //�� ������ ��������
    private string question;

    //�亯 �ۼ�
    public TMP_InputField flowerInput;
    private string flowerAnswer;

    //�ϼ��� ���� ��������
    private string flowerName;

    // Start is called before the first frame update
    void Start()
    {
        //�� ���� ��ĥ �ۼ�?
        flowerPeriod = GameObject.Find("Header").transform.Find("Date").GetComponentInChildren<TextMeshProUGUI>();
        flowerNum = 15;
        flowerPeriod.text = "���� " + flowerNum + "��";

        //�� ��° ����?
        questionNumUI = GameObject.Find("QuestionBox").transform.Find("QuestionNumber").GetComponentInChildren<TextMeshProUGUI>();
        questionNum = 10;
        questionNumUI.text = "# " + questionNum + "��° ����";

        //���� ����
        questionUI = GameObject.Find("QuestionBox").transform.Find("Question").GetComponentInChildren<TextMeshProUGUI>();
        question = "���� �Ϸ� ���� ��￡ ���� ���� �����ΰ���?";
        questionUI.text = question;

        //����ġ
        flowerExp = 90;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Write()
    {
        flowerAnswer = flowerInput.text;
        //�ۼ��߰� ���� �������� ��
        Debug.Log(flowerExp);
        flowerExp += 10;
        if (flowerExp < 100 && flowerAnswer.Length != 0)
        {
            GameObject.Find("Canvas").transform.Find("WriteComplete").gameObject.SetActive(true);
            GameObject.Find("WriteComplete").transform.Find("WritePopup").gameObject.SetActive(true);
            GameObject.Find("WritePopup").transform.Find("PopupText").GetComponentInChildren<TextMeshProUGUI>().text = "�ۼ��� �Ϸ�Ǿ����ϴ�! :)";
        }
        //�ƹ� �͵� �ۼ����� �ʾ��� ���
        else if(flowerAnswer.Length == 0)
        {
            flowerExp -= 10;
            GameObject.Find("Canvas").transform.Find("WriteComplete").gameObject.SetActive(true);
            GameObject.Find("WriteComplete").transform.Find("WritePopup").gameObject.SetActive(true);
            GameObject.Find("WritePopup").transform.Find("PopupText").GetComponentInChildren<TextMeshProUGUI>().text = "���ڸ� �ۼ����ּ���! :(";
        }
        else
        {
            GameObject.Find("Canvas").transform.Find("WriteComplete").gameObject.SetActive(true);
            GameObject.Find("WriteComplete").transform.Find("CompletePopup").gameObject.SetActive(true);
            //�� �̸�
            flowerName = "�عٶ��";
            GameObject.Find("CompleteTextWrap").transform.Find("CompleteText").GetComponentInChildren<TextMeshProUGUI>().text
                = flowerName + "��(��) Ȱ¦ �Ǿ����!";
        }
    }

    public void Close()
    {
        //�ۼ����� ��� �Թ����� ���ư���
        if(flowerAnswer.Length != 0)
        {
            //�ۼ�â�� �Ϸ�â ��� ����
            GameObject.Find("Canvas").transform.Find("WriteComplete").gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.Find("FlowerWrite").gameObject.SetActive(false);
        }
        //�ۼ����� �ʾ��� ��� �ۼ� ȭ������ ���ư���
        else
        {
            //�Ϸ�â�� ����
            GameObject.Find("Canvas").transform.Find("WriteComplete").gameObject.SetActive(false);
        }
    }
    public void Complete()
    {
        //�ۼ�â�� �Ϸ�â ��� ����
        GameObject.Find("Canvas").transform.Find("WriteComplete").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("FlowerWrite").gameObject.SetActive(false);
    }
}
