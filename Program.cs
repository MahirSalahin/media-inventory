using System;
namespace MediaInventory{
    class Driver{
        public static void Main(){
            MediaInventory mediaInventory=new MediaInventory();
            //Adding medias is done with the help of AI,to populate with actual data and to save some time as well.
            mediaInventory.AddMedias(
            new Media<string>[]{
                new Book("The Catcher in the Rye", new string[] { "J.D. Salinger" }, 1951) { Price = 70, SoldCopies = 100, Rating = 9, Genre = new string[] { "Fiction" }, Awards = new string[] { "Bestseller" } },
                new Book("To Kill a Mockingbird", new string[] { "Harper Lee" }, 1960) { Price = 60, SoldCopies = 120, Rating = 9.4, Genre = new string[] { "Fiction" }, Awards = new string[] { "Pulitzer Prize" } },
                new Book("1984", new string[] { "George Orwell" }, 1949) { Price = 65, SoldCopies = 90, Rating = 9.6, Genre = new string[] { "Dystopian" }, Awards = new string[] { "Classic" } },
                new Book("Pride and Prejudice", new string[] { "Jane Austen" }, 1813) { Price = 55, SoldCopies = 150, Rating = 9.2, Genre = new string[] { "Romance" }, Awards = new string[] { "Classic" } },
                new Book("The Great Gatsby", new string[] { "F. Scott Fitzgerald" }, 1925) { Price = 75, SoldCopies = 80, Rating = 8.8, Genre = new string[] { "Fiction" }, Awards = new string[] { "American Literature" } },
                new Book("Harry Potter and the Sorcerer's Stone", new string[] { "J.K. Rowling" }, 1997) { Price = 10, SoldCopies = 120000000, Rating = 9.4, Genre = new string[] { "Fantasy" }, Awards = new string[] { "British Fantasy Award" } },
                new Book("Harry Potter and the Chamber of Secrets", new string[] { "J.K. Rowling" }, 1998) { Price = 11, SoldCopies = 77000000, Rating = 9.2, Genre = new string[] { "Fantasy" }, Awards = new string[] { "Nestlé Smarties Book Prize" } },
                new Book("Harry Potter and the Prisoner of Azkaban", new string[] { "J.K. Rowling" }, 1999) { Price = 12, SoldCopies = 68000000, Rating = 9.2, Genre = new string[] { "Fantasy" }, Awards = new string[] { "Bram Stoker Award" } },
                new Book("Harry Potter and the Goblet of Fire", new string[] { "J.K. Rowling" }, 2000) { Price = 13, SoldCopies = 87000000, Rating = 9.0, Genre = new string[] { "Fantasy" }, Awards = new string[] { "Hugo Award" } },
                new Book("Harry Potter and the Order of the Phoenix", new string[] { "J.K. Rowling" }, 2003) { Price = 14, SoldCopies = 65000000, Rating = 9.0, Genre = new string[] { "Fantasy" }, Awards = new string[] { "Quill Book Award" } },
                new Book("Harry Potter and the Half-Blood Prince", new string[] { "J.K. Rowling" }, 2005) { Price = 15, SoldCopies = 65000000, Rating = 8.8, Genre = new string[] { "Fantasy" }, Awards = new string[] { "Bram Stoker Award" } },
                new Book("Harry Potter and the Deathly Hallows", new string[] { "J.K. Rowling" }, 2007) { Price = 16, SoldCopies = 110000000, Rating = 9.4, Genre = new string[] { "Fantasy" }, Awards = new string[] { "British Book of the Year" }},
                new CD("Thriller", new string[] { "Michael Jackson" }, 1982, 9, 42) { Price = 12, SoldCopies = 66000000, Rating = 9.4, Genre = new string[] { "Pop" } },
                new CD("The Dark Side of the Moon", new string[] { "Pink Floyd" }, 1973, 10, 43) { Price = 11, SoldCopies = 45000000, Rating = 9.6, Genre = new string[] { "Progressive Rock" } },
                new CD("Back in Black", new string[] { "AC/DC" }, 1980, 10, 42) { Price = 14, SoldCopies = 50000000, Rating = 9.2, Genre = new string[] { "Hard Rock" } },
                new CD("Abbey Road", new string[] { "The Beatles" }, 1969, 17, 47) { Price = 13, SoldCopies = 50000000, Rating = 9.8, Genre = new string[] { "Rock" } },
                new CD("Rumors", new string[] { "Fleetwood Mac" }, 1977, 11, 40) { Price = 15, SoldCopies = 45000000, Rating = 9.4, Genre = new string[] { "Rock" } },
                new DVD("The Shawshank Redemption", new string[] { "Tim Robbins" }, new string[] { "Frank Darabont" }, 1994, 16, 142) { Price = 15, SoldCopies = 8000000, Rating = 9.3, Genre = new string[] { "Drama" } },
                new DVD("The Godfather", new string[] { "Marlon Brando", "Al Pacino" }, new string[] { "Francis Ford Coppola" }, 1972, 13, 175) { Price = 14, SoldCopies = 7000000, Rating = 9.2, Genre = new string[] { "Crime" } },
                new DVD("Pulp Fiction", new string[] { "John Travolta", "Samuel L. Jackson" }, new string[] { "Quentin Tarantino" }, 1994, 11, 154) { Price = 12, SoldCopies = 6000000, Rating = 8.9, Genre = new string[] { "Crime" } },
                new DVD("The Lord of the Rings: The Return of the King", new string[] { "Elijah Wood", "Viggo Mortensen" }, new string[] { "Peter Jackson" }, 2003, 12, 201) { Price = 16, SoldCopies = 11000000, Rating = 8.9, Genre = new string[] { "Adventure" } },
                new DVD("Forrest Gump", new string[] { "Tom Hanks" }, new string[] { "Robert Zemeckis" }, 1994, 12, 142) { Price = 13, SoldCopies = 9000000, Rating = 8.8, Genre = new string[] { "Drama" } }
            }); 
            while(true){
                Console.WriteLine("1. Add Media\n2. Remove Media\n3. Update Media\n4. Filter Media\n5. Show Current Medias\n0. Exit");
                int n=Media<int>.GetInput();
                try{
                    if(n==0)break;
                    else if(n<0 || n>5)throw new Exception("InValid Input!");
                    else if(n==1) ChooseMediaAndTakeInput(mediaInventory);
                    else if(n==2) RemoveItems(mediaInventory);
                    else if(n==3) UpdateMedia(mediaInventory);
                    else if(n==4) ApplyFilter(mediaInventory);
                    else if(n==5) mediaInventory.ShowCurrentMedias();
                }
                catch(ArgumentOutOfRangeException e){Console.WriteLine(e.Message);}
                catch(Exception e){Console.WriteLine(e.Message);}
            }

            static void RangeInput<T>(string s,ref T FromVal,ref T ToVal){
                string[] words=new string[]{};
                if(s=="")return;                
                try{
                    words=s.Split(',');
                }catch(FormatException){
                    return;
                }
                int wordCount= words.SelectMany(s=>s.Split(',')).Count();
                if(wordCount>0)FromVal=(T)Convert.ChangeType(words[0],typeof(T));
                if(wordCount>1)ToVal=(T)Convert.ChangeType(words[1],typeof(T));
            }
            static void ApplyFilter(MediaInventory mediaInventory){
                Console.WriteLine("\t\tFiltering...\n\t[Use Comma(,) for Multiple Input.\n"+
                "\tYou can Leave The Fields as Empty]\n____________________________________________________");
                mediaInventory.StartFiltering();

                //In this Filter, user can skip any number of fields.
                /*In case of Range input(like Minimun-Price to Maximum-Price) 
                  user can provide only one value or skip that too*/
                /*If all fields are skipped, the filter will contain all the medias*/

                int n=Media<int>.GetInput("Select Media Type( 1.Book  2.CD  3.DVD ): ");
                if(n==1)mediaInventory.FilterMediasOfType<Book>();
                else if(n==2)mediaInventory.FilterMediasOfType<CD>();
                else if(n==3)mediaInventory.FilterMediasOfType<DVD>();
                string? title=Media<string>.GetInput("Titile: ")??"";
                int FromPublishedYear=-1,ToPublishedYear=-1;
                RangeInput<int>(Media<string>.GetInput("Published Year Range(use comma): ")??"",ref FromPublishedYear,ref ToPublishedYear);
                double FromRating=-1,ToRating=-1,FromPrice=-1,ToPrice=-1;
                RangeInput<double>(Media<string>.GetInput("Rating Range(use comma): ")??"",ref FromRating,ref ToRating);
                RangeInput<double>(Media<string>.GetInput("Price Range(use comma): ")??"",ref FromPrice,ref ToPrice);
                string[] awards=(Media<string>.GetInput("Awards(use comma): ")??"").Split(',');
                string[] genres=(Media<string>.GetInput("Genre(use comma): ")??"").Split(',');

                //Applying common filters
                mediaInventory.FilterByTitle(title);
                mediaInventory.FilterByPublishedYear(FromPublishedYear,ToPublishedYear);
                mediaInventory.FilterByRating(FromRating,ToRating);
                mediaInventory.FilterByPrice(FromPrice,ToPrice);
                mediaInventory.FilterByAwards(awards);
                mediaInventory.FilterByGenres(genres);
                
                if(n==1){
                    bool IsBestSeller=Media<bool>.GetInput("Is Bestseller?(yes/no): ");
                    string[] authors=(Media<string>.GetInput("Authors(use comma): ")??"").Split(',');
                    if(IsBestSeller)mediaInventory.FilterBestsellers();
                    mediaInventory.FilterByAuthors(authors);
                }
                else if(n==2 || n==3){
                    int FromDuration=-1,ToDuration=-1;
                    RangeInput<int>(Media<string>.GetInput("Duration Range(use comma): ")??"",ref FromDuration,ref ToDuration);
                    string[] artists=(Media<string>.GetInput("Artists(use comma): ")??"").Split(',');
                    mediaInventory.FilterByDuration(FromDuration,ToDuration);
                    mediaInventory.FilterByArtists(artists);
                    if(n==3){
                        string[] directors=(Media<string>.GetInput("Directors(use comma): ")??"").Split(',');
                        mediaInventory.FilterByDirectors(directors);
                    }
                }
                mediaInventory.ShowFilteredMedias();
            }

            static void ChooseMediaAndTakeInput(MediaInventory mediaInventory){
                while(true){
                    Console.WriteLine("Choose Media(1.Book 2.CD 3.DVD)\n0.Back");
                    int n=Convert.ToInt32(Console.ReadLine());
                    if(n==0)return;
                    if(n<0 || n>3)throw new InvalidDataException("InValid Input!");
                    string title=Media<string>.GetInput("Title: ")??"";
                    int publishedYear=Media<int>.GetInput("Published Year: ");
                    double price=Media<double>.GetInput("Price($): ");
                    int SoldCopies=Media<int>.GetInput("Sold Copies: ");
                    double rating=Media<double>.GetInput("Rating[0,10]: ");
                    if(rating<0.0 || rating>10.0)throw new ArgumentOutOfRangeException("Rating should be in the range[0,10]");
                    string[] genre=(Media<string>.GetInput("Genre(use comma): ")??"").Split(',');
                    string[] Awards=(Media<string>.GetInput("Awards(use comma): ")??"").Split(',');
                    if(n==1){
                        string[] authors=(Media<string>.GetInput("Authors(use comma): ")??"").Split(',');
                        Book book=new Book(title,authors,publishedYear);
                        book.TotalPage=Media<int>.GetInput("Total Page: ");
                        book.Rating=rating;
                        book.Awards=Awards;
                        book.SoldCopies=SoldCopies;
                        book.Price=price;
                        book.Genre=genre;
                        mediaInventory.AddMedias(book);
                    }
                    else if(n==2){
                        string[] artists=(Media<string>.GetInput("Artists(use comma): ")??"").Split(',');
                        int totalTracks=Media<int>.GetInput("Total Tracks: ");
                        int DurationMin=Media<int>.GetInput("Duration(Minute): ");
                        CD cD=new CD(title,artists,publishedYear,totalTracks,DurationMin);
                        mediaInventory.AddMedias(cD);
                    }
                    else if(n==3){  
                        string[] artists=(Media<string>.GetInput("Artists(use comma): ")??"").Split(',');
                        int totalTracks=Media<int>.GetInput("Total Tracks: ");
                        int DurationMin=Media<int>.GetInput("Duration(Minute): ");
                        string[] directors=(Media<string>.GetInput("Directors(use comma): ")??"").Split(',');
                        DVD dVD=new DVD(title,artists,directors,publishedYear,totalTracks,DurationMin);
                        mediaInventory.AddMedias(dVD);
                    }
                Console.WriteLine("Added Successfully");
                }
            }
            static void RemoveItems(MediaInventory mediaInventory){
                ApplyFilter(mediaInventory);
                var filteredList=mediaInventory.GetFilteredMedias();
                string input=Media<string>.GetInput("Press 0 to remove all Filtered-Medias,or\n"
                         +                      "the Media Number(s) you want to Remove(use comma)\n")??""; 
                string[] numbers=input.Split(',');
                if(numbers.Count()==1 && Convert.ToInt32(numbers[0])==0){
                    mediaInventory.RemoveMedias(filteredList.ToArray());
                }
                else{
                    foreach(var x in numbers){
                        int i=Convert.ToInt32(x)-1;
                        mediaInventory.RemoveMedias(filteredList[i]);
                    }
                }
                Console.WriteLine("The selected media(s) are Removed successfylly");
            }
            static void UpdateMedia(MediaInventory mediaInventory){
                ApplyFilter(mediaInventory);
                string input=Media<string>.GetInput("Select a Media Number to Update\n")??""; 
                var filteredList=mediaInventory.GetFilteredMedias();
                int i=Convert.ToInt32(input)-1;
                Console.WriteLine("Previous Info:");
                filteredList[i].DisplayInfo();

                //Some information-change is not allowed because of privacy policy
                Console.WriteLine("\nProvide new Info:");
                double price=Media<double>.GetInput("Price($): ");
                int SoldCopies=Media<int>.GetInput("Sold Copies: ");
                double rating=Media<double>.GetInput("Rating[0,10]: ");
                if(rating<0.0 || rating>10.0)throw new ArgumentOutOfRangeException("Rating should be in the range[0,10]");
                string[] Awards=(Media<string>.GetInput("Awards(use comma): ")??"").Split(',');
                if(price!=0)filteredList[i].Price=price;
                if(SoldCopies!=0)filteredList[i].SoldCopies=SoldCopies;
                if(rating!=0)filteredList[i].Rating=rating;
                foreach(var award in filteredList[i].Awards) Awards.Append(award);
                filteredList[i].Awards=Awards;
                Console.WriteLine("Updated Successfully");
            }
        }
    }
}
