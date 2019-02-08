using System;
using System.Collections;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    public LayerMask whatIsPlayer;

    public GameObject brokenBlock;

    public AudioClip hitClip;

    public bool canBreak;

    private BoxCollider2D m_boxCollider2D;

    private void Awake()
    {
        m_boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        //
        if (collision2D.gameObject.tag == "Player")
        {
            Vector2 pos = transform.position;
            
            //ブロックのどこに触られたらブロックは崩れるか 元々はtransform.lossy.yの前の符号は-で下から叩く形式
            Vector2 groundCheck = new Vector2(pos.x, pos.y + transform.lossyScale.y); 
            //Debug.Log(pos.y + "," + (pos.y - transform.lossyScale.y));

            Vector2 groundArea = new Vector2(m_boxCollider2D.size.x * transform.lossyScale.y * 0.45f, 0.05f);
            var col2D = Physics2D.OverlapArea(groundCheck + groundArea, groundCheck - groundArea, whatIsPlayer);

           

            if (col2D)
            {
                if (canBreak)
                {
                    Invoke("Break_Brock",1.5f);
                    //GameObject broken = (GameObject) Instantiate(brokenBlock, transform.position, transform.rotation);
                    //broken.transform.localScale = transform.lossyScale;
                    //Destroy(gameObject);
                }
                else
                {
                    AudioSourceController.instance.PlayOneShot(hitClip);
                }
            }
        }
    }
    //private IEnumerator Break_Brock()
    void Break_Brock(){
    //    yield return new WaitForSeconds(2);

        GameObject broken = (GameObject)Instantiate(brokenBlock, transform.position, transform.rotation);
        broken.transform.localScale = transform.lossyScale;
        Destroy(gameObject);
    }

}