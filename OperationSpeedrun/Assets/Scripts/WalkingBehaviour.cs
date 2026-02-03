using UnityEngine;

public class WalkingBehaviour : StateMachineBehaviour
{
    private AudioSource[] audio;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Get the audio source component
        audio = animator.GetComponentsInParent<AudioSource> ();
        //Play the audio at the beginning of its index, 0
        audio[0].Play();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Stops the audio when the state has been exited
        audio[0].Stop();
    }
}
