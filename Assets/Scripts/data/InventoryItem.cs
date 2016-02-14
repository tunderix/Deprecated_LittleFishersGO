using UnityEngine;
using System.Collections;

public class InventoryItem {

	public Sprite iItemIcon;
	public Item item;
	public string tooltipText;

	public InventoryItem(Sprite icon, Item iItem, string ttt)
	{
		this.iItemIcon = icon;
		this.item = iItem;
		this.tooltipText = ttt;
	}
}
