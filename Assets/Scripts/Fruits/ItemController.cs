using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ItemController : MonoBehaviour
{

    [SerializeField] public int itemHp;

    bool executeOnlyOnce = true;
    // Bezier rate
    [Range(0f, 1f)] public float rate;
    // Bezier position
    public Vector2[] controllPosition;
    // End Bezier and Force
    public Rigidbody2D rb;
    Animator itemAnimator;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        itemAnimator = GetComponent<Animator>();


    }

    private void FixedUpdate()
    {
        if (gameObject.transform.position.y <= 0.7f)
        // ��ᰡ �� �Ʒ��� �������� ���� ��Ű��
        {
            Destroy(gameObject);
        }

        // ���������� ����� ������� �����Ӱ� ������ ������ �ð��� ��� ���� �̵��Ѵ�.
        rate += Time.deltaTime;
        transform.position = BezierTest(controllPosition[0], controllPosition[1], controllPosition[2], controllPosition[3], rate);


        if (rate >= 1f)
        // ��ᰡ �����ǰ� ������ ��� ���󰡴ٰ�, �������� 1�ʰ� ������ ���� ��������
        // AddForce�� �ֱ�(���ư��� ���� ȿ���� ����)
        {
            Vector2 pushForce = Vector2.left * 250.0f;
            rb.AddForce(pushForce);
        }


        if (itemHp == 0) // ����� hp�� 0�̶��
        {
            if (executeOnlyOnce) // ��� �ϳ��� �ѹ����� ����Ǵ� bool�� ����
            {
                itemAnimator.SetTrigger("slice"); // �����̽� �ִϸ��̼� �ο�
                rb.MovePosition(new Vector2(4f, 3f)); // ��Ḧ �ش���ġ�� �̵���Ű��
                Recipe.DecreaseIngredient(this.name);
                executeOnlyOnce = false;
            }
            Vector2 rightForce = Vector2.right * 250.0f;

            // ���̻� �������� �̵����� �ʰ� ������ �������� �Ȱ��� 250��ŭ ���� �־� ���ڸ��� ������ �� ó�� ���̰� �����
            rb.AddForce(rightForce);

            rb.gravityScale = 15f; // �߷��� �ο��� �Ʒ��� �������� �ϱ�
        }
    }

    // https://www.youtube.com/watch?v=KTEX2L4T4zE
    // ���� �� ���հ��� �����ϱ� ���Ͽ� ���� �Ÿ��� ���� ���������� ����ϴ� ����̴�.
    public Vector2 BezierTest(Vector2 P_1, Vector2 P_2, Vector2 P_3, Vector2 P_4, float value)
    {
        Vector2 A = Vector2.Lerp(P_1, P_2, value);  //P_1������ P_2������ �������� ��갪 : A
        Vector2 B = Vector2.Lerp(P_2, P_3, value);  //P_2������ P_3������ �������� ��갪 : B
        Vector2 C = Vector2.Lerp(P_3, P_4, value);  //P_3������ P_4������ �������� ��갪 : C

        Vector2 D = Vector2.Lerp(A, B, value);      //A������ B������ �������� ��갪 : D
        Vector2 E = Vector2.Lerp(B, C, value);      //B������ C������ �������� ��갪 : E

        Vector2 F = Vector2.Lerp(D, E, value);      //D������ E������ �������� ��갪 : F
        return F;                                   //������ ����� �� ������� F�� ��ȯ
    }


}