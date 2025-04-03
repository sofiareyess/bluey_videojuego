using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public int columns = 0;
    public int rows = 0;
    public float squaresGap = 0.1f;
    public GameObject gridsquare;
    public Vector2 startposition = new Vector2(0.0f, 0.0f);
    public float squarescale = 0.5f;
    public float everysquareOffset = 0.0f;

    private Vector2 _offset = new Vector2(0.0f, 0.0f);
    private List<GameObject> _gridSquares = new List<GameObject>();
    void Start()
    {
        CreateGrid();
    }

    private void CreateGrid()
    {
        SpawnGridSquares();
        SetGridSquaresPositions();
    }


    private void SpawnGridSquares()
    {
        //0, 1, 2, 3, 4,
        // 5, 6, 7, 8, 9

        int square_index = 0;

        for(var row = 0; row < rows; ++row)
        {
            for (var column = 0;column < columns; ++column)
            {
                _gridSquares.Add(Instantiate(gridsquare)as GameObject);
                _gridSquares[_gridSquares.Count-1].transform.SetParent(this.transform);
                _gridSquares[_gridSquares.Count-1].transform.localScale = new Vector3(squarescale, squarescale, squarescale);
                _gridSquares[_gridSquares.Count-1].GetComponent<GridSquare>().SetImage(square_index % 2 == 0);
                square_index++;
            }
        }
    }

    private void SetGridSquaresPositions()
    {
        int colum_number = 0;
        int row_number = 0;
        Vector2 square_gap_number = new Vector2(0.0f, 0.0f);
        bool row_moved = false;

        var square_rect = _gridSquares[0].GetComponent<RectTransform>();

        _offset.x = square_rect.rect.width * square_rect.transform.localScale.x + everysquareOffset;
        _offset.y = square_rect.rect.height * square_rect.transform.localScale.y + everysquareOffset;

        foreach (GameObject square in _gridSquares)
        {
            if (colum_number + 1 > columns)
            {
                square_gap_number.x = 0;
                //go to next column
                colum_number = 0;
                row_number++;
                row_moved = false;
            }
            var position_x_offset = _offset.x * colum_number + (square_gap_number.x * squaresGap);
            var position_y_offset = _offset.y * row_number + (square_gap_number.y * squaresGap);

            if (colum_number > 0 && colum_number %3 == 0)
            {
                square_gap_number.x++;
                position_x_offset += squaresGap;
            }

            if (row_number > 0 && row_number % 3 == 0 && row_moved == false)
            {
                row_moved = true;
                square_gap_number.y++;
                position_y_offset += squaresGap;
            }

            square.GetComponent<RectTransform>().anchoredPosition = new Vector2(startposition.x + position_x_offset, 
            startposition.y - position_y_offset);

            square.GetComponent<RectTransform>().localPosition = new Vector3 (startposition.x + position_x_offset, 
            startposition.y - position_y_offset, 0.0f);

            colum_number++;
        }
    }
 
}
