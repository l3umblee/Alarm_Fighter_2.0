using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager
{
    private Player currentPlayer;
    public void SetPlayer(Player player) { this.currentPlayer = player; }
    public Transform GetCurrentTransform() { return currentPlayer.transform; }
    public float GetCurrentPositionX() { return currentPlayer.transform.position.x; }
    public float GetCurrentPositionY() {  return currentPlayer.transform.position.y;}
    public int GetCurrentIndX() { return currentPlayer.GetPlayerCurrentIndX(); }
    public int GetCurrentIndY() {  return currentPlayer.GetPlayerCurrentIndY(); }
}
