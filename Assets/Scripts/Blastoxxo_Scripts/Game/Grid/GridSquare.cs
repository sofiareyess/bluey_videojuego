using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSquare : MonoBehaviour
{
    public Image normalImage;
    public Image hoverImage;
    public Image ActiveImage;
    public List<Sprite> normalImages;

    public bool Selected {get; set;}
    public int SquareIndex {get; set;}
    public bool SquareOccupied{get; set;}

    void Start()
    {
        Selected = false;
        SquareOccupied = false;
    }
    //temporal
    public bool CanUseThisSquare()
    {
        return hoverImage.gameObject.activeSelf;
    }

    public void PlaceShapeOnBoard()
    {
        ActivateSquare();
    }



    public void ActivateSquare()
    {
        hoverImage.gameObject.SetActive(false);
        ActiveImage.gameObject.SetActive(true);
        Selected = true;
        SquareOccupied = true;
    }

    public void SetImage(bool setFirstImage)
    {
        normalImage.GetComponent<Image>().sprite = setFirstImage? normalImages[1]: normalImages[0];
    }

     private void OnTriggerEnter2D(Collider2D collision)
     {
        if (SquareOccupied == false)
        {
            Selected = true;
            hoverImage.gameObject.SetActive(true);
        }
        else if (collision.GetComponent<ShapeSquare>() != null)
        {
            collision.GetComponent<ShapeSquare>().SetOccupied();
        }
     }

     private void OnTriggerStay(Collider collision)
     {
        Selected = true;
        if (SquareOccupied == false)
        {
            hoverImage.gameObject.SetActive(true);
        }
        else if (collision.GetComponent<ShapeSquare>() != null)
        {
            collision.GetComponent<ShapeSquare>().SetOccupied();
        }
     }

     private void OnTriggerExit2D(Collider2D collision)
     {
        if (SquareOccupied == false)
        {
            Selected = false;
            hoverImage.gameObject.SetActive(false);
        }
        else if (collision.GetComponent<ShapeSquare>()!= null)
        {
            collision.GetComponent<ShapeSquare>().UnsetOccupied();
        }
     }

}
