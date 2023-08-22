using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutoConcept : MonoBehaviour
{
    [SerializeField]
    //public static bool isTouch = false;
    GameObject RButton;
    [SerializeField]
    GameObject LButton;
    [SerializeField]
    GameObject Heart;

    public TextMeshProUGUI tt = null;

    private void Start()
    {
        Heart.gameObject.SetActive(false);
        RButton.gameObject.SetActive(false);
        LButton.gameObject.SetActive(false);
        GameDirector.isTouch = false;
        tt.text = "�ȳ��ϼ��� ���ι����� Ʃ�丮�� �Դϴ�!";
    }
    // Update is called once per frame
    void Update()
    {
        
        
        if (Input.GetMouseButtonDown(0))
        {
            tt.text = "���ι����̴� �̽İ�(npc)�� ������ ���� ������ �����ǿ� ���߾� �丮�� �ϴ� �����Դϴ�.";
            GameDirector.isTouch = true;
            Invoke("TouchControll", 0.5f);
        }
        
    }
    void TouchControll()
    {
        GameDirector.isTouch = false;
    }
}
