using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using ScriptableObjectArchitecture;
using System.Linq;
public class DiceManager : MonoBehaviour
{
    [Title("Config")]
    public GameObject FarkleObject;
    public IntReference score;
    public BoolReference farkle;
    public List<Die> hand;
    List<Die> rolled = new List<Die>();
    [Button("Init Dice From Children")]
    public void GetDiceFromChildren(){
        hand.Clear();
        foreach(Transform c in transform){
            if(c.GetComponent<Die>()){
                hand.Add(c.GetComponent<Die>());
            }
        }
    }
    void Start(){
        ResetHand();
        Roll();
    }
    [Button("Roll")]
    public void Roll(){
        
        rolled.Clear();
        foreach(Die d in hand){
            if(!d.held){
                d.RollInstant();
                rolled.Add(d);
            }
        }
        score.Value = TallyScore();
        //holdable has been reset.
        bool farkled = true;
        foreach(Die d in rolled){
            if(d.holdable == true){
                farkled = false;
            }
        }

        if(farkled){
            FarkleObject.SetActive(true);
            farkle.Value = true;
            score.Value = 0;
        }

    }
    [Button("Reset Hand")]
    public void ResetHand(){
        FarkleObject.SetActive(false);
        farkle.Value = false;
        score.Value = 0;
        foreach(Die d in hand){
            d.held = false;
            d.holdable = false;
        }
    }
    void SetHoldableAllNonHeld(bool holdable){
        foreach(Die d in hand){
            if(!d.held){
                d.holdable = holdable;
            }
        }
    }
    void SetHoldableAllOfValue(int val,bool holdable){
        foreach(Die d in hand){
            if(d.value == val){
                d.holdable = holdable;
            }
        }
    }
    public int[] ValuesFromHand(){
        int[] vs = new int[hand.Count];
        for(int i = 0;i<hand.Count;i++){
            vs[i] = hand[i].value;
        }
        return vs;
    }

    public int TallyScore(){//uses set value for 4,5,and 6 of a kinds.
        SetHoldableAllNonHeld(false);//assume none are scoring.
    ///TODO
    /// //A full house (three of a kind and a pair) is scored as the three of a kind value plus 250. e.g. 3-3-3-2-2 = 550, 4-4-4-3-3 = 650, 5-5-5-1-1 = 750, 1-1-1-3-3 = 1250
    //

        int points = 0;
        int[] vs = ValuesFromHand();
        int[] totals = new int[]{0,0,0,0,0,0,0};//index 0 is always 0 because, we will always have 0 dice with the value "0". fucken arrays.
        foreach(int v in vs){
            totals[v]++;
        }
        //Totals is an array that counts the number of values. 
        
        int pairs = 0;
        int solos = 0;
        for(int i = 0;i < totals.Length;i++){
            //6,5, and 4 of a kinds, of which we can ever only have one of. 
            if(totals[i] == 6){
                points = 6000;
                SetHoldableAllOfValue(i,true);
                return points;
            }else if(totals[i] == 5){
                points = 4000;
                if(i != 5){
                    SetHoldableAllOfValue(5,true);
                    points = points + totals[5]*50;//each 5 is worth 50.
                }
                if(i != 1){
                    SetHoldableAllOfValue(1,true);
                    points = points + totals[1]*100;//each 1 is worth 100.
                }
                SetHoldableAllOfValue(i,true);
                return points;
            }else if(totals[i] == 4){
                points = 2000;
                if(i != 5){
                    SetHoldableAllOfValue(1,true);
                    points = points + totals[5]*50;//each 5 is worth 50.
                }
                if(i != 1){
                    SetHoldableAllOfValue(1,true);
                    points = points + totals[1]*100;//each 1 is worth 100.
                }
                SetHoldableAllOfValue(i,true);
                return points;
            }else if(totals[i] == 3){
                if(i == 1){
                    points = points + 300;//3 1's is 300.
                }else{
                    points = points+(i*100);//3 x's is x*100.
                }
                SetHoldableAllOfValue(i,true);
            }else if(totals[i] == 2){
                pairs++;
            }else if(totals[i] == 1){
                solos++;
            }
        }
        if(pairs == 3){//3 pairs is 1000.
            SetHoldableAllNonHeld(true);//all dice are scoring
            points = 1000;
            return points;
        }
        if(solos == 6){//one of each dice is a straight
            SetHoldableAllNonHeld(true);//all dice are scoring
            points = 2500;
            return points;
        }
        //

        if(totals[1]<3){
            SetHoldableAllOfValue(1,true);
            points = points+totals[1]*100;
        }
        if(totals[5]<3){
            SetHoldableAllOfValue(5,true);
            points = points+totals[5]*50;
        }
     

       return points;
    }

}
