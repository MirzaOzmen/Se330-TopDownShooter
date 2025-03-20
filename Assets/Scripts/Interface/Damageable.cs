using UnityEngine;

public interface Damageble 
{
    TeamEnum Team { get; }
    void ChangeHealthOfTheCharacter(GameObject character, int amount);
}
