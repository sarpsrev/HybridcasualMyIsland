using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickController : MonoBehaviour
{
    public RectTransform joystickOutline;
    public RectTransform joystickButton;
    public RectTransform joystickArea;
    
    // Start is called before the first frame update
    void Start()
    {
        hideJoystick();
        
    }

    // Update is called once per frame
     void Update()
    {

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {

                case TouchPhase.Began:
                    Vector2 localPoint;
                //
                    RectTransformUtility.ScreenPointToLocalPointInRectangle(joystickArea, touch.position, null, out localPoint);

                    joystickOutline.anchoredPosition = localPoint;

                    joystickOutline.gameObject.SetActive(true);
                    break;

                case TouchPhase.Moved:
                Vector2 movementPos = touch.deltaPosition;

                // Calculating area of joystick outline.               
                float joystickAreaWidth = joystickOutline.rect.width;
                float joystickAreaHeight = joystickOutline.rect.height;

                // Calculating new position of joystick
                Vector3 newPos = joystickButton.gameObject.transform.localPosition + new Vector3(movementPos.x, movementPos.y, 0f);


                //Make it move within a certain area with clamp for joystick              
                float halfButtonWidth = joystickButton.rect.width * 0.5f;
                float halfButtonHeight = joystickButton.rect.height * 0.5f;
                newPos.x = Mathf.Clamp(newPos.x, -joystickAreaWidth * 0.5f + halfButtonWidth, joystickAreaWidth * 0.5f - halfButtonWidth);
                newPos.y = Mathf.Clamp(newPos.y, -joystickAreaHeight * 0.5f + halfButtonHeight, joystickAreaHeight * 0.5f - halfButtonHeight);

                //Set joystick position
                joystickButton.gameObject.transform.localPosition = newPos;

                    break;

                case TouchPhase.Ended:
                    hideJoystick();
                    break;
            }
        }
    }


    private void hideJoystick()
    {
        joystickOutline.gameObject.SetActive(false);
        
    }

}
