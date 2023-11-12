using System;
using System.Security.Cryptography.X509Certificates;
namespace MediaInventory{
    class MediaInventory{
        //Medias are stored in this list
        private List<Media<string>> MediaList=new List<Media<string>>();
        //Indexer
        public Media<string> this[int index]{
            get{
                if(index<0 || index >= MediaList.Count){
                    throw new IndexOutOfRangeException("Index is out of range");
                }
                return MediaList[index];
            }
            //set
        }

        //Filtered Medias are stored in this list
        private List<Media<string>> FilteredList=new List<Media<string>>();
        
        //Enumerator for MediaList
        public IEnumerator<Media<string>> GetEnumerator(){
            return MediaList.GetEnumerator();
        }
        
        //To Add medias
        public void AddMedias(params Media<string>[] medias){
            foreach(var media in medias)
                MediaList.Add(media);
        }
        
        //To Remove medias
       public void RemoveMedias(params Media<string>[] medias){
            foreach(var media in medias)
                MediaList.Remove(media);
        }
        public void RemoveAll() => MediaList=new List<Media<string>>();
        
        //To Show medias
        private void ShowMedias(List<Media<string>> mediaList){
            int i=1;
            foreach(var media in mediaList){
                Console.WriteLine("_______________________________________________________\nNo. "+i++);
                media.DisplayInfo();
            }
            Console.WriteLine("_______________________________________________________\n");
        }
        public void ShowCurrentMedias()=> ShowMedias(MediaList);
        
        public int TotalMedias() =>MediaList.Count;
        //To show Filtered medias
        public void ShowFilteredMedias()=> ShowMedias(FilteredList);

        //To start the Filtering process 
        public void StartFiltering() => FilteredList=MediaList;

        //To get the Filtered medias as List
        public List<Media<string>> GetFilteredMedias(){
            return FilteredList;
        }
        
        //To clear the Filter
        public void ClearFilter()=> FilteredList=new List<Media<string>>();
        
        //Filter by the Media-Type(Book or CD or DVD)
        public void FilterMediasOfType<T>()where T : Media<string>{
            List<T> Flist=FilteredList.Where(m=> m.GetType()==typeof(T)).Cast<T>().ToList();
            FilteredList=Flist.Cast<Media<string>>().ToList();
        }

        //Filter by the Title
        public void FilterByTitle(string title){
            FilteredList=Media<string>.FilterByTitle(FilteredList,title).ToList();
        }

        //Filter by the Published Year
        public void FilterByPublishedYear(int fromYear=-1,int toYear=-1){
            if(fromYear==-1)return;
            if(toYear==-1)toYear=fromYear;
            FilteredList=Media<string>.FilterByPublishedYear(FilteredList,fromYear,toYear).ToList();
        }

        //Filter by Rating
        public void FilterByRating(double fromRating=-1, double toRating=-1){
            if(fromRating==-1)return;
            if(toRating==-1)toRating=fromRating;
            FilteredList=Media<string>.FilterByRating(FilteredList,fromRating,toRating).ToList();
        }

        //Filter by Price
        public void FilterByPrice(double fromPrice=-1, double toPrice=-1){
            if(fromPrice==-1)return;
            if(toPrice==-1)toPrice=fromPrice;
            FilteredList=Media<string>.FilterByPrice(FilteredList,fromPrice,toPrice).ToList();
        }


        //Filter by Awards
        public void FilterByAwards(params string[] awards){
            foreach(var award in awards){
                if(award=="")return;
                FilteredList=Media<string>.FilterByAwards(FilteredList,award).ToList();
            }
        }
        
        //Filter by Genre
        public void FilterByGenres(params string[] genres){
            foreach(var genre in genres){
                if(genre=="")return;
                FilteredList=Media<string>.FilterByGenre(FilteredList,genre).ToList();
            }
        }

        //Filter by Bestsellers
        public void FilterBestsellers(){
            FilteredList=Media<string>.FilterBestSellers(FilteredList).ToList();
        }

        //Filter by Authors
        public void FilterByAuthors(params string[] authors){
            List<Book> books=FilteredList.OfType<Book>().Cast<Book>().ToList();
            foreach(var author in authors){
                if(author=="")return;
                FilteredList=Book.FilterByAuthor(books,author).Cast<Media<string>>().ToList();
            }
        }

        //Filter by Duration
        public void FilterByDuration(int fromMin=-1,int toMin=-1){
            if(fromMin==-1)return;
            if(toMin==-1){
                toMin=fromMin;fromMin=0;
            }
            List<CD> cDs=FilteredList.OfType<CD>().Cast<CD>().ToList();
            FilteredList=CD.FilterByDuration(cDs,fromMin,toMin).Cast<Media<string>>().ToList();
        }

        //Filter by Artists
        public void FilterByArtists(params string[] artists){
            List<CD> cDs=FilteredList.OfType<CD>().Cast<CD>().ToList();
            foreach(var artist in artists){
                if(artist=="")return;
                FilteredList=CD.FilterByArtist(cDs,artist).Cast<Media<string>>().ToList();

            }
        }

        //Filter by Directors
        public void FilterByDirectors(params string[] directors){
            List<DVD> dVDs=FilteredList.OfType<DVD>().Cast<DVD>().ToList();
            foreach(var director in directors){
                if(director=="")return;
                FilteredList=DVD.FilterByDirector(dVDs,director).Cast<Media<string>>().ToList();
            }
        }
       
    }
}