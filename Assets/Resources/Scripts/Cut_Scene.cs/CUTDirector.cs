using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CUTDirector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SkipScene", 15f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  
    public void SkipScene() 
    { //skip ��ư�� �����Ͽ� Ŭ���� �� �ٷ� ���Ӿ����� ��ȯ
        SceneDirector.ChangeScene1();
    }
}
