using UnityEngine;

public class PointClickScript : MonoBehaviour
{
	private Renderer _renderer;

	GameObject gameObject;

	private void Start()
	{
		_renderer = GetComponent<Renderer>();
		gameObject = GameObject.Find("Door");
	}

	private void OnMouseDown()
	{
		Debug.Log("Clicked!");
		DestroyObject();
	}

	void DestroyObject()
	{
		Destroy(gameObject);
	}
}

