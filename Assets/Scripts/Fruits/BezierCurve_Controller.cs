using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierCurve_Controller : MonoBehaviour
{
    // ������ ���൵�� �ǽð����� �����ؼ� ������ ���� ���� ����
    [Range(0f, 1f)] public float m_rate = 0f; // 0 ~ 1 ���������� ���۵ǰ� �����ϱ� ���� ����
    public float moveSpeed = 1f;

    // �������� / �������� ������Ʈ�� �޾Ƽ� Transform �� ������ ���� ����
    public Transform m_p_Start;
    public Transform m_p_End;
    // �߰����� ������Ʈ�� �޾Ƽ� Transform �� ��� ���� �迭
    public Transform[] m_pos_Num = new Transform[2];

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        m_rate += Time.deltaTime;
        transform.position = BezierCurve();

        if (m_rate >= 1f)
        {
            m_rate = 0f;
        }
    }

    Vector3 BezierCurve()
    {
        // ��ü ������ ��ġ ������ �����ϱ� ���� ��ġ����Ʈ(�迭)
        List<Vector3> t_pointList = new List<Vector3>();

        // �������� ��ġ���� ��ġ����Ʈ �� �߰�
        t_pointList.Add(m_p_Start.position);

        // �߰����� ��ġ���� ��ġ����Ʈ �� �߰�
        foreach (var T in m_pos_Num)
        {
            t_pointList.Add(T.position);
        }

        // �������� ��ġ���� ��ġ����Ʈ�� �߰�
        t_pointList.Add(m_p_End.position);

        // ������Ʈ�� ��ġ�� ����ϱ� ���� ��� ����
        // ��ġ�� 1�� ������ ���� �ݺ��� ���� ���
        while (t_pointList.Count > 1)
        {
            //������������ ���� ������� �����ϱ� ���� ���������Ʈ(�迭)
            List<Vector3> t_resultList = new List<Vector3>();

            for (int i = 0; i < t_pointList.Count - 1; i++)
            {
                // ���� ������ ���� ������ ���������� ���� ��ġ�� ���
                Vector3 result = Vector3.Lerp(t_pointList[i], t_pointList[i + 1], m_rate);

                // ���� ��ġ ���� ���������Ʈ�� ����
                t_resultList.Add(result);
            }
            // ��ġ����Ʈ�� ����� ����Ʈ�� ����
            t_pointList = t_resultList;
        }
        return t_pointList[0];
    }
}
