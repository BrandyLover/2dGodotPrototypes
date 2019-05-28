using Godot;
using System;

public class coffin1 : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    private AudioStreamPlayer dublagem;
    [Signal] public delegate void AcabouCena();
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        dublagem = GetNode<AudioStreamPlayer>("Dublagem");
        
        if(GetParent().Name == "main")
            GetParent().GetNode("SelectionScreen").QueueFree();
        
        dublagem.Connect("finished", this, nameof(_DublagemEnd));
        dublagem.Play();
    }

    public void _DublagemEnd()
    {
        dublagem.Stop();
        GetNode<ColorRect>("Fade").SetVisible(true);
        EmitSignal(nameof(AcabouCena));
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        if(Input.IsActionPressed("ui_accept"))
            _DublagemEnd();
    }
}
