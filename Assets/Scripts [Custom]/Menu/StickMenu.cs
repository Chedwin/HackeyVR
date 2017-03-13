using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StickMenu : MonoBehaviour {

    public RectTransform leftHandMenu;
    public RectTransform rightHandMenu;

	// Use this for initialization
	void Start ()
    {
        ChangeMenuColor();
    }

    public void ChangeMenuColor()
    {
        if (GameManager.Instance.stickHand == GameManager.STICKHANDEDNESS.LEFT)
        {
            Image imgLeft = leftHandMenu.GetComponent<Image>();
            imgLeft.color = Color.green;

            Image imgRight = rightHandMenu.GetComponent<Image>();
            imgRight.color = Color.white;
        }
        else
        {
            Image imgLeft = leftHandMenu.GetComponent<Image>();
            imgLeft.color = Color.white;

            Image imgRight = rightHandMenu.GetComponent<Image>();
            imgRight.color = Color.green;
        }
    }
    
	
	
} // end class StickMenu
