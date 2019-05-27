using Godot;
using System;

public class coffin2 : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    [Signal] public delegate void AcabouCena();
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        if(GetParent().Name == "main")
            GetParent().GetNode("coffin1").QueueFree();
        GetNode<AudioStreamPlayer>("Dublagem").Play();
        GetNode<AudioStreamPlayer>("Dublagem").Connect("finished", this, nameof(_DublagemEnd));
    }

    public void _DublagemEnd()
    {
        GetNode<AudioStreamPlayer>("Dublagem").Stop();
        GetNode<ColorRect>("Fade").SetVisible(true);
        EmitSignal(nameof(AcabouCena));
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
