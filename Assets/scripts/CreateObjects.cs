using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObjects : MonoBehaviour {

   
    public GameObject cube;
    public int widthAmount;
    public int heightAmount;
    public GameObject[,] cubes;
    private changeColor[,] info;
    private float offSetx = 0;
    private float offSety = 0;
    private float size = 0.5f;

    void Start () {
        cubes = new GameObject[widthAmount, heightAmount];
        info = new changeColor[widthAmount, heightAmount];
        for(int i = 0; i < widthAmount; i++)
        {
            offSety = 0;
            for(int y = 0; y < heightAmount; y++)
            {
                cubes[i,y] = Instantiate(cube, new Vector3((this.gameObject.transform.position.x + (i * size) + offSetx), (this.gameObject.transform.position.y + (y * size) + offSety)),Quaternion.identity);
                cubes[i, y].transform.localScale = new Vector3(size,size,1);
                info[i, y] = cubes[i, y].GetComponent<changeColor>();
                offSety += size/10;
            }
            offSetx+= size/10;
        }
        offSetx = 0;
    }
    void Update()
    {
          
    }
    public GameObject[,] getCubesInfo()
    {
        return cubes;
    }
}
