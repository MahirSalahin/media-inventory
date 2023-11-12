using System;
namespace MediaInventory{
    partial class Book:Media<string>{
        public string[] Authors{get;}=new string[]{};
        public int TotalPage{get;set;}
        public Book(string title, string[] authors,int releaseYear)
        :base(title,releaseYear){
            Authors=authors;
        }
        public override void DisplayInfo(){
            base.DisplayInfo();
            Console.Write($"Authors: ");
            foreach(string author in Authors)Console.Write($"{author}. ");
            Console.WriteLine();
            Console.WriteLine($"TotalPage: {TotalPage}");
        }
    }
}