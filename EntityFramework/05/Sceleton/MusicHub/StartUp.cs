namespace MusicHub
{
    using System;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Data;
    using Initializer;
    using System.Text;
    using System.Globalization;
    using System.IO;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

             //DbInitializer.ResetDatabase(context);

            using (var stream = File.Create("result_duraion.txt"))
            {
                var result = ExportSongsAboveDuration(context, 4);
                byte[] info = new UTF8Encoding(true).GetBytes(result);
                stream.Write(info, 0, info.Length);

            }
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {

            var albums = context.Producers
                .Include(x => x.Albums)
                .ThenInclude(x => x.Songs)
                .ThenInclude(x => x.Writer)
                .Where(x => x.Id == producerId)
                .Select(x => x.Albums
                        // .OrderByDescending(a => a.Price)
                        .Select(c => new
                        {
                            AlbumName = c.Name,
                            ReleaseDate = c.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                            ProducerName = c.Producer.Name,
                            Songs = c.Songs

                                    // .OrderByDescending(s => s.Name)
                                    //    .ThenBy(s => s.Writer)
                                    .Select(s => new
                                    {
                                        SongName = s.Name,
                                        SongPrice = s.Price,
                                        SongWriter = s.Writer.Name
                                    }),

                            AlbumPrice = c.Price

                        }))

                .First();

            var sb = new StringBuilder();

            foreach (var album in albums.OrderByDescending(p=>p.AlbumPrice))
            {
                sb.AppendLine($"-AlbumName: {album.AlbumName}");
                sb.AppendLine($"-ReleaseDate: {album.ReleaseDate}");
                sb.AppendLine($"-ProducerName: {album.ProducerName}");
                sb.AppendLine("-Songs:");
                int indexSong = 1;
                foreach (var song in album.Songs.OrderByDescending(n=>n.SongName).ThenBy(w=>w.SongWriter))
                {
                    sb.AppendLine($"---#{indexSong}");
                    sb.AppendLine($"---SongName: {song.SongName}");
                    sb.AppendLine($"---Price: {song.SongPrice:f2}");
                    sb.AppendLine($"---Writer: {song.SongWriter}");
                    indexSong++;
                }
                sb.AppendLine($"-AlbumPrice: {album.AlbumPrice:f2}");
            }


            return sb.ToString().TrimEnd();
            //throw new NotImplementedException();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            //TimeSpan temp = TimeSpan.Parse($"00:00:{duration}");
            var songs = context.Songs.Where(d => d.Duration.TotalSeconds > duration)
                .Select(x => new
                {
                    SongName = x.Name,
                    PerformerFullName = x.SongPerformers.Select(x => x.Performer).FirstOrDefault(),
                    WriterName = x.Writer.Name,
                    AlbumProducer = x.Album.Producer.Name,
                    Duration = x.Duration
                }).ToList();

            var sb = new StringBuilder();
            int indexSong = 1;

            foreach (var song in songs.OrderBy(x=>x.SongName).ThenBy(x=>x.WriterName).ThenBy(x=>x.PerformerFullName))
            {
                sb.AppendLine($"-Song #{indexSong}");
                sb.AppendLine($"---SongName: {song.SongName}");
                sb.AppendLine($"---Writer: {song.WriterName}");
                sb.AppendLine($"---Performer: {song.PerformerFullName.FirstName} {song.PerformerFullName.LastName}");
                sb.AppendLine($"---AlbumProducer: {song.AlbumProducer}");
                sb.AppendLine($"---Duration: {song.Duration.ToString("c")}");

                indexSong++;
            }

            return sb.ToString().TrimEnd();
            //throw new NotImplementedException();
        }
    }
}
