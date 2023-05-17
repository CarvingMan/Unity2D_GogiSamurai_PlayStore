using UnityEngine;

public class Yellow : MonoBehaviour
{
    [SerializeField] private float pushPower;
    //private Rigidbody2D rb;

    [Range(0f, 1f)] public float m_rate = 0f; // 0 ~ 1 ���������� ���۵ǰ� �����ϱ� ���� ����
    public float moveSpeed = 1f;

    // �������� / �������� ������Ʈ�� �޾Ƽ� Transform �� ������ ���� ����
    public Transform m_p_Start;
    public Transform m_p_End;
    // �߰����� ������Ʈ�� �޾Ƽ� Transform �� ��� ���� �迭
    public Transform[] m_pos_Num = new Transform[2];

    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Move the object to the right
/*        Vector2 movement = new Vector2(3, 2);
        rb.AddForce(movement * pushPower, ForceMode2D.Impulse);*/

        m_rate += Time.deltaTime;
        transform.position = GetComponent<BezierCurve_Controller>().BezierCurve();

        if (m_rate >= 1f)
        {
            m_rate = 0f;
        }
    }
}