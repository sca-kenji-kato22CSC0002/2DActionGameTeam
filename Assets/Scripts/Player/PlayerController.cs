using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            anim.SetBool("Move", false);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            anim.SetBool("Move", true);
        }
        if (Input.GetMouseButtonDown(0)) 
        {
            anim.SetTrigger("Attack");
        }
    }
}
