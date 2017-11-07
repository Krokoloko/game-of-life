using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOfLife : MonoBehaviour {

    public GameObject source;
    private CreateObjects script;
    private bool[,] toDie;
    private bool[,] toLive;
    private int neighboursAlive;
    private GameObject[,] cubes;
    public bool running;
    enum progress {check,removal,add,end};
    private progress state = progress.check;


    void Start() {
        script = source.GetComponent<CreateObjects>();
        toDie = new bool[script.widthAmount, script.heightAmount];
        toLive = new bool[script.widthAmount, script.heightAmount];
        cubes = script.cubes;
        neighboursAlive = 0;
    }
	
	void Update () {
        if (running)
        {
            
            for (int i = 0; i < script.widthAmount; i++)
            {
                for (int y = 0; y < script.heightAmount; y++)
                {
                    if (cubes[i, y].GetComponent<changeColor>().IsAlive())
                    {
                        neighboursAlive = CheckNeighboursAlive(i, y);                      
                    }
                    else
                    {

                        toDie[i, y] = false;
                    }                    
                }
            }
        }
    }



    int CheckNeighboursAlive(int posx,int posy)
    {
        int res = 0;
        //beneath the cell.
        if (BeyondUnder(posy - 1,0))
        {            
            if (cubes[posx, posy - 1].GetComponent<changeColor>().IsAlive())
            {
                res++;
            }
            if (BeyondUnder(posx - 1,0))
            {
                if(cubes[posx - 1, posy - 1].GetComponent<changeColor>().IsAlive())
                {
                    res++;
                }
            }
            if(BeyondOver(posx + 1, script.widthAmount))
            {
                if (cubes[posx + 1, posy - 1].GetComponent<changeColor>().IsAlive())
                {
                    res++;
                }
            }            
        }
        //The middle from left and right
        if (BeyondUnder(posx - 1,0))
        {
            if (cubes[posx - 1, posy].GetComponent<changeColor>().IsAlive())
            {
                res++;
            }
        }
        if (BeyondOver(posx + 1,script.widthAmount))
        {
            if (cubes[posx + 1, posy].GetComponent<changeColor>().IsAlive())
            {
                res++;
            }
        }
        //Above the cells
        if (BeyondOver(posy + 1,script.heightAmount))
        {
            if (cubes[posx, posy + 1].GetComponent<changeColor>().IsAlive())
            {
                res++;
            }
            if (BeyondUnder(posx - 1, 0))
            {
                if (cubes[posx - 1, posy + 1].GetComponent<changeColor>().IsAlive())
                {
                    res++;
                }
            }
            if (BeyondOver(posx + 1, script.widthAmount))
            {
                if (cubes[posx + 1, posy + 1].GetComponent<changeColor>().IsAlive())
                {
                    res++;
                }
            }
        }

        return res;
    }

    bool BeyondUnder(int i, int limit)
    {
        ///<summary>
        ///Returns true if under zero else false
        ///</summary>
        bool bol;

        if (!(i < limit))
        {
            bol = true;
        }
        else
        {
            bol = false;
        }

        return bol;
    }
   
    bool BeyondOver(int i,int limit)
    {
        ///<summary>
        ///Returns false if it overextends from the given value else true.
        /// </summary>
        bool bol;

        if (!(i > limit))
        {
            bol = false;
        }
        else
        {
            bol = true;
        }

        return bol;
    }
}
