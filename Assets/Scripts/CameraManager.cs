using UnityEngine;

public class CameraManager : ErshenMonoBehaviour
{
    [SerializeField] protected SpriteRenderer backGround;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadBackGround();
    }

    protected virtual void LoadBackGround()
    {
        if (backGround != null) return;
        backGround = GameObject.Find("Back Ground").GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        ProcessCamera();
    }

    protected virtual void ProcessCamera()
    {
        float widthBG = backGround.bounds.size.x;
        float heightCamera = Camera.main.orthographicSize * 2f;
        float widthCamera = heightCamera * Screen.width / Screen.height;

        Vector3 posCamera = transform.position;
        posCamera.x = (widthCamera - widthBG) / 2;
        transform.position = posCamera;
    }
}
