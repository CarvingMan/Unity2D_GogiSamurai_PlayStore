using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerController : MonoBehaviour
{
    private bool hasAttacked = false; // ������ �������� ���θ� ��Ÿ���� ����
    private float lastAttackTime = -1f; // ������ ���� �ð��� �����ϴ� ����
    private float doubleAttackTimeWindow = 0.2f; // ���� ������ �ν��ϱ� ���� �ð� ����

    public Vector2 boxSize; // OverlapBox�� ũ�⸦ �����ϴ� ����
    public Transform pos; // OverlapBox�� ��ġ�� �����ϴ� ����
    bool isPunched = false; // �÷��̾ ��ġ�� ���ߴ��� ���θ� ��Ÿ���� ����
    public bool isDelay = false; // ���� ������ ���θ� ��Ÿ���� ����
    Animator playerAnimator; // �÷��̾��� �ִϸ����� ������Ʈ�� �����ϴ� ����

    private void Start()
    {
        playerAnimator = GetComponent<Animator>(); // �ִϸ����� ������Ʈ�� ������
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isPunched) // �����̽��ٸ� ������ ƨ�ܳ��� ���� �ƴ� ��
        {
            Attack(); // Attack �޼��� ȣ��
        }
        else if (Input.GetKeyDown(KeyCode.LeftControl) && !hasAttacked) // ���� ��Ʈ�� Ű�� ������ ���� ���� �ƴ� ��
        {
            PunchBack(); // PunchBack �޼��� ȣ��
        }

        if (GameDirector.hp <= 0) // ������ ü���� 0 ������ ��
        {
            playerAnimator.SetTrigger("game_over");
            // ���� ���� Ʈ���Ÿ� �����Ͽ� �ִϸ��̼� ���
            // ���� ���� ������ ��ȯ
        }
    }

    // PunchBack �Լ��� ƨ�ܳ��� �Լ�
    public void PunchBack()
    {
        isPunched = true; // �÷��̾ ��ġ�� ���� ���·� ����
        playerAnimator.SetTrigger("punch"); // ��ġ �ִϸ��̼� ���

        var colliders = Physics2D.OverlapBoxAll(pos.position, boxSize, 0).ToList(); // OverlapBox �ȿ� �ִ� ��� �浹ü���� ������
        // OverlapBoxAll �޼���� �־��� ��ġ(pos.position)�� ũ��(boxSize)�� ������ �浹 �ڽ� ���� �ִ� ��� �浹ü ��ȯ
        // �� ��° �Ű������� 0�� �浹 ����ũ�� ��Ÿ����, �⺻������ �����Ǿ� ��� �浹ü�� ����
        // .ToList()�� OverlapBoxAll �޼��尡 ��ȯ�ϴ� �迭�� List���·� ��ȯ

        foreach (Collider2D collider in colliders)
        {
           // colliders List�� �ִ� �� ��Ҹ� �ݺ������� ó���ϱ� ���� ���� ����
           // colliders ����Ʈ�� �ִ� �� ��Ҹ� collider ������ �Ҵ��Ͽ� ���� ������ ���

            if (collider.tag == "Target") // collider ������ �����ϴ� �浹ü�� �±װ� Target�̶��
            {
                KatanaEffect.Punch(); // ƨ�ܳ��� ����Ʈ �ߵ�
                Effect.Apply(collider.gameObject); // ƨ�ܳ��� ȿ�� ����
            }
        }
        StartCoroutine(CountAttackDelay(0.4f)); // ���ݰ� ƨ�ܳ��� ���̿� �����̸� �����ϱ� ���� CountAttackDelay �ڷ�ƾ ����
    }

    public void Attack()
    {
        hasAttacked = true; // ������ ���·� ����
        float currentTime = Time.time; // ���� �ð� ����
        var colliders = Physics2D.OverlapBoxAll(pos.position, boxSize, 0).ToList(); // OverlapBox �ȿ� �ִ� ��� �浹ü���� ������
        if (!isDelay) // ���� ������ ���°� �ƴ� ���
        {
            playerAnimator.SetTrigger("attack"); // ���� �ִϸ��̼� ���
            foreach (Collider2D collider in colliders)
            {
                if (collider.tag == "Target") // �浹ü�� �±װ� "Target"�� ���
                {
                    KatanaEffect.Attack(); // ���� ����Ʈ �ߵ�
                    collider.gameObject.GetComponent<ItemController>().itemHp--; // �浹ü�� ������ ü�� ����
                    Recipe.DecreaseIngredient(collider.name); // Recipe.decreaseIngredient �Լ��� ����Ͽ� ��� ����
                }
            }
            isDelay = true; // ���� ������ ���·� ����
            lastAttackTime = currentTime; // ������ ���� �ð��� ���� �ð����� ������Ʈ
            
        }
        else if ((currentTime - lastAttackTime) <= doubleAttackTimeWindow) // ���� �ð��� ������ ���� �ð��� ���̰� ���� ���� �ð� ���ݺ��� �۰ų� ���� ���
                                                                           // (0.2�� �ȿ� ������ �ι� ���� ���� ���)
        {
            playerAnimator.SetTrigger("double_attack"); // ���� ���� �ִϸ��̼� ���
            foreach (Collider2D collider in colliders)
            {
                if (collider.tag == "Target") // �浹ü�� �±װ� "Target"�� ���
                {
                    KatanaEffect.DoubleAttack(); // ���� ���� ����Ʈ �ߵ�
                    collider.gameObject.GetComponent<ItemController>().itemHp--; // �浹ü�� ������ ü�� ����
                    Recipe.DecreaseIngredient(collider.name); // Recipe.decreaseIngredient �Լ��� ����Ͽ� ��� ����
                }
            }
            isDelay = true; // ���� ������ ���·� ����
            
        }
        StartCoroutine(CountAttackDelay(0.4f)); // ���ݰ� ƨ�ܳ��� ���̿� �����̸� �����ϱ� ���� CountAttackDelay �ڷ�ƾ ����
    }

    // ������ ���� �ڷ�ƾ
    IEnumerator CountAttackDelay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime); // �־��� �ð���ŭ ���
        isDelay = false; // ���� ������ ���� ����
        isPunched = false; // �÷��̾ ��ġ�� ���� ���� ����
        hasAttacked = false; // ������ ���� ����
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Target") // �浹ü�� �±װ� "Target"�� ���
        {
            Destroy(collider.gameObject); // �浹ü�� ����
            GameDirector.hp--; // ���� ü�� ����
            playerAnimator.SetTrigger("damaged"); // �ǰ� �ִϸ��̼� ���
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(pos.position, boxSize); // OverlapBox�� �׸��� Gizmos
    }
}
