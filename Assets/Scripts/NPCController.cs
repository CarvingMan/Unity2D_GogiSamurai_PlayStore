using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    Animator npcAnimator;
    // npc��Ʈ�ѷ����� ����ϱ� ���� ����
    public static bool isDrawing;

    // Start is called before the first frame update
    void Start()
    {
        npcAnimator = GetComponent<Animator>();
        isDrawing = false; //�����Ҷ� �ʱ�ȭ
    }

    // Update is called once per frame
    void Update()
    {

        //isDrawing�� true�� ������ �ִϸ��̼��� ���´�. isDrawing�� ���ʷ����� ��ũ��Ʈ���� �������� �����ɶ� true�� �ȴ�.
        if (isDrawing == true) {
            npcAnimator.SetTrigger("drawing");
            isDrawing = false; // �������� �ʱ�ȭ
        }


    }
}
