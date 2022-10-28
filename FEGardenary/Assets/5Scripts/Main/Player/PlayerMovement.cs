using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    GameObject nearObject;
    private GameObject targetObject;

    static public PlayerMovement player;

    // Scene ��ȯ ���Ŀ��� Player�� �����ֵ���
    private void Awake()
    {
        if (player == null)
        {
            player = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(this.gameObject);

        }

    }

    public static PlayerMovement Instance   // singleton
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PlayerMovement>();
                if (instance == null)
                {
                    var instanceContainer = new GameObject("PlayerMovement");
                    instance = instanceContainer.AddComponent<PlayerMovement>();
                }
            }
            return instance;
        }
    }

    private static PlayerMovement instance;

    Rigidbody rb;
    public float moveSpeed = 25f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(JoyStickMovement.Instance.joyVec.x * moveSpeed, rb.velocity.y, JoyStickMovement.Instance.joyVec.y * moveSpeed);
    }

    void Update()
    {
        // Scene ��ȯ
        if (nearObject != null)
        {
            if (nearObject.tag == "Farm")
            {
                SceneManager.LoadScene("Farm");
            }
            else if (nearObject.tag == "Garden")
            {
                SceneManager.LoadScene("Garden");
            }
        }

        // å������ ī�޶� ����
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("?");
            targetObject = GetClickedObject();

            if (targetObject != null)
            {
                //Debug.Log(targetObject.name);
            }
        }
    }

    // Ŭ���� ������Ʈ
    GameObject GetClickedObject()
    {

        RaycastHit hit; // �浹�� ������ ����
        GameObject target = null;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);    // ���콺 ����Ʈ ��ó ��ǥ ����

        // ���콺 ��ó�� ������Ʈ�� �ִ��� Ȯ��
        if (Physics.Raycast(ray.origin, ray.direction * 10, out hit))
        {
            target = hit.collider.gameObject;   // �ش� ������Ʈ ����
        }

        return target;
    }

    void OnTriggerStay(Collider other)
    {
        // Scene ��ȯ�� ���� ������Ʈ ����
        if (other.tag == "Farm" || other.tag == "Garden")
        {
            nearObject = other.gameObject;
        }
    }
}
