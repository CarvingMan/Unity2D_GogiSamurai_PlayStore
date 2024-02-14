using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class PlayerController : MonoBehaviour
{

    private bool hasAttacked = false; // ������ �������� ���θ� ��Ÿ���� ����
    private float lastAttackTime = -1f; // ������ ���� �ð��� �����ϴ� ����
    private float doubleAttackTimeWindow = 0.4f; // ���� ������ �ν��ϱ� ���� �ð� ����


    public Vector2 boxSize; // OverlapBox�� ũ�⸦ �����ϴ� ����
    public Transform pos; // OverlapBox�� ��ġ�� �����ϴ� ����
    bool isPunched = false; // �÷��̾ ƨ�ܳ������ΰ� ���θ� ��Ÿ���� ����
                            // bool isDouble = false;  // �÷��̰Ű� ����������ΰ� ���θ� ��Ÿ���� ����
    public bool isDelay = false; //attack delay
    Animator playerAnimator; // �÷��̾��� �ִϸ����� ������Ʈ�� �����ϴ� ����
    AudioDirector audioDirector; // �÷��̾��� ��������� ������Ʈ�� �����ϴ� ����

    [SerializeField] GameObject LButton, RButton;

    private void Start()
    {
        playerAnimator = GetComponent<Animator>(); // �ִϸ����� ������Ʈ�� ������
        audioDirector = GetComponent<AudioDirector>(); // ��������� ������Ʈ�� ������
    }

    private void Update()
    {
        if (GameDirector.hp > 0) // ĳ���Ͱ� ����ִ� ��Ȳ�̸�
        {
            if (Input.GetKeyDown(KeyCode.Space) && !isPunched)
            // �����̽��ٸ� ������ ƨ�ܳ��� ���� �ƴ� ��
            {
                Attack(); // Attack �޼���(����) ȣ��
            }
            else if (Input.GetKeyDown(KeyCode.LeftControl) && !hasAttacked)
            // ���� ��Ʈ�� Ű�� ������ ���� ���� �ƴ� ��
            {
                PunchBack(); // PunchBack �޼���(ƨ�ܳ���) ȣ��
            }
        }

        if (GameDirector.hp <= 0) // ĳ������ ü���� 0 ������ ��
        {

            playerAnimator.SetTrigger("game_over"); // ���ӿ��� �ִϸ��̼� ���
        }

    }

    public void PunchBack() //effect of punching back ingredients
    {

        if (isDelay == false)
        {
            isPunched = true; // �÷��̾ ƨ�ܳ��� ���� ���·� ����
            playerAnimator.SetTrigger("punch"); // ƨ�ܳ��� �ִϸ��̼� ���


            var colliders = Physics2D.OverlapBoxAll(pos.position, boxSize, 0).ToList();
            // OverlapBox �ȿ� �ִ� ��� �浹ü���� ������
            // OverlapBoxAll �޼���� �־��� ��ġ(pos.position)�� ũ��(boxSize)�� ������ �浹 �ڽ� ���� �ִ� ��� �浹ü ��ȯ
            // �� ��° �Ű������� 0�� �浹 ����ũ�� ��Ÿ����, �⺻������ �����Ǿ� ��� �浹ü�� ����
            // .ToList()�� OverlapBoxAll �޼��尡 ��ȯ�ϴ� �迭�� List���·� ��ȯ

            if (colliders.Count == 0)
            {
                LButton.GetComponent<Button>().interactable = false;
                RButton.GetComponent<Button>().interactable = false;
                Invoke("NewButtonDelay", 0.18f);
            }

                foreach (Collider2D collider in colliders)
                // colliders List�� �ִ� �� ��Ҹ� �ݺ������� ó���ϱ� ���� ���� ����
                // colliders ����Ʈ�� �ִ� �� ��Ҹ� collider ������ �Ҵ��Ͽ� ���� ������ ���
                {

                    if (collider.tag == "Target")
                    // collider ������ �����ϴ� �浹ü�� �±װ� Target�̶��
                    {
                        audioDirector.SoundPlay("Sound/effect_sound/snare"); // ƨ�ܳ��� ���� ���
                        KatanaEffect.Punch(); // ƨ�ܳ��� ����Ʈ �ߵ�(�Ķ����� ƨ��� ȿ��)
                        Effect.Apply(collider.gameObject); // ƨ�ܳ��� ����Ʈ ����(��ῡ ����Ǵ� ȿ��)
                        break;
                    }
                    else
                    {
                        audioDirector.SoundPlay("Sound/effect_sound/swing1"); // �꽺�� �Ҹ� ���
                    }
                }
            isDelay = true; // �����̸� �ֱ� ���� isDelay��� bool������ true �Ҵ�
            StartCoroutine(CountAttackDelay(0.1f)); // ������ ������ �ֱ����� �ڷ�ƾ ����
        }

    }

    // ���� �Լ�
    public void Attack()
    {
        hasAttacked = true; // �÷��̾ �������� ���·� ����
        float currentTime = Time.time; // ���� �ð� ����

        var colliders = Physics2D.OverlapBoxAll(pos.position, boxSize, 0).ToList();

        if (!isDelay && (currentTime - lastAttackTime) >= doubleAttackTimeWindow) //if attack delay is false, attack. attack delay is true when player attacks
                                                                                  // ���� �����̰� OFF���
        {

            playerAnimator.SetTrigger("attack"); // ���� �ִϸ��̼� ���

            if (colliders.Count == 0)
            {
                LButton.GetComponent<Button>().interactable = false;
                RButton.GetComponent<Button>().interactable = false;
                Invoke("NewButtonDelay", 0.18f);
            }
            else
                foreach (Collider2D collider in colliders)
                {
                    if (collider.tag == "Target") //if there is collider in the box, play the sound of slicing ingredient
                    {
                        KatanaEffect.Attack(); // ���� ����Ʈ �ߵ�(īŸ���� ����Ǵ� ȿ��)
                        collider.gameObject.GetComponent<ItemController>().itemHp--; // ������ �浹ü�� ������ ü�� ���� 
                        audioDirector.SoundPlay("Sound/effect_sound/HiHat"); // �ڸ��� ȿ���� ���
                        if (collider.name == "chicken") //if the ingredient is chicken, play the sound of slicing chicken
                        {
                            audioDirector.SoundPlay("Sound/effect_sound/chicken"); // ġŲ �ڸ��� �Ҹ�
                        }
                        break;
                    }
                    else
                    {
                        audioDirector.SoundPlay("Sound/effect_sound/swing1"); // �꽺�� �Ҹ� ���
                    }
                }

            isDelay = true; // ������ ON
            lastAttackTime = Time.time; //reset the last attack time
            // ������ ���� �ð��� ���� �ð����� ������Ʈ
            StartCoroutine(CountAttackDelay(0.1f)); // 0.4�� �� ���� ������, �������� ���� OFF
        }
        else if ((currentTime - lastAttackTime) <= doubleAttackTimeWindow) //if player attacks again within 0.2 seconds
        {
            // isDouble = true; // �÷��̾ ������� ���� ���·� ����
            playerAnimator.SetTrigger("double_attack"); // ���� ���� �ִϸ��̼� ���

            foreach (Collider2D collider in colliders)
            {
                if (collider.tag == "Target") //if there is collider in the box, play the sound of slicing ingredient
                {
                    audioDirector.SoundPlay("Sound/effect_sound/HiHat2"); // ���� ���� �Ҹ� ���
                    if (collider.name == "chicken") //if the ingredient is chicken, play the sound of slicing chicken
                    {
                        audioDirector.SoundPlay("Sound/effect_sound/chicken"); // ġŲ �ڸ��� �Ҹ�
                    }
                    KatanaEffect.DoubleAttack(); // ���� ����Ʈ �ߵ�(īŸ���� ����Ǵ� ȿ��)
                    collider.gameObject.GetComponent<ItemController>().itemHp--; // ������ �浹ü�� ������ ü�� ���� 
                }
                else
                {
                    audioDirector.SoundPlay("Sound/effect_sound/swing2"); // �꽺�� �Ҹ� ���
                }
            }
            isDelay = true; // ������ ON
            StartCoroutine(CountAttackDelay(0.1f)); // 0.4�� �� ���� ������, �������� ���� OFF
            lastAttackTime = 0; //reset the last attack time
        }
    }

    void ResetDelay() // ������, ����, ƨ�ܳ��� ���¸� ���� �ʱ�ȭ �����ִ� �Լ�
    {
        isDelay = false;
        isPunched = false;
        hasAttacked = false;
    }

    IEnumerator CountAttackDelay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);


        ResetDelay(); // delayTime�� ��ŭ �� �ʱ�ȭ


    }

    // �÷��̾�� ������Ʈ(���)�� �浹�� ��� ü�°���
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Target") //�����۰� �浹�� 
        {
            Destroy(collider.gameObject);
            GameDirector.hp--; //hp����
            audioDirector.SoundPlay("Sound/effect_sound/hit");
            playerAnimator.SetTrigger("damaged");
        }
    }

    public void NewButtonDelay()
    {
        LButton.GetComponent<Button>().interactable = true;
        RButton.GetComponent<Button>().interactable = true;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(pos.position, boxSize);
    }

}