using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckCannon : MonoBehaviour
{
    public Transform playerTarget;
    public float rotationSpeed = 2.0f;

    public float shootSpeed = 80.0f;

    Transform nozzle;

    void Start()
    {
        nozzle = transform.FindChild("PCshooter");
    }

    private void Update()
    {
        Vector3 n = new Vector3(playerTarget.position.x, transform.position.y, playerTarget.position.z);
        Vector3 z = transform.position - new Vector3(0, transform.position.y, 0);

        Vector3 direction = (n - z).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }

    public void FireCannon()
    {
        SkillCompetition skillRef = SkillCompetition.GetSkillRef();
        skillRef.ShootPuck(nozzle.position, nozzle.forward, 0.0f, shootSpeed);     
    }

} // end class PuckCannon