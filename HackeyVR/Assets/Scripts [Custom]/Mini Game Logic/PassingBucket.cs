using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassingBucket : MonoBehaviour {

    public GameManager.STICKHANDEDNESS stickHand;

    public GameObject puck;
    public Transform spawnPoint;

    [Range(0.25f, 3.0f)]
    public float shootSpeed = 0.25f;

    // Use this for initialization
    void Awake ()
    {
        //if (GameManager.Instance.StickHandedness != stickHand)
        //{
        //    gameObject.SetActive(false);
        //}
        //else
        //{
        //    gameObject.SetActive(true);
        //}

	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    IEnumerator WaitDelay()
    {
        yield return new WaitForSeconds(1.0f);
    }

    public void SpawnPuck()
    {
        GameObject newBall = Instantiate(puck, spawnPoint.transform.position, Quaternion.identity) as GameObject;
        newBall.GetComponent<Rigidbody>().AddForce(spawnPoint.transform.right * shootSpeed, ForceMode.Impulse);
    }

} // end class PassingBucket