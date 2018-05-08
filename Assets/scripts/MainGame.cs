using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGame : MonoBehaviour {
    
    private int TottleAcount = 50;
    public GameObject Wall;
    private List<Vector3> posList;
    private bool same;
	public GameObject Stone;
	//public Transform[] StonePos;
    private void Awake()
    {
        Time.timeScale = 1;
        posList = new List<Vector3>();
        same = false;
		Stone = GameObject.Find ("Map");
    }
    void Start()
    {
        CreateWallOnGameStart(Wall);
    }

    public void CreateWallOnGameStart(GameObject wall)
    {
        for(int i = 0; i< TottleAcount; i++)
        {
            int x = Random.Range(-12, 13);
            int y = Random.Range(-8, 9);
            Vector3 pos = new Vector3(x, y, 0);
            
            if (posList != null)
            {
				foreach (Vector3 p in posList)
				{
					if (p != pos) 
					{
						foreach (Vector3 f in FindStonePosOnGameStart()) 
						{
							if (f == pos)
							{
								same = true;
								break;
							}
							same = false;
						}
					
					}
					if (p == pos) 
					{
						same = true;
						break;
					}
				}
            }
            else if (posList == null)
            {
                foreach (Vector3 f in FindStonePosOnGameStart())
                {
                    if (f != pos)
                    {
                        posList.Add(pos);
                        Instantiate(wall, pos, Quaternion.identity);
                        break;
                    }
                    same = true;
                }
            }
            if (!same && posList != null)
            {
                posList.Add(pos);
                Instantiate(wall, pos, Quaternion.identity);
            }
            if (same)
            {
                i--;
            }

        }
    }
	public List <Vector3 > FindStonePosOnGameStart()
	{
        Transform[] StonePos;
		List <Vector3 > SPos = new List<Vector3> ();
        StonePos = Stone.GetComponentsInChildren <Transform > ();
		foreach (Transform t in StonePos) 
		{
			SPos.Add (t.position);
		}

		return SPos;
	}
}
