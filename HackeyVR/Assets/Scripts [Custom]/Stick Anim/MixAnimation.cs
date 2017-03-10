using UnityEngine;
using UnityEngine.Experimental.Director;

[RequireComponent(typeof(Animator))]
public class MixAnimation : MonoBehaviour
{

    public AnimationClip clip1;
    public AnimationClip clip2;

    private AnimationMixerPlayable m_Mixer;

    void Strat()
    {
        //create the mixer and connect it to the clip
        //(AnimationClipPlayable are created implicitly)
        m_Mixer = AnimationMixerPlayable.Create();
        m_Mixer.SetInputs(new[] { clip1, clip2 });

        //Bind the playable graph to the player
        GetComponent<Animator>().Play(m_Mixer);
    }

    void Update()
    {
        //Adjust the weight of each clip in the blend tree base
        float weight = (Time.time % 10) / 10;
        m_Mixer.SetInputWeight(0, weight);
        m_Mixer.SetInputWeight(1, 1 - weight);
    }

}

