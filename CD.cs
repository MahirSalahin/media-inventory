using System;
namespace MediaInventory{
    partial class CD:Media<string>{
        public string[] Artists{get;}
        public int TotalTracks{get;set;}
        public int DurationMin{get;set;}
        public CD(string title, string[] artists,int releaseYear,int totalTracks,int durationMin)
        :base(title,releaseYear){
            Artists=artists;
            TotalTracks=totalTracks;
            DurationMin=durationMin;
        }
        public override void DisplayInfo(){
            base.DisplayInfo();
            Console.Write($"Artists: ");
            foreach(string artist in Artists)Console.Write($"{artist}. ");
            Console.WriteLine();
            Console.WriteLine($"Duration: {DurationMin} minutes");
        }
    }
}