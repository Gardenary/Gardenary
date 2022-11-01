using TMPro;
using UnityEngine;

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

    //�ۼ� �� ����ġ
    private int allExp;

    //������ ȹ�� ����
    private bool itemFlag;

    //ĳ���� ȹ�� ����
    private int characterFlag;

    // Start is called before the first frame update
    void Start()
    {
        //�� ����ġ, ���� ����, �� ��° ����, ���� ��ĥ �Ǿ������� ���� ������ �ٸ� ��ũ��Ʈ���� ��������
        WriteDiary writeDiary = GameObject.Find("FlowerGroup").GetComponent<WriteDiary>();
        flowerExp = writeDiary.flowerExp;
        question = writeDiary.questionContent;
        questionNum = writeDiary.questionNum;
        flowerNum = writeDiary.flowerNum;

        //�� ���� ��ĥ �ۼ�?
        flowerPeriod = GameObject.Find("Header").transform.Find("Date").GetComponentInChildren<TextMeshProUGUI>();
        flowerPeriod.text = "���� " + flowerNum + "��";

        //�� ��° ����?
        questionNumUI = GameObject.Find("QuestionBox").transform.Find("QuestionNumber").GetComponentInChildren<TextMeshProUGUI>();
        questionNumUI.text = "# " + questionNum + "��° ����";

        //���� ����
        questionUI = GameObject.Find("QuestionBox").transform.Find("Question").GetComponentInChildren<TextMeshProUGUI>();
        questionUI.text = question;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //�ۼ� ��ư Ŭ��
    public void Write()
    {
        //�ۼ��� �亯
        flowerAnswer = flowerInput.text;
        //�ۼ��� ������ ���� ��
        if (flowerAnswer.Length == 0)
        {
            //�ۼ� �Ϸ� UI ǥ��
            GameObject.Find("FarmUI").transform.Find("WriteComplete").gameObject.SetActive(true);
            GameObject.Find("WriteComplete").transform.Find("WritePopup").gameObject.SetActive(true);
            //���ڸ� �ۼ��ش޶�� ���� ���
            GameObject.Find("WritePopup").transform.Find("PopupText").GetComponentInChildren<TextMeshProUGUI>().text = "���ڸ� �ۼ����ּ���! :(";
        }
        //�ۼ��� ������ ���� ��
        else if (flowerAnswer.Length != 0)
        {
            //�� ���̾ �ۼ� API ȣ��
            //�ۼ� �� �� ����ġ�� ������ ȹ�� ���θ� ����
            allExp = 100;
            itemFlag = true;

            //�ۼ� �Ϸ� UI ǥ��
            GameObject.Find("FarmUI").transform.Find("WriteComplete").gameObject.SetActive(true);
            GameObject.Find("WriteComplete").transform.Find("WritePopup").gameObject.SetActive(true);
            //�ۼ� �Ϸ� ���� ���
            GameObject.Find("WritePopup").transform.Find("PopupText").GetComponentInChildren<TextMeshProUGUI>().text = "�ۼ��� �Ϸ�Ǿ����ϴ�! :)";
        }
    }

    //������ ȹ��
    public void GetItem()
    {
        //������ ȹ�� API ȣ�� -> ������ ���� ���̵�, �̸�
        GameObject.Find("FarmUI").transform.Find("GetItem").gameObject.SetActive(true);
        //�ϼ����� ��� ĳ���� API ȣ��
        if (allExp == 100)
        {
            //ĳ���� ���̵� ���̳�
            characterFlag = 1;
            //��ȯ�� ĳ���� ���̵� ���� 0�� ���� ���ο� ĳ���͸� ���� ���� ��
            if (characterFlag != 0)
            {
                //���ο� ĳ���͸� ����ٴ� UI ǥ��
                GameObject.Find("FarmUI").transform.Find("GetCharacter").gameObject.SetActive(true);
            }
        }
    }

    public void Close()
    {
        //�ۼ����� ��� �Թ����� ���ư���
        if (flowerAnswer.Length != 0)
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
