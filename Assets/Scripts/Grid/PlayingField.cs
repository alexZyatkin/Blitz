using Cells;
using TMPro;
using UnityEngine;

namespace Grid
{
    public class PlayingField
    {
        private const string CellPath = "Cell";
        private readonly int _row;
        private readonly int _column;
        private int[,] _gridArray;
        private CellBehavior[,] _cellBehaviors;

        public PlayingField(Transform parent, int row, int column)
        {
            _row = row;
            _column = column;

            _gridArray = new int[row, column];
            _cellBehaviors = new CellBehavior[row, column];

            for (int x = 0; x < _gridArray.GetLength(0); x++)
            {
                for (int y = 0; y < _gridArray.GetLength(1); y++)
                {
                    var cell = Instantiate(CellPath, parent);
                    SetText(cell, x, y);
                    _cellBehaviors[x, y] = cell.GetComponent<CellBehavior>();
                    _cellBehaviors[x, y].x = x;
                    _cellBehaviors[x, y].y = y;
                }
            }
        }
        
        public GameObject Instantiate(string path, Vector3 at)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab, at, Quaternion.identity);
        }
        public GameObject Instantiate(string path, Transform parent)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab, parent);
        }

        public CellBehavior[,] GetCells()
        {
            return _cellBehaviors;
        }

        private void SetText(GameObject cellInfo, int x, int y)
        {
            string info = x.ToString() + " ; " + y.ToString();
            //cellInfo.GetComponentInChildren<TMP_Text >().text = info;
        }
    }
    
    
}