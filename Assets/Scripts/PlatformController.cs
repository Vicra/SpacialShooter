using UnityEngine;
using System.Collections;

public class PlatformController : MonoBehaviour {

    public GameObject upPlatform;
    public GameObject downPlatform;
    
    public float speed;
    
    void Update()
    {
        MoveLeft();
        if(upPlatform.transform.position.y > 1.5)
            MoveDown(upPlatform);
        if (downPlatform.transform.position.y < -1.5)
            MoveUp(downPlatform);
    }
    void MoveUp(GameObject platform)
    {
        platform.transform.Translate(0, speed, 0);
    }
    void MoveDown(GameObject platform)
    {
        platform.transform.Translate(0, -speed, 0);
    }
    void MoveLeft()
    {
        upPlatform.transform.Translate(-speed/2,0, 0);
        downPlatform.transform.Translate(-speed / 2, 0, 0);
    }
}
