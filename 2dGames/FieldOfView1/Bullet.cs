using Godot;
using System;

public class Bullet : KinematicBody2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    private Vector2 mousePos;

    private Vector2 targetDirection;
    //Bullet Speed Interger
    [Export] public int BulletSpeed = 300;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
        mousePos = GetParent().GetNode<Node2D>("Player").GetLocalMousePosition();

        //Calculates the directional Vector based on mouse position to the player and the position of the "bullet
        targetDirection.x = mousePos.x - Transform.x.x ;
        targetDirection.y = mousePos.y - Transform.y.y;

        //Normalizes and multiplies the vector by the bullet speed
        targetDirection = targetDirection.Normalized() * BulletSpeed;
        
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }

    public override void _PhysicsProcess(float delta)
    {
        //Moves the bullet in the mouse direction
        MoveAndSlide(targetDirection);
    }
    
}
