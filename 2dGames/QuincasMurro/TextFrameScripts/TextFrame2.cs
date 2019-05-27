using Godot;
using System;

public class TextFrame2 : TextureRect
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    [Signal] public delegate void NextScene();
    private string[] PHRASES = Phrases.PhrasesScene2;
    private char[] charArray;
    private float elapsed = 0;
    

    private bool textStart = false, skipText = false;
    private int nextChari = 0,phrasei = 0;
    RichTextLabel TextBOX;
    
    
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {

        TextBOX = GetNode<RichTextLabel>("TextBOX");
        
        textStart = true;
    }

    public void _StartText()
    {
        textStart = true;
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        elapsed += delta;
        
        if(Input.IsActionPressed("ui_accept"))
            skipText = true;
        
        if(textStart && !skipText){
                if(  phrasei < PHRASES.Length )
                {
                    charArray =  PHRASES[phrasei].ToCharArray();
                    foreach (char c in charArray)
                    {
                        TextBOX.AddText(c.ToString());
                    }
                    TextBOX.Newline();
                    phrasei++;
                    
                }
                else if( phrasei > PHRASES.Length)
                //Emit the signal to sinalize the next phrase bank
                    EmitSignal(nameof(NextScene));
            else if(skipText){
                skipText = false;

            }
        }
        
    }
}






//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }

