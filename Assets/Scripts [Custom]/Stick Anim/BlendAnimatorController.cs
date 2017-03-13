using UnityEngine;
using UnityEngine.Experimental.Director;

[RequireComponent (typeof(Animator))]
public class BlendAnimatorController : MonoBehaviour {

    public AnimationClip clip;
    public RuntimeAnimatorController animController;

    void Start()
    {
        //Wrap the clip and the controllerin playables
        var clipsPlayable = AnimationClipPlayable.Create(clip);
        var controllerPlayable = AnimatorControllerPlayable.Create(animController);
        var mixer = AnimationMixerPlayable.Create();
        mixer.SetInputs(new Playable[] { clipsPlayable, controllerPlayable });

        //Bind the playable graph to the player
        GetComponent<Animator>().Play(mixer);

    }
	
}
