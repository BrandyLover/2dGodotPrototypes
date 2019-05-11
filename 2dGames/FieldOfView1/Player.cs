using Godot;
using System;

public class Player : KinematicBody2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    [Export] public int PlayerSpeed = 200;
    [Export] public Vector2 LinearVelocity;

    Vector2 targetVelocity;
    
    

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {

    }

    public override void _PhysicsProcess(float delta)
    {
        
        GetInput();
        GetNode<Node2D>("Rotating").LookAt(GetGlobalMousePosition());

        LinearVelocity = targetVelocity.Normalized() * PlayerSpeed;

        MoveAndSlide(LinearVelocity);

    }

    //Getting Input Vector
    private void GetInput()
    {
        targetVelocity = new Vector2();

        if(Input.IsActionPressed("move_up"))
            targetVelocity.y -= 1;
        
        if(Input.IsActionPressed("move_down"))
            targetVelocity.y += 1;

        if(Input.IsActionPressed("move_right"))
            targetVelocity.x += 1;
        
        if(Input.IsActionPressed("move_left"))
            targetVelocity.x -= 1;
    }





    
}
