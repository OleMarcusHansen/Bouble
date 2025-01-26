using Unity.Cinemachine;
using UnityEngine;

public class PlayerBubble : GasBubble
{
    public CinemachineCamera cinemachineCamera;
    private float cinemachineCameraIdealsize;
    private float sizeDiff;
    public float cameraScaleSpeed = 0.05f;
    public float cameraZoomLimit = 1;
    
    // Update is called once per frame
    public void CameraAdjustSize(){
        cinemachineCameraIdealsize = gasTotal/8;
        sizeDiff = cinemachineCameraIdealsize - cinemachineCamera.Lens.OrthographicSize; 
        cinemachineCamera.Lens.OrthographicSize += sizeDiff * cameraScaleSpeed; 
        if (cinemachineCamera.Lens.OrthographicSize < 8){
            cinemachineCamera.Lens.OrthographicSize = 8;
        }
    }
    void Update()
    {
        if (oxygen > 0){
            oxygen -= Time.deltaTime * 0.4f;
        }
        UpdateBubble();

        if (oxygen < 0 || gasTotal < 10)
        {
            Debug.Log("Player died :(");
            Time.timeScale = 0;
        }
        CameraAdjustSize();
    }

    void AddGasses(float ox, float up, float down)
    {
        oxygen += ox;
        upgas += up;
        downgas += down;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collided with: " + collision.gameObject);

        if (collision.gameObject.GetComponent<GasBubble>())
        {
            GasBubble otherBubble = collision.gameObject.GetComponent<GasBubble>();
                if (!otherBubble.gracePeriod){
                    otherBubble.gracePeriod = true;
                    AddGasses(otherBubble.oxygen, otherBubble.upgas, otherBubble.downgas);
                    Destroy(otherBubble.gameObject);
                }

        }
        else if (collision.gameObject.GetComponent<SeaMine>())
        {
            Destroy(collision.gameObject);
            AddGasses(oxygen / -2, upgas / -2, downgas / -2);
        }


    }
}
