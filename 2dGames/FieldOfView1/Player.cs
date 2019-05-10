using Godot;
using System;

public class Player : KinematicBody2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    [Export] public int PlayerSpeed = 200;
    [Export] public Vector2 LinearVelocity;
    
    

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {

    }

    public override void _PhysicsProcess(float delta)
    {
         Vector2 targetVelocity = new Vector2();

        if(Input.IsActionPressed("move_up"))
            targetVelocity.y -= 1;
        
        if(Input.IsActionPressed("move_down"))
            targetVelocity.y += 1;

        if(Input.IsActionPressed("move_right"))
            targetVelocity.x += 1;
        
        if(Input.IsActionPressed("move_left"))
            targetVelocity.x -= 1;
        
        LinearVelocity = targetVelocity.Normalized() * PlayerSpeed;

        MoveAndSlide(LinearVelocity,new Vector2(0,0));

    }

    
}
