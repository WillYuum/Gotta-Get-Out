using UnityEngine;

public class PlayerModelController : MonoBehaviour
{

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayIdleAnimation()
    {
        animator.SetTrigger("Idle");
    }


    public void PlayerRunAnimation()
    {
        animator.SetTrigger("Run");
    }
}
