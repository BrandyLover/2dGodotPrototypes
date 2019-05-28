using Godot;
using System;

public class coffin3 : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    [Signal] public delegate void AcabouCena();
    
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        GetNode<Timer>("ChangeScene/Timer").Connect("timeout", this, nameof(_Free));
        
        GetNode<AudioStreamPlayer>("ChangeScene/Dublagem").Connect("finished", this, nameof(_DublagemEnd));
    }

    public void _DublagemEnd()
    {
        GetNode<AudioStreamPlayer>("ChangeScene/Dublagem").Stop();
        GetNode<ColorRect>("ChangeScene/Fade").SetVisible(true);
        EmitSignal(nameof(AcabouCena));
    }

    public void _Free()
    {
        if(GetParent().Name == "main")
            GetParent().GetNode("coffin2").QueueFree();
        GetNode<AudioStreamPlayer>("ChangeScene/Dublagem").Play();
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
    
}
