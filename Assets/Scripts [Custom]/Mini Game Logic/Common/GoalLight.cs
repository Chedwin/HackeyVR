using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalLight : MonoBehaviour {

    public Light goalLight;


    private void Start()
    {
        SetLight(false);
    }

    public IEnumerator SoundGoalLight(float _time)
    {
        SetLight(true);
        yield return new WaitForSeconds(_time);
        SetLight(false);
    }

    void SetLight(bool _b) {
        goalLight.enabled = _b;
    }

} // end class GoalLight