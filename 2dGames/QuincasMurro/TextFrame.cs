using Godot;
using System;

public class TextFrame : TextureRect
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
<<<<<<< HEAD

    [Signal] public delegate void NextScene();
    private string[] PHRASES = Phrases.PhrasesScene1;
    private char[] charArray;
    private float elapsed = 0;
    

    private bool textStart = false, skipText = false;
    private int nextChari = 0,phrasei = 0;
    RichTextLabel TextBOX;
    
=======
    [Export] public int PhraseIndex = 0;
>>>>>>> parent of 2cdee66... Text pipeline WIP
    
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
<<<<<<< HEAD
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
        charArray =  PHRASES[phrasei].ToCharArray();
        if(Input.IsActionPressed("ui_accept"))
            skipText = true;
        
        if(textStart && !skipText){
                if(elapsed == 0.5f && (phrasei < PHRASES.Length) )
                {
                    if(nextChari < charArray.Length){
                        GD.Print(charArray[nextChari]);
                        nextChari++;
                    }
                    else
                        phrasei++; nextChari = 0;
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


<<<<<<< HEAD
=======
        
    }
>>>>>>> parent of 2cdee66... Text pipeline WIP
=======
public static class Phrases 
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    public static string[] PhrasesScene1 = {
        "(Narrador) Eduardo estirou as pernas, pensou em sua cama. Doía-lhe o pescoço. No canto doquarto, Curió, Péde-Vento e cabo Martim conversavam em voz baixa, numa discussão apaixonante: qual deles substituiria Quincas no coração e no leito de Quitéria do OlhoArregalado?",
"(Eduardo) – Me digam uma coisa...",
"(Cabo Martim) – Às suas ordens, meu comandante.",
"(Narrador)Quem sabe não iria o comerciante mandar comprar uma bebidinha para ajudar a travessia da noite longa?",
"(Eduardo) – Vocês vão ficar a noite toda?",
"(Cabo Martim) – Com ele? Sim senhor. A gente era amigo.",
"(Eduardo) – Então vou em casa, descansar um pouco – meteu a mão no bolso, retirou uma nota. Os olhos do Cabo, de Curió e Pé-de-Vento acompanhavam seus gestos.",
"(Eduardo) – Tá aí para vocês comprarem uns sanduíches. Mas não deixem ele sozinho. Nem um minuto, hein!",
"(Cabo Martim) – Pode ir descansado, a gente faz companhia a ele."
    };
    public static string[] PhrasesScene2 ={
        "(Narrador) Negro Pastinha acordou quando sentiu o cheiro de cachaça. Antes de começar a beber, Curió e Pé-de-Vento acenderam cigarros.",
"(Negro pastinha)– Está um senhor! Um defunto porreta!",
"(Negro pastinha)– Um defunto porreta!",
"(Narrador)Quincas sorriu com o elogio, o negro retribuiu-lhe o sorriso:",
"(Negro pastinha)– Paizinho...",
"(Narrador)Curió e Pé-de-Vento voltaram com caixões, um pedaço de salame e algumas garrafas cheias. Fizeram um semicírculo em torno ao morto e então Curió propôs rezarem em conjunto o Padre-Nosso.",
"(Narrador)Curió puxa a reza, mas os outros passam dificuldade ao acompanha-lo. Curió indigna-se:",
"(Curió)– Cambada de burros...",
"(Cabo Martim) – Falta de treino...",
"(Cabo Martim) – Mas já foi alguma coisa. O resto o padre faz amanhã."
    };
    // Called when the node enters the scene tree for the first time.
    public static string[] PhrasesScene3 = {
    "(Narrador) Entre cabo Martim e Curió recomeçou a discussão sobre Quitéria do Olho Arregalado. Com a bebida, Curió ficava mais combativo, elevava a voz em defesa dos seus interesses. Negro Pastinha reclamou:",
    "(Negro Pastinha) – Vocês não têm vergonha de disputar a mulher dele na vista dele? Ele ainda quente e vocês que nem urubu em carniça?",
    "(Pé-de-Vento.)– Ele é que pode decidir... – disse Pé-de-Vento.",
    "(Barulho vindo do caixão)– Hum!",
    "(Negro Pastinha) – Tá vendo? Ele não está gostando dessa conversa.",
    "(Cabo Martim) – Vamos dar um gole a ele também... –"
    };
>>>>>>> parent of a99ed32...  preparing to add GodotTIE to QuincasMurro

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
