using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationContol : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        
    }
    [SerializeField] private Animator playerAC;
    // Update is called once per frame
    void Update()
    {
        
    }
    // RunningAnim starts when Vector3 have magnitude otherwise IdleAnim plays
    public void AnimControl(Vector3 move)
    {
        if(Vector3.Magnitude(move)>0)
        {
          playRunAnim();

          playerAC.transform.forward = move.normalized;

        }
        else
        {
          playIdleAnim();
        }
    }

    private void playRunAnim()
    {
        playerAC.Play("RUN");

    }

    private void playIdleAnim()
    {
        playerAC.Play("IDLE");

    }
}
