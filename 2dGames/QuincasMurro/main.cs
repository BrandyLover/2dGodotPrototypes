using Godot;
using System;

public class main : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    private AudioStreamPlayer Track1,Track2;



    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {


        Track1 = GetNode("Sound").GetNode<AudioStreamPlayer>("Track1");
        Track1.Connect("finished", this, nameof(_Track1Finished));

        Track2 = GetNode("Sound").GetNode<AudioStreamPlayer>("Track2");
        Track2.Connect("finished", this, nameof(_Track2Finished));
        
        Track1.Play();
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }

    public void _Track1Finished()
    {
        Track1.Stop();
        Track2.Play();
    }

    public void _Track2Finished()
    {
        Track2.Stop();
        Track1.Play();
    }
}
