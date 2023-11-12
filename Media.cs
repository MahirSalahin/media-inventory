using System;
namespace MediaInventory{
    partial class Media<T>{
        // protected int typeCode;
        // public int TypeCode{get=>typeCode;} 
        public string Title{get;}
        public int ReleaseYear{get;}
        public double Price{get;set;}
        public int SoldCopies{get;set;}
        public bool IsBestSeller{get=>(SoldCopies>1000000);}
        public double Rating{get;set;} 
        public string[] Genre{get;set;}=new string[]{};
        public string[] Awards{get;set;}=new string[]{};
        public Media(string title,int releaseYear){
            Title=title;
            ReleaseYear=releaseYear;
        }
         public virtual void DisplayInfo(){
            Console.WriteLine($"\nTitle: {Title}");
            Console.WriteLine($"Release Year: {ReleaseYear}");
            Console.WriteLine($"Price($) : {Price}");
            Console.WriteLine($"Sold Copies: {SoldCopies}");
            Console.WriteLine($"Best Seller: {IsBestSeller}");
            Console.WriteLine($"Rating: {Rating}");
            Console.Write($"Genre: ");
            foreach(string genre in Genre)Console.Write($"{genre}. ");
            Console.WriteLine();
            Console.Write($"Award(s): ");
            foreach(string award in Awards)Console.Write($"{award}. ");
            Console.WriteLine();
        }
        public static T? GetInput(string stringToPrint=""){
            Console.Write(stringToPrint);
            string input = (Console.ReadLine()??"null").Trim();
            try{
                //Converting the input to type T
                T ConvertedInput=(T)Convert.ChangeType(input,typeof(T));
                return ConvertedInput;
            }
            catch(Exception){
                //If exception occurs it returns default value
                return default(T);
            }
        }
    }
}