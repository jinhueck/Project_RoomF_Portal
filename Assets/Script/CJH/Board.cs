using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour {

    public Vector3 point1;
    public Vector3 point2;
    //public Vector3 point3;
    public GameObject board;
    private float speed = 3f;

    //라인
    LineRenderer lr;
    Vector3 cube1Pos, cube2Pos;

    private void Start()
    {
        lr = GameObject.Find("Bridge").GetComponent<LineRenderer>();
        //lr.startWidth = .05f;
        //lr.endWidth = .05f;
        cube1Pos = GameObject.Find("Bridge").transform.GetChild(0).GetComponent<Transform>().position;
        cube2Pos = GameObject.Find("Bridge").transform.GetChild(1).GetComponent<Transform>().position;
        lr.SetPosition(0, cube1Pos);
        lr.SetPosition(1, cube2Pos);

        board.transform.position = GameObject.Find("Bridge").transform.GetChild(0).position;
        MoveBridge();
    }

    public void MoveBridge()
    {
        GameObject oldLine = gameObject;
        LineRenderer oldLineComponent = GameObject.Find("Bridge").GetComponent<LineRenderer>();
        point1 = new Vector3(oldLineComponent.GetPosition(0).x, -0.5f, oldLineComponent.GetPosition(0).z);
        point2 = new Vector3(oldLineComponent.GetPosition(1).x, -0.5f, oldLineComponent.GetPosition(1).z);
        //point3 = new Vector3(oldLineComponent.GetPosition(2).x, 1.83f, oldLineComponent.GetPosition(2).z);
        StartCoroutine("MoveBoard");
    }

    IEnumerator MoveBoard()
    {
        while(board.transform.position != point2)
        {
            Vector3 CurrPosition = board.transform.position;
            float step = speed * Time.deltaTime;
            board.transform.position = Vector3.MoveTowards(CurrPosition, point2, step);
            yield return null;
        }
        /*
        while(board.transform.position != point3)
        {
            Vector3 CurrPosition = board.transform.position;
            float step = speed * Time.deltaTime;
            board.transform.position = Vector3.MoveTowards(CurrPosition, point3, step);
            yield return null;
        }
        */
        yield return new WaitForSeconds(1f);
        /*
        while (board.transform.position != point2)
        {
            Vector3 CurrPosition = board.transform.position;
            float step = speed * Time.deltaTime;
            board.transform.position = Vector3.MoveTowards(CurrPosition, point2, step);
            yield return null;
        }
        */
        while (board.transform.position != point1)
        {
            Vector3 CurrPosition = board.transform.position;
            float step = speed * Time.deltaTime;
            board.transform.position = Vector3.MoveTowards(CurrPosition, point1, step);
            yield return null;
        }
        yield return new WaitForSeconds(1f);
        StopCoroutine("MoveBoard");
        StartCoroutine("MoveBoard");
    }
}
