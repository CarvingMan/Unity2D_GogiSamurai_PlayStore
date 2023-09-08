using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EffectUI : MonoBehaviour
{
    [SerializeField] public GameObject textScore_Prefeb;
    [SerializeField] public GameObject ImageRecipe_Prefeb;

    GameObject textObj;
    GameObject imageObj;
    GameObject showRecipe;

    public float movespeed;
    public float alphaSpeed;
    public float destroyTime;
    
    TextMeshProUGUI text;
    Image image;

    Color textAlpha;
    Color ImageAlpha;

    float time = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        textObj = Instantiate(textScore_Prefeb, GameObject.Find("Canvas").transform);
        imageObj = Instantiate(ImageRecipe_Prefeb, GameObject.Find("Canvas").transform);
        showRecipe = GameObject.Find("Canvas/Recipe");

        text = textObj.GetComponent<TextMeshProUGUI>(); // TextMeshPro ������Ʈ ��������
        image = imageObj.GetComponent<Image>();

        textAlpha = text.color;                 // ���� �ؽ�Ʈ ���� �� ��������
        ImageAlpha = image.color;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        //Debug.Log(time);

        textObj.transform.Translate(new Vector3(0, movespeed * time, 0));
        imageObj.transform.Translate(new Vector3(0, movespeed * time, 0));
        SpringRecipe(showRecipe, time);

        // �ؽ�Ʈ ������Ʈ�� ���� �̵���Ű�� ���
        // alpha ���� ������ �ð��� ���� 0���� �����Ͽ� ���ҽ�Ŵ
        textAlpha.a = Mathf.Lerp(textAlpha.a, 0, time * alphaSpeed);
        ImageAlpha.a = Mathf.Lerp(ImageAlpha.a, 0, time * alphaSpeed);

        // ������ alpha ������ �ؽ�Ʈ ���� ������Ʈ
        text.color = textAlpha;
        image.color = ImageAlpha;
        
        // ���� �ð� ���Ŀ� ���ھ� ������Ʈ ����
        Invoke("DestroyScore", destroyTime);
    }

    private void DestroyScore()
    {
        // ���ھ� ������Ʈ ����
        Destroy(gameObject);
        Destroy(textObj);
        Destroy(imageObj);
    }

    public void SpringRecipe(GameObject gameObject, float time)
    {
        if (time < 0.4f) //Ư�� ��ġ���� �������� �̵�
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 130 - 325 * time, 0);
        }
        else if (time < 0.5f) // ƨ���
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, time - 0.4f, 0) * 100;
        }
        else if (time < 0.6f) //�ٽ� ���ڸ���
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0.6f - time, 0) * 100;
        }
        else if (time < 0.7f) //ƨ���
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, (time - 0.6f) / 2, 0) * 100;
        }
        else if (time < 0.8f) //�ٽ� ���ڸ�
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0.05f - (time - 0.7f) / 2, 0) * 100;
        }
        else
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
        }
    }
}