using UnityEngine;
using UnityEngine.Experimental.Director;

public class PlayAnimation : MonoBehaviour {

    public AnimationClip clip;

    void start()
    {
        //Wrap the clip in a playable
        var clipPlayable = AnimationClipPlayable.Create(clip);

        //Bind the playable to the player
        GetComponent<Animator>().Play(clipPlayable);
    }
}
