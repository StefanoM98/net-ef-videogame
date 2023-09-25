using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame
{
    public class VideoGameManager
    {
        public static Videogioco CreazioneVideogioco()
        {
            Console.WriteLine("Inserisci il nome del videogioco che vuoi inserire:");
            string name = Console.ReadLine();

            Console.WriteLine("Inserisci la descrizione del videogioco che vuoi inserire:");
            string overview = Console.ReadLine();

            Console.WriteLine("Inserisci la data di rilascio del videogioco che vuoi inserire:");
            DateTime realease_date = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Inserisci la software house del videogioco che vuoi inserire:");
            long software_house = long.Parse(Console.ReadLine());

            Videogioco nuovoVideogioco = new Videogioco()
            {
                Name = name,
                Overview = overview,
                Release_date = realease_date,
                Software_houseId = software_house
            };

            return nuovoVideogioco;
        }

        public static Software_house CreazioneSoftwareHouse()
        {
            Console.Write("Inserisci il nome della software house --> ");
            string nomeHouse = Console.ReadLine();

            Console.Write("Inserisci il nome della città di provenienza della software house --> ");
            string cittaHouse = Console.ReadLine();

            Console.Write("Inserisci il nome del paese della software house --> ");
            string paeseHouse = Console.ReadLine();

            Software_house nuovaSoftwareHouse = new Software_house()
            {
                Name = nomeHouse,
                City = cittaHouse,
                Country = paeseHouse
            };

            return nuovaSoftwareHouse;
        }
    }
}
