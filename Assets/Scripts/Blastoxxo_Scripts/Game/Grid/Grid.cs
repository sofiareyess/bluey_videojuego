using System.Collections.Generic;
using NUnit.Framework;
using TMPro;
using UnityEditor;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public ShapeStorage shapeStorage;
    public int columns = 0;
    public int rows = 0;
    public float squaresGap = 0.0f;
    public GameObject gridsquare;
    public Vector2 startposition = new Vector2(0.0f, 0.0f);
    public float squarescale = 0.5f;
    public float everysquareOffset = 0.0f;
    public PreguntasController preguntasControllerBlastOxxo;

    private Vector2 _offset = new Vector2(0.0f, 0.0f);
    private List<GameObject> _gridSquares = new List<GameObject>();
    private LineIndicator _lindeIndicator;
    private int rounds = 0;

      public void OnEnable()
    {
        GameEvents.CheckIfShapeCanBePlaced += CheckIfShapeCanBePlaced;
    }

    public void OnDisable()
    {
        GameEvents.CheckIfShapeCanBePlaced -= CheckIfShapeCanBePlaced;
    }

    void Start()
    {
        _lindeIndicator = GetComponent<LineIndicator>();
        CreateGrid();
        preguntasControllerBlastOxxo = FindFirstObjectByType<PreguntasController>();
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
                _gridSquares[_gridSquares.Count-1].GetComponent<GridSquare>().SquareIndex = square_index;
                _gridSquares[_gridSquares.Count-1].transform.SetParent(this.transform);
                _gridSquares[_gridSquares.Count-1].transform.localScale = new Vector3(squarescale, squarescale, squarescale);
                _gridSquares[_gridSquares.Count-1].GetComponent<GridSquare>().SetImage(_lindeIndicator.GetGridSquareIndex(square_index) % 2 == 0);
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

    private void CheckIfShapeCanBePlaced()
    {
        var squareIndexes = new List<int>();
        foreach (var square in _gridSquares)
        {
            var gridsquare = square.GetComponent<GridSquare>();
            if (gridsquare.Selected && !gridsquare.SquareOccupied)
            {
                squareIndexes.Add(gridsquare.SquareIndex);
                gridsquare.Selected = false;
                //gridsquare.ActiveSquare();
            }
        }
        var _CurrentSelectedShape = shapeStorage.GetCurrentSelectedShape();
        if (_CurrentSelectedShape == null) return; //no hay shape selected

        if (_CurrentSelectedShape.TotalSquaresNumber == squareIndexes.Count)
        {
            foreach (var SquareIndex in squareIndexes)
            {
                _gridSquares[SquareIndex].GetComponent<GridSquare>().PlaceShapeOnBoard();
            }

            var shapeLeft = 0;

            foreach (var shape in shapeStorage.shapeList)
            {
                if (shape.IsOnStartPosition() && shape.IsAnyOfShapeSquareActive())
                {
                    shapeLeft++;
                }
            }

            if (shapeLeft == 0)
            {
                rounds++;
                if (rounds == 3)
                {
                    GameEvents.ShowPanel();
                    preguntasControllerBlastOxxo.GetPreguntaActual();
                    preguntasControllerBlastOxxo.MostrarPregunta();
                    var index = PlayerPrefs.GetInt("IndexPreguntas");
                    index++;
                    PlayerPrefs.SetInt("IndexPreguntas",index);
                    rounds = 0;
                }
                GameEvents.RequestNewShapes();
            }
            else
            {
                GameEvents.SetShapeInactive();
            }

            CheckifAnyLineIsCompleted();
           
        }
        else
        {
            GameEvents.MoveShapeToStartPosition();
        }
    }

    void CheckifAnyLineIsCompleted()
    {
        List<int[]> lines = new List<int[]>();

        //columns
        foreach (var column in _lindeIndicator.columnIndexes)
        {
            lines.Add(_lindeIndicator.GetVerticalLine(column));
        }

        //row
        for (var row = 0; row< 9; row++)
        {
            List<int> data = new List<int>(9);
            for (var index = 0; index < 9; index++)
            {
                data.Add(_lindeIndicator.line_data[row,index]);
            }
            lines.Add(data.ToArray());
        }

        // squares
        for (var square = 0; square < 9; square++)
        {
            List<int> data = new List<int>(9);
            for (var index = 0; index < 9; index ++)
            {
                data.Add(_lindeIndicator.square_data[square,index]);
            }
            lines.Add(data.ToArray());
        }

        var completedlines = CheckIfSquaresAreCompleted(lines);

        if (completedlines > 2)
        {
            //animation bonus
        }

        var totalScores= 10 * completedlines;
        GameEvents.AddScores(totalScores);
        CheckIfPlayerLost();
    }

    private int CheckIfSquaresAreCompleted(List<int[]> data)
    {
        List<int[]> completedLines = new List<int[]>();

        var linesCompleted = 0;

        foreach (var line in data)
        {
            var lineCompleted = true;
            foreach (var squareIndex in line)
            {
                var comp = _gridSquares[squareIndex].GetComponent<GridSquare>();
                if(comp.SquareOccupied == false)
                {
                    lineCompleted = false;
                }
            }
            if (lineCompleted)
            {
                completedLines.Add(line);
            }
        }
        foreach (var line in completedLines)
        {
            var completed = false;
            foreach (var squareIndex in line)
            {
                var comp = _gridSquares[squareIndex].GetComponent<GridSquare>();
                comp.Deactivate();
                completed = true;
            }
            foreach (var squareIndex in line)
            {
                var comp = _gridSquares[squareIndex].GetComponent<GridSquare>();
                comp.ClearOccupied();
            }

            if(completed)
            {
                linesCompleted++;
            }
        }
        return linesCompleted;
    }

    private void CheckIfPlayerLost()
    {
        var validShapes = 0;
        for (var index = 0; index < shapeStorage.shapeList.Count; index++)
        {
            var isShapeActive = shapeStorage.shapeList[index].IsAnyOfShapeSquareActive();
            if (CheckIfShapeCanBePlacedOnGrid(shapeStorage.shapeList[index]) && isShapeActive)
            {
                shapeStorage.shapeList[index]?.ActivateShape();
                validShapes++;
            }
        }

        if (validShapes == 0)
        {
            //Game Over
            GameEvents.GameOver(true);
            //Debug.Log("GameOver");
        }
    }

    private bool CheckIfShapeCanBePlacedOnGrid(Shape currentShape)
    {
        var currentShapeData = currentShape.CurrentShapeData;
        var shapeColumns = currentShapeData.columns;
        var shapeRows = currentShapeData.rows;

        //All indexes of filled up squares
        List<int> originalShapeFilledUpSquares = new List<int>();
        var squareindex = 0;

        for (var rowIndex = 0; rowIndex < shapeRows; rowIndex++)
        {
            for (var columnIndex = 0; columnIndex < shapeColumns; columnIndex++)
            {
                if (currentShapeData.board[rowIndex].column[columnIndex])
                {
                    originalShapeFilledUpSquares.Add(squareindex);
                }
                squareindex++;
            }
        }

        if (currentShape.TotalSquaresNumber != originalShapeFilledUpSquares.Count)
        {
            Debug.LogError("Number of filled up sqaures are not the same as the original shape has");
        }

        var squareList = GetAllSquaresCombination(shapeColumns, shapeRows);

        bool canBePlaced = false;

        foreach (var number in squareList)
        {
            bool shapeCanBePlacedOnTheBoard = true;
            foreach (var squareIndexToCheck in originalShapeFilledUpSquares)
            {
                var comp = _gridSquares[number[squareIndexToCheck]].GetComponent<GridSquare>();
                if (comp.SquareOccupied)
                {
                    shapeCanBePlacedOnTheBoard = false;

                }
            }

            if (shapeCanBePlacedOnTheBoard)
            {
                canBePlaced = true;
            }
        }
        return canBePlaced;
    }

    private List<int[]> GetAllSquaresCombination(int columns, int rows)
    {
        var squareList = new List<int[]>();
        var lastColumnsIndex = 0;
        var lastRowIndex = 0;

        int safeIndex = 0;

        while (lastRowIndex + (rows -1) < 9)
        {
            var rowData = new List<int>();
            for (var row = lastRowIndex; row < lastRowIndex + rows; row++)
            {
                for (var column = lastColumnsIndex; column < lastColumnsIndex + columns; column++)
                {
                    rowData.Add(_lindeIndicator.line_data[row,column]);
                }
            }

            squareList.Add(rowData.ToArray());
            lastColumnsIndex++;

            if (lastColumnsIndex + (columns -1) >= 9)
            {
                lastRowIndex++;
                lastColumnsIndex = 0;
            }

            safeIndex++;

            if (safeIndex > 100)
            {
                break;
            }
        }
        return squareList;
    }
 
}
