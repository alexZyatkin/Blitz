using System;
using System.Collections.Generic;
using Cells;
using JetBrains.Annotations;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Grid
{
    public class GridBehavior : MonoBehaviour
    {
        [SerializeField] private Transform gridParent;
        [SerializeField] private GridPosibilityPlacement gridPlacementContol;
        [SerializeField] private GridClearControl gridClearControl;
        private PlayingField _grid;
        public CellBehavior[,] cells;
        
        private void Awake()
        {
            _grid = new PlayingField(gridParent, 5, 5);
            cells = _grid.GetCells();
            SetAllNeighbour(cells);
            gridPlacementContol.SetCellBehavior(cells);
            gridClearControl.SetCellBehavior(cells);
        }

        public void SetAllNeighbour(CellBehavior[,] cellList)
        {
            for (int x = 0; x < cellList.GetLength(0); x++)
            {
                for (int y = 0; y < cellList.GetLength(1); y++)
                {
                    AddNeighboursIfNotNull(cellList[x,y].Neighbours, cellList, x, y);
                }
            }
        }
        private CellBehavior GetNeighbours(CellBehavior[,] cellList, int i, int j)
        {
            CellBehavior neighbour;

            if (i < 0 || i >= cellList.GetLength(0) || j < 0 || j >= cellList.GetLength(1))
                return null;           
            
            neighbour = cellList[i, j];

            return neighbour;
        }
        private void AddNeighboursIfNotNull(List<CellBehavior> listNeighbour, CellBehavior[,] cellList, int i, int j)
        {
            var neighbour1 = GetNeighbours(cellList, i, j + 1);
            var neighbour2 = GetNeighbours(cellList, i + 1, j);
            var neighbour3 = GetNeighbours(cellList, i, j - 1);
            var neighbour4 = GetNeighbours(cellList, i - 1, j);
            
            if(neighbour1 != null)
                listNeighbour.Add(neighbour1);
            if(neighbour2 != null)
                listNeighbour.Add(neighbour2);
            if(neighbour3 != null)
                listNeighbour.Add(neighbour3);
            if(neighbour4 != null)
                listNeighbour.Add(neighbour4);
        }
    }
}