using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishTutorialsItemControl : TutorialsItemControl
{
    protected override void Run()
    {
        // 튜토리얼 완성 기록
       // PlayerPrefs.SetInt(Define.TutorialsDone, 1);

        // home scene을 연다.
        //SceneManager.LoadScene(Define.HomeScene);


        base.Run();
    }
}
