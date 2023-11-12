using System;
namespace MediaInventory{
    partial class DVD:CD{
        public string[] Directors{get;}
        public DVD(string title, string[] artists,string[] directors,int releaseYear,int totalTracks,int duration)
        :base(title,artists,releaseYear,totalTracks,duration){
            TotalTracks=totalTracks;
            Directors=directors;
        }
        public override void DisplayInfo(){
            base.DisplayInfo();
            Console.Write($"Directors: ");
            foreach(string diector in Directors)Console.Write($"{diector}. ");
            Console.WriteLine();
        }
    }
}