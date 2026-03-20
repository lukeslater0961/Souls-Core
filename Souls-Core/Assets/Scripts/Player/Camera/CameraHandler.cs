using UnityEngine;

public class CameraHandler : MonoBehaviour
{
#region References
	private InputHandler	_input;
#endregion

#region Values
	private Camera		_camera;
	public  Transform	_transform;
#endregion

    void Start()
    {
		_camera = Camera.main;
        _input = GetComponentInParent<InputHandler>();
    }

    void LateUpdate()
    {
		_transform = _camera.transform;
        if (_input.lookDirection.sqrMagnitude <= 0)
			return;
		
		this.transform.Rotate(Vector3.up, _input.lookDirection.x * 100f * Time.deltaTime);
		//apply camera rotation y axis
    }
}
