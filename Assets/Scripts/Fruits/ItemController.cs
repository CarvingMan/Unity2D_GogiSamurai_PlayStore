using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ItemController : MonoBehaviour
{

    [SerializeField] public int itemHp;

    bool executeOnlyOnce = true;
    // Bezier rate
    [Range(0f, 1f)] public float rate;
    // Bezier position
    public Vector2[] controllPosition;
    // End Bezier and Force
    public Rigidbody2D rb;
    Animator itemAnimator;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        itemAnimator = GetComponent<Animator>();


    }

    private void FixedUpdate()
    {
        if (gameObject.transform.position.y <= 0.7f)
            // 재료가 맵 아래로 떨어지면 삭제 시키기
        {
            Destroy(gameObject);
        }

<<<<<<< Updated upstream
        // �꽑�삎蹂닿컙�쓣 怨꾩궛�븳 寃곌낵媛믪쓣 �봽�젅�엫怨� �봽�젅�엫 �궗�씠�쓽 �떆媛꾩쓣 怨꾩냽 �뜑�빐 �씠�룞
=======
        // ?좏삎蹂닿컙??怨꾩궛??寃곌낵媛믪쓣 ?꾨젅?꾧낵 ?꾨젅???ъ씠???쒓컙??怨꾩냽 ?뷀빐 ?대룞
>>>>>>> Stashed changes
        rate += Time.deltaTime;
        transform.position = BezierTest(controllPosition[0], controllPosition[1], controllPosition[2], controllPosition[3], rate);
        

        if (rate >= 1f)
            // 재료가 생성되고 베지어 곡선을 따라가다가, 생성된지 1초가 넘으면 왼쪽 방향으로
            // AddForce를 주기(날아가는 듯한 효과를 위함)
        {
            Vector2 pushForce = Vector2.left * 250.0f;
            rb.AddForce(pushForce);
        }


        if (itemHp == 0) // 재료의 hp가 0이라면
        {
            if (executeOnlyOnce) // 재료 하나당 한번씩만 실행되는 bool형 변수
            {
                itemAnimator.SetTrigger("slice"); // 슬라이스 애니메이션 부여
                rb.MovePosition(new Vector2(4f, 3f)); // 재료를 해당위치로 이동시키기
                Recipe.DecreaseIngredient(this.name);
                executeOnlyOnce = false;
            }
            Vector2 rightForce = Vector2.right * 250.0f;

            // 더이상 왼쪽으로 이동하지 않게 오른쪽 방향으로 똑같이 250만큼 힘을 주어 제자리에 정지된 것 처럼 보이게 만들기
            rb.AddForce(rightForce);

            rb.gravityScale = 15f; // 중력을 부여해 아래로 떨어지게 하기
        }
    }

    // https://www.youtube.com/watch?v=KTEX2L4T4zE

<<<<<<< Updated upstream
    // �젏怨� �젏 �궗�엲媛믪쓣 異붿젙�븯湲� �쐞�븯�뿬 吏곸꽑 嫄곕━�뿉 �뵲�씪 �꽑�삎�쟻�쑝濡� 怨꾩궛�븯�뒗 諛⑸쾿�씠�떎.
    public Vector2 BezierTest(Vector2 P_1, Vector2 P_2, Vector2 P_3, Vector2 P_4, float value)
    {
        Vector2 A = Vector2.Lerp(P_1, P_2, value);  // P_1吏��젏怨� P_2吏��젏�쓽 �꽑�삎援ш컙 怨꾩궛媛� : A
        Vector2 B = Vector2.Lerp(P_2, P_3, value);  // P_2吏��젏怨� P_3吏��젏�쓽 �꽑�삎援ш컙 怨꾩궛媛� : B
        Vector2 C = Vector2.Lerp(P_3, P_4, value);  // P_3吏��젏怨� P_4吏��젏�쓽 �꽑�삎援ш컙 怨꾩궛媛� : C

        Vector2 D = Vector2.Lerp(A, B, value);      // A吏��젏怨� B吏��젏�쓽 �꽑�삎援ш컙 怨꾩궛媛� : D
        Vector2 E = Vector2.Lerp(B, C, value);      // B吏��젏怨� C吏��젏�쓽 �꽑�삎援ш컙 怨꾩궛媛� : E

        Vector2 F = Vector2.Lerp(D, E, value);      // D吏��젏怨� E吏��젏�쓽 �꽑�삎援ш컙 怨꾩궛媛� : F
        return F;                                   // �쐞�뿉�꽌 怨꾩궛�븳 珥� 寃곌낵媛믪쓣 F濡� 諛섑솚
=======
    // ?먭낵 ???ъ엲媛믪쓣 異붿젙?섍린 ?꾪븯??吏곸꽑 嫄곕━???곕씪 ?좏삎?곸쑝濡?怨꾩궛?섎뒗 諛⑸쾿?대떎.
    public Vector2 BezierTest(Vector2 P_1, Vector2 P_2, Vector2 P_3, Vector2 P_4, float value)
    {
        Vector2 A = Vector2.Lerp(P_1, P_2, value);  // P_1吏�?먭낵 P_2吏�?먯쓽 ?좏삎援ш컙 怨꾩궛媛?: A
        Vector2 B = Vector2.Lerp(P_2, P_3, value);  // P_2吏�?먭낵 P_3吏�?먯쓽 ?좏삎援ш컙 怨꾩궛媛?: B
        Vector2 C = Vector2.Lerp(P_3, P_4, value);  // P_3吏�?먭낵 P_4吏�?먯쓽 ?좏삎援ш컙 怨꾩궛媛?: C

        Vector2 D = Vector2.Lerp(A, B, value);      // A吏�?먭낵 B吏�?먯쓽 ?좏삎援ш컙 怨꾩궛媛?: D
        Vector2 E = Vector2.Lerp(B, C, value);      // B吏�?먭낵 C吏�?먯쓽 ?좏삎援ш컙 怨꾩궛媛?: E

        Vector2 F = Vector2.Lerp(D, E, value);      // D吏�?먭낵 E吏�?먯쓽 ?좏삎援ш컙 怨꾩궛媛?: F
        return F;                                   // ?꾩뿉??怨꾩궛??珥?寃곌낵媛믪쓣 F濡?諛섑솚
>>>>>>> Stashed changes
    }


}

// Bezier graphic area
[CanEditMultipleObjects]
[CustomEditor(typeof(ItemController))]
public class Test_Editor : Editor
{
    private void OnSceneGUI()
    {
<<<<<<< Updated upstream
        // �쁽�옱 �삤釉뚯젥�듃 李몄“
        ItemController Generator = (ItemController)target;

        // �삤釉뚯젥�듃 �젣�뼱
        // �젣�뼱 �룷�씤�듃 0遺��꽣 3源뚯���쓽 �쐞移섎�� �빖�뱾�쓣 �넻�빐 議곗젙�빀�땲�떎.
=======
        // ?꾩옱 ?ㅻ툕?앺듃 李몄“
        ItemController Generator = (ItemController)target;

        // ?ㅻ툕?앺듃 ?쒖뼱
        // ?쒖뼱 ?ъ씤??0遺�??3源뚯????꾩튂瑜??몃뱾???듯빐 議곗젙?⑸땲??
>>>>>>> Stashed changes
        Generator.controllPosition[0] = Handles.PositionHandle(Generator.controllPosition[0], Quaternion.identity);
        Generator.controllPosition[1] = Handles.PositionHandle(Generator.controllPosition[1], Quaternion.identity);
        Generator.controllPosition[2] = Handles.PositionHandle(Generator.controllPosition[2], Quaternion.identity);
        Generator.controllPosition[3] = Handles.PositionHandle(Generator.controllPosition[3], Quaternion.identity);

<<<<<<< Updated upstream
        // pos[0], pos[1] �뿰寃�
        // �젣�뼱 �룷�씤�듃 0怨� 1�쓣 �꽑�쑝濡� �뿰寃고빀�땲�떎.
        Handles.DrawLine(Generator.controllPosition[0], Generator.controllPosition[1]);
        // pos[2], pos[3] �뿰寃�
        // �젣�뼱 �룷�씤�듃 2��� 3�쓣 �꽑�쑝濡� �뿰寃고빀�땲�떎.
        Handles.DrawLine(Generator.controllPosition[2], Generator.controllPosition[3]);

        // 移댁슫�듃媛� 利앷���븿�뿉 �뵲�씪 �뜑 遺��뱶�읇寃� �맗�땲�떎.
        int Count = 50;
        for (float i = 0; i < Count; i++)
        {
            // Bezier 怨≪꽑�쓣 �뵲�씪 �씠�쟾 �쐞移섎�� 怨꾩궛�빀�땲�떎.
            float value_Before = i / Count;
            Vector2 Before = Generator.BezierTest(Generator.controllPosition[0], Generator.controllPosition[1], Generator.controllPosition[2], Generator.controllPosition[3], value_Before);

            // Bezier 怨≪꽑�쓣 �뵲�씪 �떎�쓬 �쐞移섎�� 怨꾩궛�빀�땲�떎.
            float value_After = (i + 1) / Count;
            Vector2 After = Generator.BezierTest(Generator.controllPosition[0], Generator.controllPosition[1], Generator.controllPosition[2], Generator.controllPosition[3], value_After); ;

            // �씠�쟾 �쐞移섏�� �떎�쓬 �쐞移섎�� �꽑�쑝濡� �뿰寃고빀�땲�떎.
=======
        // pos[0], pos[1] ?곌껐
        // ?쒖뼱 ?ъ씤??0怨?1???좎쑝濡??곌껐?⑸땲??
        Handles.DrawLine(Generator.controllPosition[0], Generator.controllPosition[1]);
        // pos[2], pos[3] ?곌껐
        // ?쒖뼱 ?ъ씤??2?� 3???좎쑝濡??곌껐?⑸땲??
        Handles.DrawLine(Generator.controllPosition[2], Generator.controllPosition[3]);

        // 移댁슫?멸? 利앷??⑥뿉 ?곕씪 ??遺�?쒕읇寃??⑸땲??
        int Count = 50;
        for (float i = 0; i < Count; i++)
        {
            // Bezier 怨≪꽑???곕씪 ?댁쟾 ?꾩튂瑜?怨꾩궛?⑸땲??
            float value_Before = i / Count;
            Vector2 Before = Generator.BezierTest(Generator.controllPosition[0], Generator.controllPosition[1], Generator.controllPosition[2], Generator.controllPosition[3], value_Before);

            // Bezier 怨≪꽑???곕씪 ?ㅼ쓬 ?꾩튂瑜?怨꾩궛?⑸땲??
            float value_After = (i + 1) / Count;
            Vector2 After = Generator.BezierTest(Generator.controllPosition[0], Generator.controllPosition[1], Generator.controllPosition[2], Generator.controllPosition[3], value_After); ;

            // ?댁쟾 ?꾩튂?� ?ㅼ쓬 ?꾩튂瑜??좎쑝濡??곌껐?⑸땲??
>>>>>>> Stashed changes
            Handles.DrawLine(Before, After);
        }
    }
}
