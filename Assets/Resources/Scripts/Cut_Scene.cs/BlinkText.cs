using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkText : MonoBehaviour
{
    private float nOpacity = 1; // ����

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    private void FixedUpdate() //���� ������ �ӵ�
    {
        if (nOpacity < 0.5f) //������ 0.5����
        {
           GetComponent<Text>().color = new Color(1,0,0, 1 - nOpacity); //Color�� ����(����)�κ��� nOpacity��ŭ ����ŭ ���
        }
        else 
        {
            GetComponent<Text>().color = new Color(1,0,0, nOpacity); //Color�� �����κ��� nOpacity��ŭ ����ŭ ���
            if (nOpacity > 1)//������ 1�̻��� �Ǹ� �ʱ�ȭ 
            { 
                nOpacity = 0;
            }
        }
        nOpacity += 0.015f;
    }
}
