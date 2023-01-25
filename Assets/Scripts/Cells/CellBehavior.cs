using System;
using System.Collections.Generic;
using UnityEngine;

namespace Cells
{
    public class CellBehavior : MonoBehaviour
    {
        public List<CellBehavior> Neighbours;
        public int x;
        public int y;
        [SerializeField] private List<CellColor> _cellColorList;
        [SerializeField] private List<CellFigure> _cellFigureList;
        [SerializeField] private CellType _cellType;
        [SerializeField] private bool _isPosibleToPlace;
        public CellType Type
        {
            get => _cellType;
            set => _cellType = value;
        }
        public bool IsPosibleToPlace
        {
            get => _isPosibleToPlace;
            set => _isPosibleToPlace = value;
        }

        private void Awake()
        {
            IsPosibleToPlace = true;
        }

        public List<CellColor> CellColorList => _cellColorList;
        public List<CellFigure> CellFigureList => _cellFigureList;

        public void SetAroundCellValue(CellColor color, CellFigure type)
        {
            foreach (CellBehavior cell in Neighbours)
            {
                cell.SetCellValue(color, type);
            }
        }

        public void SetCellValue(CellColor color, CellFigure figure)
        {
            if (Type == CellType.Filled)
            {
                return;
            }

            _cellColorList.Add(color);
            _cellFigureList.Add(figure);
        }

        public void FillCellType()
        {
            Type = CellType.Filled;
        }

        public void ClearCellColorAndFigure()
        {
            _cellColorList.Clear();
            _cellFigureList.Clear();
        }
    }
}