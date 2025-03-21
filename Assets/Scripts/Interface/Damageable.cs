using UnityEngine;

public interface Damageble 
{
    TeamEnum Team { get; }
    void ChangeHealthOfTheCharacter(int amount);
}
