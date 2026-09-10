using UnityEngine;
using UnityEngine.InputSystem;

public class ShootDirection : MonoBehaviour
{
    public Transform player;
    void Update()
    {
        Vector2 input = Vector2.zero;
        var kb = Keyboard.current;
        transform.position = player.position;
        if (kb != null)
        {
            //shoots in 8 directions
            if (kb.wKey.isPressed || kb.upArrowKey.isPressed)
            {
                transform.position = player.position + new Vector3(0f, 0.5f, 0f); //up
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            if (kb.sKey.isPressed || kb.downArrowKey.isPressed)
            {
                transform.position = player.position + new Vector3(0f, -0.5f, 0f); //down
                transform.rotation = Quaternion.Euler(0,0,180);
            }
            if (kb.aKey.isPressed || kb.leftArrowKey.isPressed)
            {
                transform.position = player.position + new Vector3(-0.5f, 0f, 0f); //left
                transform.rotation = Quaternion.Euler(0,0,90);
            }
            if (kb.dKey.isPressed || kb.rightArrowKey.isPressed)
            {
                transform.position = player.position + new Vector3(0.5f, 0f, 0f); //right
                transform.rotation = Quaternion.Euler(0,0,270);
            }
            if (kb.wKey.isPressed && kb.aKey.isPressed || kb.upArrowKey.isPressed && kb.leftArrowKey.isPressed)
            {
                transform.position = player.position + new Vector3(-0.5f, 0.3f, 0f); //up and left
                transform.rotation = Quaternion.Euler(0, 0, 45);
            }
            if (kb.wKey.isPressed && kb.dKey.isPressed || kb.upArrowKey.isPressed && kb.rightArrowKey.isPressed)
            {
                transform.position = player.position + new Vector3(0.5f, 0.3f, 0f); //up and right
                transform.rotation = Quaternion.Euler(0,0,315);
            }
            if (kb.sKey.isPressed && kb.aKey.isPressed || kb.downArrowKey.isPressed && kb.leftArrowKey.isPressed)
            {
                transform.position = player.position + new Vector3(-0.5f, -0.3f, 0f); //down and left
                transform.rotation = Quaternion.Euler(0,0,135);
            }
            if (kb.sKey.isPressed && kb.dKey.isPressed || kb.downArrowKey.isPressed && kb.rightArrowKey.isPressed)
            {
                transform.position = player.position + new Vector3(0.5f, -0.3f, 0f); //down and right
                transform.rotation = Quaternion.Euler(0,0,225);
            }

        }



    }
}
