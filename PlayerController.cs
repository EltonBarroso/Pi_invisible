using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector2 target;    
    public float speed;
    

    private Vector3 scale;

    public Animator anim;

    private Rigidbody2D rb;
    

    
    // Start is called before the first frame update
    void Start()
    {
        
        target = transform.position;
        scale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //recebe coordenada do mouse na tela
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //muda a posi��o alvo do personagem
        
            if (Input.GetMouseButtonDown(0))
            {
                target = new Vector2(mousePos.x, transform.position.y);

            }

            //movimenta o personagem para a nova posi��o alvo
            transform.position = Vector2.MoveTowards(transform.position, target, Time.deltaTime * speed);
        


        //gira o personagem
        if (target.x - transform.position.x < 0)
        {
            transform.localScale = new Vector3(-1*scale.x, scale.y, scale.z);
        }
        if (target.x - transform.position.x > 0)
        {
            transform.localScale = new Vector3( 1 * scale.x, scale.y, scale.z);            
        }


        //habilita a anima��o de movimento
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("isMoving", true);
        }


        //desabilita a anima��o de movimento
        if (target.x == transform.position.x)
        {
            
            anim.SetBool("isMoving", false);
        }      

   
    }
    

}
