using System;
using System.Collections.Generic;
using Cells;
using DG.Tweening;
using Grid;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Tools;

public class TileGame : MonoBehaviour
{
    [SerializeField] private TileProperties _tileProperties;
    private Vector3 _positionOnGrid;
    private Vector3 _startPosition;
    [SerializeField] private Vector3 _touchPos;
    [SerializeField] private LayerMask _targetLayer;
    [SerializeField] private CellBehavior _selectedCell;

    private void Awake()
    {
        _startPosition = transform.position;
        _tileProperties = GetComponent<TileProperties>();
    }

    public void CheckCell(PointerEventData eventData)
    {
        _touchPos = eventData.position;
        _touchPos = new Vector3(_touchPos.x, _touchPos.y, _touchPos.z - 10f);
        
        RaycastHit hit;
        
        if (Physics.Raycast(_touchPos, Vector3.forward * 100f, out hit, _targetLayer))
        {
            _selectedCell = hit.transform.GetComponent<CellBehavior>();
            if (_selectedCell != null && _selectedCell.Type == CellType.Empty)
            { 
                _positionOnGrid = _selectedCell.transform.position;
            }
        }
        else
        {
            _selectedCell = null;
        }
    }

    public bool SetTileToCell()
    {
        if (_selectedCell != null && _selectedCell.Type == CellType.Empty && _selectedCell.IsPosibleToPlace)
        {
            transform.SetParent(_selectedCell.transform);
            transform.position = _positionOnGrid;
            _selectedCell.SetCellValue(_tileProperties.TileColor, _tileProperties.TileFigure);
            _selectedCell.SetAroundCellValue(_tileProperties.TileColor, _tileProperties.TileFigure);
            _selectedCell.FillCellType();
            FindObjectOfType<GridClearControl>().ClearRowOrColumn(_selectedCell.x, _selectedCell.y);
            return true;
        }
        else
        {
            transform.DOMove(_startPosition, .61f).SetEase(Ease.Linear);
            return false;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(_touchPos, Vector3.forward * 200f);
        Gizmos.color = Color.green;
    }
    
    
}