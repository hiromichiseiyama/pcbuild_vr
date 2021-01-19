using UnityEngine;
using System.Collections;

public class ActiveStateToggler : MonoBehaviour {

	public void ToggleActive () {
		gameObject.SetActive (!gameObject.activeSelf);
	}

    public void ToggleActive(GameObject obj)
    {
        obj.gameObject.SetActive(!gameObject.activeSelf);
    }

    public void Deactivate(GameObject deactivate)
    {
        deactivate.gameObject.SetActive(false);
    }
}
