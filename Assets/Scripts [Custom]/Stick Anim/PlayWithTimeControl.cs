using UnityEngine;
using UnityEngine.Experimental.Director;

[RequireComponent (typeof(Animator))]
public class PlayWithTimeControl : MonoBehaviour {

    public AnimationClip clip;

    private Playable m_Root;
    private const float k_SpeedFactor = 1f;


    void Start()
    {
        m_Root = AnimationClipPlayable.Create(clip);

        //Bind the playable to the player
        GetComponent<Animator>().Play(m_Root);

        m_Root.state = PlayState.Paused;

    }

    void update()
    {
        //Control the time manually based on the input
        float horizontalInput = Input.GetAxis("Horizontal");
        m_Root.time += horizontalInput * k_SpeedFactor * Time.deltaTime;

    }
}
