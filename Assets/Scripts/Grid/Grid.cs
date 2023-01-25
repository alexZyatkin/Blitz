using CodeMonkey.Utils;
using UnityEngine;

namespace Grid
{
    public class Grid
    {
        private readonly int _width;
        private readonly int _height;
        private readonly float _cellSize;
        private int[,] _gridArray;
        private TextMesh[,] _debugTextArray;

        public Grid(int width, int height, float cellSize)
        {
            _width = width;
            _height = height;
            _cellSize = cellSize;

            _gridArray = new int[_width, _height];
            _debugTextArray = new TextMesh[_width, height];

            for (int x = 0; x < _gridArray.GetLength(0); x++)
            {
                for (int y = 0; y < _gridArray.GetLength(1); y++)
                {
                    _debugTextArray[x,y] = UtilsClass.CreateWorldText(_gridArray[x, y].ToString(), null,
                        GetWorldPosition(x, y, _cellSize), 20, Color.white, TextAnchor.MiddleCenter);
                    Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.white, 100f);
                    Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.white, 100f);
                }
            }
            Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);
            Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100f);

        }

        private Vector3 GetWorldPosition(int x, int y, float cellSize)
        {
            return new Vector3(x, y) * cellSize + new Vector3(cellSize, cellSize) * .5f;
        }
        private Vector3 GetWorldPosition(int x, int y)
        {
            return new Vector3(x, y) * _cellSize;
        }

        private void GetXYFromPosition(Vector3 worldPosition, out int x, out int y)
        {
            x = Mathf.FloorToInt(worldPosition.x / _cellSize);
            y = Mathf.FloorToInt(worldPosition.y / _cellSize);
        }

        public void SetValue(int x, int y, int value)
        {
            if (x >= 0 && y >= 0 && x < _width && y < _height)
            {
                _gridArray[x, y] = value;
                _debugTextArray[x, y].text = _gridArray[x, y].ToString();
            }
        }

        public void SetValue(Vector3 worldPosition, int value)
        {
            int x, y;
            GetXYFromPosition(worldPosition, out x, out y);
            SetValue(x, y, value);
        }

        public int GetValue(int x, int y)
        {
            if (x >= 0 && y >= 0 && x < _width && y < _height)
                return _gridArray[x, y];
            else
                return 0;
        }

        public int GetValue(Vector3 worldPosition)
        {
            int x, y;
            GetXYFromPosition(worldPosition, out x, out y);
            return GetValue(x, y);
        }
    }
}