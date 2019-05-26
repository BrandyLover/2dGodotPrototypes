using Godot;
using System;

public class main : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    private AudioStreamPlayer musicPlayer;
    private int musicCounter = 1;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {

        musicPlayer = GetNode<AudioStreamPlayer>("MusicPlayer");
        musicPlayer.Connect("finished", this, nameof(_MusicFinished));
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }

    public void _MusicFinished()
    {
        musicCounter++;
        switch (musicCounter)
        {
            case 1:
                musicPlayer.Stream.SetPath("res://audio/1.ogg");
                break;
            
            case 2:
                musicPlayer.Stream.SetPath("res://audio/2.ogg");
                break;

            default: 
                musicCounter = 1;
                break;
        }

        musicPlayer.Play(0);
            
    }
}
