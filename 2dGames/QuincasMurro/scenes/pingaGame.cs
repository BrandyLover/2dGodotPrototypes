using Godot;
using System;

public class pingaGame : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    Sprite quincasHead;
    PackedScene pinga;

    [Signal] public delegate void AcabouPinga();
    public static bool endthis = false;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
        quincasHead = GetNode<Sprite>("Sprite");
        pinga = GD.Load<PackedScene>("res://charac/pinga.tscn");
        GetNode<Timer>("Timer").Connect("timeout", this, nameof(_Timeout));
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
    public void _Timeout()
    {
        EmitSignal(nameof(AcabouPinga));
    }

    public override void _PhysicsProcess(float delta)
    {
        if(GetNodeOrNull("pinga") == null)
            AddChild((Node2D)pinga.Instance());
            
        Vector2 mousePos = GetGlobalMousePosition();
      
        quincasHead.SetTransform(new Transform2D(0,new Vector2(mousePos.x,550)));
        quincasHead.SetScale(new Vector2(10,10));
        
    }

    
}
