using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class DebugRender : MonoBehaviour {

	public static bool Render = false;
	
	public void Update()
	{
		if (renderer.enabled != DebugRender.Render)
		{
			renderer.enabled = DebugRender.Render;
		}
	}
}
