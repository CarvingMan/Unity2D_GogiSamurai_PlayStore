using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerController : MonoBehaviour
{
    private bool hasAttacked = false;
    private float lastAttackTime = -1f;
    private float doubleAttackTimeWindow = 0.2f;

    public Vector2 boxSize;
    public Transform pos;
    bool isPunched = false;
    bool isDouble = false;
    public bool isDelay = false; //attack delay
    Animator playerAnimator;
    AudioDirector audioDirector;

    GameObject Gameover;

    private void Start()
    {
        Gameover = GameObject.Find("Gameover");
        playerAnimator = GetComponent<Animator>();
        audioDirector = GetComponent<AudioDirector>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isPunched)
        {
            Attack();
        }
        else if (Input.GetKeyDown(KeyCode.LeftControl) && !hasAttacked)
        {
            PunchBack();
        }

        if (GameDirector.hp <= 0)
        {
/*            Gameover.GetComponent<Gameover_sound>().gameover();
*/            playerAnimator.SetTrigger("game_over");
/*            audioDirector.SoundMute(true);*/
        }
    }
    public void PunchBack() //effect of punching back ingredients
    {
        isPunched = true;
        playerAnimator.SetTrigger("punch");

        var colliders = Physics2D.OverlapBoxAll(pos.position, boxSize, 0).ToList(); //get colliders in the box, and put them in the list
        if (colliders.Count == 0) //if there is no collider in the box, play the sound of punching air
        {
            isPunched = true;
            playerAnimator.SetTrigger("punch");
            
            var colliders = Physics2D.OverlapBoxAll(pos.position, boxSize, 0).ToList();
            foreach (Collider2D collider in colliders)
            {
                if (collider.tag == "Target")
                {
                    audioDirector.SoundPlay("Sound/effect_sound/fryingpan");
                    KatanaEffect.Punch();
                    Effect.Apply(collider.gameObject);
                }
                else {
                    audioDirector.SoundPlay("Sound/effect_sound/swing1");
                }
            }
            isDelay = true;
            StartCoroutine(CountAttackDelay(0.4f));
        }
    }

    public void Attack() //
    {
        hasAttacked = true;
        float currentTime = Time.time;

        var colliders = Physics2D.OverlapBoxAll(pos.position, boxSize, 0).ToList();
        if (!isDelay) //if attack delay is false, attack. attack delay is true when player attacks
        {

            playerAnimator.SetTrigger("attack");
            

            foreach (Collider2D collider in colliders)
            {
                if (collider.tag == "Target") //if there is collider in the box, play the sound of slicing ingredient
                {
                    KatanaEffect.Attack();
                    collider.gameObject.GetComponent<ItemController>().itemHp--;
                    audioDirector.SoundPlay("Sound/effect_sound/slice1");
                }
                else {
                    audioDirector.SoundPlay("Sound/effect_sound/swing1");
                }
            }

            isDelay = true;
            lastAttackTime = currentTime; //reset the last attack time
            StartCoroutine(CountAttackDelay(0.3f));
        }
        else if ((currentTime - lastAttackTime) <= doubleAttackTimeWindow) //if player attacks again within 0.2 seconds
        {
            isDouble = true;
            playerAnimator.SetTrigger("double_attack");

            foreach (Collider2D collider in colliders)
            {
                if (collider.tag == "Target") //if there is collider in the box, play the sound of slicing ingredient
                {
                    audioDirector.SoundPlay("Sound/effect_sound/slice2");
                    if (collider.name == "chicken") //if the ingredient is chicken, play the sound of slicing chicken
                    {
                        audioDirector.SoundPlay("Sound/effect_sound/chicken");
                    }
                    KatanaEffect.DoubleAttack();
                    collider.gameObject.GetComponent<ItemController>().itemHp--;
                }
                else {
                    audioDirector.SoundPlay("Sound/effect_sound/swing2");
                }
            }
            isDelay = true;
        }
        StartCoroutine(CountAttackDelay(0.4f));
    }


    IEnumerator CountAttackDelay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime); //wait for delayTime seconds
        isDelay = false;
        isPunched = false;
        hasAttacked = false;

    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Target") //if player collides with ingredient, decrease hp
        {
            Destroy(collider.gameObject);
            GameDirector.hp--;
            audioDirector.SoundPlay("Sound/effect_sound/hit");
            playerAnimator.SetTrigger("damaged");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(pos.position, boxSize);
    }
}