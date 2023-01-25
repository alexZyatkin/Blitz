using System;
using EventWork;
using Grid;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.WSA;

[RequireComponent(typeof(Image))]
public class TileMove : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private TileProperties _tileProperties;
    private RectTransform _tileRect;
    private TileGame _tileGame;
    private void Awake()
    {
        _tileRect = GetComponent<RectTransform>();
        _tileGame = GetComponent<TileGame>();
        _tileProperties = GetComponent<TileProperties>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _tileRect.gameObject.transform.SetAsLastSibling();
        SetDraggedPosition(eventData);
        //method from event
        GameEventSystem.SendTileMove(_tileProperties);
    }

    public void OnDrag(PointerEventData data)
    {
        if (_tileRect != null)
            SetDraggedPosition(data);
        
        _tileGame.CheckCell(data);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        bool setTile = _tileGame.SetTileToCell();
        if (setTile)
        {
            enabled = false;
            GameEventSystem.SendEmptySpawnPoint();
            GameEventSystem.SendCheckSpawn();
        }
        
        GameEventSystem.SendTileEndMove();
    }

    private void SetDraggedPosition(PointerEventData data)
    {
        _tileRect.position = data.position;
    }
}