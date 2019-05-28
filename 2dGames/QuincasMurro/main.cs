using Godot;
using System;

public class main : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    private AudioStreamPlayer Track1,Track2,Track3,Track4,Track5,Track6,Track7,Track8,Track9;
    PackedScene packedGameScene;
    

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        packedGameScene = GD.Load<PackedScene>("res://coffin1.tscn");

        GetNode("SelectionScreen/Buttons/Play").Connect("pressed",this,nameof(_PlayPressed));

        Track1 = CallTrack(Track1,"Track1",this,nameof(_Track1Finished));

        Track2 = CallTrack(Track2,"Track2",this,nameof(_Track2Finished));

        Track5 = CallTrack(Track5,"Track5",this,nameof(_Track5Finished));

        

        
        
        Track1.Play();
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }

    public void _PlayPressed()
    {
        this.GetNode<Panel>("SelectionScreen").SetVisible(false);

        AddChild((Node2D)packedGameScene.Instance());

        packedGameScene = GD.Load<PackedScene>("res://coffin2.tscn");
        if(GetNode("coffin1").IsInsideTree())
            GetNode("coffin1").Connect("AcabouCena",this,nameof(_AcabouCoffin1));
    }

    public void _AcabouCoffin1(){
        AddChild((Node2D)packedGameScene.Instance());

        //Debug line, change to coffin3 when implemented
        packedGameScene = GD.Load<PackedScene>("res://scenes/coffin3.tscn");

        if(GetNode("coffin2").IsInsideTree())
            GetNode("coffin2").Connect("AcabouCena2",this,nameof(_AcabouCoffin2));
    }

    public void _AcabouCoffin2()
    {
        //DebugCode
        AddChild((Node2D)packedGameScene.Instance());

        packedGameScene = GD.Load<PackedScene>("res://scene4.tscn");

        if(GetNode("coffin3").IsInsideTree()){
            GetNode("coffin3").Connect("AcabouCena",this,nameof(_AcabouCoffin3));
            GetNode("coffin3").Connect("PlayTrack5", this, nameof(_PlayTrack5));
            


        }

    }

    public void _AcabouCoffin3()
    {
        AddChild((Node2D)packedGameScene.Instance());

        packedGameScene = GD.Load<PackedScene>("res://scene5.tscn");

        if(GetNode("scene4").IsInsideTree())
            GetNode("scene4").Connect("AcabouCena",this,nameof(_AcabouScene4));
    }

    

    public void _AcabouScene4()
    {
        AddChild((Node2D)packedGameScene.Instance());

        packedGameScene = GD.Load<PackedScene>("res://scenes/scene7.tscn");

        if(GetNode("scene5").IsInsideTree())
            GetNode("scene5").Connect("AcabouCena",this,nameof(_AcabouScene5));
    }

    public void _AcabouScene5()
    {

    }

    

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

    public void _PlayTrack5()
    {
        Track1.Stop();
        Track2.Stop();
        Track5.Play();
    }
    public void _Track5Finished()
    {
        if(GetNodeOrNull("coffin3").IsInsideTree())
            Track5.Play();
        else
        {
            Track5.Stop();
            Track1.Play();
        }
    }

    private AudioStreamPlayer CallTrack(AudioStreamPlayer TrackPlayer,string TrackName,Godot.Object target, string method)
    {
        TrackPlayer = GetNode("Sound").GetNode<AudioStreamPlayer>(TrackName);
        TrackPlayer.Connect("finished", target, method);
        return TrackPlayer;
    }
}
