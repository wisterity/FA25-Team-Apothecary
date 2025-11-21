using UnityEngine;

public class RoomSwitcher : MonoBehaviour
{
    public Transform cauldronRoomCamPos;   // empty object marking camera position
    public Transform orderRoomCamPos;      // empty object marking camera position

    private bool inCauldronRoom = true;
    private Camera mainCam;

    void Start()
    {
        mainCam = Camera.main;
        // Start at cauldron room
        mainCam.transform.position = cauldronRoomCamPos.position;
    }

    public void ToggleRoom()
    {
        inCauldronRoom = !inCauldronRoom;

        if (inCauldronRoom)
        {
            mainCam.transform.position = cauldronRoomCamPos.position;
        }
        else
        {
            mainCam.transform.position = orderRoomCamPos.position;
        }
    }
}
