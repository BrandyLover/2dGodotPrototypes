using Godot;
using System;

public class TextFrame : TextureRect
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    [Signal] public delegate void NextScene();
    private string[] PHRASES = Phrases.PhrasesScene1;
    private char[] charArray;
    private float elapsed ;
    

    private bool textStart = false, skipText = false;
    private int phrasei = 0, charArrayIndex = 0;
    
    RichTextLabel TextBOX;
    
    
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        TextBOX = GetNode<RichTextLabel>("TextBOX");
        this.GetNode<Timer>("Timer").Connect("timeout",this,nameof(_Triggered));
        
        textStart = true;
        UpdatePhrase(phrasei);
    }

 // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        //Checks if the player wants to skip the text
        if(Input.IsActionPressed("ui_accept"))
            skipText = true;
    }

    public void _StartText()
    {
        textStart = true;
    }

    public  void _Triggered()
    {
        if(textStart && !skipText ){
                    if( phrasei < PHRASES.Length && charArrayIndex < charArray.Length )
                    {   
                        TextBOX.AddText(charArray[charArrayIndex].ToString());
                        charArrayIndex++;
                    }
                    else if( phrasei > PHRASES.Length)
                    //Emit the signal to sinalize the next phrase bank
                        EmitSignal(nameof(NextScene));
                    else if( charArrayIndex > charArray.Length){
                        charArrayIndex = 0;
                        phrasei++;
                        UpdatePhrase(phrasei);
                    }
                        
                //Called when the player wants to skip text        
                else if(skipText){
                    skipText = false;

                }
            
        }
        //DEBUG CODE
        /* 
        GD.Print(nextChari.ToString() +" "+ phrasei.ToString() + " " + PHRASES.Length.ToString() + " " + elapsed.ToString());
        if(elapsed > 0.5)
            GD.Print("TRIGGER SECOND IF");
        */
    }
    public void UpdatePhrase(int PhraseIndex)
    {
        charArray = PHRASES[PhraseIndex].ToCharArray();
    }
}



