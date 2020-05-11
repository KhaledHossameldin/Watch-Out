using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealtBarHandler : MonoBehaviour
{
	[SerializeField] Gradient gradient;
	[SerializeField] Image fill;
    Slider slider;

	private void Start()
	{
		slider = GetComponent<Slider>();
		fill.color = gradient.Evaluate(1);
	}

	public void SetHealth(int health)
	{
		slider.value = health;
		fill.color = gradient.Evaluate(slider.normalizedValue);
	}
}
