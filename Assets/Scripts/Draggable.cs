using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	public void OnBeginDrag(PointerEventData eventData){

	}

	//TODO: add offset to mouse
	public void OnDrag(PointerEventData eventData){
		this.transform.position = eventData.position;
	}

	public void OnEndDrag(PointerEventData eventData){
		
	}
}
