using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PlayerBubble : GasBubble
{
    public CinemachineCamera cinemachineCamera;
    private float cinemachineCameraIdealsize;
    private float sizeDiff;
    public float cameraScaleSpeed = 0.05f;
    public float cameraZoomLimit = 1;

    [SerializeField] Volume postProcessingVolume;
    Vignette vignette;

    void Start()
    {
        UpdateBubble();

        if (postProcessingVolume != null)
        {
            if (postProcessingVolume.profile.TryGet<Vignette>(out Vignette foundVignette))
            {
                vignette = foundVignette;
            }
        }

    }

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

        if (postProcessingVolume != null)
        {
            if (oxygen < 10)
            {
                float intensity = Mathf.Lerp(0.2f, 1, (10 - oxygen) / 10);
                vignette.intensity.Override(intensity);
            }
            else
            {
                vignette.intensity.Override(0.2f);
            }
        }

        UpdateBubble();

        if (oxygen < 0 || gasTotal < 10)
        {
            Debug.Log("Player died :(");
            //Time.timeScale = 0;
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
