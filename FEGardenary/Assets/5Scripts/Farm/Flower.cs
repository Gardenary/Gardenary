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
        question = "���� �Ϸ� ��￡ ���� ���� �����ΰ���?";
        questionUI.text = question;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Write()
    {
        flowerAnswer = flowerInput.text;
    }
}
