using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;
using Sirenix.OdinInspector;
using UnityEngine.UI;
public class Die : MonoBehaviour
{
    [Title("Config")]
    public SpriteCollection spriteFaces;
    [ReadOnly]
    [Range(0,20)]
    public int sides = 6;
    //
    public bool held = false;
    
    public bool holdable = true;
    public int value {get{return currentFaceIndex+1;}}
    [TitleGroup("Debugging")]
    
    //References
    int currentFaceIndex;//0-5
    Image image;

    void Awake()
    {
        image = GetComponent<Image>();
    }
    void Start(){
        RollInstant();
    }
    //Color of the dice
    void Update(){
        if(held){
            image.color = Color.blue;
        }else if(holdable){
            image.color = Color.red;
        }else{
            image.color = Color.black;
        }
        
    }
    public void Selected(){
        if(holdable){
            held = !held;
        }
    }
    public void RollInstant(){
        if(image == null){//Debugging
            image = GetComponent<Image>();
        }
        //
        currentFaceIndex = (int)Random.Range((int)0,(int)sides);//Random.Range is exclusive max, when given integers. So it will never give 6 (but will give 0. ie: 0-5).
        SetFace();
    }
    [TitleGroup("Debugging")]
    [Button("Roll")]
    public void Roll(){
        ///Don't roll if we are held.
        if(held){
            return;
        }

        if(image == null){//Debugging
            image = GetComponent<Image>();
        }
        StartCoroutine(RollingAnimation(Random.Range(7,9),0.1f));
    }
    IEnumerator RollingAnimation(float rolls,float speed){
        for(int i = 0;i<rolls;i++){
            image.sprite = spriteFaces[(int)Random.Range((int)0,(int)sides)];
            yield return new WaitForSeconds(speed);
        }
        RollInstant();
    }
    void SetFace()
    {
        SetFace(currentFaceIndex);
    }
    void SetFace(int index){
        image.sprite = spriteFaces[index];
    }
    void SetFaceByValue(int value){
        image.sprite = spriteFaces[value-1];
    }
}
