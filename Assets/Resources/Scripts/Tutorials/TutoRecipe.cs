using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutoRecipe : MonoBehaviour
{
    public TextMeshProUGUI tt = null;
    private enum TutorialState { ment1, ment2, ment3, ment4 }
    private TutorialState currentState;

    private void Start()
    {
        GameDirector.isTouch = false;
        currentState = TutorialState.ment1;
    }


    void Update()
    {
        switch (currentState)
        {
            case TutorialState.ment1:
                tt.text = "�� ���ĵ��� ���� �ٸ� �����Ǹ� ������ �ֽ��ϴ�.";
                if (Input.GetMouseButtonDown(0))
                {
                    currentState = TutorialState.ment2;
                }
                break;
            case TutorialState.ment2:
                tt.text = "����� ������ ������ ���߾� ���� �ְ� �丮�� �ϼ� �ϼ���!";
                if (Input.GetMouseButtonDown(0))
                {
                    currentState = TutorialState.ment3;
                }
                break;
            case TutorialState.ment3:
                tt.text = "�����Ǹ� �ϼ��� ������ 300���� ��Ե˴ϴ�!";
                if (Input.GetMouseButtonDown(0))
                {
                    currentState = TutorialState.ment4;

                }
                break;
            case TutorialState.ment4:
                tt.text = "��! <color=red>�����ǿ� ���� �ʴ� ���</color>�� <color=red>�� ���� ���</color>�� �� �� <color=red>��� ������ ����</color>�ǹǷ� ������ �ּ���!";

                GameDirector.isTouch = true;
                TutoAtkRange.availableMove = true;           
                Invoke("TouchControll", 0.5f);


                break;
            default:
                tt.text = "Error";
                break;
        }
    }



    void TouchControll()
    {
        GameDirector.isTouch = false;
    }

}
