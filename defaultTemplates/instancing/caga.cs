using Godot;
using System;

public class caga : Panel
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    Button test = new Button();
    bool one = true;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
        GetNode("Button").Connect("pressed", this, nameof(_On_Button_Pressed));

    }

    public void _On_Button_Pressed(){
        if(one){
            GetNode<Label>("Label").Text = "8051";
            one = false;
        }
        else{
            GetNode<Label>("Label").Text = "TA EGADO";
            one = true;
        }

    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
