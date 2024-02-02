using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISeasonListener 
{
    public void SeasonChangeAction(SeasonType seasonType);
}
