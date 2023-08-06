using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneFader : MonoBehaviour
{
    public Image fadeImage;         // ȭ���� ���� UI Image ������Ʈ�� ���� ����
    public float fadeDuration = 1.5f; // ���̵� ȿ���� ���� �ð�(��)

    private bool isFading = false; // ���̵� ȿ�� ������ ���θ� ��Ÿ���� �÷���

    // ���̵� �ƿ� ȿ���� ���� �ڷ�ƾ
    private IEnumerator FadeOut(string sceneName)
    {
        if (isFading) yield break; // ���̵� ȿ�� ���� ��� �� �ٸ� ���̵� ȿ���� �������� ����

        isFading = true;
        fadeImage.gameObject.SetActive(true);
        fadeImage.color = new Color(0f, 0f, 0f, 0f);

        float t = 0f;
        while (t < 1f)
        {
            t += Time.unscaledDeltaTime / fadeDuration;
            fadeImage.color = new Color(0f, 0f, 0f, t);
            yield return null;
        }

        SceneManager.LoadScene(sceneName);
    }

    public void StartFadeOut(string sceneName)
    {
        StartCoroutine(FadeOut(sceneName));
    }

    // ���̵� ȿ���� ������ ȣ���Ͽ� �÷��׸� �����մϴ�.
    private void OnFadeComplete()
    {
        isFading = false;
    }
}