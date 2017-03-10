using UnityEngine;
using UnityEngine.Experimental.Director;

public class PlayQueueAnimation : CustomAnimationPlayable
{
    public int m_CurrentClipIndex = -1;
    public float m_TimeToNextClip;
    public AnimationMixerPlayable m_Mixer;

    public PlayQueueAnimation()
    {
        m_Mixer = AnimationMixerPlayable.Create();
        AddInput(m_Mixer);
    }

    public void SetInputs(AnimationClip[] clipsToPlay)
    {
        foreach (AnimationClip clip in clipsToPlay)
        {
            m_Mixer.AddInput(AnimationClipPlayable.Create(clip));
        }
    }

    override public void PrepareFrame(FrameData info)
    {
        // Advance to next clip if necessary
        m_TimeToNextClip -= (float)info.deltaTime;
        if (m_TimeToNextClip <= 0.0f)
        {
            m_CurrentClipIndex++;
            if (m_CurrentClipIndex < m_Mixer.inputCount)
            {
                var currentClip = m_Mixer.GetInput(m_CurrentClipIndex).CastTo<AnimationClipPlayable>();

                // Reset the time so that the next clip starts at the correct position
                currentClip.time = 0;
                m_TimeToNextClip = currentClip.clip.length;
            }
            else
            {
                // Pause when queue is complete
                state = PlayState.Paused;
            }
        }

        // Adjust the weight of the inputs
        for (int a = 0; a < m_Mixer.inputCount; a++)
        {
            if (a == m_CurrentClipIndex)
                m_Mixer.SetInputWeight(a, 1.0f);
            else
                m_Mixer.SetInputWeight(a, 0.0f);
        }
    }
}


[RequireComponent(typeof(Animator))]
public class PlayQueue : MonoBehaviour
{
    public AnimationClip[] clipsToPlay;

    void Start()
    {
        var playQueue = Playable.Create<PlayQueueAnimation>();
        playQueue.SetInputs(clipsToPlay);

        // Bind the queue to the player
        GetComponent<Animator>().Play(playQueue);
    }
}

