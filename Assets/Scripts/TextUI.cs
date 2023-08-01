using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextUI : MonoBehaviour
{ 
    public float movespeed;
    public float alphaSpeed;
    public float destroyTime;
    TextMeshPro text;
    Color alpha;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshPro>(); // TextMeshPro ������Ʈ ��������
        alpha = text.color;                 // ���� �ؽ�Ʈ ���� �� ��������
    }

    // Update is called once per frame
    void Update()
    {
        // �ؽ�Ʈ ������Ʈ�� ���� �̵���Ű�� ���
        transform.Translate(new Vector3(0, movespeed * Time.deltaTime, 0));
        // alpha ���� ������ �ð��� ���� 0���� �����Ͽ� ���ҽ�Ŵ
        alpha.a = Mathf.Lerp(alpha.a, 0, Time.deltaTime * alphaSpeed);
        // ������ alpha ������ �ؽ�Ʈ ���� ������Ʈ
        text.color = alpha;
        // ���� �ð� ���Ŀ� ���ھ� ������Ʈ ����
        Invoke("DestroyScore", destroyTime);
    }
    private void DestroyScore()
    {
        // ���ھ� ������Ʈ ����
        Destroy(gameObject);
    }
}
