using Godot;
using System;

public class Player : KinematicBody2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    [Export] public int PlayerSpeed = 200;
     public Vector2 LinearVelocity;

    Vector2 targetVelocity;
    
    PackedScene Bullet;
    

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Bullet = GD.Load<PackedScene>("res://Bullet.tscn");
    }

    public override void _PhysicsProcess(float delta)
    {
        //Setting movement vector
        GetMoveInput();
        //Rotating the MouseFollow Node to point at the mouse position
        GetNode<Node2D>("MouseFollow").LookAt(GetGlobalMousePosition());

        //Shooting Example
        if(Input.IsActionPressed("Fire"))
            SpawnBullet();
            

        //Calculating Movement vector and moving
        LinearVelocity = targetVelocity.Normalized() * PlayerSpeed;
        MoveAndSlide(LinearVelocity);

    }

    //Getting Input Vector
    private void GetMoveInput()
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

    private void SpawnBullet()
    {
        Node2D node2D = (Node2D)Bullet.Instance();
        node2D.Transform = GetNode<Position2D>("MouseFollow/BulletSpawn").GlobalTransform;

        //Adds the bullet scene as a child of the root node, so the player's position and rotation doesn't interfere with the bullet
        GetParent().AddChild(node2D);
    }





    
}
