using System;
namespace MediaInventory
{
    partial class Media<T>{
        // protected static IEnumerable<Media<T>> Medias= new Media<T>[]{};
        public static IEnumerable<Media<T>> FilterByRating(IEnumerable<Media<T>> medias, double minRating, double maxRating=10.0)
            => medias.Where(media => (media.Rating >= minRating && media.Rating <= maxRating));         
        public static IEnumerable<Media<T>> FilterByPrice(IEnumerable<Media<T>> medias, double minPrice, double maxPrice)
            => medias.Where(media => (media.Price >= minPrice && media.Price <= maxPrice));

        public static IEnumerable<Media<T>> FilterBestSellers(IEnumerable<Media<T>> medias)
            => medias.Where(media => media.IsBestSeller);
        
        public static IEnumerable<Media<T>> FilterByGenre(IEnumerable<Media<T>> medias, string genre)
            => medias.Where(media => media.Genre.Any(x=> x.Contains(genre,StringComparison.OrdinalIgnoreCase)));
        
        public static IEnumerable<Media<T>> RemoveByGenre(IEnumerable<Media<T>> medias, string genre)
            => medias.Where(media => !media.Genre.Any(x=> x.Contains(genre,StringComparison.OrdinalIgnoreCase)));
        
        public static IEnumerable<Media<T>> FilterByPublishedYear(IEnumerable<Media<T>> medias, int fromYear, int toYear)
            => medias.Where(media => (media.ReleaseYear >= fromYear && media.ReleaseYear <= toYear));
        
        public static IEnumerable<Media<T>> RemoveByPublishedYear(IEnumerable<Media<T>> medias, int fromYear, int toYear)
            => medias.Where(media => !(media.ReleaseYear >= fromYear && media.ReleaseYear <= toYear));
        
        
        public static IEnumerable<Media<T>> FilterByAwards(IEnumerable<Media<T>> medias, string award)
            => medias.Where(media => media.Awards.Any(x=> x.Contains(award,StringComparison.OrdinalIgnoreCase)));
        

        public static IEnumerable<Media<T>> FilterByTitle(IEnumerable<Media<T>> medias,string title)
            => medias.Where(media=> media.Title.Contains(title,StringComparison.OrdinalIgnoreCase));
        
        public static IEnumerable<Media<T>> RemoveByTitle(IEnumerable<Media<T>> medias,string title)
            => medias.Where(media=> !media.Title.Equals(title,StringComparison.OrdinalIgnoreCase));
        
    }
    partial class Book{
        public static IEnumerable<Book> FilterByAuthor(IEnumerable<Book> books, string author)  
            => books.Where(book=> book.Authors.Any(x=>x.Contains(author,StringComparison.OrdinalIgnoreCase)));
        public static IEnumerable<Book> RemoveByAuthor(IEnumerable<Book> books, string author)
            => books.Where(book=> !book.Authors.Any(x=>x.Contains(author,StringComparison.OrdinalIgnoreCase)));
        public static IEnumerable<Book> FilterByRating(IEnumerable<Book> books, double fromRating,double toRating=10.0)  
            => books.Where(book=> book.Rating>=fromRating && book.Rating<=toRating);
        public static IEnumerable<Book> FilterByPrice(IEnumerable<Book> books, double fromPrice,double toPrice)  
            => books.Where(book=> book.Price>=fromPrice && book.Price<=toPrice);            
        public static IEnumerable<Book> FilterBestSeller(IEnumerable<Book> books)  
            => books.Where(book=> book.IsBestSeller);
        public static IEnumerable<Book> FilterByAward(IEnumerable<Book> books,string award)  
            => books.Where(book=> book.Awards.Contains(award));
        public static IEnumerable<Book> FilterGenre(IEnumerable<Book> books, string genre)  
            => books.Where(book=> book.Genre.Contains(genre));        
        public static IEnumerable<Book> FilterByPage(IEnumerable<Book> books, int minPage, int maxPage)
            => books.Where(book => (book.TotalPage >= minPage && book.TotalPage <= maxPage));   
        public static IEnumerable<string> AllAuthors(IEnumerable<Book> books)
            => books.SelectMany(book=> book.Authors).Distinct();
    }
    partial class CD{
        public static IEnumerable<CD> FilterByArtist(IEnumerable<CD> cds, string artist)
            => cds.Where(cd=> cd.Artists.Any(x=>x.Contains(artist,StringComparison.OrdinalIgnoreCase)));
        public static IEnumerable<CD> RemoveByArtist(IEnumerable<CD> cds, string artist)
            => cds.Where(cd=> !cd.Artists.Any(x=>x.Contains(artist,StringComparison.OrdinalIgnoreCase)));
        public static IEnumerable<CD> FilterByRating(IEnumerable<CD> cds, double fromRating,double toRating=10.0)  
            => cds.Where(cd=> cd.Rating>=fromRating && cd.Rating<=toRating);
        public static IEnumerable<CD> FilterByPrice(IEnumerable<CD> cds, double fromPrice,double toPrice)  
            => cds.Where(cd=> cd.Price>=fromPrice && cd.Price<=toPrice);            
        public static IEnumerable<CD> FilterBestSeller(IEnumerable<CD> cds)  
            => cds.Where(book=> book.IsBestSeller);
        public static IEnumerable<CD> FilterByAward(IEnumerable<CD> cds,string award)  
            => cds.Where(cd=> cd.Awards.Contains(award));
        public static IEnumerable<CD> FilterGenre(IEnumerable<CD> cds, string genre)  
            => cds.Where(book=> book.Genre.Contains(genre));        
        public static IEnumerable<string> AllArtists(IEnumerable<CD> cds)
            => cds.SelectMany(book=> book.Artists).Distinct();
        public static IEnumerable<CD> FilterByDuration(IEnumerable<CD> cDs, int minDuration, int maxDuration)
            => cDs.Where(cd => (cd.DurationMin >= minDuration && cd.DurationMin <= maxDuration));
    }
    partial class DVD{
        public static IEnumerable<DVD> FilterByDirector(IEnumerable<DVD> dVds, string drector)
            => dVds.Where(dvd=> dvd.Directors.Any(x=>x.Contains(drector,StringComparison.OrdinalIgnoreCase)));
        public static IEnumerable<DVD> RemoveByDirector(IEnumerable<DVD> dVds, string drector)
            => dVds.Where(dvd=> !dvd.Directors.Any(x=>x.Contains(drector,StringComparison.OrdinalIgnoreCase)));
        public static IEnumerable<DVD> FilterByRating(IEnumerable<DVD> dvds, double fromRating,double toRating=10.0)  
            => dvds.Where(cd=> cd.Rating>=fromRating && cd.Rating<=toRating);
        public static IEnumerable<DVD> FilterByPrice(IEnumerable<DVD> dvds, double fromPrice,double toPrice)  
            => dvds.Where(cd=> cd.Price>=fromPrice && cd.Price<=toPrice);            
        public static IEnumerable<DVD> FilterBestSeller(IEnumerable<DVD> dvds)  
            => dvds.Where(dvd=> dvd.IsBestSeller);
        public static IEnumerable<DVD> FilterByAward(IEnumerable<DVD> dvds,string award)  
            => dvds.Where(cd=> cd.Awards.Contains(award));
        public static IEnumerable<DVD> FilterGenre(IEnumerable<DVD> dvds, string genre)  
            => dvds.Where(dvd=> dvd.Genre.Contains(genre));        
        public static IEnumerable<string> AllArtists(IEnumerable<DVD> dvds)
            => dvds.SelectMany(dvd=> dvd.Artists).Distinct();
    }
}