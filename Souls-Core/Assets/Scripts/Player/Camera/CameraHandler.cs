using UnityEngine;

public class CameraHandler : MonoBehaviour
{
#region References
	private InputHandler input;
#endregion

#region Values
	private Camera		_camera;
	private Transform	_transform;
#endregion

    void Start()
    {
		_camera = Camera.main;
        input = GetComponentInParent<InputHandler>();
    }

    void LateUpdate()
    {
		_transform = _camera.transform;
        if (input.lookDirection.sqrMagnitude <= 0)
			return;
		//apply camera rotation
    }
}
