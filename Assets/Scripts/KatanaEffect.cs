using UnityEngine;

public class KatanaEffect : MonoBehaviour
{
    public static Animator katanaAni;
    void Start()
    {
        katanaAni = GetComponent<Animator>(); // īŸ������Ʈ ������Ʈ�� �ִϸ����� ������Ʈ�� �����´�.
    }

    public static void Punch()
    {
        katanaAni.SetTrigger("punch"); //��ġ����Ʈ �ִϸ��̼� ���
    }

    public static void DoubleAttack()
    {
        katanaAni.SetTrigger("double_attack"); // ������� ����Ʈ �ִϸ��̼� ���
    }

    public static void Attack()
    {
        katanaAni.SetTrigger("attack"); // ���� ����Ʈ �ִϸ��̼� ���
    }
}