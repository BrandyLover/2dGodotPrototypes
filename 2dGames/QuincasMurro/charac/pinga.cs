using Godot;
using System;

public class pinga : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    Vector2 originalPos;
    string labeltext;
    int life = 10;
    Area2D col;
    int speed = 5;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        originalPos = GetPosition();
        col = (Area2D)GetNode("Sprite/Area2D");
        
    }

  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        MoveLocalY(1*speed);
        if(col.OverlapsArea(GetParent().GetNode("Sprite/Area2D")))
        {
            life++;
            QueueFree();
        }
           
        else if(col.OverlapsArea(GetParent().GetNode("Area2D")))
        {
            life --;
            QueueFree();
        }

        if(life >= 20)
            pingaGame.endthis = true;
        else if(life <= 0)
            pingaGame.endthis = true;

            
    }
    

    
}
