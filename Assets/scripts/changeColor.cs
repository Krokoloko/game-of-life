using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeColor : MonoBehaviour {

    public Material[] colorsMat = new Material[6];
    public MeshRenderer mesh;
    enum colors {white, black, yellow, red, green, blue};
    private colors colorState;
    private int num = 0;
	// Use this for initialization
	void Start () {
        mesh = gameObject.GetComponent<MeshRenderer>();
	}

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            nextColor();
        }
    }

    void nextColor()
    {
        num++;
        print(num);
        if (num > 1)
        {
            num = 0;
        }
        colorState = (colors)num;
        switch (colorState)
        {
            case colors.white:
                mesh.material = colorsMat[num];
                break;
            case colors.black:
                mesh.material = colorsMat[num];
                break;
        }
    }
    public void SetDead()
    {
        mesh.material = colorsMat[0];
        colorState = colors.white;
    }
    public void SetAlive()
    {
        mesh.material = colorsMat[1];
        colorState = colors.black;
    }
    public bool IsAlive()
    {
        bool life;

        if(colorState == colors.black)
        {
            life = true;
        } else
        {
            life = false;
        }

        return life;
    }
}
