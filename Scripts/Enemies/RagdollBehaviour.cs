using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollBehaviour : MonoBehaviour
{
	public float fadeSpeed;

    public IEnumerator FadeOut() {
    	Renderer myRenderer = this.GetComponentInChildren<Renderer>();
    	Color objectColor = myRenderer.material.color;

    	//sets the render mode to fade so it allows transparency
    	myRenderer.material.SetFloat("_Mode", 2f);
    	myRenderer.material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        myRenderer.material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        myRenderer.material.SetInt("_ZWrite", 0);
        myRenderer.material.DisableKeyword("_ALPHATEST_ON");
        myRenderer.material.EnableKeyword("_ALPHABLEND_ON");
        myRenderer.material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        myRenderer.material.renderQueue = 3000;
        //thank god for forum code

    	while (objectColor.a > 0) {
    		//update objectColor
			objectColor = myRenderer.material.color;
			//create a new alpha by subtracting fadeSpeed from the last alpha
	    	float newAlpha = objectColor.a - (fadeSpeed * Time.deltaTime);
	    	//apply the new color
	    	myRenderer.material.color = new Color(objectColor.r, objectColor.g, objectColor.b, newAlpha);
	    	yield return new WaitForSeconds(0.1f);
    	}

    	Destroy(gameObject);
    }
}
