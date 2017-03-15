using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneTimerNet : MonoBehaviour {

    public bool isFreeMode = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Puck")
            return;

        Projectile proj = other.gameObject.GetComponent<Projectile>();

        if (proj != null) {
            if (proj.shot)
                return;
            proj.shot = true;
        }

        SkillCompetition inst = SkillCompetition.GetSkillRef();

        inst.playerScore++;
        inst.SetHomeScoreText(inst.playerScore);

        if (isFreeMode == false)
            inst.CheckFinish();

        AudioManager.Instance.PlayClip("goalHorn");
    }


} // end class OneTimerNet
