using Godot;
using System;

public class coffin3 : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    [Signal] public delegate void AcabouCena();
    [Signal] public delegate void PlayTrack5();
    
    
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        if(GetParent().Name == "main")
            GetParent().GetNode("coffin2").QueueFree();
        GetNode<AudioStreamPlayer>("ChangeScene/Dublagem").Play();

        GetNode<Timer>("ChangeScene/Timer").Connect("timeout", this, nameof(_Free));
        
        GetNode<AudioStreamPlayer>("ChangeScene/Dublagem").Connect("finished", this, nameof(_Minigame));
    }

    public void _DublagemEnd()
    {
        GetNode<AudioStreamPlayer>("ChangeScene/Dublagem").Stop();
        GetNode<ColorRect>("ChangeScene/Fade").SetVisible(true);
        EmitSignal(nameof(AcabouCena));
    }

    public void _Free()
    {
        
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
    
    public void _Minigame()
    {
        PackedScene packed = GD.Load<PackedScene>("res://scenes/pingaGame.tscn");
        AddChild((Node2D)packed.Instance());
        EmitSignal(nameof(PlayTrack5));
        if(GetNode("pingaGame").IsInsideTree())
            GetNode("pingaGame").Connect("AcabouPinga",this,nameof(_DublagemEnd));
    }
}
